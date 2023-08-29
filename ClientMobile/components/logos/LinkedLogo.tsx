import * as React from "react";
import Svg, { G, Path, Defs, ClipPath } from "react-native-svg";

export const LinkedLogo = (props:any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={24}
    height={24}
    fill="none"
    {...props}
  >
    <G clipPath="url(#a)">
      <Path fill="#fff" d="M1.5 1.5h21v21h-21z" />
      <Path
        fill="#0A66C2"
        d="M22.228 0H1.772A1.772 1.772 0 0 0 0 1.772v20.456A1.772 1.772 0 0 0 1.772 24h20.456A1.772 1.772 0 0 0 24 22.228V1.772A1.772 1.772 0 0 0 22.228 0ZM7.153 20.445H3.545V8.983h3.608v11.462ZM5.347 7.395a2.072 2.072 0 1 1 2.083-2.07 2.042 2.042 0 0 1-2.083 2.07Zm15.106 13.06h-3.606v-6.262c0-1.846-.785-2.416-1.799-2.416-1.07 0-2.12.806-2.12 2.463v6.215H9.32V8.992h3.47v1.588h.047c.348-.705 1.568-1.91 3.43-1.91 2.013 0 4.188 1.195 4.188 4.695l-.002 7.09Z"
      />
    </G>
    <Defs>
      <ClipPath id="a">
        <Path fill="#fff" d="M0 0h24v24H0z" />
      </ClipPath>
    </Defs>
  </Svg>
);
