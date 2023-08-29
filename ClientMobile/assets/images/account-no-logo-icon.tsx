import * as React from "react";
import Svg, {
  Path,
  Defs,
  RadialGradient,
  Stop,
  LinearGradient,
} from "react-native-svg";
export const AccountNoLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={78}
    height={81}
    fill="none"
    {...props}
  >
    <Path
      fill="url(#a)"
      fillOpacity={0.5}
      d="M19.514 72.721A38.97 38.97 0 1 0 58.485 5.222a38.97 38.97 0 0 0-38.97 67.5Z"
    />
    <Path
      fill="url(#b)"
      fillOpacity={0.5}
      d="M19.514 72.721A38.97 38.97 0 1 0 58.485 5.222a38.97 38.97 0 0 0-38.97 67.5Z"
    />
    <Path
      fill="#DBC2F5"
      d="M39 39.131c4.43 0 8.03-4.7 8.03-9.13 0-4.43-3.6-8.03-8.03-8.03s-8.03 3.6-8.03 8.03 3.6 9.13 8.03 9.13ZM45.03 39.211a9.204 9.204 0 0 1-5.61 1.89h-.85c-2.11 0-4.05-.71-5.61-1.89-5.08.82-8.96 5.23-8.96 10.55 0 2.92 6.72 5.29 15 5.29 8.28 0 15-2.37 15-5.29 0-5.32-3.88-9.73-8.97-10.55ZM62 65.511c-1.87 0-3.39 1.52-3.39 3.39s1.52 3.39 3.39 3.39 3.39-1.52 3.39-3.39-1.52-3.39-3.39-3.39Z"
    />
    <Path
      fill="#DBC2F5"
      d="M62 62.101c-3.75 0-6.8 3.05-6.8 6.8s3.05 6.8 6.8 6.8 6.8-3.05 6.8-6.8-3.05-6.8-6.8-6.8Zm0 11.52c-2.6 0-4.71-2.11-4.71-4.71s2.11-4.71 4.71-4.71 4.71 2.11 4.71 4.71-2.11 4.71-4.71 4.71Z"
    />
    <Path
      fill="#DBC2F5"
      d="M73.73 59.071h-3.98l-.34-1.51a3.275 3.275 0 0 0-3.22-2.58h-8.38c-1.56 0-2.89 1.06-3.22 2.58l-.34 1.51h-3.98c-1.82 0-3.27 1.5-3.27 3.32v14.51c0 1.82 1.45 3.31 3.27 3.31h23.46c1.82 0 3.27-1.49 3.27-3.31v-14.51c0-1.82-1.45-3.32-3.27-3.32ZM62 77.031c-4.48 0-8.12-3.64-8.12-8.12 0-4.48 3.64-8.13 8.12-8.13 4.48 0 8.12 3.64 8.12 8.12 0 4.48-3.64 8.13-8.12 8.13Z"
    />
    <Defs>
      <RadialGradient
        id="a"
        cx={0}
        cy={0}
        r={1}
        gradientTransform="matrix(77.94238 80.21123 -706.9587 686.96173 .029 0)"
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#602EA6" />
        <Stop offset={1} stopColor="#C977D6" />
      </RadialGradient>
      <LinearGradient
        id="b"
        x1={39}
        x2={39}
        y1={-18.382}
        y2={80.211}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#FEC8F1" />
        <Stop offset={0.404} stopColor="#FEC8F1" stopOpacity={0} />
      </LinearGradient>
    </Defs>
  </Svg>
)
