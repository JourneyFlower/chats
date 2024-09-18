import { useTranslation } from 'next-i18next';

import { IconError } from '@/components/Icons';
import { Alert, AlertDescription } from '@/components/ui/alert';

const ChatError = () => {
  const { t } = useTranslation('client');
  return (
    <Alert variant="destructive" className="bg-[#f93a370d]">
      <AlertDescription className="flex items-center gap-1">
        <IconError stroke="#7f1d1d" />
        {t(
          'There were some errors during the chat. You can switch models or try again later.',
        )}
      </AlertDescription>
    </Alert>
  );
};

export default ChatError;
