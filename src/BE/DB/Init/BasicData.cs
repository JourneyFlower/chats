using Chats.BE.DB;

namespace Chats.BE.DB.Init;

internal static class BasicData
{
    public static void InsertAll(ChatsDB db)
    {
        InsertFileContentTypes(db);
        InsertFileServiceTypes(db);
        InsertChatRoles(db);
        InsertCurrencyRates(db);
        InsertFinishReasons(db);
        InsertMessageContentTypes(db);
        InsertTokenizers(db);
        InsertTransactionTypes(db);
        InsertModelReferences(db);
        InsertModelProviders(db);
    }

    private static void InsertFileContentTypes(ChatsDB db)
    {
        // Generated from data, hash: 84c703836219bfb53bb7b0b273640901c61910927175f5a8b7085f1d72b6a32b
        db.FileContentTypes.AddRange(
        [
            new(){ Id=1, ContentType="image/jpeg",    },
            new(){ Id=2, ContentType="image/png",     },
            new(){ Id=3, ContentType="image/gif",     },
            new(){ Id=4, ContentType="image/bmp",     },
            new(){ Id=5, ContentType="image/svg+xml", },
            new(){ Id=6, ContentType="image/webp",    },
            new(){ Id=7, ContentType="image/tiff",    },
            new(){ Id=8, ContentType="image/heif",    },
            new(){ Id=9, ContentType="image/heic",    }
        ]);
    }

    private static void InsertFileServiceTypes(ChatsDB db)
    {
        // Generated from data, hash: 9187cf7c6622d5341c31b350377cb545d1fef17d3ecd43401bad0be964e8b043
        db.FileServiceTypes.AddRange(
        [
            new(){ Id=0, Name="Local",              InitialConfig="./AppData/Files",                                                                                                                                             },
            new(){ Id=1, Name="Minio",              InitialConfig="""{"endpoint": "https://minio.example.com", "accessKey": "your-access-key", "secretKey": "your-secret-key", "bucket": "your-bucket", "region": null}""",      },
            new(){ Id=2, Name="AWS S3",             InitialConfig="""{"region": "ap-southeast-1", "accessKeyId": "your-access-key-id", "secretAccessKey": "your-secret-access-key", "bucket": "your-bucket"}""",                 },
            new(){ Id=3, Name="Aliyun OSS",         InitialConfig="""{"endpoint": "oss-cn-hangzhou.aliyuncs.com", "accessKeyId": "your-access-key-id", "accessKeySecret": "your-access-key-secret", "bucket": "your-bucket"}""", },
            new(){ Id=4, Name="Azure Blob Storage", InitialConfig="DefaultEndpointsProtocol=https;AccountName=your-account-name;AccountKey=your-account-key;EndpointSuffix=core.windows.net",                                    }
        ]);
    }

    private static void InsertChatRoles(ChatsDB db)
    {
        // Generated from data, hash: e2b927c371db77befad6f04b1844b97f12985d9ffdec513fdf08aee842f75cf1
        db.ChatRoles.AddRange(
        [
            new(){ Id=1, Name="system",    },
            new(){ Id=2, Name="user",      },
            new(){ Id=3, Name="assistant", }
        ]);
    }

    private static void InsertCurrencyRates(ChatsDB db)
    {
        // Generated from data, hash: bc4028c01aefd32ef1bf1533fc9e181ab4f0f673b85a9a282cab92a90cf4116c
        db.CurrencyRates.AddRange(
        [
            new(){ Code="RMB", ExchangeRate=1.000000M, },
            new(){ Code="USD", ExchangeRate=7.120300M, }
        ]);
    }

    private static void InsertFinishReasons(ChatsDB db)
    {
        // Generated from data, hash: a39da809c9c6d37bb1d7933fd873bd0bd11185aa4cb2cf324826ae98846758e2
        db.FinishReasons.AddRange(
        [
            new(){ Id=0,   Name="Success",             },
            new(){ Id=1,   Name="Stop",                },
            new(){ Id=2,   Name="Length",              },
            new(){ Id=3,   Name="ToolCalls",           },
            new(){ Id=4,   Name="ContentFilter",       },
            new(){ Id=5,   Name="FunctionCall",        },
            new(){ Id=100, Name="UnknownError",        },
            new(){ Id=101, Name="InsufficientBalance", },
            new(){ Id=102, Name="UpstreamError",       },
            new(){ Id=103, Name="InvalidModel",        },
            new(){ Id=104, Name="SubscriptionExpired", },
            new(){ Id=105, Name="BadParameter",        },
            new(){ Id=106, Name="Cancelled",           }
        ]);
    }

