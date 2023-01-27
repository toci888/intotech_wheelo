import { Theme, useTheme as _useTheme } from "@react-navigation/native";

export default function useTheme(): any {
    const theme = _useTheme() as Theme;
    
    const myTheme = Object.assign({secondary: 'red'}, theme);

    return myTheme;
}
