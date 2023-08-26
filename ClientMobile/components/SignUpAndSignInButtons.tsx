import React from "react";
import { View, StyleSheet, Text, Pressable } from "react-native";
import { useNavigation } from "@react-navigation/native";

import { theme } from "../theme";
import { GoogleButton } from "./GoogleButton";
import { FacebookButton } from "./FacebookButton";
import { AppleButton } from "./AppleButton";
import { OrDivider } from "./OrDivider";
import { useAuth } from "../hooks/useAuth";
import useTheme from "../hooks/useTheme";
import { i18n } from "../i18n/i18n";
import { WheeloLogo } from "./logos/WheeloLogo";
import { WheeloIcon } from "./logos/WheeloIcon";
import { GoogleLogos } from "./logos/GoogleLogos";
import { FacebookLogos } from "./logos/FacebookLogos";
import { LinkedLogo } from "./logos/LinkedLogo";
import { AppleLogo } from "./logos/AppleLogo";

export const SignUpAndSignInButtons = () => {
  const navigation = useNavigation();
  const { colors } = useTheme();
  
  return (
    <View style={styles.container}>
      <WheeloLogo />
      <WheeloIcon />
      <Text style={styles.sloganTitle}>{i18n.t("WheeloSloganTitle")}</Text>
      <Text style={styles.sloganSubtitle}>{i18n.t("WheeloSloganSubtitle")}</Text>
      

      <Pressable onPress={() => navigation.navigate("SignIn")} style={styles.signInButton}>
        <Text>{i18n.t("SignIn")}</Text>
      </Pressable>
        
      <Pressable onPress={() => navigation.navigate("SignUp")} style={styles.signUpButton}>
        <Text>{i18n.t("SignUp")}</Text>
      </Pressable>
      <Text style={styles.bodyText}>{i18n.t("OrSignInWith")}</Text>
      <View style={styles.socialButtonContainer}>
        <GoogleLogos />
        <FacebookLogos />
        <LinkedLogo/>
        <AppleLogo/>
      </View>
     
     
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
  },
  socialButtonContainer:
  {
    flexDirection: 'row', // Komponenty zostaną ułożone w jednej linii
   
  },
  sloganTitle: {
    textAlign: "center",
    fontFamily: "Open Sans",
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,
  },
  
  sloganSubtitle: {
    textAlign: "center",
    fontFamily: "Open Sans",
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,

  },
  signInButton: {
  
      display: 'flex',
      paddingVertical: 14,
      paddingHorizontal: 40,
      alignItems: 'center',
      alignSelf: 'stretch',
      backgroundColor: 'blue', // Na chwile
      borderRadius: 99,
    
  },
  signUpButton: {

  },
  bodyText: {
    marginTop: 10,
    textAlign: "center",
    marginHorizontal: 15,
    marginBottom: 15,
    color: '#DBC2F5'
  }
});
