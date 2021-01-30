CREATE TABLE [doc].[Document] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Name]             VARCHAR (256)    NOT NULL,
    [DocumentStatusId] INT              NOT NULL,
    [DocumentName]     NVARCHAR (255)   NOT NULL,
    [CreatedOn]        DATETIME         CONSTRAINT [DF__Document__Create] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        VARCHAR (450)    NOT NULL,
    [UpdatedOn]        DATETIME         CONSTRAINT [DF__Document__Update] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        VARCHAR (450)    NOT NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Document_DocumentStatusId] FOREIGN KEY ([DocumentStatusId]) REFERENCES [doc].[DocumentStatus] ([Id]),
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Document_Name]
    ON [doc].[Document]([Name] ASC);

