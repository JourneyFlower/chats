import { useEffect, useRef } from 'react';
import { Dispatch, createContext } from 'react';

import { useTranslation } from 'next-i18next';
import { serverSideTranslations } from 'next-i18next/serverSideTranslations';
import { useTheme } from 'next-themes';
import Head from 'next/head';
import { useRouter } from 'next/router';

import { useCreateReducer } from '@/hooks/useCreateReducer';
import { ActionType } from '@/hooks/useCreateReducer';

import {
  getPathChatId,
  getSelectChatId,
  saveSelectChatId,
} from '@/utils/chats';
import { getSelectMessages } from '@/utils/message';
import { getStorageModelId, setStorageModelId } from '@/utils/model';
import { formatPrompt } from '@/utils/promptVariable';
import { getSession } from '@/utils/session';
import { getSettings, getSettingsLanguage } from '@/utils/settings';
import { getLoginUrl, getUserInfo, getUserSessionId } from '@/utils/user';
import { UserSession } from '@/utils/user';
import { setSiteInfo } from '@/utils/website';

import { Role } from '@/types/chat';
import { ChatMessage } from '@/types/chatMessage';
import { GlobalConfigKeys, SiteInfo } from '@/types/config';
import { Model, UserModelConfig } from '@/types/model';
import { Prompt } from '@/types/prompt';
import {
  DEFAULT_LANGUAGE,
  DEFAULT_THEME,
  Languages,
  Themes,
} from '@/types/settings';

import { Chat } from '@/components/Chat/Chat';
import { Chatbar } from '@/components/Chatbar/Chatbar';
import PromptBar from '@/components/Promptbar';
import Spinner from '@/components/Spinner';

import {
  ChatResult,
  GetChatsParams,
  getChatsByPaging,
  getUserMessages,
  getUserModels,
  getUserPrompts,
  postChats,
} from '@/apis/userService';
import { ConfigsManager } from '@/managers';
import Decimal from 'decimal.js';
import { v4 as uuidv4 } from 'uuid';

interface HandleUpdateChatParams {
  isShared?: boolean;
  title?: string;
  chatModelId?: string;
}

interface HomeInitialState {
  user: UserSession | null;
  loading: boolean;
  theme: (typeof Themes)[number];
  language: (typeof Languages)[number];
  messageIsStreaming: boolean;
  models: Model[];
  chats: ChatResult[];
  chatsPaging: { count: number; page: number; pageSize: number };
  selectChatId: string | undefined;
  selectModel: Model | undefined;
  currentMessages: ChatMessage[];
  selectMessages: ChatMessage[];
  selectMessageLastId: string;
  currentChatMessageId: string;
  userModelConfig: UserModelConfig | undefined;
  chatError: boolean;
  prompts: Prompt[];
  showChatbar: boolean;
  showPromptbar: boolean;
  searchTerm: string;
}

const initialState: HomeInitialState = {
  user: null,
  loading: false,
  theme: DEFAULT_THEME,
  language: DEFAULT_LANGUAGE,
  messageIsStreaming: false,
  currentMessages: [],
  userModelConfig: undefined,
  selectMessages: [],
  selectMessageLastId: '',
  currentChatMessageId: '',
  models: [],
  chats: [],
  chatsPaging: { count: 0, page: 1, pageSize: 50 },
  selectModel: undefined,
  selectChatId: undefined,
  chatError: false,
  prompts: [],
  showPromptbar: false,
  showChatbar: true,
  searchTerm: '',
};

interface HomeContextProps {
  state: HomeInitialState;
  dispatch: Dispatch<ActionType<HomeInitialState>>;
  handleNewChat: () => void;
  handleSelectChat: (chatId: string) => void;
  handleUpdateChat: (
    chats: ChatResult[],
    id: string,
    params: HandleUpdateChatParams,
  ) => void;
  handleUpdateSelectMessage: (lastLeafId: string) => void;
  handleUpdateCurrentMessage: (chatId: string) => void;
  handleDeleteChat: (id: string) => void;
  handleSelectModel: (model: Model) => void;
  handleUpdateUserModelConfig: (value: any) => void;
  hasModel: () => boolean;
  getChats: (params: GetChatsParams, models?: Model[]) => void;
}