    private static void InsertMessageContentTypes(ChatsDB db)
    {
        // Generated from data, hash: f5f9d05c9352665080659fabd30a4dcdf3da3133d4fbd5beb5fff6c4708c6178
        db.MessageContentTypes.AddRange(
        [
            new(){ Id=0, ContentType="error",    },
            new(){ Id=1, ContentType="text",     },
            new(){ Id=2, ContentType="imageUrl", },
            new(){ Id=3, ContentType="fileId",   }
        ]);
    }

    private static void InsertTokenizers(ChatsDB db)
    {
        // Generated from data, hash: 3fd4898bb31e7a12b5d2b9b158efa6f20ca250507be2fc1dddefcd6846ab4ac9
        db.Tokenizers.AddRange(
        [
            new(){ Id=1, Name="cl100k_base", },
            new(){ Id=2, Name="o200k_base",  }
        ]);
    }

    private static void InsertTransactionTypes(ChatsDB db)
    {
        // Generated from data, hash: 03debb1a3f79c1b2fd21af5a0c0ede05a461481794cbe7e0a6a65bd47090e970
        db.TransactionTypes.AddRange(
        [
            new(){ Id=1, Name="Charge",  },
            new(){ Id=2, Name="Cost",    },
            new(){ Id=3, Name="Initial", },
            new(){ Id=4, Name="ApiCost", }
        ]);
    }

