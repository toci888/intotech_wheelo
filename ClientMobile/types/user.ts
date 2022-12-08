export type User = {
  ID: number;
  firstName?: string;
  lastName?: string;
  email: string;
  savedProperties?: number[];
  allowsNotifications: boolean;
  alterDarkMode: boolean;
  pushToken?: string;
  sessionID?: string;
  accessToken: string;
  refreshToken: string;
};
