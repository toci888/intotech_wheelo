import { Dimensions, Platform, StatusBar } from "react-native";

export const locationAPIKEY = 'pk.95fe8bb8ddbbc10ed656fe23d485c8f0&q';

export const LISTMARGIN = 6;
export const WIDTH = Dimensions.get("screen").width - LISTMARGIN * 2;
export const PHOTOS_STR = "photos";
export const AMENITIES_STR = "amenities";
export const DESCRIPTION_STR = "description";

const baseHeight = 300;
const iosNotch = 40;
const iosHeight = baseHeight + iosNotch;
let androidHeight = baseHeight;
let androidNotch = 0;
if (StatusBar.currentHeight) androidNotch = StatusBar.currentHeight;
androidHeight += androidNotch;

export const HEADERHEIGHT = Platform.OS === "ios" ? iosHeight : androidHeight;

const serverUrl = "http://20.100.196.118:5105/api"; //HERE
const chatUrl = "http://192.168.30.24:3000";
const location = "/location";
const user = "/Account";
const property = "/property";
const apartment = "/apartment";
const review = "/review";
const conversation = "/conversation";
const messages = "/messages";
const refresh = "/refresh";
const refreshTokenEndpoint = serverUrl + refresh;
const locationEndpoint = serverUrl + location;
const userEndpoint = serverUrl + user;
const propertyEndpoint = serverUrl + property;
const apartmentEndpoint = serverUrl + apartment;
const reviewEndpoint = serverUrl + review;
const conversationEndpoint = serverUrl + conversation;
const messagesEndpoint = serverUrl + messages;
const contactedEndpoint = (id: number) =>
  `${userEndpoint}/${id}/properties/contacted`;
const savedEndpoint = (id: number) => `${userEndpoint}/${id}/properties/saved`;
const pushTokenEndpoint = (id: number) => `${userEndpoint}/${id}/pushtoken`;
const allowsNotificationsEndpoint = (id: number) =>
  `${userEndpoint}/${id}/settings/notifications`;

export const endpoints = {
  chat: chatUrl,
  autoComplete: locationEndpoint + "/autocomplete",
  search: locationEndpoint + "/search",
  register: userEndpoint + "/register",
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
  createConversation: conversationEndpoint,
  getConversationByID: conversationEndpoint + "/",
  getConversationsByUserID: conversationEndpoint + "/user/",
  createMessage: messagesEndpoint,
  refreshTokens: refreshTokenEndpoint,
};

export const queryKeys = {
  contactedProperties: "contactedProperties",
  searchProperties: "searchProperties",
  selectedProperty: "selectedProperty",
  savedProperties: "savedProperties",
  myProperties: "myProperties",
  editProperty: "editProperty",
  apartments: "apartments",
  conversations: "conversations",
  selectedConversation: "selectedConversation",
};
