import { ScrollView, View, StyleSheet, Linking, Dimensions, Image, TouchableOpacity, ImageSourcePropType, Switch } from "react-native";
import React, { useState } from "react";
import { useNavigation } from "@react-navigation/native";
import { Text, Button } from "@ui-kitten/components";
import { Screen } from "../components/Screen";
import { SignUpAndSignInButtons } from "../components/SignUpAndSignInButtons";
import { theme } from "../theme";
import { ButtonList } from "../components/ButtonList";
import { useUser } from "../hooks/useUser";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";
import useColorScheme from "../hooks/useColorScheme";
import { themes } from "../constants/constants";
import { array } from "yup/lib/locale";
import { Colors } from "react-native/Libraries/NewAppScreen";



type AccountItem = {
  type: "switch" | "button",
  label: string,
  onPress: () => void,
  icon: ImageSourcePropType
}

export const AccountScreen = () => {
  const [isEnabled, setIsEnabled] = useState(false);
  const { user, logout } = useUser();
  const { colors } = useTheme();
  const colorScheme = useColorScheme();
  const navigation = useNavigation();

  const firstSignedOutButtons: AccountItem[] = [
    {
      type: "button",
      label: "Edytuj 1profil",
      onPress: () => navigation.navigate("AddProperty"),
      icon: require('../assets/images/NoImage.jpeg')
    },
    {
      type: "button",
      label: "Zapisane trasy",
      onPress: () => navigation.navigate("MyProperties"),
      icon: require('../assets/images/NoImage.jpeg')
    },
    {
      type: "button",
      label: "Ustawienia",
      onPress: () => navigation.navigate("MyProperties"),
      icon: require('../assets/images/NoImage.jpeg')
    },
    {
      type: "button",
      label: "Wiadomości",
      onPress: () => navigation.navigate("MyProperties"),
      icon: require('../assets/images/NoImage.jpeg')
    },
    {
      type: "button",
      label: "Bezpieczeństwo i prywatność",
      onPress: () => navigation.navigate("MyProperties"),
      icon: require('../assets/images/NoImage.jpeg')
    },
    {
      type: "switch",
      label: "Powiadomienia",
      onPress: () => navigation.navigate("MyProperties"),
      icon: require('../assets/images/NoImage.jpeg')
    },
  ];

  const AccManagementButtons = ({ item }: { item: AccountItem }) => {
    return (
      <TouchableOpacity style={styles.buttonContainer} onPress={item.onPress} key={item.label}>
        <Image style={styles.buttonPhoto} source={item.icon} />
        <Text style={[styles.buttonTextContainer,{color: colors.text}]}>{item.label}</Text>
      </TouchableOpacity>
    );
  };

  const AccManagementsSwitches = ({ item }: { item: AccountItem }) => {
    return (
      <TouchableOpacity style={[styles.buttonContainer, {flexDirection: "row"}]} onPress={item.onPress} key={item.label}>
        <Text style={[styles.switchText,{color: colors.text}]}>{item.label}</Text>
        <Switch style={styles.switch}
          trackColor={{ false: '#767577', true: '#81b0ff' }}
          thumbColor={isEnabled ? theme["color-primary-200"] : '#f4f3f4'}
          ios_backgroundColor="#3e3e3e"
          onValueChange={toggleSwitch}
          value={isEnabled} />
      </TouchableOpacity>
    );
  };

  const toggleSwitch = () => {
    setIsEnabled((previousState) => !previousState);
  };

  return (
    <Screen>
      {user && (
        <ScrollView style={styles.mainContainer}>
          <View style={[styles.container, {backgroundColor: theme["color-primary-500"] /*colors.background*/ }]}>          
              <Image style={styles.accountPhoto} source={user.image ? { uri: user.image } : require('../assets/images/AccountNoImage.png')} />
              <Text style={[styles.userName, {color: theme["color-primary-100"] /*colors.text*/}]}> {user.firstName ?? ""} </Text>           
          </View>
            <View style={[styles.container,{backgroundColor: theme["color-primary-500"]/*colors.background*/}]}>
              {
                firstSignedOutButtons.map(item => (
                  item.type === "button" ?
                    <AccManagementButtons item={item} />
                    : <AccManagementsSwitches item={item} />
                ))
              }
            </View>
            <View style={[styles.specialMarginVertical, styles.defaultMarginHorizontal,]}>
              <Button appearance={"ghost"} style={styles.button} onPress={logout}>{i18n.t('SignOut')}</Button>
            </View>
          
        </ScrollView>
      )}
    </Screen>
  );
};

const styles = StyleSheet.create({
  mainContainer: {
    flex: 1,
  },
  container: {
    borderRadius: 20,
    marginTop: 20,
    marginBottom: 20,
    marginLeft: 16,
    marginRight: 16,
    paddingTop: 16,
    paddingBottom: 16,
  },
  infoContainer: {
    flex: 1
  },
  buttonsContainer: {
    flex: 1,
  },
  accountPhoto: {
    width: 90,
    height: 90,
    alignSelf: "center",
  },
  buttonContainer: {
    flexDirection: 'row',
  },
  buttonPhoto: {
    width: 30,
    height: 24,
    marginLeft: 20
  },
  buttonTextContainer: {
    marginBottom: 40,  
    marginLeft: 20,
  },
  switch: {
    backgroundColor: 'blue',
    marginLeft: 300
  },
  switchText: {
    marginTop: 10,
    marginLeft: 20
  },
  lottie: {
    marginBottom: 50,
    height: 250,
    width: 250,
    alignSelf: "center",
  },
  defaultMarginHorizontal: { marginHorizontal: 10 },
  userName: {
    marginTop: 13,
    fontSize: 16,
    alignSelf: "center",
    textAlign: "center"
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
    color: theme["color-violet"],
  },
  middleContainer: {
    justifyContent: "center",
    alignItems: "center",
    paddingTop: 30,
    paddingBottom: 50,
    borderTopColor: theme["color-gray"],
    borderTopWidth: 2,
  },
  logo: {
    width: '100%',
    height: 250,
    marginTop: 50,
    marginLeft: 'auto',
    resizeMode: 'contain',
    marginRight: 'auto',
    marginBottom: Dimensions.get("screen").height / 10 //TODO
  },
  subheader: { textAlign: "center", paddingHorizontal: 20 },
  bodyText: { marginTop: 10, textAlign: "center", marginHorizontal: 15 },
  button: { marginBottom: 15, borderColor: theme["color-primary-500"] },
  specialMarginVertical: { marginTop: 30, marginBottom: 20 },
});