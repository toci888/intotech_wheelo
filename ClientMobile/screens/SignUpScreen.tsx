import React, { useState } from "react";
import { View, StyleSheet, Alert } from "react-native";
import { Input, Button, Text } from "@ui-kitten/components";
import * as yup from "yup";
import { Formik } from "formik";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { GoogleButton } from "../components/GoogleButton";
import { FacebookButton } from "../components/FacebookButton";
import { AppleButton } from "../components/AppleButton";
import { OrDivider } from "../components/OrDivider";
import { PasswordInput } from "../components/PasswordInput";
import { useAuth } from "../hooks/useAuth";
import { i18n } from "../i18n/i18n";
import { useNavigation } from "@react-navigation/native";
import { NativeStackScreenProps } from "@react-navigation/native-stack";
import { ReturnedResponse, RootStackParamList } from "../types";
import { User } from "../types/user";
import { commonAlert } from "../utils/handleError";
import { Row } from "../components/Row";

interface IUser {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}
type SignUpProps = NativeStackScreenProps<RootStackParamList, 'SignUp'>

export const SignUpScreen = () => {
  const [user, setUser] = useState<IUser>({
    firstName: "Kacper",
    lastName: "Wyb",
    email: "bartek@gg.pl",
    password: "Beatka123(",
  });
  const navigation = useNavigation();
  const { appleAuth, facebookAuth, googleAuth, nativeRegister } = useAuth();

  return (
    <KeyboardAwareScrollView bounces={false}>
      <Screen>
        <ModalHeader text={i18n.t("SignUp")} xShown />
        <View style={styles.container}>
          <Text category={"h5"} style={styles.header}>
             {/* {i18n.t('SignUp')} */}
          </Text>
          <Formik
            initialValues={{
              firstName: user.firstName,
              lastName: user.lastName,
              email: user.email,
              password: user.password,
            }}
            validationSchema={yup.object().shape({
              firstName: yup.string().required("Your first name is required."),
              lastName: yup.string().required("Your last name is required."),
              email: yup.string().email().required("Your email is required."),
              password: yup
                .string()
                .required("A password is required.")
                .matches(
                  /(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&-+=()!? "]).{8,128}$/,
                  "Your password must have 8 characters, 1 uppercase letter, 1 lowercase letter, and 1 special character."
                ),
            })}
            onSubmit={async (values) => {
              const response: ReturnedResponse<User> | undefined = await nativeRegister(values);
              if(response) {
                console.log("valuess", values)
                console.log("response", response)
                if ((response.isSuccess === true && response.errorCode === 1)
                || (response.isSuccess === false && response.errorCode === 16384)) {
                  navigation.navigate("CodeVerification", {user: values, type: "email"});
                }
                else if(response.isSuccess === false) {
                  console.log("response.isSuccess", response)
                  commonAlert(response.errorMessage)
                }
              }
            }}
          >
            {({
              values,
              errors,
              touched,
              handleChange,
              handleSubmit,
              setFieldTouched,
              setFieldValue,
            }) => {
              return (
                <>
                  <Input
                    style={styles.input}
                    value={values.firstName}
                    onChangeText={handleChange("firstName")}
                    placeholder="Your First Name"
                    label="First Name"
                    autoComplete="name"
                    textContentType="givenName"
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
                    placeholder="Your Last Name"
                    label="Last Name"
                    textContentType="familyName"
                    autoComplete="name"
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
                    value={values.email}
                    onChangeText={handleChange("email")}
                    placeholder="Your Email Address"
                    autoCapitalize="none"
                    keyboardType="email-address"
                    textContentType="emailAddress"
                    autoComplete="email"
                    autoCorrect={false}
                    label="Email"
                    onBlur={() => setFieldTouched("email")}
                    caption={
                      touched.email && errors.email ? errors.email : undefined
                    }
                    status={touched.email && errors.email ? "danger" : "basic"}
                  />
                  <PasswordInput
                    style={styles.input}
                    value={values.password}
                    onChangeText={handleChange("password")}
                    placeholder="Your Password"
                    label="Password"
                    onBlur={() => setFieldTouched("password")}
                    caption={
                      touched.password && errors.password
                        ? errors.password
                        : undefined
                    }
                    status={
                      touched.password && errors.password ? "danger" : "basic"
                    }
                  />

                  <Button
                    style={styles.signUpButton}
                    onPress={() => handleSubmit()}
                  >
                    Sign Up
                  </Button>

                  <OrDivider style={styles.orContainer} />
                  <Row style={{justifyContent: "space-evenly"}}>
                    <GoogleButton
                      text="Sign up with Google"
                      style={styles.button}
                      onPress={async () => await googleAuth()}
                    />
                    <FacebookButton
                      text="Sign up with Facebook"
                      style={styles.button}
                      onPress={async () => await facebookAuth()}
                    />
                    <AppleButton
                      type="sign-up"
                      onPress={async () => await appleAuth()}
                    />
                  </Row>
                </>
              );
            }}
          </Formik>
        </View>
      </Screen>
    </KeyboardAwareScrollView>
  );
};

const styles = StyleSheet.create({
  container: { marginHorizontal: 10 },
  header: { textAlign: "center", marginVertical: 20 },
  input: {
    marginTop: 10,
  },
  forgotPasswordContainer: { alignItems: "flex-end", marginTop: 5 },
  signUpButton: { marginTop: 20 },
  orContainer: {
    marginVertical: 30,
  },
  button: { marginBottom: 10 },
});
