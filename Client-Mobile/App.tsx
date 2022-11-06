import { StatusBar } from "expo-status-bar";
import React, { useState } from "react";
import { StyleSheet, Text, View, Button } from "react-native";
import { Apply } from "./Apply";
import { QueryClient, QueryClientProvider, useQuery } from "react-query";
import axios from 'axios';

const queryClient = new QueryClient();

const query = () =>
  useQuery([], async () => {
    // const res = await fetch(`http://192.168.1.96:5000/api/Applies/Select`);
    // console.log(res.json());
    // return await res.json();

    const res = await axios.get('http://192.168.1.96:5000/api/Applies/Select');
    console.log(res.data);
    return res.json();
  });

const ComponentA = () => {
  const { data } = query();
  if(data) {
    console.log("XXX", data);
    return <Text>{data}</Text>
  }
  return <Text></Text>;
};


export default function App() {
  const [users, setUsers] = useState([]);

  const getData = async () => {
    const res = await fetch('http://192.168.1.96:5105/api/Account/Select');
    const data = await res.json();
    setUsers(data);
  };

  return (
    <View style={styles.container}>
      <Text>Open up App.tsx to start working on your app!</Text>
      <QueryClientProvider client={queryClient}>
        <Button onPress={getData} title="Learn More"></Button>
        <View>
        {users.map((user: any) => (
          <Text key={user.name}>{user.name} {user.email}</Text>
        ))}
      </View>
        <Text><ComponentA /></Text>
      </QueryClientProvider>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
