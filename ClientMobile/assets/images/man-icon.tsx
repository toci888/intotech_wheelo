import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const ManIcon = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={30}
    height={24}
    fill="none"
    {...props}
  >
    <G fill="#C463F9" clipPath="url(#a)">
      <Path d="M15 12.45c3.214 0 5.826-3.41 5.826-6.624A5.83 5.83 0 0 0 15 0a5.83 5.83 0 0 0-5.826 5.826c0 3.214 2.612 6.624 5.826 6.624ZM19.375 12.45a6.678 6.678 0 0 1-4.07 1.371h-.617a6.724 6.724 0 0 1-4.07-1.371 7.751 7.751 0 0 0-6.5 7.654c0 2.119 4.875 3.838 10.882 3.838s10.883-1.72 10.883-3.838c0-3.86-2.815-7.06-6.508-7.654Z" />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 0h30v23.942H0z" />
      </ClipPath>
    </Defs>
  </Svg>
);

