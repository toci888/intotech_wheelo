import * as React from "react";
import Svg, { Path } from "react-native-svg";
export const WorkLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={30}
    height={30}
    fill="none"
    {...props}
  >
    <Path
      fill="#5A189A"
      fillRule="evenodd"
      d="M21.25 8.125H25c1.387 0 2.5 1.113 2.5 2.5v13.75c0 1.387-1.113 2.5-2.5 2.5H5a2.491 2.491 0 0 1-2.5-2.5v-13.75c0-1.387 1.112-2.5 2.5-2.5h3.75v-2.5c0-1.388 1.113-2.5 2.5-2.5h7.5c1.387 0 2.5 1.112 2.5 2.5v2.5Zm-2.5-2.5h-7.5v2.5h7.5v-2.5ZM25 24.375H5v-2.5h20v2.5Zm-20-6.25h20v-7.5h-3.75v2.5h-2.5v-2.5h-7.5v2.5h-2.5v-2.5H5v7.5Z"
      clipRule="evenodd"
    />
  </Svg>
);