    private static void InsertModelReferences(ChatsDB db)
    {
        // Generated from data, hash: 72d3a15e6337fecb401318e7441dd32991aa8e9ad06f972b8cab646526847f00
        db.ModelReferences.AddRange(
        [
            new(){ Id=0,   ProviderId=0, Name="Test",                        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=2048,     MaxResponseTokens=2048,   TokenizerId=1,    InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=100, ProviderId=1, Name="gpt-35-turbo-0301",           ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=101, ProviderId=1, Name="gpt-35-turbo-16k-0613",       ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16385,    MaxResponseTokens=16385,  TokenizerId=1,    InputTokenPrice1M=3.00000M,   OutputTokenPrice1M=4.00000M,   CurrencyCode="USD", },
            new(){ Id=102, ProviderId=1, Name="gpt-35-turbo-0613",           ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=103, ProviderId=1, Name="gpt-35-turbo-1106",           ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=104, ProviderId=1, Name="gpt-35-turbo-instruct",       ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=105, ProviderId=1, Name="gpt-35-turbo-0125",           ShortName="gpt-35-turbo",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=0.50000M,   OutputTokenPrice1M=1.50000M,   CurrencyCode="USD", },
            new(){ Id=106, ProviderId=1, Name="gpt-4-vision-preview",        ShortName="gpt-4-vision",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=107, ProviderId=1, Name="gpt-4-1106-preview",          ShortName="gpt-4-turbo",   IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=108, ProviderId=1, Name="gpt-4-0125-preview",          ShortName="gpt-4-turbo",   IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=109, ProviderId=1, Name="gpt-4-32k",                   ShortName="gpt-4-32k",     IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=32768,  TokenizerId=1,    InputTokenPrice1M=60.00000M,  OutputTokenPrice1M=120.00000M, CurrencyCode="USD", },
            new(){ Id=110, ProviderId=1, Name="gpt-4",                       ShortName="gpt-4",         IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=1,    InputTokenPrice1M=30.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="USD", },
            new(){ Id=111, ProviderId=1, Name="gpt-4-turbo-2024-04-09",      ShortName="gpt-4-turbo",   IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=112, ProviderId=1, Name="o1-preview-2024-09-12",       ShortName="o1-preview",    IsLegacy=false, MinTemperature=1.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=false, AllowStreaming=false, ContextWindow=128000,   MaxResponseTokens=32768,  TokenizerId=2,    InputTokenPrice1M=15.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="USD", },
            new(){ Id=113, ProviderId=1, Name="o1-mini-2024-09-12",          ShortName="o1-mini",       IsLegacy=false, MinTemperature=1.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=false, AllowStreaming=false, ContextWindow=128000,   MaxResponseTokens=65536,  TokenizerId=2,    InputTokenPrice1M=3.00000M,   OutputTokenPrice1M=12.00000M,  CurrencyCode="USD", },
            new(){ Id=114, ProviderId=1, Name="gpt-4o-mini-2024-07-18",      ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=0.15000M,   OutputTokenPrice1M=0.60000M,   CurrencyCode="USD", },
            new(){ Id=115, ProviderId=1, Name="gpt-4o-2024-05-13",           ShortName="gpt-4o",        IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=2,    InputTokenPrice1M=5.00000M,   OutputTokenPrice1M=15.00000M,  CurrencyCode="USD", },
            new(){ Id=116, ProviderId=1, Name="gpt-4o-2024-08-06",           ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=2.50000M,   OutputTokenPrice1M=10.00000M,  CurrencyCode="USD", },
            new(){ Id=117, ProviderId=1, Name="gpt-4o-2024-11-20",           ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=2.50000M,   OutputTokenPrice1M=10.00000M,  CurrencyCode="USD", },
            new(){ Id=200, ProviderId=2, Name="hunyuan-turbo",               ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=15.00000M,  OutputTokenPrice1M=50.00000M,  CurrencyCode="RMB", },
            new(){ Id=201, ProviderId=2, Name="hunyuan-pro",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=30.00000M,  OutputTokenPrice1M=100.00000M, CurrencyCode="RMB", },
            new(){ Id=202, ProviderId=2, Name="hunyuan-standard-256K",       ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=262144,   MaxResponseTokens=6144,   TokenizerId=null, InputTokenPrice1M=15.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="RMB", },
            new(){ Id=203, ProviderId=2, Name="hunyuan-standard",            ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=4.50000M,   OutputTokenPrice1M=5.00000M,   CurrencyCode="RMB", },
            new(){ Id=204, ProviderId=2, Name="hunyuan-lite",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=262144,   MaxResponseTokens=6144,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=205, ProviderId=2, Name="hunyuan-role",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=206, ProviderId=2, Name="hunyuan-functioncall ",       ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=207, ProviderId=2, Name="hunyuan-code",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=208, ProviderId=2, Name="hunyuan-vision",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=18.00000M,  OutputTokenPrice1M=18.00000M,  CurrencyCode="RMB", },
            new(){ Id=300, ProviderId=3, Name="yi-lightning",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=0.99000M,   OutputTokenPrice1M=0.99000M,   CurrencyCode="RMB", },
            new(){ Id=301, ProviderId=3, Name="yi-large",                    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=20.00000M,  OutputTokenPrice1M=20.00000M,  CurrencyCode="RMB", },
            new(){ Id=302, ProviderId=3, Name="yi-medium",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=2.50000M,   OutputTokenPrice1M=2.50000M,   CurrencyCode="RMB", },
            new(){ Id=303, ProviderId=3, Name="yi-vision",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=6.00000M,   OutputTokenPrice1M=6.00000M,   CurrencyCode="RMB", },
            new(){ Id=304, ProviderId=3, Name="yi-medium-200k",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=204800,   MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=12.00000M,  OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=305, ProviderId=3, Name="yi-spark",                    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=1.00000M,   CurrencyCode="RMB", },
            new(){ Id=306, ProviderId=3, Name="yi-large-rag",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=25.00000M,  OutputTokenPrice1M=25.00000M,  CurrencyCode="RMB", },
            new(){ Id=307, ProviderId=3, Name="yi-large-fc",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=20.00000M,  OutputTokenPrice1M=20.00000M,  CurrencyCode="RMB", },
            new(){ Id=308, ProviderId=3, Name="yi-large-turbo",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16384,    MaxResponseTokens=16384,  TokenizerId=null, InputTokenPrice1M=12.00000M,  OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=400, ProviderId=4, Name="moonshot-v1-8k",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=12.00000M,  OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=401, ProviderId=4, Name="moonshot-v1-32k",             ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=32768,  TokenizerId=null, InputTokenPrice1M=24.00000M,  OutputTokenPrice1M=24.00000M,  CurrencyCode="RMB", },
            new(){ Id=402, ProviderId=4, Name="moonshot-v1-128k",            ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=131072, TokenizerId=null, InputTokenPrice1M=60.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="RMB", },
            new(){ Id=500, ProviderId=5, Name="gpt-3.5-turbo-0301",          ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=501, ProviderId=5, Name="gpt-3.5-turbo-16k-0613",      ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=16385,    MaxResponseTokens=16385,  TokenizerId=1,    InputTokenPrice1M=3.00000M,   OutputTokenPrice1M=4.00000M,   CurrencyCode="USD", },
            new(){ Id=502, ProviderId=5, Name="gpt-3.5-turbo-0613",          ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=503, ProviderId=5, Name="gpt-3.5-turbo-1106",          ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=504, ProviderId=5, Name="gpt-3.5-turbo-instruct",      ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=1.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="USD", },
            new(){ Id=505, ProviderId=5, Name="gpt-3.5-turbo-0125",          ShortName="gpt-3.5-turbo", IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=0.50000M,   OutputTokenPrice1M=1.50000M,   CurrencyCode="USD", },
            new(){ Id=506, ProviderId=5, Name="gpt-4-vision-preview",        ShortName="gpt-4-vision",  IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=507, ProviderId=5, Name="gpt-4-1106-preview",          ShortName="gpt-4-turbo",   IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=508, ProviderId=5, Name="gpt-4-0125-preview",          ShortName="gpt-4-turbo",   IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=509, ProviderId=5, Name="gpt-4-32k",                   ShortName="gpt-4-32k",     IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=32768,  TokenizerId=1,    InputTokenPrice1M=60.00000M,  OutputTokenPrice1M=120.00000M, CurrencyCode="USD", },
            new(){ Id=510, ProviderId=5, Name="gpt-4",                       ShortName="gpt-4",         IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=1,    InputTokenPrice1M=30.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="USD", },
            new(){ Id=511, ProviderId=5, Name="gpt-4-turbo-2024-04-09",      ShortName="gpt-4-turbo",   IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=1,    InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="USD", },
            new(){ Id=512, ProviderId=5, Name="o1-preview-2024-09-12",       ShortName="o1-preview",    IsLegacy=false, MinTemperature=1.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=false, AllowStreaming=false, ContextWindow=128000,   MaxResponseTokens=32768,  TokenizerId=2,    InputTokenPrice1M=15.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="USD", },
            new(){ Id=513, ProviderId=5, Name="o1-mini-2024-09-12",          ShortName="o1-mini",       IsLegacy=false, MinTemperature=1.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=false, AllowStreaming=false, ContextWindow=128000,   MaxResponseTokens=65536,  TokenizerId=2,    InputTokenPrice1M=3.00000M,   OutputTokenPrice1M=12.00000M,  CurrencyCode="USD", },
            new(){ Id=514, ProviderId=5, Name="gpt-4o-mini-2024-07-18",      ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=0.15000M,   OutputTokenPrice1M=0.60000M,   CurrencyCode="USD", },
            new(){ Id=515, ProviderId=5, Name="gpt-4o-2024-05-13",           ShortName="gpt-4o",        IsLegacy=true,  MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=4096,   TokenizerId=2,    InputTokenPrice1M=5.00000M,   OutputTokenPrice1M=15.00000M,  CurrencyCode="USD", },
            new(){ Id=516, ProviderId=5, Name="gpt-4o-2024-08-06",           ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=2.50000M,   OutputTokenPrice1M=10.00000M,  CurrencyCode="USD", },
            new(){ Id=517, ProviderId=1, Name="gpt-4o-2024-11-20",           ShortName="gpt-4o",        IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=128000,   MaxResponseTokens=16384,  TokenizerId=2,    InputTokenPrice1M=2.50000M,   OutputTokenPrice1M=10.00000M,  CurrencyCode="USD", },
            new(){ Id=600, ProviderId=6, Name="ERNIE-4.0-Turbo-8K",          ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=30.00000M,  OutputTokenPrice1M=90.00000M,  CurrencyCode="RMB", },
            new(){ Id=601, ProviderId=6, Name="ERNIE-4.0-8K",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=20.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="RMB", },
            new(){ Id=602, ProviderId=6, Name="ERNIE-3.5-8K",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=0.80000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=603, ProviderId=6, Name="ERNIE-3.5-128K",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.80000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=604, ProviderId=6, Name="ERNIE-Speed-Pro-128K",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.30000M,   OutputTokenPrice1M=0.60000M,   CurrencyCode="RMB", },
            new(){ Id=605, ProviderId=6, Name="ERNIE-Novel-8K",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=40.00000M,  OutputTokenPrice1M=120.00000M, CurrencyCode="RMB", },
            new(){ Id=606, ProviderId=6, Name="ERNIE-Speed-128K",            ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=607, ProviderId=6, Name="ERNIE-Speed-8K",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=1024,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=608, ProviderId=6, Name="ERNIE-Lite-128K",             ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=609, ProviderId=6, Name="ERNIE-Lite-8K",               ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=610, ProviderId=6, Name="ERNIE-Tiny-128K",             ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=611, ProviderId=6, Name="ERNIE-Tiny-8K",               ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=612, ProviderId=6, Name="ERNIE-Character-Fiction-8K",  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=613, ProviderId=6, Name="ERNIE-Functions-8K",          ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=2048,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=614, ProviderId=6, Name="ERNIE-Lite-Pro-128K",         ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.20000M,   OutputTokenPrice1M=0.40000M,   CurrencyCode="RMB", },
            new(){ Id=700, ProviderId=7, Name="qwen-max",                    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=20.00000M,  OutputTokenPrice1M=60.00000M,  CurrencyCode="RMB", },
            new(){ Id=701, ProviderId=7, Name="qwen-plus",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.80000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=702, ProviderId=7, Name="qwen-turbo",                  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.30000M,   OutputTokenPrice1M=0.60000M,   CurrencyCode="RMB", },
            new(){ Id=703, ProviderId=7, Name="qwen-long",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=10000000, MaxResponseTokens=6000,   TokenizerId=null, InputTokenPrice1M=0.50000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=704, ProviderId=7, Name="qwen-vl-max",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32000,    MaxResponseTokens=2000,   TokenizerId=null, InputTokenPrice1M=20.00000M,  OutputTokenPrice1M=20.00000M,  CurrencyCode="RMB", },
            new(){ Id=705, ProviderId=7, Name="qwen-vl-plus",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8000,     MaxResponseTokens=2000,   TokenizerId=null, InputTokenPrice1M=8.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=706, ProviderId=7, Name="qwen-math-plus",              ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=3072,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=707, ProviderId=7, Name="qwen-math-turbo",             ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=3072,   TokenizerId=null, InputTokenPrice1M=2.00000M,   OutputTokenPrice1M=6.00000M,   CurrencyCode="RMB", },
            new(){ Id=708, ProviderId=7, Name="qwen-coder-turbo",            ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=2.00000M,   OutputTokenPrice1M=6.00000M,   CurrencyCode="RMB", },
            new(){ Id=709, ProviderId=7, Name="qwen2.5-72b-instruct",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=710, ProviderId=7, Name="qwen2.5-32b-instruct",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=3.50000M,   OutputTokenPrice1M=7.00000M,   CurrencyCode="RMB", },
            new(){ Id=711, ProviderId=7, Name="qwen2.5-14b-instruct",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=2.00000M,   OutputTokenPrice1M=6.00000M,   CurrencyCode="RMB", },
            new(){ Id=712, ProviderId=7, Name="qwen2.5-7b-instruct",         ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=713, ProviderId=7, Name="qwen2.5-3b-instruct",         ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=714, ProviderId=7, Name="qwen2.5-1.5b-instruct",       ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=715, ProviderId=7, Name="qwen2.5-0.5b-instruct",       ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=716, ProviderId=7, Name="qwen2-vl-7b-instruct",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32000,    MaxResponseTokens=2000,   TokenizerId=null, InputTokenPrice1M=8.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=717, ProviderId=7, Name="qwen2-vl-2b-instruct",        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32000,    MaxResponseTokens=2000,   TokenizerId=null, InputTokenPrice1M=8.00000M,   OutputTokenPrice1M=8.00000M,   CurrencyCode="RMB", },
            new(){ Id=718, ProviderId=7, Name="qwen2.5-math-72b-instruct",   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=3072,   TokenizerId=null, InputTokenPrice1M=4.00000M,   OutputTokenPrice1M=12.00000M,  CurrencyCode="RMB", },
            new(){ Id=719, ProviderId=7, Name="qwen2.5-math-7b-instruct",    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=3072,   TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=720, ProviderId=7, Name="qwen2.5-math-1.5b-instruct",  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=3072,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=721, ProviderId=7, Name="qwen2.5-coder-7b-instruct",   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=2.00000M,   CurrencyCode="RMB", },
            new(){ Id=722, ProviderId=7, Name="qwen2.5-coder-1.5b-instruct", ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.99M, AllowSearch=false, AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=800, ProviderId=8, Name="lite",                        ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=4096,     MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=801, ProviderId=8, Name="generalv3",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=7.00000M,   OutputTokenPrice1M=7.00000M,   CurrencyCode="RMB", },
            new(){ Id=802, ProviderId=8, Name="pro-128k",                    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=13.00000M,  OutputTokenPrice1M=13.00000M,  CurrencyCode="RMB", },
            new(){ Id=803, ProviderId=8, Name="generalv3.5",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=30.00000M,  OutputTokenPrice1M=30.00000M,  CurrencyCode="RMB", },
            new(){ Id=804, ProviderId=8, Name="max-32k",                     ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=32768,    MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=32.00000M,  OutputTokenPrice1M=32.00000M,  CurrencyCode="RMB", },
            new(){ Id=805, ProviderId=8, Name="4.0Ultra",                    ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=2.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=8192,   TokenizerId=null, InputTokenPrice1M=70.00000M,  OutputTokenPrice1M=70.00000M,  CurrencyCode="RMB", },
            new(){ Id=900, ProviderId=9, Name="glm-4-plus",                  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=50.00000M,  OutputTokenPrice1M=50.00000M,  CurrencyCode="RMB", },
            new(){ Id=901, ProviderId=9, Name="glm-4-0520",                  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=100.00000M, OutputTokenPrice1M=100.00000M, CurrencyCode="RMB", },
            new(){ Id=902, ProviderId=9, Name="glm-4-air",                   ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=1.00000M,   CurrencyCode="RMB", },
            new(){ Id=903, ProviderId=9, Name="glm-4-airx",                  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=10.00000M,  CurrencyCode="RMB", },
            new(){ Id=904, ProviderId=9, Name="glm-4-long",                  ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=1048576,  MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=1.00000M,   OutputTokenPrice1M=1.00000M,   CurrencyCode="RMB", },
            new(){ Id=905, ProviderId=9, Name="glm-4-flashx",                ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.10000M,   OutputTokenPrice1M=0.10000M,   CurrencyCode="RMB", },
            new(){ Id=906, ProviderId=9, Name="glm-4-flash",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=true,  AllowVision=false, AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=131072,   MaxResponseTokens=4096,   TokenizerId=null, InputTokenPrice1M=0.00000M,   OutputTokenPrice1M=0.00000M,   CurrencyCode="RMB", },
            new(){ Id=907, ProviderId=9, Name="glm-4v-plus",                 ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=8192,     MaxResponseTokens=1024,   TokenizerId=null, InputTokenPrice1M=10.00000M,  OutputTokenPrice1M=10.00000M,  CurrencyCode="RMB", },
            new(){ Id=908, ProviderId=9, Name="glm-4v",                      ShortName=null,            IsLegacy=false, MinTemperature=0.00M, MaxTemperature=1.00M, AllowSearch=false, AllowVision=true,  AllowSystemPrompt=true,  AllowStreaming=true,  ContextWindow=2048,     MaxResponseTokens=1024,   TokenizerId=null, InputTokenPrice1M=50.00000M,  OutputTokenPrice1M=50.00000M,  CurrencyCode="RMB", }
        ]);
    }

