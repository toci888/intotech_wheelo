import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const AppleLogo = (props:any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={24}
    height={24}
    fill="none"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path
        fill="#fff"
        d="M21.792 18.703a13.05 13.05 0 0 1-1.29 2.32c-.679.968-1.234 1.637-1.662 2.01-.664.61-1.375.922-2.137.94-.546 0-1.206-.155-1.973-.471-.77-.314-1.478-.47-2.124-.47-.679 0-1.407.156-2.185.47-.78.316-1.407.48-1.888.496-.73.031-1.458-.29-2.184-.966-.464-.404-1.044-1.098-1.739-2.08-.745-1.049-1.358-2.265-1.838-3.651C2.258 15.803 2 14.353 2 12.948c0-1.608.348-2.995 1.044-4.158A6.122 6.122 0 0 1 5.23 6.58a5.88 5.88 0 0 1 2.955-.835c.58 0 1.34.18 2.285.532.943.354 1.548.534 1.813.534.199 0 .871-.21 2.01-.628 1.078-.388 1.988-.549 2.733-.486 2.02.163 3.536.96 4.545 2.393-1.806 1.095-2.699 2.627-2.681 4.593.016 1.531.572 2.806 1.663 3.818.495.47 1.048.832 1.663 1.09-.134.387-.274.757-.424 1.112ZM17.161.48c0 1.2-.439 2.321-1.313 3.359-1.054 1.233-2.33 1.945-3.714 1.833a3.743 3.743 0 0 1-.027-.455c0-1.152.501-2.385 1.392-3.394.445-.51 1.01-.935 1.696-1.273.685-.334 1.332-.518 1.94-.55.019.16.026.321.026.48Z"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 0h24v24H0z" />
      </ClipPath>
    </Defs>
  </Svg>
);
