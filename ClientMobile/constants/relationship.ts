import { PickerItem } from "react-native-woodpicker";

export const notFriends = "notFriends";
export const invited = "invited";
export const suggested = "suggested";
export const friend = "friend";

export const relationship: PickerItem[] = [
  { label: notFriends, value: 1 },
  { label: invited, value: 2 },
  { label: suggested, value: 3 },
  { label: friend, value: 4 },
];
