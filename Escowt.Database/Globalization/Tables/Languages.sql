CREATE TABLE [Globalization].[Languages] (
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    [Alias]       NVARCHAR (10)    NOT NULL,
    [TitleRu]     NVARCHAR (50)    NULL,
    [TitleEn]     NVARCHAR (50)    NULL,
    [Description] NVARCHAR (1024)  NULL,
    [IsDeleted]   BIT              NOT NULL,
    CONSTRAINT [PK_Globalization.Languages] PRIMARY KEY CLUSTERED ([Guid] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_LanguageAliasUnique]
    ON [Globalization].[Languages]([Alias] ASC);

