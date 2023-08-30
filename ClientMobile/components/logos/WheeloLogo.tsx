import React from "react";
import Svg, { Defs, G, LinearGradient, Path, Stop  } from "react-native-svg";

export const WheeloLogo = (props: any) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    width={304}
    height={80}
    fill="none"
    {...props}
  >
    <G filter="url(#a)">
      <Path
        fill="url(#b)"
        d="M12.65 0C6 0 .608 5.387.608 12.032c0 3.323 1.348 6.33 3.526 8.507l8.513 8.506 8.513-8.506a11.989 11.989 0 0 0 3.526-8.507C24.686 5.387 19.294 0 12.644 0h.006Zm0 18.157a6.043 6.043 0 1 1 0-12.085 6.043 6.043 0 1 1 0 12.085Z"
      />
      <Path
        fill="url(#c)"
        d="M21.005 30.885H4.291L21.85 80h16.716l-17.56-49.115Z"
      />
      <Path
        fill="url(#d)"
        d="M38.568 80H21.851l17.56-59.077h16.715L38.568 80Z"
      />
      <Path
        fill="url(#e)"
        d="M56.168 20.923H39.454L57.012 80h16.716l-17.56-59.077Z"
      />
      <Path
        fill="url(#f)"
        d="M73.731 80H57.014l17.56-65.477h16.714L73.731 80Z"
      />
      <Path
        fill="url(#g)"
        d="M139.095 30.885V80H124.03V61.405h-16.677V80H92.289V30.885h15.064V49.48h16.677V30.885h15.065Zm38.414 11.926V30.885h-31.742V80h31.742V68.075h-16.677v-6.667h16.677V49.483h-16.677v-6.67h16.677v-.002Zm38.413 0V30.885H184.18V80h31.742V68.075h-16.677v-6.667h16.677V49.483h-16.677v-6.67h16.677v-.002Zm21.737 25.261V30.885h-15.065V80h31.741V68.075h-16.676v-.003Zm65.727-12.776v.195c0 2.037-.248 4.021-.715 5.912a24.154 24.154 0 0 1-2.762 6.666c-4.281 7.142-12.108 11.926-21.048 11.926-8.94 0-16.77-4.784-21.048-11.926a24.252 24.252 0 0 1-2.762-6.666 24.652 24.652 0 0 1-.716-5.912v-.195c0-2.005.241-3.955.697-5.819a24.362 24.362 0 0 1 2.722-6.669c3.931-6.621 10.899-11.237 18.991-11.925h4.238a24.478 24.478 0 0 1 15.225 7.082 24.662 24.662 0 0 1 3.765 4.843 24.362 24.362 0 0 1 2.722 6.67c.454 1.863.697 3.815.697 5.818h-.006Zm-13.493 6.107a12.43 12.43 0 0 0 1.511-5.96v-.102c0-2.117-.529-4.114-1.465-5.866a12.22 12.22 0 0 0-2.213-2.992 12.476 12.476 0 0 0-8.865-3.675 12.52 12.52 0 0 0-11.081 6.67 12.406 12.406 0 0 0-1.465 5.866v.101c0 2.158.547 4.19 1.511 5.96a12.534 12.534 0 0 0 11.032 6.574c4.767 0 8.914-2.659 11.033-6.574l.002-.002Z"
      />
    </G>
    <Defs>
      <LinearGradient
        id="b"
        x1={0.608}
        x2={29.279}
        y1={29.181}
        y2={5.432}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
      <LinearGradient
        id="c"
        x1={4.291}
        x2={50.593}
        y1={80.229}
        y2={47.942}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
      <LinearGradient
        id="d"
        x1={21.851}
        x2={73.357}
        y1={80.275}
        y2={50.417}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
      <LinearGradient
        id="e"
        x1={39.454}
        x2={90.96}
        y1={80.275}
        y2={50.417}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
      <LinearGradient
        id="f"
        x1={57.014}
        x2={111.047}
        y1={80.305}
        y2={52.043}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
      <LinearGradient
        id="g"
        x1={92.289}
        x2={114.087}
        y1={80.229}
        y2={-13.388}
        gradientUnits="userSpaceOnUse"
      >
        <Stop stopColor="#7B2CBF" />
        <Stop offset={1} stopColor="#372672" />
      </LinearGradient>
    </Defs>
  </Svg>
);
