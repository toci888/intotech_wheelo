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

export const server = "http://20.68.18.151";

const serverUrl = server + ":5105/api";
const integrationApiUrl = server + ":5108/api";
const chatUrl = "http://192.168.30.24:3000";

const location = "/location";
const google = "/GoogleMap";
const workTrip = serverUrl + "/WorkTrip";
const user = "/Account";
const property = "/property";
const apartment = "/apartment";
const review = "/review";
const conversation = "/conversation";
const messages = "/messages";
const refresh = "/refresh";
const refreshTokenEndpoint = serverUrl + refresh;
const locationEndpoint = serverUrl + location;
const googleEndpoint = integrationApiUrl + google;
const userEndpoint = serverUrl + user;
const propertyEndpoint = serverUrl + property;
const apartmentEndpoint = serverUrl + apartment;
const reviewEndpoint = serverUrl + review;
const conversationEndpoint = serverUrl + conversation;
const messagesEndpoint = serverUrl + messages;
const contactedEndpoint = (id: number) => `${userEndpoint}/${id}/properties/contacted`;
const savedEndpoint = (id: number) => `${userEndpoint}/${id}/properties/saved`;
const pushTokenEndpoint = (id: number) => `${userEndpoint}/${id}/pushtoken`;
const allowsNotificationsEndpoint = (id: number) => `${userEndpoint}/${id}/settings/notifications`;
const themeModeEndpoint = (idAccount: number, darkModeEnabled: boolean) => `${userEndpoint}/${idAccount}/settings/theme-mode?darkmode=${darkModeEnabled}`;

export const endpoints = {
  chat: chatUrl,
  autoComplete: googleEndpoint + "/address-autocomplete",
  recognizePlaceId: googleEndpoint + "/recognize-place-id",
  search: locationEndpoint + "/search",
  addWorkTrip: workTrip + "/add-work-trip",
  register: userEndpoint + "/register",
  emailVerification: userEndpoint + "/confirm-email",
  login: userEndpoint + "/login",
  forgotPassword: userEndpoint + "/forgotpassword",
  resetPassword: userEndpoint + "/resetpassword",
  createProperty: propertyEndpoint,
  getPropertyByID: propertyEndpoint + "/",
  getContactedPropertiesByUserID: contactedEndpoint,
  getPropertiesByUserID: propertyEndpoint + "/userid/",
  getPropertiesByBoundingBox: propertyEndpoint + "/search",
  deleteProperty: propertyEndpoint + "/",
  updateProperty: propertyEndpoint + "/update/",
  getApartmentsByPropertyID: apartmentEndpoint + "/property/",
  updateApartments: apartmentEndpoint + "/property/",
  createReview: reviewEndpoint + "/property/",
  getSavedPropertiesByUserID: savedEndpoint,
  alterSavedPropertiesByUserID: savedEndpoint,
  alterPushToken: pushTokenEndpoint,
  allowsNotifications: allowsNotificationsEndpoint,
  themeMode: themeModeEndpoint,
  createConversation: conversationEndpoint,
  getConversationByID: conversationEndpoint + "/",
  getConversationsByUserID: conversationEndpoint + "/user/",
  createMessage: messagesEndpoint,
  refreshTokens: refreshTokenEndpoint,
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