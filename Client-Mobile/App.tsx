import { StatusBar } from "expo-status-bar";
import React, { useState } from "react";
import { StyleSheet, Text, View, Button } from "react-native";
import { Apply } from "./Apply";
import { QueryClient, QueryClientProvider, useQuery } from "react-query";
import axios from 'axios';

const queryClient = new QueryClient();

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
