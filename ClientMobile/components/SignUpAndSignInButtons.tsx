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
import * as Font from 'expo-font';


export const SignUpAndSignInButtons = () => {
  const navigation = useNavigation();
  const { colors } = useTheme();
  const { nativeLogin, facebookAuth, googleAuth, appleAuth } = useAuth();
  
  return (
    <View style={styles.container}>
      <WheeloLogo style={{ marginTop:20, marginBottom: 70 }} /> 
      <WheeloIcon style={{ marginBottom: 70 }} />
      <Text style={styles.sloganTitle}>{i18n.t("WheeloSloganTitle")}</Text>
      <Text style={styles.sloganSubtitle}>{i18n.t("WheeloSloganSubtitle")}</Text>
      

      <Pressable onPress={() => navigation.navigate("SignIn")} style={styles.signInButtonContainer}>
  <View style={styles.signInButton}>
    <Text style={styles.SignInTxt}>{i18n.t("SignIn")}</Text>
  </View>
</Pressable>
        
      <Pressable onPress={() => navigation.navigate("SignUp")} style={styles.signUpButton}>
        <Text style={styles.SignUpTxt}>{i18n.t("SignUp")}</Text>
      </Pressable>
      <Text style={styles.bodyText}>{i18n.t("OrSignInWith")}</Text>
      <View style={styles.socialButtonContainer}>
      {/* <GoogleLogos style={{ marginRight: 30 }} /> */}
      <GoogleButton
              text={i18n.t('ContinueWithGoogle')}
              style={{borderColor: colors.text, marginRight: 30}}
              onPress={async () => await googleAuth()}
            />
      
      <FacebookLogos style={{ marginRight: 30 }} />
      <LinkedLogo style={{ marginRight: 30 }} />
      <AppleLogo />
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
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,
    marginBottom:-70,
  },
  
  sloganSubtitle: {
    textAlign: "center",
    fontSize: 46,
    fontStyle: "normal",
    fontWeight: "700",
    lineHeight: 120,

  },
  signInButton: {
  
      display: 'flex',
      paddingVertical: 14,
      paddingHorizontal: 40,
      alignSelf: 'stretch',
      backgroundColor: '#9C4DC7', 
      borderRadius: 99,
      width:310,
      alignItems: 'center',
      justifyContent: 'center',
      

  },
  signInButtonContainer: {
     marginBottom:30,
  },

  signUpButton: {
    marginBottom:30,
    color: '#DBC2F5'

  },
  SignInTxt : {
    color:'#DBC2F5',
  },
  SignUpTxt: { 
    color:'#DBC2F5',

  },
  bodyText: {
    marginTop: 10,
    textAlign: "center",
    marginHorizontal: 15,
    marginBottom: 30,
    color: '#DBC2F5'

  }
});
