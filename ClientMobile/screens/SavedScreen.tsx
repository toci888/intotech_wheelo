import React from "react";
import { View, StyleSheet, FlatList, TouchableOpacity, Platform } from "react-native";
import { Button, Input, Text } from "@ui-kitten/components";
import { useState } from "react";
import LottieView from "lottie-react-native";
import { useFocusEffect, useNavigation } from "@react-navigation/native";

import { Screen } from "../components/Screen";
import { Row } from "../components/Row";
import { theme } from "../theme";
import { Card } from "../components/Card";
import { CollocateAccount, Collocation } from "../types/collocation";
import { SignUpAndSignInButtons } from "../components/SignUpAndSignInButtons";
import { useUser } from "../hooks/useUser";
import { Loading } from "../components/Loading";
import { useSavedCollocationsQuery as useFriendsQuery } from "../hooks/queries/useSavedCollocationsQuery";
import { useContactedPropertiesQuery } from "../hooks/queries/useContactedPropertiesQuery";
import { i18n } from "../i18n/i18n";
import { useInvitedFriendsQuery } from "../hooks/queries/useInvitedFriendsQuery";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { LISTMARGIN, os } from "../constants/constants";

export const SavedScreen = () => {
  const [value, setValue] = useState<string>();
  const [activeIndex, setActiveIndex] = useState<number>(0);
  const { user } = useUser();
  const navigation = useNavigation();
  const friends = useFriendsQuery();
  const associatedCollocations = useContactedPropertiesQuery();
  const invitedFriends = useInvitedFriendsQuery();

  // Refetching saved properties doesn't occur after login
  useFocusEffect(() => {
    if ( //TODO! time out 0.5 sec
      (!friends.data || friends.data.length === 0) &&
      user && user?.savedCollocations && user.savedCollocations.length > 0
    ) {
      friends.refetch();
      associatedCollocations.refetch();
      invitedFriends.refetch();
    }
  });

  const handleChange = async (val: string) => {
    setValue(val);
    console.log(value)
    if (activeIndex === 0 && friends.data) {
      let results: CollocateAccount[] = [];
      friends.data.map(collocation =>{
        if(collocation.name.includes(val)) {
          results.push(collocation);
        }
      })
      console.log("WYNIKI", results)
      friends.data = results;
    }
    // if (val.length > 2) await getSuggestions(val);
    // else if (val.length === 0) setSuggestions([]);
  };

  const handleSubmitEditing = async () => {
    // await getSuggestions(value);
    console.log("WYBRALES", value)
    // // If only 1 suggestion appears, it's better UX for them to just press enter on the
    // // keyboard, but if they are searching for a specific address & multiple appear,
    // // the user needs to choose
    // if (
    //   (type === "autocomplete" && suggestions.length > 0) ||
    //   suggestions.length === 1
    // )
    //   handleSuggestionPress(suggestions[0]);
  };

  const getButtonAppearance = (buttonIndex: number) => {
    if (activeIndex === buttonIndex) return "filled";
    return "ghost";
  };

  const handleButtonPress = (index: number) => {
    setActiveIndex(index);
  };

  if (friends.isLoading || associatedCollocations.isLoading || invitedFriends.isLoading)
    return <Loading />;

  const getBodyText = (heading: string, subHeading: string) => {
    return (
      <View style={styles.textContainer}>
        <Text category={"h6"} style={styles.text}>
          {heading}
        </Text>
        <Text appearance={"hint"} style={[styles.text, styles.subHeading]}>
          {subHeading}
        </Text>
      </View>
    );
  };

  const getPropertiesFlatList = (collocation: CollocateAccount[]) => {
    return (<>
      <View style={{marginTop: Platform.OS === os.ios ? 10 : 10}}>
        <Row style={[{ alignItems: "center"}, styles.defaultMarginHorizontal ]}>
          <MaterialCommunityIcons
            name="magnify"
            color={theme["color-primary-500"]}
            size={28}
            style={{alignItems: 'center', }}
            // style={{marginLeft:10, alignItems: 'center', marginRight: 'auto'}}
          />
          <Input
            keyboardType="default"
            selectionColor={theme["color-primary-500"]}
            placeholder={i18n.t('Search')}
            size={"medium"}
            value={value}
            onChangeText={handleChange}
            onSubmitEditing={handleSubmitEditing}
            style={{width: '80%'}}
          />
          <MaterialCommunityIcons
            name="magnify"
            color={theme["color-primary-500"]}
            size={28}
            // style={{marginLeft:10, alignItems: 'center', marginRight: 'auto'}}
          />
        </Row>
      </View>
      <FlatList
        showsVerticalScrollIndicator={false}
        data={collocation}
        style={{ marginTop: 10 }}
        renderItem={({ item }) => (
          <Card
            collocation={item}
            style={styles.card}
            myCollocation={true}
            onPress={() =>
              navigation.navigate("PropertyDetails", { collocationID: item.idAccount })
            }
          />
        )}
        keyExtractor={(item) => item.idAccount.toString()}
      />
      </>
    );
  };

  const getBody = () => {
    if (activeIndex === 0) {
      if (friends?.data && friends.data.length > 0)
        return getPropertiesFlatList(friends.data);
      return (
        <>
          <LottieView
            autoPlay
            style={styles.lottie}
            source={require("../assets/lotties/Favorites.json")}
          />
          {getBodyText(
            "You do not have any favorites saved",
            "Tap the heart icon on rentals to add favorites"
          )}
          {!user && (
            <SignUpAndSignInButtons
              style={styles.signInAndSignUpButtonContainer}
            />
          )}
        </>
      );
    }
    
    if (activeIndex === 1) {
      if (associatedCollocations?.data && associatedCollocations.data.length > 0)
        return getPropertiesFlatList(associatedCollocations.data);
      return (
        <>
          <LottieView
            autoPlay
            style={styles.lottie}
            source={require("../assets/lotties/Contacted.json")}
          />
          {getBodyText(
            "You have not contacted any properties yet",
            "Your contacted properties will show here"
          )}
          {!user && (
            <SignUpAndSignInButtons
              style={styles.signInAndSignUpButtonContainer}
            />
          )}
        </>
      );
    }
    if (activeIndex === 2)
      if (invitedFriends?.data && invitedFriends.data.length > 0)
        return getPropertiesFlatList(invitedFriends.data);
    return (
      <>
        <LottieView
          autoPlay
          style={styles.lottie}
          source={require("../assets/lotties/Applications.json")}
        />
        {getBodyText(
          "Check the status of your rental applications here",
          "Any properties that you have applied to will show here"
        )}
        {!user && (
          <SignUpAndSignInButtons
            style={styles.signInAndSignUpButtonContainer}
          />
        )}
      </>
    );
  };

  return (
    <Screen>
      <Row style={styles.buttonContainer}>
        <Button
          style={[styles.button, styles.favoritesButton]}
          size={"small"}
          appearance={getButtonAppearance(0)}
          onPress={() => handleButtonPress(0)}
        >
          {i18n.t("Friends")}
        </Button>
        <Button
          style={[styles.button, styles.contactedButton]}
          size={"small"}
          appearance={getButtonAppearance(1)}
          onPress={() => handleButtonPress(1)}
        >
          {i18n.t('Associated')}
        </Button>
        <Button
          style={[styles.button, styles.applicationButton]}
          size={"small"}
          appearance={getButtonAppearance(2)}
          onPress={() => handleButtonPress(2)}
        >
          {i18n.t('Invited')}
        </Button>
      </Row>
      <View style={styles.container}>{getBody()}</View>
    </Screen>
  );
};

const styles = StyleSheet.create({
  buttonContainer: {
    alignItems: "center",
    borderRadius: 5,
  },
  button: {
    width: "33.3%",
    borderRadius: 0,
    borderColor: theme["color-primary-500"],
  },
  applicationButton: { borderTopRightRadius: 5, borderBottomRightRadius: 5 },
  favoritesButton: { borderTopLeftRadius: 5, borderBottomLeftRadius: 5 },
  contactedButton: {
    borderLeftWidth: 0,
    borderRightWidth: 0,
  },
  container: { flex: 1, justifyContent: "center" },
  lottie: {
    height: 180,
    width: 180,
    marginBottom: 20,
    alignSelf: "center",
  },
  text: {
    textAlign: "center",
  },
  subHeading: {
    marginTop: 10,
  },
  textContainer: {
    marginVertical: 15,
  },
  signInAndSignUpButtonContainer: {
    marginTop: 15,
  },
  card: { marginVertical: 10 },
  defaultMarginHorizontal: {
    marginHorizontal: LISTMARGIN,
  },
});
