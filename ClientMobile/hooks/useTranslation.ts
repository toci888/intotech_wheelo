import { useContext } from "react";

import { LoadingContext } from "../context";

export const useTranslation = () => {
  const { loading, setLoading } = useContext(LoadingContext);

  return { loading, setLoading };
};
