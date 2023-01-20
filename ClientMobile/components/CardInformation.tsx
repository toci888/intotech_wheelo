import React from "react";
import { View, StyleSheet, Pressable } from "react-native";
import { Text, Button, Divider } from "@ui-kitten/components";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { CollocateAccount } from "../types/collocation";
import { Row } from "./Row";
import { callPhoneNumber } from "../utils/callPhoneNumber";
import { useUser } from "../hooks/useUser";
import { useSaveCollocationMutation } from "../hooks/mutations/useSavePropertyMutation";
import { commonAlert } from "../utils/handleError";
import { i18n } from "../i18n/i18n";

export const CardInformation = ({
  collocation,
  myCollocation,
}: {
  collocation: CollocateAccount;
  myCollocation?: boolean;
}) => {
  const navigation = useNavigation();
  const { user, setSavedProperties } = useUser();
  const saveCollocation = useSaveCollocationMutation();

  const alterUsersSavedProperties = (
    collocationID: number,
    type: "add" | "remove"
  ) => {
    let newCollocations: number[] = user?.savedCollocations
      ? [...user.savedCollocations]
      : [];

    if (type === "add") newCollocations.push(collocationID);
    else newCollocations = newCollocations.filter((i) => i !== collocationID);

    setSavedProperties(newCollocations);
  };

  const handleStarPress = () => {
    if (!user) return commonAlert(i18n.t('PleaseSignUpOrSignInToSaveProperties'));
    // commonAlert('klik');
    console.log('kik', user)
    let op: "add" | "remove" = "add";
    if (collocation?.relationshipStatus) op = "remove";

    alterUsersSavedProperties(collocation.idAccount, op);
    saveCollocation.mutate({ collocationID: collocation.idAccount, op });
  };

  const manageUnitsNavigation = () =>
    navigation.navigate("ManageUnits", { collocationID: collocation.idAccount });

  const emailNavigation = () =>
    navigation.navigate("MessageProperty", { collocationID: collocation.idAccount });

  const editPropertyNavigation = () =>
    navigation.navigate("EditProperty", { collocationId: collocation.idAccount });

  const DefaultInfo = () => (
    <>
      {
        <Row style={styles.rowJustification}>
          <Text category={"s1"}>{collocation.name + " " + collocation.surname}</Text>
          <Pressable onPress={handleStarPress} style={styles.heartContainer}>
            <MaterialCommunityIcons
              name={collocation?.relationshipStatus ? "star" : "star-outline"}
              color={theme["color-primary-500"]}
              size={24}
            />
          </Pressable>
        </Row>
      }
      {collocation?.name ? (
        <Text category={"c1"} style={styles.defaultMarginTop}>
          {collocation.phoneNumber}
        </Text>
      ) : null}

      <Row style={[styles.defaultMarginTop, styles.rowJustification]}>
        <Button
          appearance={"ghost"}
          style={[
            {
              borderColor: theme["color-primary-500"],
            },
            styles.button,
          ]}
          size="small"
          onPress={emailNavigation}
        >
          Chat
        </Button>
        <Button
          style={styles.button}
          size="small"
          onPress={() => {collocation.phoneNumber ? callPhoneNumber(collocation.phoneNumber) : console.log("nie ma numeru tele")}}
        >
          Call
        </Button>
      </Row>
    </>
  );

  const MyPropertyInfo = () => (
    <>
      <Text category={"s1"}>
        {collocation?.name}
      </Text>
      <Row style={[styles.rowAlign, styles.defaultMarginTop]}>
        {/* {property?.apartments && property.apartments.length > 0 ? (
          <Text category={"c1"}>
            {property.apartments.length}{" "}
            {property.apartments.length > 1 ? "Units" : "Unit"}
          </Text>
        ) : null} */}
        
        <Button
          appearance={"ghost"}
          status="info"
          size={"small"}
          onPress={manageUnitsNavigation}
        >
          Manage Units
        </Button>
      </Row>

      <Divider style={styles.divider} />

      <Row
        style={[
          styles.defaultMarginTop,
          styles.rowJustification,
          styles.rowAlign,
        ]}
      >
        <Text category={"s2"}>
          Listing: {/* {property?.onMarket ? "On Market" : "Off Market"} */}
        </Text>
        <Button
          size={"small"}
          appearance="ghost"
          status={"info"}
          onPress={editPropertyNavigation}
        >
          "Deactivate"{/* {property?.onMarket ? "Deactivate" : "Reactivate"} */}
        </Button>
      </Row>
    </>
  );

  return (
    <View style={styles.informationContainer}>
      {myCollocation ? <MyPropertyInfo /> : <DefaultInfo />}
    </View>
  );
};

const styles = StyleSheet.create({
  informationContainer: {
    paddingVertical: 10,
    paddingHorizontal: 5,
    borderWidth: 1,
    borderColor: theme["color-gray"],
    borderBottomLeftRadius: 5,
    borderBottomRightRadius: 5,
  },
  defaultMarginTop: {
    marginTop: 5,
  },
  divider: {
    backgroundColor: theme["color-gray"],
  },
  rowAlign: { alignItems: "center" },
  rowJustification: {
    justifyContent: "space-between",
  },
  button: {
    width: "49%",
  },
  heartContainer: {
    paddingHorizontal: 10,
    paddingTop: 10,
    paddingBottom: 5,
  },
});
