import { Theme, useTheme as _useTheme } from "@react-navigation/native";

export default function useTheme(): Theme {
    return _useTheme() as Theme;
}
