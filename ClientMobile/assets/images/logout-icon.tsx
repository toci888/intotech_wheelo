import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const LogoutIcon = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={30}
    height={23}
    fill="none"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path
        fill="#C463F9"
        d="M3.967 14.872h13v2h-13c-1.1 0-2 .9-2 2s.9 2 2 2h13v2h-13c-5.29-.17-5.29-7.83 0-8Zm14.21-7.99c-.28 7.92-11.69 7.92-11.97 0 .28-7.92 11.69-7.92 11.97 0Zm-5.98-3.99c-5.27.17-5.27 7.8 0 7.97 5.26-.17 5.27-7.8 0-7.97Zm10.06 11.84-1.41 1.41 1.71 1.71h-4.03v2h4.03l-1.71 1.71 1.41 1.41 4.12-4.12-4.12-4.13v.01Z"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 .942h30v22.03H0z" />
      </ClipPath>
    </Defs>
  </Svg>
)