export type User = {
  id: number;
  firstName?: string;
  lastName?: string;
  email: string;
  savedCollocations?: number[];
  allowsNotifications: boolean;
  darkMode: boolean;
  pushToken?: string;
  sessionID?: string;
  accessToken: string;
  refreshToken: string;
};
