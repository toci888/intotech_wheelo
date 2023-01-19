export type User = {
  id: number;
  firstName?: string;
  lastName?: string;
  email: string;
  savedCollocations?: number[];
  allowsNotifications: boolean;
  darkMode?: boolean; //to remove
  pushToken?: string;
  sessionID?: string;
  accessToken: string;
  refreshtoken: string;
};
