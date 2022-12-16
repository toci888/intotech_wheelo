import { useNavigation } from "@react-navigation/native";
import * as Facebook from "expo-auth-session/providers/facebook";
import * as Google from "expo-auth-session/providers/google";
import * as AppleAuthentication from "expo-apple-authentication";
import { useEffect } from "react";

import { appleLoginOrRegister, facebookLoginOrRegister, googleLoginOrRegister, loginUser, registerUser } from "../services/user";
import { User } from "../types/user";
import { useUser } from "./useUser";
import { useLoading } from "./useLoading";
import { loginDto, registerDto, ReturnedResponse } from "../types";
import { i18n } from "../i18n/i18n";
import { commonAlert } from "../utils/handleError";
import { androidClientId, expoClientId, facebookClientId, iosClientId, webClientId } from "../constants/constants";

export const useAuth = () => {
  const [_, googleResponse, googleAuth] = Google.useAuthRequest({
    expoClientId: expoClientId,
    iosClientId: iosClientId,
    androidClientId: androidClientId,
    webClientId: webClientId,
    selectAccount: true,
  });

  const [___, ____, fbPromptAsync] = Facebook.useAuthRequest({
    clientId: facebookClientId,
  });

  useEffect(() => {
    async function loginUserWithGoogle(access_token: string) {
      try {
        setLoading(true);
        const user = await googleLoginOrRegister(access_token);
        handleSignInUser(user?.methodResult);
      } catch (error) {
        handleAuthError();
      } finally {
        setLoading(false);
      }
    }

    if (googleResponse?.type === "success") {
      const { access_token } = googleResponse.params;
      loginUserWithGoogle(access_token);
    }
  }, [googleResponse]);

  const { login } = useUser();
  const { goBack } = useNavigation();
  const { setLoading } = useLoading();

  const handleSignInUser = (user?: User) => {
    if (user) {
      login(user);
      goBack();
    }
  };

  const handleAuthError = (description?: string) => {
    description? commonAlert(description) : commonAlert(i18n.t('UnableToAuthorize'));
  }

  const nativeRegister = async (values: registerDto) => {
    try {
      setLoading(true);
      const user = await registerUser(values);

      handleSignInUser(user?.methodResult);
      
      return user;
    } catch (error) {
      handleAuthError();
    } finally {
      setLoading(false);
    }
  };

  const nativeLogin = async (values: loginDto) => {
    try {
      setLoading(true);
      const user = await loginUser(values);
      
      handleSignInUser(user?.methodResult);

      return user;
    } catch (error) {
      handleAuthError();
    } finally {
      setLoading(false);
    }
  };

  const facebookAuth = async () => {
    try {
      const response = await fbPromptAsync();
      if (response.type === "success") {
        setLoading(true);
        const { access_token } = response.params;
        const user = await facebookLoginOrRegister(access_token);
        handleSignInUser(user?.methodResult);
      }
    } catch (error) {
      handleAuthError();
    } finally {
      setLoading(false);
    }
  };

  const appleAuth = async () => {
    try {
      const { identityToken } = await AppleAuthentication.signInAsync({
        requestedScopes: [
          AppleAuthentication.AppleAuthenticationScope.EMAIL,
          AppleAuthentication.AppleAuthenticationScope.FULL_NAME,
        ],
      });

      if (identityToken) {
        setLoading(true);
        const user = await appleLoginOrRegister(identityToken);
        handleSignInUser(user?.methodResult);
      }
    } catch (error) {
      handleAuthError();
    } finally {
      setLoading(false);
    }
  };

  return { nativeRegister, nativeLogin, facebookAuth, googleAuth, appleAuth };
};
