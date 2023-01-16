import React from "react";
import { light, dark } from "@eva-design/eva";
import { DefaultTheme } from "@react-navigation/native";

const importedTheme = {
  "color-primary-100": "#F8C6E9",
  "color-primary-200": "#F291DD",
  "color-primary-300": "#D856C7",
  "color-primary-400": "#B12CAB",
  "color-primary-500": "#78007D",
  "color-primary-600": "#5E006B",
  "color-primary-700": "#470059",
  "color-primary-800": "#330048",
  "color-primary-900": "#25003B",
  "color-success-100": "#EBFBD0",
  "color-success-200": "#D2F8A2",
  "color-success-300": "#AEEA71",
  "color-success-400": "#88D54B",
  "color-success-500": "#57BA1A",
  "color-success-600": "#409F13",
  "color-success-700": "#2C850D",
  "color-success-800": "#1C6B08",
  "color-success-900": "#105904",
  "color-info-100": "#C7F9E9",
  "color-info-200": "#91F3DC",
  "color-info-300": "#57DBC7",
  "color-info-400": "#2DB7AE",
  "color-info-500": "#008487",
  "color-info-600": "#006774",
  "color-info-700": "#004E61",
  "color-info-800": "#00384E",
  "color-info-900": "#002940",
  "color-warning-100": "#FBF8CB",
  "color-warning-200": "#F8F099",
  "color-warning-300": "#EADD64",
  "color-warning-400": "#D5C53D",
  "color-warning-500": "#BAA509",
  "color-warning-600": "#9F8B06",
  "color-warning-700": "#857304",
  "color-warning-800": "#6B5B02",
  "color-warning-900": "#594A01",
  "color-danger-100": "#FAD6D0",
  "color-danger-200": "#F5A8A2",
  "color-danger-300": "#E16F72",
  "color-danger-400": "#C44857",
  "color-danger-500": "#9E1936",
  "color-danger-600": "#871237",
  "color-danger-700": "#710C36",
  "color-danger-800": "#5B0732",
  "color-danger-900": "#4B042F"
}

const lightTheme = {
  ...light,
  ...importedTheme,
  "color-violet": "#6e53a6",
  "color-white": "#ffffff",
  "color-black": "#000000",
  "color-blue": "#6b50a5",
  "color-green": "#34c25f",
  "color-check": "#5e4496",
  "color-gray": "#d3d3d3",
  "color-light-gray": "#e5eaef",
};

const darkTheme = {
  ...light, //todo!
  ...importedTheme,
  "color-violet": "#6e53a6",
  "color-white": "#ffffff",
  "color-black": "#000000",
  "color-blue": "#6b50a5",
  "color-green": "#34c25f",
  "color-check": "#5e4496",
  "color-gray": "#d3d3d3",
  "color-light-gray": "#e5eaef",
};

export const updateTheme = (color: 'light' | 'dark') => {
  console.log("XXXXDDDDD", color);
  theme = color === 'dark' ?  {...dark, ...darkTheme} : { ...light, ...lightTheme};
}

export let theme = DefaultTheme.dark ? {...dark, ...darkTheme} : { ...light, ...lightTheme};
