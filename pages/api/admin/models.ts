import { ChatModelManager } from '@/managers';
import { ModelDefaultTemplates } from '@/types/template';
import { ModelVersions } from '@/types/model';
import { BadRequest } from '@/utils/error';
import { ChatModels } from '@prisma/client';
import { apiHandler } from '@/middleware/api-handler';
import { ChatsApiRequest } from '@/types/next-api';
import { conversionModelPriceToSave } from '@/utils/model';
export const config = {
  api: {
    bodyParser: {
      sizeLimit: '1mb',
    },
  },
  maxDuration: 5,
};

const handler = async (req: ChatsApiRequest) => {
  if (req.method === 'GET') {
    const { all } = req.query;
    const models = await ChatModelManager.findModels(!!all);
    const data = models.map((x: ChatModels) => {
      return {
        rank: x.rank,
        modelId: x.id,
        modelVersion: x.modelVersion,
        name: x.name,
        type: x.type,
        enabled: x.enabled,
        remarks: x.remarks,
        modelKeysId: x.modelKeysId,
        fileServerId: x.fileServerId,
        fileConfig: x.fileConfig,
        modelConfig: x.modelConfig,
        priceConfig: x.priceConfig,
      };
    });
    return data;
  } else if (req.method === 'PUT') {
    const {
      modelId,
      name,
      enabled,
      modelKeysId,
      fileServerId,
      fileConfig,
      modelConfig,
      priceConfig,
      remarks,
    } = req.body;
    const model = await ChatModelManager.findModelById(modelId);
    if (!model) {
      throw new BadRequest('Model is not Found');
    }

    const data = await ChatModelManager.updateModel({
      id: modelId,
      name,
      enabled,
      modelKeysId,
      fileServerId,
      fileConfig,
      modelConfig,
      priceConfig: conversionModelPriceToSave(priceConfig),
      remarks,
    });
    return data;
  } else if (req.method === 'POST') {
    const {
      modelVersion,
      name,
      enabled,
      modelKeysId,
      fileServerId,
      priceConfig,
      modelConfig,
      fileConfig,
      remarks,
    } = req.body;

    const template = ModelDefaultTemplates[modelVersion as ModelVersions];

    if (!template) {
      throw new BadRequest('Model is not Found');
    }
    const data = await ChatModelManager.createModel({
      type: template.type,
      modelVersion,
      name,
      enabled,
      modelKeysId,
      fileServerId,
      fileConfig,
      modelConfig,
      priceConfig: conversionModelPriceToSave(priceConfig),
      remarks,
    });
    return data;
  } else if (req.method === 'DELETE') {
    const { id } = req.query as { id: string };
    const model = await ChatModelManager.findModelById(id);
    if (model) {
      await ChatModelManager.deleteModelById(id);
    }
    throw new BadRequest('Model is not Found!');
  }
};

export default apiHandler(handler);
