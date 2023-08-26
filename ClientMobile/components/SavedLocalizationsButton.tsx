import React, { StyleHTMLAttributes } from "react"
import { StyleSheet, Text, TouchableOpacity, View, ViewStyle } from "react-native"

export const SavedLocalizationButton = ({
    logo : LogoComponent,
    text,
    style,
    textStyle,
    onPress
}:{
    logo: React.ComponentType
    text: string,
    style?: ViewStyle,
    textStyle: ViewStyle,
    onPress?: () => void
}) =>{
    return(
        <TouchableOpacity style={style} onPress={onPress}>
            <LogoComponent/>
            <Text style={textStyle}>
                    {text}
            </Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    tileText: {
        fontSize: 14,
        fontFamily: "Open Sans",
        fontStyle: "normal",
        fontWeight: "700",
        lineHeight: 16.8,
        letterSpacing: 0.15,
        alignSelf: "flex-end",
        marginLeft: 5
        },
})