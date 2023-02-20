import { View, StyleSheet, TouchableOpacity, Alert, Platform } from "react-native";
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
import { commonAlert } from "../utils/handleError";
import { OrDivider } from "../components/OrDivider";
import { AppleButton } from "../components/AppleButton";
import { FacebookButton } from "../components/FacebookButton";
import { GoogleButton } from "../components/GoogleButton";
import { Row } from "../components/Row";
import useTheme from "../hooks/useTheme";

export const SignInScreen = () => {
  const navigation = useNavigation();
  const {colors} = useTheme();
  const { nativeLogin, facebookAuth, googleAuth, appleAuth } = useAuth();

  return (
    <KeyboardAwareScrollView bounces={false}>
      <Screen>
        <ModalHeader text={i18n.t('SignIn')} xShown />
        <View style={styles.container}>
          <Text category={"h5"} style={styles.header}>
            {/* {i18n.t('SignIn')} */}
          </Text>
          <Formik
            initialValues={{
              email: Platform.OS === "ios" ? "bartek@gg.pl" : "bzapart@gmail.com",
              password: "Beatka123(",
            }}
            validationSchema={yup.object().shape({
              email: yup.string().email().required("Email jest wymagany."),
              password: yup
                .string()
                .required("Hasło jest wymagane..")
            })}
            onSubmit={async (values) => {
              const response: ReturnedResponse<User> | undefined = await nativeLogin(values);
              if (response && response.isSuccess === false) {
                console.log("Logged user response:", response)
                if (response.errorCode === 256) {
                  navigation.navigate(`CodeVerification`, { user: values as User, type: "email" });
                } else {
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

          <OrDivider style={styles.orContainer} />
          <Row style={{justifyContent: "space-evenly"}}>
            <GoogleButton
              text={i18n.t('ContinueWithGoogle')}
              style={{borderColor: colors.text}}
              onPress={async () => await googleAuth()}
            />
            <FacebookButton
              text={i18n.t('ContinueWithFacebook')}
              style={{borderColor: colors.text}}
              onPress={async () => await facebookAuth()}
            />
            <AppleButton 
              type="sign-in" 
              onPress={async () => await appleAuth()} 
              style={{borderColor: colors.text}}
            />
          </Row>
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
  button: {  },
});
