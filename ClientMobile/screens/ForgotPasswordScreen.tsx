import React from "react";
import { StyleSheet } from "react-native";
import { Input, Button, Text } from "@ui-kitten/components";
import * as yup from "yup";
import { Formik } from "formik";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";
import { useState } from "react";

import { Screen } from "../components/Screen";
import { ModalHeader } from "../components/ModalHeader";
import { useLoading } from "../hooks/useLoading";
import { forgotPassword } from "../services/user";
import { i18n } from "../i18n/i18n";

export const ForgotPasswordScreen = () => {
  const [emailSent, setEmailSent] = useState(false);
  const { setLoading } = useLoading();

  const handleSubmit = async (values: { email: string }) => {
    try {
      setLoading(true);
      const response = await forgotPassword(values.email);
      if (response?.isSuccess) setEmailSent(true);
    } catch (error) {
      alert("Error placing email");
    } finally {
      setLoading(false);
    }
  };

  return (
    <KeyboardAwareScrollView bounces={false}>
      <Screen style={styles.container}>
        <ModalHeader text={i18n.t('AppName')} xShown />
        {emailSent ? (
          <>
            <Text category={"h5"} style={styles.header}>
              {i18n.t('EmailSent')}
            </Text>
            <Text>
              {i18n.t('AnemailcontaininginstructionsabouthowtochangeyourpasswordhasbeensenttoyouPleasecheckyourjunkmailorspamsectionifyoudonotseeanemail')}
            </Text>
          </>
        ) : (
          <>
            <Text category={"h5"} style={styles.header}>
              {i18n.t('ForgotYourPassword')}
            </Text>
            <Text>
              {i18n.t('Pleaseenteryouremailandwewillsendyoualinktochangeyourpassword')}
            </Text>
            <Formik
              initialValues={{
                email: "new@wp.plxb",
              }}
              validationSchema={yup.object().shape({
                email: yup.string().email().required(i18n.t('Youremailisrequired')),
              })}
              onSubmit={handleSubmit}
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
                      value={values.email}
                      onChangeText={handleChange("email")}
                      placeholder={i18n.t('YourEmailAddress')}
                      keyboardType="email-address"
                      autoCapitalize="none"
                      autoComplete="email"
                      label="Email"
                      onBlur={() => setFieldTouched("email")}
                      caption={
                        touched.email && errors.email ? errors.email : undefined
                      }
                      status={
                        touched.email && errors.email ? "danger" : "basic"
                      }
                    />

                    <Button
                      style={styles.button}
                      onPress={() => handleSubmit()}
                    >
                      {i18n.t('Continue')}
                    </Button>
                  </>
                );
              }}
            </Formik>
          </>
        )}
      </Screen>
    </KeyboardAwareScrollView>
  );
};

const styles = StyleSheet.create({
  container: { marginHorizontal: 10 },
  header: { textAlign: "center", marginVertical: 20 },
  button: { marginTop: 20 },
  input: {
    marginTop: 10,
  },
});
