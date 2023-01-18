// import { getLocales } from "expo-localization";
import { I18n } from 'i18n-js';
import Pl from './pl.json';
import En from './en.json';
import * as Localization from 'expo-localization';

export const i18n = new I18n({
  pl: Pl,
  en: En,
});

i18n.locale = Localization.locale; // todo
i18n.enableFallback = true;
