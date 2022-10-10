import { StatusBar } from "expo-status-bar";
import React from "react";
import { StyleSheet, Text, View } from "react-native";
import { Apply } from "./Apply";
import { QueryClient, QueryClientProvider, useQuery } from "react-query";

const queryClient = new QueryClient();

const query = () =>
  useQuery([], async () => {
    // const res = await fetch(`https://localhost:44301/api/Applies`);
    const res = await fetch(`https://reqres.in/api/user/1`);
    return await res.json();
  });

const ComponentA = () => {
  const { data } = query();
  if(data) {
    console.log("XXX", data['data'].name);
    return <Text>{data['data'].name}</Text>
  }
  return <Text></Text>;
};


export default function App() {
  return (
    <View style={styles.container}>
      <Text>Open up App.tsx to start working on your app!</Text>
      <QueryClientProvider client={queryClient}>
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
