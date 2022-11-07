import { StatusBar } from "expo-status-bar";
import React, { useState } from "react";
import { StyleSheet, Text, View, Button } from "react-native";
import { QueryClient, QueryClientProvider, useQuery } from "react-query";
import axios from 'axios';
import { environment } from "./environment";

const queryClient = new QueryClient();

export default function App() {
  const [users, setUsers] = useState([]);

  const getData = async () => {
    // const res = await axios.get(environment.apiUrl + 'api/Account/Select');
    const res = await fetch(environment.apiUrl + 'api/Account/Select');
    
    setUsers(await res.json());
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
