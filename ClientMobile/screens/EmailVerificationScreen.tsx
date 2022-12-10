import {
  Animated,
  Image,
  Platform,
  SafeAreaView,
  Text,
  View,
  StyleSheet,
} from "react-native";
import React, { useEffect, useState } from "react";
import { theme } from "../theme";

import {
  CodeField,
  Cursor,
  useBlurOnFulfill,
  useClearByFocusCell,
} from "react-native-confirmation-code-field";
import { useRoute } from "@react-navigation/native";
import { useAuth } from "../hooks/useAuth";
import axios from "axios";
import { endpoints } from "../constants/constants";

const { Value, Text: AnimatedText } = Animated;

const CELL_COUNT = 4;
const source = {
  uri: "https://user-images.githubusercontent.com/4661784/56352614-4631a680-61d8-11e9-880d-86ecb053413d.png",
};

const animationsColor = [...new Array(CELL_COUNT)].map(() => new Value(0));
const animationsScale = [...new Array(CELL_COUNT)].map(() => new Value(1));
//TODO: typing any
const animateCell = ({ hasValue, index, isFocused }: any) => {
  Animated.parallel([
    Animated.timing(animationsColor[index], {
      useNativeDriver: false,
      toValue: isFocused ? 1 : 0,
      duration: 250,
    }),
    Animated.spring(animationsScale[index], {
      useNativeDriver: false,
      toValue: hasValue ? 0 : 1,
      duration: hasValue ? 300 : 250,
    }),
  ]).start();
};

export const EmailVerificationScreen = () => {
  const route = useRoute();
  const [value, setValue] = useState("");
  const [registrationForm, setRegistartionForm] = useState({});
  const { appleAuth, facebookAuth, googleAuth, nativeRegister } = useAuth();

  const ref = useBlurOnFulfill({ value, cellCount: CELL_COUNT });
  const [props, getCellOnLayoutHandler] = useClearByFocusCell({
    value,
    setValue,
  });

  const handleVerify = () => {
    const user = route.params.values;
    setRegistartionForm({ ...user, code: value });
    console.log(user.email);
    console.log(parseInt(value));
    console.log(`${endpoints.emailVerification}`);

    axios
      .post(`${endpoints.emailVerification}`, {
        email: `${user.email}`,
        code: parseInt(value),
      })
      .then(function (response) {
        response.data.isSuccess ? alert("sukces") : alert("niepowodzenie");
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  useEffect(() => {}, [registrationForm]);

  const renderCell = ({ index, symbol, isFocused }) => {
    const hasValue = Boolean(symbol);
    const animatedCellStyle = {
      backgroundColor: hasValue
        ? animationsScale[index].interpolate({
            inputRange: [0, 1],
            outputRange: [NOT_EMPTY_CELL_BG_COLOR, ACTIVE_CELL_BG_COLOR],
          })
        : animationsColor[index].interpolate({
            inputRange: [0, 1],
            outputRange: [DEFAULT_CELL_BG_COLOR, ACTIVE_CELL_BG_COLOR],
          }),
      borderRadius: animationsScale[index].interpolate({
        inputRange: [0, 1],
        outputRange: [CELL_SIZE, CELL_BORDER_RADIUS],
      }),
      transform: [
        {
          scale: animationsScale[index].interpolate({
            inputRange: [0, 1],
            outputRange: [0.2, 1],
          }),
        },
      ],
    };

    // Run animation on next event loop tik
    // Because we need first return new style prop and then animate this value
    setTimeout(() => {
      animateCell({ hasValue, index, isFocused });
    }, 0);

    return (
      <AnimatedText
        key={index}
        style={[styles.cell, animatedCellStyle]}
        onLayout={getCellOnLayoutHandler(index)}
      >
        {symbol || (isFocused ? <Cursor /> : null)}
      </AnimatedText>
    );
  };

  return (
    <SafeAreaView style={styles.root}>
      <Text style={styles.title}>Email Verification</Text>
      <Image style={styles.icon} source={source} />
      <Text style={styles.subTitle}>
        Please enter the verification code{"\n"}
        we send to your email address
      </Text>

      <CodeField
        ref={ref}
        {...props}
        value={value}
        onChangeText={setValue}
        cellCount={CELL_COUNT}
        rootStyle={styles.codeFieldRoot}
        keyboardType="number-pad"
        textContentType="oneTimeCode"
        renderCell={renderCell}
      />
      <View style={styles.nextButton}>
        <Text style={styles.nextButtonText} onPress={handleVerify}>
          Verify
        </Text>
      </View>
    </SafeAreaView>
  );
};
const CELL_SIZE = 70;
const CELL_BORDER_RADIUS = 8;
const DEFAULT_CELL_BG_COLOR = theme["color-white"];
const NOT_EMPTY_CELL_BG_COLOR = theme["color-violet"];
const ACTIVE_CELL_BG_COLOR = theme["color-white"];

const styles = StyleSheet.create({
  codeFieldRoot: {
    height: CELL_SIZE,
    marginTop: 30,
    paddingHorizontal: 20,
    justifyContent: "center",
  },
  cell: {
    marginHorizontal: 8,
    height: CELL_SIZE,
    width: CELL_SIZE,
    lineHeight: CELL_SIZE - 5,
    ...Platform.select({ web: { lineHeight: 65 } }),
    fontSize: 30,
    textAlign: "center",
    borderRadius: CELL_BORDER_RADIUS,
    color: theme["color-violet"],
    backgroundColor: theme["color-white"],

    // IOS
    shadowColor: theme["color-black"],
    shadowOffset: {
      width: 0,
      height: 1,
    },
    shadowOpacity: 0.22,
    shadowRadius: 2.22,

    // Android
    elevation: 3,
  },

  // =======================

  root: {
    minHeight: 800,
    padding: 20,
  },
  title: {
    paddingTop: 50,
    color: theme["color-black"],
    fontSize: 25,
    fontWeight: "700",
    textAlign: "center",
    paddingBottom: 40,
  },
  icon: {
    width: 217 / 2.4,
    height: 158 / 2.4,
    marginLeft: "auto",
    marginRight: "auto",
  },
  subTitle: {
    paddingTop: 30,
    color: theme["color-black"],
    textAlign: "center",
  },
  nextButton: {
    marginTop: 30,
    borderRadius: 8,
    height: 60,
    backgroundColor: theme["color-violet"],
    justifyContent: "center",
    minWidth: 200,
    marginBottom: 100,
    marginHorizontal: 20,
  },
  nextButtonText: {
    textAlign: "center",
    fontSize: 20,
    color: theme["color-white"],
    fontWeight: "700",
  },
});
