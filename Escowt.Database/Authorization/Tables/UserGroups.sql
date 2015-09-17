CREATE TABLE [Authorization].[UserGroups] (
    [Guid] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Authorization.UserGroups] PRIMARY KEY CLUSTERED ([Guid] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_LanguageAliasUnique]
    ON [Authorization].[UserGroups]([Name] ASC);

