import * as React from "react";
import Svg, { Path } from "react-native-svg";
export const ClearLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={24}
    height={25}
    fill="none"
    {...props}
  >
    <Path
      fill="#F3EBFC"
      d="M19 6.91 17.59 5.5 12 11.09 6.41 5.5 5 6.91l5.59 5.59L5 18.09l1.41 1.41L12 13.91l5.59 5.59L19 18.09l-5.59-5.59L19 6.91Z"
    />
  </Svg>
);
