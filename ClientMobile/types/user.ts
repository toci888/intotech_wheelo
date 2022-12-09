import { ThemeMode } from "../types";

export type User = {
  ID: number;
  firstName?: string;
  lastName?: string;
  email: string;
  savedProperties?: number[];
  allowsNotifications: boolean;
  themeMode: ThemeMode;
  pushToken?: string;
  sessionID?: string;
  accessToken: string;
  refreshToken: string;
};
