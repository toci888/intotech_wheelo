import { useState } from "react";
import { Share, View, StyleSheet, TouchableOpacity } from "react-native";
import { Text } from "@ui-kitten/components";
import { MaterialCommunityIcons, MaterialIcons } from "@expo/vector-icons";

import { CollocateAccount } from "../../types/collocation";
import { theme } from "../../theme";
import { Row } from "../Row";
import { getStateAbbreviation } from "../../utils/getStateAbbreviation";
import { useUser } from "../../hooks/useUser";
import { useSaveCollocationMutation } from "../../hooks/mutations/useSavePropertyMutation";
import React from "react";
import { commonAlert } from "../../utils/handleError";
import { i18n } from "../../i18n/i18n";

export const CollocationHeaderSection = ({ collocation }: { collocation: CollocateAccount }) => {
  const { user, setSavedProperties } = useUser();
  const saveCollocation = useSaveCollocationMutation();

  const alterUsersSavedProperties = (
    collocationID: number,
    type: "add" | "remove"
  ) => {
    let newProperties: number[] = user?.savedCollocations
      ? [...user.savedCollocations]
      : [];

    if (type === "add") newProperties.push(collocationID);
    else newProperties = newProperties.filter((i) => i !== collocationID);

    setSavedProperties(newProperties);
  };

  const handleHeartPress = () => {
    if (!user) return commonAlert(i18n.t('PleaseSignUpOrSignInToSaveProperties'));
    let op: "add" | "remove" = "add";
    if (collocation?.relationshipStatus) op = "remove";

    alterUsersSavedProperties(collocation.idAccount, op);
    saveCollocation.mutate({ collocationID: collocation.idAccount, op } as any);
  };

  const shareItem = async () => {
    try {
      await Share.share({
        message: "Check out this sweet apartment I found on JPArtments.com.",
      });
    } catch (error: unknown) {
      commonAlert("Sorry, we're unable to share");
    }
  };

  return (
    <>
      {collocation.name ? (
        <Text category={"h5"} style={styles.defaultMarginTop}>
          {collocation.name}
        </Text>
      ) : null}
      <Row style={[styles.containerRow, styles.defaultMarginTop]}>
        <View>
          <Text category={"c1"}>{collocation.name}</Text>
          <Text category={"c1"}>{`${collocation.surname}`}</Text>
        </View>
        <Row style={styles.iconRow}>
          <MaterialIcons
            onPress={async () => {
              await shareItem();
            }}
            name="ios-share"
            size={30}
            color={theme["color-primary-500"]}
            style={styles.shareIcon}
          />
          <MaterialCommunityIcons
            onPress={handleHeartPress}
            name={collocation?.relationshipStatus ? "heart" : "heart-outline"}
            size={30}
            color={theme["color-primary-500"]}
          />
        </Row>
      </Row>
    </>
  );
};

const styles = StyleSheet.create({
  defaultMarginVertical: { marginVertical: 10 },
  containerRow: {
    justifyContent: "space-between",
  },
  iconRow: { paddingRight: 5 },
  shareIcon: {
    marginRight: 20,
    marginTop: -4,
  },
  defaultMarginTop: { marginTop: 10 },
});
