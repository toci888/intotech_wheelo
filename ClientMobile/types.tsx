import { BottomTabScreenProps } from "@react-navigation/bottom-tabs";
import {
  CompositeScreenProps,
  NavigatorScreenParams,
} from "@react-navigation/native";
import { NativeStackScreenProps } from "@react-navigation/native-stack";
import { Location } from "./types/locationIQ";
import { User } from "./types/user";

declare global {
  namespace ReactNavigation {
    interface RootParamList extends RootStackParamList {}
  }
}

export type RootStackParamList = {
  Root: NavigatorScreenParams<RootTabParamList> | undefined;
  FindLocations: undefined;
  SignIn: undefined;
  SignUp: undefined;
  ForgotPassword: undefined;
  ResetPassword: { token: string, email: string };
  PropertyDetails: { collocationID: number };
  MessageProperty: { collocationID: number; tour?: boolean };
  AddProperty: undefined;
  EditProperty: { collocationId: number };
  MyProperties: undefined;
  ManageUnits: { collocationID: number };
  Review: { collocationID: number; propertyName: string };
  CodeVerification: { params: User};
  Messages: { conversationID: number; recipientName: string };
};

export type RootStackScreenProps<Screen extends keyof RootStackParamList> =
  NativeStackScreenProps<RootStackParamList, Screen>;

export type RootTabParamList = {
  Search: undefined | SearchScreenParams;
  Saved: undefined;
  Saved2: undefined;
  AccountRoot: NavigatorScreenParams<AccountTabParamList> | undefined;
};

export type AccountTabParamList = {
  Account: undefined;
  Settings: undefined;
  Conversations: undefined;
  Messages: { conversationID: number; recipientName: string };
};

export type ChatTabParamList = {
  Chat: undefined;
  Conversations: undefined;
  Messages: { conversationID: number; recipientName: string };
};

export type AuthParamList = {
  Account: undefined;
  SignIn: undefined;
  SignUp: undefined;
  ForgotPassword: undefined;
  ResetPassword: undefined;
  CodeVerification: undefined;
};

export type RootTabScreenProps<Screen extends keyof RootTabParamList> =
  CompositeScreenProps<
    BottomTabScreenProps<RootTabParamList, Screen>,
    NativeStackScreenProps<RootStackParamList>
  >;

export type SearchScreenParams = {
  startLocation: Location;
  startLocationTime: string;
  endLocation: Location;
  endLocationTime: string;
  driverPassenger: number;
  acceptableDistance?: number;
};

export enum ThemeMode {
  'light' = 0,
  'dark' = 1,
  'blue' = 2
}

export enum Driver {
  'driver' = 1,
  'passenger' = 2,
  'both' = 3
}

export enum Relationship {
  'notFriends' = 1,
  'invited' = 2,
  'suggested' = 3,
  'friend' = 4
}

type Response = {
  errorMessage: string;
  isSuccess: boolean;
  errorCode: number;
}

export type ReturnedResponse<TModel> = 
Response & {
  methodResult: TModel
}

export type registerDto = {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  method?: string;
}

export type loginDto = {
  email: string;
  password: string;
  method?: string;
  token?: string;
}

export type NotificationsParams = { 
  root?: string, 
  screen?: string, 
  screenParams?: Object
}
