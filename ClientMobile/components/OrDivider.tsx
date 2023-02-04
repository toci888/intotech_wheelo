import { Text, Divider } from "@ui-kitten/components";
import { StyleSheet, ViewStyle } from "react-native";

import { Row } from "./Row";
import { theme } from "../theme";
import { i18n } from "../i18n/i18n";
import useTheme from "../hooks/useTheme";

export const OrDivider = ({ style }: { style?: ViewStyle }) => {
  const {colors} = useTheme();
  return (
    <Row style={[styles.container, style as ViewStyle]}>
      <Divider style={styles.divider} />
      <Text style={[styles.orText, {color: colors.text}]} appearance={"hint"}>
        {i18n.t('or')}
      </Text>
      <Divider style={styles.divider} />
    </Row>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: "center",
    justifyContent: "center",
  },
  orText: { paddingHorizontal: 10, marginTop: -5 },
  divider: {
    borderWidth: 1,
    width: "45%",
    borderColor: theme["color-gray"],
  },
});
