import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const SecurityAndPrivacyIcon = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={30}
    height={31}
    fill="none"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path
        fill="#C463F9"
        d="M23.15 4.832c-2.31 0-6.48-.56-10.65-3.89-3.33 3.33-7.78 3.89-10.37 3.89-1.3 0-2.13-.14-2.13-.14v7.16c0 15 12.5 19.09 12.5 19.09S25 26.852 25 11.852v-7.16s-.69.14-1.85.14Zm-12.21 16.11-5.31-5.62 1.56-1.88 3.75 2.66 7.81-5.78 1.41 1.25-9.22 9.38v-.01Z"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 .942h30v30H0z" />
      </ClipPath>
    </Defs>
  </Svg>
);
