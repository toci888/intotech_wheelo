import React from "react";
import { StyleSheet } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialIcons } from "@expo/vector-icons";

import { Row } from "../Row";
import { CollocateAccount } from "../../types/collocation";

export const AboutSection = ({ collocation }: { collocation: CollocateAccount }) => {
  if (collocation.name)
    return (
      <>
        <Text category={"h5"} style={styles.header}>
          About
        </Text>
        {collocation?.name ? (
          <Row>
            <MaterialIcons color={"#36454f"} size={24} name="apartment" />

            <Text category={"h6"} style={styles.apartmentText}>
              {collocation?.name}
            </Text>
          </Row>
        ) : null}
        <Text category={"c1"}>{collocation.surname}</Text>
      </>
    );

  return null;
};

const styles = StyleSheet.create({
  header: { marginBottom: 15, marginTop: 10 },
  apartmentText: { paddingLeft: 10, marginBottom: 10 },
});
