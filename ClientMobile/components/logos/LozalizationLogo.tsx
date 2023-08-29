import * as React from "react";
import Svg, { Path } from "react-native-svg";

export const LozalizationLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={15}
    height={21}
    fill="none"
    {...props}
  >
    <Path
      fill="#DBC2F5"
      fillRule="evenodd"
      d="M7.183 5.387c1.57 0 2.832 1.18 2.832 2.75s-1.262 2.767-2.832 2.767c-1.57 0-2.847-1.255-2.847-2.766 0-1.512 1.262-2.751 2.847-2.751Zm7.094 2.047C14.27 3.582 11.123.5 7.183.5 3.243.5 0 3.582 0 7.434c0 .16 0 .403.08.55H0C0 11.77 7.183 20.5 7.183 20.5s7.094-8.73 7.094-12.516v-.55Z"
      clipRule="evenodd"
    />
  </Svg>
);

