import { IconChevronLeft, IconChevronRight } from '@/components/Icons';
import { Button } from '@/components/ui/button';

interface Props {
  hidden?: boolean;
  disabledPrev?: boolean;
  disabledNext?: boolean;
  currentSelectIndex: number;
  messageIds: string[];
  onChangeMessage?: (messageId: string) => void;
}

export const PaginationAction = (props: Props) => {
  const {
    disabledPrev,
    disabledNext,
    currentSelectIndex,
    messageIds,
    onChangeMessage,
    hidden,
  } = props;

  const Render = () => {
    return (
      <div className="flex text-sm items-center">
        <Button
          variant="ghost"
          className="p-1 m-0 h-auto disabled:opacity-50"
          disabled={disabledPrev}
          onClick={() => {
            if (onChangeMessage) {
              const index = currentSelectIndex - 1;
              onChangeMessage(messageIds[index]);
            }
          }}
        >
          <IconChevronLeft />
        </Button>
        <span className="font-bold">
          {`${currentSelectIndex + 1}/${messageIds.length}`}
        </span>
        <Button
          variant="ghost"
          className="p-1 m-0 h-auto"
          disabled={disabledNext}
          onClick={() => {
            if (onChangeMessage) {
              const index = currentSelectIndex + 1;
              onChangeMessage(messageIds[index]);
            }
          }}
        >
          <IconChevronRight />
        </Button>
      </div>
    );
  };

  return <>{!hidden && Render()}</>;
};

export default PaginationAction;
