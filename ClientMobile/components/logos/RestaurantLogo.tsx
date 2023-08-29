import * as React from "react";
import Svg, { Path } from "react-native-svg";
export const RestaurantLogo = (props: any) => (
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
      d="M24.812 12.423c-1.988 1.987-4.675 2.612-6.588 1.725l-1.837 1.837 8.6 8.6-1.763 1.763-8.6-8.6-8.612 8.587-1.763-1.762 12.2-12.2c-.887-1.913-.262-4.6 1.725-6.588 2.4-2.387 5.825-2.837 7.65-1.012 1.838 1.837 1.375 5.262-1.012 7.65Zm-11.525.45L9.749 16.41l-5.237-5.225a5.01 5.01 0 0 1 0-7.075l8.775 8.763Z"
      clipRule="evenodd"
    />
  </Svg>
);
