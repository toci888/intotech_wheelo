import { View, StyleSheet, TouchableOpacity, Alert } from "react-native";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";
import { Text, Input, Button } from "@ui-kitten/components";
import * as yup from "yup";
import { Formik } from "formik";
import { useNavigation } from "@react-navigation/native";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { PasswordInput } from "../components/PasswordInput";
import { useAuth } from "../hooks/useAuth";
import React from "react";
import { ReturnedResponse } from "../types";
import { User } from "../types/user";
import { i18n } from "../i18n/i18n";

export const SignInScreen = () => {
  const navigation = useNavigation();
  const { nativeLogin } = useAuth();

  return (
    <KeyboardAwareScrollView bounces={false}>
      <Screen>
        <ModalHeader text="WHEELO" xShown />
        <View style={styles.container}>
          <Text category={"h5"} style={styles.header}>
            Zaloguj się
          </Text>
          <Formik
            initialValues={{
              email: "asdf@wp.plzxcxxxc",
              password: "zxcD@#gry123",
            }}
            validationSchema={yup.object().shape({
              email: yup.string().email().required("Email jest wymagany."),
              password: yup
                .string()
                .required("Hasło jest wymagane..")
            })}
            onSubmit={async (values) => {
              const user: ReturnedResponse<User> | undefined = await nativeLogin(values);
              if(user?.isSuccess === false && user?.errorCode) {
                console.log("User", user);
                navigation.navigate(`EmailVerification`, user.methodResult)
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
            }) => {
              return (
                <>
                  <Input
                    style={styles.input}
                    value={values.email}
                    onChangeText={handleChange("email")}
                    placeholder="Wpisz swój email"
                    autoCapitalize="none"
                    keyboardType="email-address"
                    textContentType="emailAddress"
                    autoComplete="email"
                    label="Email"
                    autoCorrect={false}
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
                    placeholder="Twoje hasło"
                    label="Hasło"
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

                  <TouchableOpacity
                    style={styles.forgotPasswordContainer}
                    onPress={() => navigation.navigate("ForgotPassword")}
                  >
                    <Text category={"c1"} status={"info"}>
                      Zapomniałeś hasła?
                    </Text>
                  </TouchableOpacity>

                  <Button
                    style={styles.signInButton}
                    onPress={() => handleSubmit()}
                  >
                    Zaloguj
                  </Button>
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
  signInButton: { marginTop: 20 },
  orContainer: {
    marginVertical: 30,
  },
  button: { marginBottom: 10 },
});
