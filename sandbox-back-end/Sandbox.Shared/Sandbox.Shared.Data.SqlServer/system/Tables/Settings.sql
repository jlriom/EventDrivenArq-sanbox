CREATE TABLE [system].[Settings] (
    [Key]    NVARCHAR (200)  NOT NULL,
    [Value]  NVARCHAR (1000) NOT NULL,
    [Module] NVARCHAR (200)  NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([Key] ASC)
);

