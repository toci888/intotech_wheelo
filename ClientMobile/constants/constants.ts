import { Dimensions, Platform, StatusBar } from "react-native";

export const expoClientId = "102834178930-2ttlkgvfa9g29umbtuqtv90vjasf4mop.apps.googleusercontent.com";
export const iosClientId = "102834178930-2ttlkgvfa9g29umbtuqtv90vjasf4mop.apps.googleusercontent.com";
export const androidClientId = "102834178930-2ttlkgvfa9g29umbtuqtv90vjasf4mop.apps.googleusercontent.com";
export const webClientId = "102834178930-2ttlkgvfa9g29umbtuqtv90vjasf4mop.apps.googleusercontent.com";
export const facebookClientId = "1596113584178438";

export const locationAPIKEY = 'pk.95fe8bb8ddbbc10ed656fe23d485c8f0&q';
export const googleAPIKEY = 'AIzaSyDxVQqaiKE1L6N9Etv9SUgKsEHfPr9Et40';

export const LISTMARGIN = 10;
export const WIDTH = Dimensions.get("screen").width - LISTMARGIN * 2;
export const PHOTOS_STR = "photos";
export const AMENITIES_STR = "amenities";
export const DESCRIPTION_STR = "description";

const baseHeight = 160;
const iosNotch = 40;
const iosHeight = baseHeight + iosNotch;
let androidHeight = baseHeight;
let androidNotch = 0;
if (StatusBar.currentHeight) androidNotch = StatusBar.currentHeight;
androidHeight += androidNotch;

export const HEADERHEIGHT = Platform.OS === "ios" ? iosHeight : androidHeight;

export const server = "http://89.40.12.1";

const serverUrl = server + ":5015/api";
const integrationApiUrl = server + ":5108/api";
const chatUrl = server + ":5130/"; //check

const location = "/location";
const google = "/GoogleMap";
const workTrip = serverUrl + "/WorkTrip";
const user = "/Account";
const property = "/property";
const apartment = "/apartment";
const review = "/review";
const conversation = "/conversation";
const messages = "/messages";
const refresh = "/refresh-token";
const wheeloChat = "wheeloChat"
const friends = "/friends"
const refreshTokenEndpoint = serverUrl + user + refresh;
const locationEndpoint = serverUrl + location;
const googleEndpoint = integrationApiUrl + google;
const userEndpoint = serverUrl + user;
const collocationEndpoint = serverUrl + property;
const apartmentEndpoint = serverUrl + apartment;
const reviewEndpoint = serverUrl + review;
const conversationEndpoint = chatUrl + "api" + conversation;
const conversationWheeloChatEndpoint = chatUrl + wheeloChat + conversation;
const messagesEndpoint = serverUrl + messages;
// const contactedEndpoint = (id: number) => `${serverUrl}/Invitations/view-invitations${id}`;
const friendsEndpoint = (id: number) => `${serverUrl}/Friends/your-friends/${id}`;
const pushTokenEndpoint = (id: number) => `${userEndpoint}/${id}/pushtoken`;
const allowsNotificationsEndpoint = (id: number) => `${userEndpoint}/${id}/settings/notifications`;
const themeModeEndpoint = (idAccount: number, darkModeEnabled: boolean) => `${userEndpoint}/${idAccount}/settings/theme-mode?darkmode=${darkModeEnabled}`;
const currentLocationEndpoint = (latitude: number, longitude: number) => `${googleEndpoint}/current-button-location?latitude=${latitude}&longitude=${longitude}`;


export const endpoints = {
  chat: chatUrl + wheeloChat,
  autoComplete: googleEndpoint + "/address-autocomplete",
  recognizePlaceId: googleEndpoint + "/recognize-place-id",
  search: locationEndpoint + "/search",
  addWorkTrip: workTrip + "/add-work-trip",
  register: userEndpoint + "/register",
  emailVerification: userEndpoint + "/confirm-email",
  login: userEndpoint + "/login",
  forgotPassword: userEndpoint + "/forgot-password",
  resetPassword: userEndpoint + "/reset-password",
  forgotPasswordCheckCode: userEndpoint + "/forgot-password-check-code",
  createProperty: collocationEndpoint,
  getCollocationByID: serverUrl + '/AssociationMapData/association-user/',
  getInvitedFriendsByUserID: serverUrl + '/Invitations/view-invitations',
  getAssociationsByUserID: serverUrl + '/AssociationMapData/associations-users',
  getPropertiesByUserID: collocationEndpoint + "/userid/",
  getPropertiesByBoundingBox: collocationEndpoint + "/search",
  deleteFriend: serverUrl + friends + "/unfriend",
  updateProperty: collocationEndpoint + "/update/",
  getApartmentsByPropertyID: apartmentEndpoint + "/property/",
  updateApartments: apartmentEndpoint + "/property/",
  createReview: reviewEndpoint + "/property/",
  getFriendsByUserID: friendsEndpoint,
  alterSavedPropertiesByUserID: friendsEndpoint,
  alterPushToken: pushTokenEndpoint,
  allowsNotifications: allowsNotificationsEndpoint,
  themeMode: themeModeEndpoint,
  createConversation: conversationWheeloChatEndpoint,
  getConversationByID: conversationEndpoint + "/get-conversation-by-id",
  getConversationsByUserEmail: conversationEndpoint + "/get-conversations-by-user-email",
  createMessage: messagesEndpoint,
  refreshTokens: refreshTokenEndpoint,
  currentLocation: currentLocationEndpoint
};

export const queryKeys = {
  contactedProperties: "contactedProperties",
  searchCollocations: "searchCollocations",
  selectedCollocation: "selectedCollocation",
  savedProperties: "savedProperties",
  myProperties: "myProperties",
  editProperty: "editProperty",
  apartments: "apartments",
  conversations: "conversations",
  selectedConversation: "selectedConversation",
};

export const os = {
  android: "android",
  ios: "ios"
}

export const themes = {
  dark: "dark",
  light: "light"
}