import { useCallback } from 'react';
import { useIntl } from 'react-intl';
import { PrimitiveType } from 'intl-messageformat';

export const useTranslation = () => {
  const intl = useIntl();

  const t: Translaction = useCallback(
    (id, values) => intl.formatMessage({ id }, values),
    [intl]
  );

  return { t, ...intl };
};

export type TranslactionKeys = keyof typeof import('./pl.json');
export type Translaction = (
  id: TranslactionKeys,
  values?: Record<string, PrimitiveType>
) => string;
