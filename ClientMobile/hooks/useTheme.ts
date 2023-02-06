import { Theme, useTheme as _useTheme } from "@react-navigation/native";

export default function useTheme(): any {
    
    return _useTheme() as Theme;
}
