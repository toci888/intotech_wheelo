// import { getLocales } from "expo-localization";
import { I18n } from 'i18n-js';
import Pl from './pl.json';
import En from './en.json';
import * as Localization from 'expo-localization';

// Set the key-value pairs for the different languages you want to support.
// const pl = import('./pl.json');

export const i18n = new I18n({
  pl: Pl,
  en: En,
});

// Set the locale once at the beginning of your app.
i18n.locale = Localization.locale;
i18n.enableFallback = true;
