import React from "react";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import { View, StyleSheet, ViewStyle } from "react-native";
import { Text } from "@ui-kitten/components";
import { useNavigation } from "@react-navigation/native";

import { Row } from "./Row";
import useTheme from "../hooks/useTheme";

export const ModalHeader = ({
  xShown,
  text,
  onPress,
  style,
}: {
  xShown?: boolean;
  text?: string;
  onPress?: () => void;
  style?: ViewStyle | ViewStyle[];
}) => {
  const {colors} = useTheme();
  const navigation = useNavigation();

  if (text) {
    return (
      <Row style={[styles.container, style as ViewStyle]}>
        {xShown ? (
          <MaterialCommunityIcons
            onPress={onPress ? onPress : navigation.goBack}
            style={styles.x}
            name="arrow-left"
            color={colors.text}
            size={24}
          />
        ) : null}
        <Text category={"h5"} style={{color: colors.text}}>{text}</Text>
      </Row>
    );
  }

  return (
    <View style={[styles.container, style as ViewStyle]}>
      <View style={styles.bar} />
    </View>
  );
};

const styles = StyleSheet.create({
  x: { position: "absolute", left: 20, alignSelf: "center" },
  container: {
    alignItems: "center",
    justifyContent: "center",
    padding: 15,
    borderBottomWidth: 1,
    borderBottomColor: "#a4a4a4",
  },
  bar: {
    width: 50,
    backgroundColor: "#a4a4a4",
    height: 4,
    borderRadius: 30,
  },
});
