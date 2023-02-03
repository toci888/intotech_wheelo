import { ScrollView, View, StyleSheet, Linking } from "react-native";
import { useNavigation } from "@react-navigation/native";
import { Text, Button } from "@ui-kitten/components";

import { Screen } from "../components/Screen";
import { SignUpAndSignInButtons } from "../components/SignUpAndSignInButtons";
import { theme } from "../theme";
import { ButtonList } from "../components/ButtonList";
import { useUser } from "../hooks/useUser";
import React from "react";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";

export const AccountScreen = () => {
  const { user, logout } = useUser();
  const { colors } = useTheme();
  const navigation = useNavigation();

  const firstSignedOutButtons = [
    {
      label: "Add a Property",
      onPress: () => navigation.navigate("AddProperty"),
    },
    {
      label: "View My Properties",
      onPress: () => navigation.navigate("MyProperties"),
    },
  ];

  const supportButtons = [
    {
      label: "Help Center",
      onPress: () => console.log("navigate to Help Center"), //navigation.navigate("AddProperty")
    },
    {
      label: "Terms and Conditions",
      onPress: () => console.log("navigate to Terms and Conditions"),
    },
  ];

  const rentingButtons = [
    {
      label: "Favorite Properties",
      onPress: () => navigation.navigate("Root", { screen: "Saved" }),
    },
    {
      label: "Rental Applications",
      onPress: () => console.log("navigate to Rental Applications"),
    },
    {
      label: "My Residences",
      onPress: () => navigation.navigate("MyProperties"),
    },
    {
      label: "Rent Payments",
      onPress: () => console.log("navigate to Rent Payments"),
    },
  ];

  const accountButtons = [
    {
      label: "Account Settings",
      onPress: () =>
        navigation.navigate("Root", {
          screen: "AccountRoot",
          params: {
            screen: "Settings",
          },
        }),
    },
    {
      label: "Billing History",
      onPress: () => console.log("navigate to Billing History"),
    },
    {
      label: "Banks and Cards",
      onPress: () => console.log("navigate to Banks and Cards"),
    },
    {
      label: "Messages",
      onPress: () =>
        navigation.navigate("Root", {
          screen: "AccountRoot",
          params: {
            screen: "Conversations",
          },
        }),
    },
  ];

  const rentalManagementButtons = [
    {
      label: "Add a Property",
      onPress: () => navigation.navigate("AddProperty"),
    },
    {
      label: "Add Apartment to Property",
      onPress: () => console.log("navigate to MyProperties"),
    },
    {
      label: "View My Properties",
      onPress: () => navigation.navigate("MyProperties"),
    },
  ];



  return (
    <Screen>
      <ScrollView style={styles.container}>
        <View style={styles.defaultMarginHorizontal}>
          <Text style={[styles.header, {color: colors.text}]} category={"h5"}>
            {i18n.t('Welcome')}!
          </Text>
          <SignUpAndSignInButtons />
        </View>
        {user ? (
          <>
            <ButtonList data={rentingButtons} header={"Renting Made Easy"} />
            <ButtonList data={accountButtons} header={"My Account"} />
            <ButtonList
              data={rentalManagementButtons}
              header={"Rental Manager Tools"}
            />
            <ButtonList data={firstSignedOutButtons} header="Properties" borderTop />
            <ButtonList data={supportButtons} header="Support" marginTop borderTop />
            <View style={[styles.specialMarginVertical, styles.defaultMarginHorizontal,]}>
              <Button appearance={"ghost"} style={styles.button} onPress={logout}>
                {i18n.t('SignOut')}
              </Button>
            </View>
          </>
        ) : (
          <>
            <Text appearance={"hint"} style={[styles.brandText, styles.specialMarginVertical, {color: colors.primary}]}>
              {i18n.t('AppName').toUpperCase()}
            </Text>
          </>
        )}
      </ScrollView>
    </Screen>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  defaultMarginHorizontal: { marginHorizontal: 10},
  userName: {
    textAlign: "center",
    fontWeight: "600",
    marginBottom: 5,
    textTransform: "capitalize",
  },
  email: {
    textAlign: "center",
    fontWeight: "500",
    marginBottom: 20,
  },
  header: {
    textAlign: "center",
    marginVertical: 25,
    marginHorizontal: 70,
    fontWeight: "600",
    fontSize: 44,
  },
  middleContainer: {
    justifyContent: "center",
    alignItems: "center",
    paddingTop: 30,
    paddingBottom: 50,
    borderTopColor: theme["color-gray"],
    borderTopWidth: 2,
  },
  subheader: { textAlign: "center", paddingHorizontal: 20 },
  bodyText: { marginTop: 10, textAlign: "center", marginHorizontal: 15 },
  button: { marginBottom: 15, borderColor: theme["color-primary-500"] },
  specialMarginVertical: { marginTop: 30, marginBottom: 20 },
  brandText: {
    textAlign: "center",
    fontSize: 24,
    fontWeight: "700",
  },
});
