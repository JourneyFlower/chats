import { Content, Role } from './chat';

import Decimal from 'decimal.js';

export interface ChatMessage {
  id: string;
  parentId: string | null;
  childrenIds: string[];
  assistantChildrenIds: string[];
  role: Role;
  content: Content;
  modelName?: string;
  modelId?: number;
  inputPrice?: Decimal;
  outputPrice?: Decimal;
  inputTokens?: number;
  outputTokens?: number;
  reasoningTokens?: number;
  duration?: number;
  firstTokenLatency?: number;
}

export interface MessageNode {
  id: string;
  parentId: string | null;
  content: Content;
  childrenIds?: string[];
  assistantChildrenIds?: string[];
  modelName?: string;
  role: Role;
  inputTokens: number;
  outputTokens: number;
  reasoningTokens: number;
  inputPrice: Decimal;
  outputPrice: Decimal;
}
