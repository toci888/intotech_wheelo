import * as React from "react";
import Svg, { Path } from "react-native-svg";
export const AlarmLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={20}
    height={20}
    fill="none"
    {...props}
  >
    <Path
      fill="#DBC2F5"
      fillRule="evenodd"
      d="M6.567 2.883 5.5 1.608 1.667 4.817l1.075 1.275 3.825-3.209Zm11.766 1.942L14.5 1.608l-1.075 1.275L17.258 6.1l1.075-1.275Zm-9.166 1.9h1.25V11.1l3.333 1.975-.625 1.025-3.958-2.375v-5ZM10 3.392a7.5 7.5 0 0 0-7.5 7.5c0 4.141 3.35 7.5 7.5 7.5a7.5 7.5 0 0 0 0-15Zm-5.833 7.5A5.829 5.829 0 0 0 10 16.725a5.829 5.829 0 0 0 5.833-5.833A5.83 5.83 0 0 0 10 5.058a5.83 5.83 0 0 0-5.833 5.834Z"
      clipRule="evenodd"
    />
  </Svg>
);
