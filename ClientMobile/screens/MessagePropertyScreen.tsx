import React from "react";
import { Platform, StyleSheet, View, Image } from "react-native";
import { Input, Button, Text } from "@ui-kitten/components";
import * as yup from "yup";
import { Formik } from "formik";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";
import { useNavigation } from "@react-navigation/native";
import DateTimePicker from "react-native-modal-datetime-picker";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { Row } from "../components/Row";
import { getStateAbbreviation } from "../utils/getStateAbbreviation";
import { useUser } from "../hooks/useUser";
import { PressableInput } from "../components/PressableInput";
import { useSelectedCollocationQuery } from "../hooks/queries/useSelectedPropertyQuery";
import { SignUpOrSignInScreen } from "./SignUpOrSignInScreen";
import { useConversationsQuery } from "../hooks/queries/useConversationsQuery";
import { useCreateConversationMutation } from "../hooks/mutations/useCreateConversationMutation";
import { Loading } from "../components/Loading";
import { i18n } from "../i18n/i18n";

export const MessagePropertyScreen = ({
  route,
}: {
  route: { params: { collocationID: number; tour?: boolean } };
}) => {
  const navigation = useNavigation();
  const { tour, collocationID } = route.params;
  const collocationQuery = useSelectedCollocationQuery(collocationID);
  const collocation = collocationQuery.data;
  const { user } = useUser();
  const conversations = useConversationsQuery();
  const createConversation = useCreateConversationMutation();
  console.log("zxcvb", user)
  console.log("zx2vb", collocation)
  if (!user) return <SignUpOrSignInScreen />;
  if (!collocation) return <Text>{i18n.t('UnableToGetCollocationMessage')}</Text>;
  if (conversations.isLoading) return <Loading />;

  const navigateToMessageScreen = (
    roomId: string,
    recipientName: string
  ) => {
    navigation.navigate("Root", {
      screen: "AccountRoot",
      params: {
        screen: "Messages",
        initial: false, // won't render back button w/out set to false
        params: {
          roomId,
          recipientName,
        },
      } as any,
    });
  };

  if (conversations?.data && conversations.data.length > 0) {
    const index = conversations.data.findIndex(
      (i) => i.idRoom === route.params.collocationID
    );
    if (index >= 0) {
      navigateToMessageScreen(
        conversations.data[index].roomId,
        conversations.data[index].recipientName
      );
    }
  }

  const sendMessage = (text: string) => {
    // createConversation.mutate({
    //   ownerID: collocation.idAccount, //property.userID,
    //   propertyID: collocation.idAccount,
    //   tenantID: user.id,
    //   propertyName: collocation.name
    //     ? collocation.name : 'brak 74 linia',
    //     // : `${property.street}, ${property.city}, ${getStateAbbreviation(
    //     //     property.state
    //     //   )}`,
    //   senderName:
    //     user.firstName && user.lastName
    //       ? `${user.firstName} ${user.lastName}`
    //       : `${user.email}`,
    //   text,
    // });
    console.log("MESSAGE PROP SCREEN SEND MESSAGE")
  };

  return (
    <KeyboardAwareScrollView bounces={false}>
      <Screen style={styles.container}>
        {/* {Platform.OS === "ios" ? <ModalHeader /> : null} */}
        <Row style={styles.row}>
          {collocation.image && collocation.image.length > 0 ? (
            <Image style={styles.image} source={{uri: 'base64Icon'}}/>
            // <Image style={styles.image} source={{ property.methodResult.accountsCollocated[propertyID].image }} />
          ) : null}
          <View style={styles.address}>
            {collocation?.name ? (
              <Text category={"s1"}>{collocation.name}</Text>
            ) : null}
            
            <Text category={"c1"}>
              {/* {property.street}, {property.city},{" "}
              {getStateAbbreviation(property.state)} {property.zip} */}
              where
            </Text>
            <Text category={"c1"}>
              {/* ${property.rentLow.toLocaleString()} -{" "}
              {property.rentHigh.toLocaleString()} | {property.bedroomLow} -{" "}
              {property.bedroomHigh} Beds */}
              wiecej danych
            </Text>
          </View>
        </Row>

        <Formik
          initialValues={{
            firstName: user ? user.firstName : "",
            lastName: user ? user.lastName : "",
            phoneNumber: "",
            email: user ? user.email : "",
            message: tour ? "I would like to schedule a tour." : "",
            date: new Date(),
            showCalendar: false,
          }}
          validationSchema={yup.object().shape({
            firstName: yup.string().required("Required"),
            lastName: yup.string().required("Required"),
            phoneNumber: yup.string(),
            email: yup.string().email().required("Required"),
            message: yup.string().required("Required"),
            date: yup.date().required("Required"),
            showCalendar: yup.bool(),
          })}
          onSubmit={(values) => {
            // Apartments.com uses a different approach to messaging, hence all the field
            // names. In our implementation we will only need the messsage from values
            sendMessage(values.message);
          }}
        >
          {({
            values,
            errors,
            touched,
            handleChange,
            handleSubmit,
            isSubmitting,
            setFieldTouched,
            setFieldValue,
          }) => {
            return (
              <>
                <Input
                  style={styles.input}
                  value={values.firstName}
                  onChangeText={handleChange("firstName")}
                  placeholder="Your first name"
                  keyboardType="default"
                  label="First Name*"
                  onBlur={() => setFieldTouched("firstName")}
                  caption={
                    touched.firstName && errors.firstName
                      ? errors.firstName
                      : undefined
                  }
                  status={
                    touched.firstName && errors.firstName ? "danger" : "basic"
                  }
                />
                <Input
                  style={styles.input}
                  value={values.lastName}
                  onChangeText={handleChange("lastName")}
                  placeholder="Your last name"
                  keyboardType="default"
                  label="Last Name*"
                  onBlur={() => setFieldTouched("lastName")}
                  caption={
                    touched.lastName && errors.lastName
                      ? errors.lastName
                      : undefined
                  }
                  status={
                    touched.lastName && errors.lastName ? "danger" : "basic"
                  }
                />
                <Input
                  style={styles.input}
                  value={values.phoneNumber}
                  onChangeText={handleChange("phoneNumber")}
                  placeholder="Your phone number"
                  keyboardType="number-pad"
                  label="Phone Number"
                />
                <Input
                  style={styles.input}
                  value={values.email}
                  onChangeText={handleChange("email")}
                  placeholder="Your Email Address"
                  keyboardType="email-address"
                  label="Email*"
                  onBlur={() => setFieldTouched("email")}
                  caption={
                    touched.email && errors.email ? errors.email : undefined
                  }
                  status={touched.email && errors.email ? "danger" : "basic"}
                />

                <PressableInput
                  style={styles.input}
                  label="Move-In Date"
                  value={values.date.toDateString()}
                  onPress={() => setFieldValue("showCalendar", true)}
                />

                <DateTimePicker
                  isVisible={values.showCalendar}
                  mode="date"
                  onConfirm={(selectedDate: Date) => {
                    if (selectedDate) {
                      setFieldValue("showCalendar", false);
                      setFieldValue("date", selectedDate);
                    }
                  }}
                  onCancel={() => setFieldValue("showCalendar", false)}
                />

                <Input
                  style={styles.input}
                  value={values.message}
                  onChangeText={handleChange("message")}
                  label="Custom Message"
                  multiline
                  numberOfLines={10}
                  onBlur={() => setFieldTouched("message")}
                  textAlignVertical="top"
                  caption={
                    touched.message && errors.message
                      ? errors.message
                      : undefined
                  }
                  placeholder="Say something nice, or not ..."
                  status={
                    touched.message && errors.message ? "danger" : "basic"
                  }
                />

                <Button
                  style={styles.sendMessageButton}
                  onPress={() => handleSubmit()}
                >
                  Send Message
                </Button>
              </>
            );
          }}
        </Formik>
      </Screen>
    </KeyboardAwareScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: 10,
  },
  row: { alignItems: "center", paddingVertical: 10 },
  address: { marginLeft: 10 },
  image: { height: 50, width: 70 },
  input: {
    marginTop: 10,
  },
  sendMessageButton: { marginTop: 20 },
});
