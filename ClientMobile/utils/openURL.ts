import * as WebBrowser from "expo-web-browser";
import { i18n } from "../i18n/i18n";
import { commonAlert } from "./handleError";

export const openURL = (url: string) => {
  try {
    WebBrowser.openBrowserAsync(url);
  } catch (error) {
    commonAlert(i18n.t('UnableToViewWebsite'))
  }
};
