﻿CREATE TABLE [blob].[Document] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Content] VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_BlobDocument] PRIMARY KEY CLUSTERED ([Id] ASC)
);