const HomeContext = createContext<HomeContextProps>(undefined!);

export { initialState, HomeContext };

const Home = ({ siteInfo }: { siteInfo: SiteInfo }) => {
  const router = useRouter();
  const { t } = useTranslation('chat');
  const contextValue = useCreateReducer<HomeInitialState>({
    initialState,
  });

  const {
    state: { chats, currentMessages, models, user, userModelConfig },
    dispatch,
  } = contextValue;
  const stopConversationRef = useRef<boolean>(false);
  const { setTheme } = useTheme();

  const calcSelectModel = (chats: ChatResult[], models: Model[]) => {
    const lastChat = chats.findLast((x) => x.chatModelId);
    const model = models.find((x) => x.id === lastChat?.chatModelId);
    if (model) return model;
    else return models.length > 0 ? models[0] : undefined;
  };

  const getChatModel = (chatId: string, models: Model[]) => {
    const chatModelId = chats.find((x) => x.id === chatId)?.chatModelId;
    const model = models.find((x) => x.id === chatModelId);
    return model;
  };

  const chatErrorMessage = (messageId: string) => {
    return {
      id: uuidv4(),
      parentId: messageId,
      childrenIds: [],
      assistantChildrenIds: [],
      role: 'assistant' as Role,
      content: { text: '', image: [] },
      inputTokens: 0,
      outputTokens: 0,
      inputPrice: new Decimal(0),
      outputPrice: new Decimal(0),
    };
  };

  const handleSelectModel = (model: Model) => {
    const { modelConfig } = model;
    dispatch({ field: 'selectModel', value: model });
    handleUpdateUserModelConfig({
      ...modelConfig,
      temperature: modelConfig?.temperature,
      prompt: formatPrompt(modelConfig?.prompt, { model }),
      enableSearch: modelConfig?.enableSearch,
    });
  };

  const handleNewChat = () => {
    postChats({ title: t('New Conversation') }).then((data) => {
      const model = calcSelectModel(chats, models);
      dispatch({ field: 'selectChatId', value: data.id });
      dispatch({ field: 'selectMessageLastId', value: '' });
      dispatch({ field: 'currentMessages', value: [] });
      dispatch({ field: 'selectMessages', value: [] });
      dispatch({ field: 'chatError', value: false });
      dispatch({ field: 'chats', value: [...chats, data] });
      handleSelectModel(model!);
      router.push('#/' + data.id);
    });
  };

  const handleUpdateCurrentMessage = (chatId: string) => {
    getUserMessages(chatId).then((data) => {
      if (data.length > 0) {
        dispatch({ field: 'currentMessages', value: data });
        const lastMessage = data[data.length - 1];
        const _selectMessages = getSelectMessages(data, lastMessage.id);
        dispatch({
          field: 'selectMessages',
          value: _selectMessages,
        });
        dispatch({ field: 'selectMessageLastId', value: lastMessage.id });
      } else {
        dispatch({ field: 'currentMessages', value: [] });
        dispatch({
          field: 'selectMessages',
          value: [],
        });
      }
    });
  };

  const handleSelectChat = (chatId: string) => {
    dispatch({
      field: 'chatError',
      value: false,
    });
    dispatch({ field: 'selectChatId', value: chatId });
    const chat = chats.find((x) => x.id === chatId)!;
    const selectModel =
      getChatModel(chatId, models) || calcSelectModel(chats, models);
    selectModel && setStorageModelId(selectModel.id);
    getUserMessages(chatId).then((data) => {
      if (data.length > 0) {
        dispatch({ field: 'currentMessages', value: data });
        const lastMessage = data[data.length - 1];
        const _selectMessages = getSelectMessages(data, lastMessage.id);
        if (lastMessage.role !== 'assistant') {
          dispatch({
            field: 'chatError',
            value: true,
          });
          _selectMessages.push(chatErrorMessage(lastMessage.id));
        }

        dispatch({
          field: 'selectMessages',
          value: _selectMessages,
        });
        dispatch({ field: 'selectMessageLastId', value: lastMessage.id });
        dispatch({ field: 'userModelConfig', value: chat.userModelConfig });
        dispatch({
          field: 'selectModel',
          value: selectModel,
        });
      } else {
        handleSelectModel(selectModel!);
        dispatch({ field: 'currentMessages', value: [] });
        dispatch({
          field: 'selectMessages',
          value: [],
        });
      }
    });
    router.push('#/' + chat.id);
    saveSelectChatId(chatId);
  };

  const handleUpdateSelectMessage = (messageId: string) => {
    const _selectMessages = getSelectMessages(currentMessages, messageId);
    dispatch({
      field: 'selectMessages',
      value: _selectMessages,
    });
  };

  const handleUpdateUserModelConfig = (value: any) => {
    dispatch({
      field: 'userModelConfig',
      value: { ...userModelConfig, ...value },
    });
  };
  const handleUpdateChat = (
    chats: ChatResult[],
    id: string,
    params: HandleUpdateChatParams,
  ) => {
    const _chats = chats.map((x) => {
      if (x.id === id) return { ...x, ...params };
      return x;
    });

    dispatch({ field: 'chats', value: _chats });
  };

  const handleDeleteChat = (id: string) => {
    const _chats = chats.filter((x) => {
      return x.id !== id;
    });
    dispatch({ field: 'chats', value: _chats });
    dispatch({ field: 'selectChatId', value: '' });
    dispatch({ field: 'selectMessageLastId', value: '' });
    dispatch({ field: 'currentMessages', value: [] });
    dispatch({ field: 'selectMessages', value: [] });
    dispatch({
      field: 'selectModel',
      value: calcSelectModel(chats, models),
    });
    dispatch({ field: 'userModelConfig', value: {} });
  };

  const hasModel = () => {
    return models?.length > 0;
  };

  const selectChat = (
    chatList: ChatResult[],
    chatId: string | null,
    models: Model[],
  ) => {
    const chat = chatList.find((x) => x.id === chatId);
    if (chat) {
      dispatch({ field: 'selectChatId', value: chatId });

      getUserMessages(chat.id).then((data) => {
        if (data.length > 0) {
          dispatch({ field: 'currentMessages', value: data });
          const lastMessage = data[data.length - 1];
          const _selectMessages = getSelectMessages(data, lastMessage.id);
          if (lastMessage.role !== 'assistant') {
            dispatch({
              field: 'chatError',
              value: true,
            });
            _selectMessages.push(chatErrorMessage(lastMessage.id));
          }
          dispatch({
            field: 'selectMessages',
            value: _selectMessages,
          });
          dispatch({ field: 'selectMessageLastId', value: lastMessage.id });
        } else {
          dispatch({ field: 'currentMessages', value: [] });
          dispatch({
            field: 'selectMessages',
            value: [],
          });
        }
        const model =
          getChatModel(chat?.id, models) || calcSelectModel(chatList, models);
        handleSelectModel(model!);
      });
    }
  };

  const getChats = (params: GetChatsParams, modelList?: Model[]) => {
    const { page, pageSize } = params;
    getChatsByPaging(params).then((data) => {
      const { rows, count } = data;
      dispatch({
        field: 'chatsPaging',
        value: { count, page, pageSize },
      });
      let _chats = rows;
      if (!modelList) {
        _chats = rows.concat(chats);
      }
      dispatch({ field: 'chats', value: _chats });
      if (modelList) {
        const selectChatId = getPathChatId(router.asPath) || getSelectChatId();
        selectChat(rows, selectChatId, modelList || models);
      }
    });
  };

  useEffect(() => {
    setSiteInfo(siteInfo);
    const settings = getSettings();
    if (settings.theme) {
      dispatch({
        field: 'theme',
        value: settings.theme,
      });
      setTheme(settings.theme);
    }

    if (settings.language) {
      dispatch({
        field: 'language',
        value: settings.language,
      });
    }

    const showChatbar = localStorage.getItem('showChatbar');
    if (showChatbar) {
      dispatch({ field: 'showChatbar', value: showChatbar === 'true' });
    }

    const showPromptbar = localStorage.getItem('showPromptbar');
    if (showPromptbar) {
      dispatch({ field: 'showPromptbar', value: showPromptbar === 'true' });
    }
  }, []);

  useEffect(() => {
    const session = getUserInfo();
    const sessionId = getUserSessionId();
    if (session && sessionId) {
      setTimeout(() => {
        dispatch({ field: 'user', value: session });
      }, 1000);
    } else {
      router.push(getLoginUrl(getSettingsLanguage()));
    }
    if (sessionId) {
      getUserModels().then((modelData) => {
        dispatch({ field: 'models', value: modelData });
        if (modelData && modelData.length > 0) {
          const selectModelId = getStorageModelId();
          const model =
            modelData.find((x) => x.id === selectModelId) ?? modelData[0];
          if (model) {
            setStorageModelId(model.id);
            handleSelectModel(model);
          }
        }

        getChats({ page: 1, pageSize: 50 }, modelData);
      });

      getUserPrompts().then((data) => {
        dispatch({ field: 'prompts', value: data });
      });
    }
  }, []);

  useEffect(() => {
    const handlePopState = (event: PopStateEvent) => {
      const chatId = getPathChatId(event.state.as);
      selectChat(chats, chatId, models);
    };

    window.addEventListener('popstate', handlePopState);

    return () => {
      window.removeEventListener('popstate', handlePopState);
    };
  }, [chats]);

  return (
    <HomeContext.Provider
      value={{
        ...contextValue,
        handleNewChat,
        handleSelectChat,
        handleUpdateChat,
        handleDeleteChat,
        handleSelectModel,
        handleUpdateSelectMessage,
        handleUpdateCurrentMessage,
        handleUpdateUserModelConfig,
        hasModel,
        getChats,
      }}
    >
      <Head>
        <title>Chats</title>
        <meta name="description" content="" />
        <meta
          name="viewport"
          content="height=device-height ,width=device-width, initial-scale=1, user-scalable=no"
        />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <main>
        {!user && (
          <div
            className={`fixed top-0 left-0 bottom-0 right-0 bg-white dark:bg-[#202123] text-black/80 dark:text-white/80 z-50 text-center text-[12.5px]`}
          >
            <div className="fixed w-screen h-screen top-1/2">
              <div className="flex justify-center">
                <Spinner
                  size="18"
                  className="text-gray-500 dark:text-gray-50"
                />
              </div>
            </div>
          </div>
        )}
        <div className={`flex h-screen w-screen flex-col text-sm`}>
          <div className="flex h-full w-full dark:bg-[#262630]">
            <Chatbar />
            <div className="flex w-full">
              <Chat stopConversationRef={stopConversationRef} />
            </div>
            <PromptBar />
          </div>
        </div>
      </main>
    </HomeContext.Provider>
  );
};

export default Home;

export const getServerSideProps = async ({
  locale,
  req,
}: {
  locale: string;
  req: any;
}) => {
  const siteInfo: SiteInfo = await ConfigsManager.get(
    GlobalConfigKeys.siteInfo,
  );
  const session = await getSession(req.headers.cookie);
  return {
    props: {
      siteInfo: siteInfo || {},
      locale,
      session,
      ...(await serverSideTranslations(locale ?? DEFAULT_LANGUAGE, [
        'common',
        'chat',
        'sidebar',
        'markdown',
        'prompt',
        'settings',
      ])),
    },
  };
};
