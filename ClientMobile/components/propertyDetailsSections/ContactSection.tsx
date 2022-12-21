import { Text, Button } from "@ui-kitten/components";
import { StyleSheet, View, TouchableOpacity, Share } from "react-native";
import { MaterialCommunityIcons, MaterialIcons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../../theme";
import { Row } from "../Row";
import { CollocateAccount, Collocation } from "../../types/collocation";
import { callPhoneNumber } from "../../utils/callPhoneNumber";
import { openURL } from "../../utils/openURL";
import React from "react";

const formatPhoneNumber = (str: string) => {
  let cleaned = ("" + str).replace(/\D/g, "");
  let match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/);
  if (match) {
    return [
      `+$48 `,
      "(",
      match[2],
      ") ",
      match[3],
      "-",
      match[4],
    ].join("");
  }
  return "Give Us A Call";
};

export const ContactSection = ({ collocation }: { collocation: CollocateAccount }) => {
  const navigation = useNavigation();

  return (
    <>
      <Text category={"h5"} style={styles.defaultMarginVertical}>
        Contact
      </Text>
      <TouchableOpacity onPress={() => callPhoneNumber(collocation.phoneNumber)}>
        <Row style={styles.row}>
          <MaterialIcons
            name="smartphone"
            color={theme["color-info-500"]}
            size={16}
          />

          <Text category={"c1"} status={"info"} style={styles.rowText}>
            {formatPhoneNumber(collocation.phoneNumber)}
          </Text>
        </Row>
      </TouchableOpacity>
      {collocation?.name ? (
        <TouchableOpacity
          onPress={() =>
            // can also use Linking.openURL but that takes you out of the app
            {
              if (collocation.phoneNumber) openURL("WWW.GOOGLE.COM/kotki");
            }
          }
        >
          <Row style={styles.row}>
            <MaterialCommunityIcons
              name="web"
              color={theme["color-info-500"]}
              size={16}
            />
            <Text category={"c1"} status={"info"} style={styles.rowText}>
              View Property Website
            </Text>
          </Row>
        </TouchableOpacity>
      ) : null}
      <Row style={styles.buttonRow}>
        <Button
          style={styles.button}
          appearance={"ghost"}
          onPress={() => {
            navigation.navigate("MessageProperty", {
              collocationID: collocation.idAccount,
              tour: true,
            });
          }}
        >
          Tour
        </Button>
        <Button
          style={styles.button}
          appearance={"ghost"}
          onPress={() => {
            navigation.navigate("MessageProperty", {
              collocationID: collocation.idAccount,
            });
          }}
        >
          Message
        </Button>
      </Row>
    </>
  );
};

const styles = StyleSheet.create({
  defaultMarginVertical: { marginVertical: 10 },
  row: { alignItems: "center", paddingVertical: 5 },
  rowText: { marginLeft: 10 },
  buttonRow: { justifyContent: "space-between", paddingVertical: 10 },
  button: {
    borderColor: theme["color-primary-500"],
    borderWidth: 1,
    width: "45%",
  },
});