    private static void InsertModelProviders(ChatsDB db)
    {
        // Generated from data, hash: ca38a28a3e95fcb5fcd96fa2a35db6a86ee7d356ac7e2a20b8d7d9b52b895abd
        db.ModelProviders.AddRange(
        [
            new(){ Id=0, Name="Test",             InitialHost=null,                                        InitialSecret=null,                                          },
            new(){ Id=1, Name="Azure OpenAI",     InitialHost="https://<resource-name>.openai.azure.com/", InitialSecret="",                                            },
            new(){ Id=2, Name="Tencent Hunyuan",  InitialHost="hunyuan.tencentcloudapi.com",               InitialSecret="""{"secretId":"", "secretKey":""}""",         },
            new(){ Id=3, Name="01.ai",            InitialHost=null,                                        InitialSecret="",                                            },
            new(){ Id=4, Name="Moonshot",         InitialHost=null,                                        InitialSecret="",                                            },
            new(){ Id=5, Name="OpenAI",           InitialHost="https://api.openai.com/v1",                 InitialSecret="",                                            },
            new(){ Id=6, Name="Wenxin Qianfan",   InitialHost=null,                                        InitialSecret="""{"apiKey":"", "secret":""}""",              },
            new(){ Id=7, Name="DashScope",        InitialHost=null,                                        InitialSecret="",                                            },
            new(){ Id=8, Name="Xunfei SparkDesk", InitialHost=null,                                        InitialSecret="""{"appId": "", "apiKey":"", "secret":""}""", },
            new(){ Id=9, Name="Zhipu AI",         InitialHost=null,                                        InitialSecret="",                                            }
        ]);
    }
};