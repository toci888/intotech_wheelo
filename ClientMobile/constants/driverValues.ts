import { PickerItem } from "react-native-woodpicker";

export const passenger = "passenger";
export const driver = "driver";
export const both = "both";

export const driverValues: PickerItem[] = [
  { label: passenger, value: 1 },
  { label: driver, value: 2 },
  { label: both, value: 3 },
];

export enum Driver {
  'passenger' = 1,
  'driver' = 2,
  'both' = 3
}
