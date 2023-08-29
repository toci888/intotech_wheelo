import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const MessagesIcon = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={30}
    height={22}
    fill="none"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path
        fill="#C463F9"
        d="M3 .942c-.65 0-1.25.21-1.75.56h.01l13.13 12.34c.29.27.93.27 1.22 0l13.12-12.33h.01c-.49-.36-1.09-.57-1.75-.57H3ZM.29 2.652c-.19.39-.29.83-.29 1.29v14.25c0 1.66 1.34 3 3 3h24c1.66 0 3-1.34 3-3V3.942c0-.46-.11-.9-.29-1.29l-13.07 12.28c-.92.86-2.36.86-3.28 0L.29 2.652Z"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 .942h30v20.25H0z" />
      </ClipPath>
    </Defs>
  </Svg>
);
