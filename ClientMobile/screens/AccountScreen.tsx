import { ScrollView, View, StyleSheet, Linking, Dimensions, Image, TouchableOpacity, ImageSourcePropType, Switch } from "react-native";
import React, { useState } from "react";
import { useNavigation } from "@react-navigation/native";
import { Text } from "@ui-kitten/components";
import { Screen } from "../components/Screen";
import { theme } from "../theme";
import { useUser } from "../hooks/useUser";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";
import useColorScheme from "../hooks/useColorScheme";
import { AccountNoLogo } from "../assets/images/account-no-logo-icon";
import { ManIcon } from "../assets/images/man-icon";
import { SaveRoadIcon } from "../assets/images/save-road-icon";
import { SettingsIcon } from "../assets/images/settings-icon";
import { MessagesIcon } from "../assets/images/messages-icon";
import { SecurityAndPrivacyIcon } from "../assets/images/security-and-privacy-icon";
import { LogoutIcon } from "../assets/images/logout-icon";

type AccountItem = {
  type: "switch" | "button",
  label: string,
  onPress: () => void,
  icon: JSX.Element | null
};

export const AccountScreen = () => {
  const [isEnabled, setIsEnabled] = useState(false);
  const { user, logout } = useUser();
  const { colors } = useTheme();
  const colorScheme = useColorScheme();
  const navigation = useNavigation();

  const firstFieldButtons: AccountItem[] = [
    {
      type: "button",
      label: i18n.t('EditProfile') ,
      onPress: () => console.log("Pressed Edit Profile"),
      icon: <ManIcon style={styles.buttonPhoto}/>
    },
    {
      type: "button",
      label: i18n.t('SavedRoutes') ,
      onPress: () => console.log("Pressed Saved Routes"),
      icon: <SaveRoadIcon style={styles.buttonPhoto}/>
    },
    {
      type: "button",
      label: i18n.t('OpenSettings') ,
      onPress: () => console.log("Pressed Open Settings"),
      icon: <SettingsIcon style={styles.buttonPhoto}/>
    },
    {
      type: "button",
      label: i18n.t('Messages'),
      onPress: () => console.log("Pressed Messages"),
      icon: <MessagesIcon style={styles.buttonPhoto}/>
    },
    {
      type: "button",
      label: i18n.t('SecurityAndPrivacy'),
      onPress: () => console.log("Pressed Security And Privacy"),
      icon: <SecurityAndPrivacyIcon style={styles.buttonPhoto}/>
    },
    {
      type: "switch",
      label: i18n.t('Notifications'),
      onPress: () => toggleSwitch(),
      icon: null
    },
  ];

  const AccManagementButtons = ({ item }: { item: AccountItem }) => {
    return (
      <TouchableOpacity style={styles.buttonContainer} onPress={item.onPress} key={item.label}>
        { item.icon }
        <Text style={[styles.buttonTextContainer,{color: theme["color-primary-100"] /*colors.text*/}]}>{item.label}</Text>
      </TouchableOpacity>
    );
  };

  const AccManagementsSwitches = ({ item }: { item: AccountItem }) => {
    return (
      <TouchableOpacity style={[styles.buttonContainer, {flexDirection: "row"}]} onPress={item.onPress} key={item.label}>
        <View style={{flex: 1}}>
          <Text style={[styles.switchText,{color: theme["color-primary-100"] /*colors.text*/}]}>{item.label}</Text>
        </View>
        <View style={{flex: 1, marginRight: 20}}>
          <Switch style={styles.switch}
            trackColor={{ false: '#767577', true: '#ffffff' }}
            thumbColor={isEnabled ? theme["color-primary-200"] : '#f4f3f4'}
            ios_backgroundColor="#3e3e3e"
            onValueChange={toggleSwitch}
            value={isEnabled} />
        </View>
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
              <View style={{marginVertical: 16}}>
                { user.image ?
                  <Image style={styles.accountPhoto} source={{ uri: user.image }}/>
                  : <AccountNoLogo style={styles.accountPhoto}/>
                }
                  <Text style={[styles.userName, {color: theme["color-primary-100"] /*colors.text*/}]}> {user.firstName ?? ""} {user.lastName ?? ""} </Text>           
              </View>        
            </View>
            <View style={[styles.container,{backgroundColor: theme["color-primary-500"]/*colors.background*/}]}>
              {
                firstFieldButtons.map(item => (
                  item.type === "button" ?
                    <AccManagementButtons item={item} />
                    : <AccManagementsSwitches item={item} />
                ))
              }
            </View>
            <View style={[styles.container,{backgroundColor: theme["color-primary-500"] /*colors.background*/ }]}>
              <TouchableOpacity style={[styles.buttonContainer, {flexDirection: "row"}]} onPress={logout}>
                    <LogoutIcon style={styles.buttonPhoto}/>
                    <Text style={[styles.buttonTextContainer,{color: theme["color-primary-100"] /*colors.text*/}]}>{i18n.t('SignOut')}</Text>
              </TouchableOpacity>
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
    marginVertical: 20,
    marginHorizontal: 16,
  },
  accountPhoto: {
    width: 90,
    height: 90,
    alignSelf: "center",
  },
  buttonContainer: {
    marginVertical: 20,
    flexDirection: 'row',
  },
  buttonPhoto: {
    width: 30,
    height: 24,
    marginLeft: 20
  },
  buttonTextContainer: { 
    marginLeft: 20,
  },
  switch: {
    borderRadius: 10,
    borderColor: "blue"
  },
  switchText: {
    marginTop: 10,
    marginLeft: 20
  },
  userName: {
    marginTop: 13,
    fontSize: 16,
    alignSelf: "center",
    textAlign: "center"
  },
});