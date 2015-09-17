CREATE TABLE [Authorization].[UserGroupCaptions] (
    [UserGroupGuid] UNIQUEIDENTIFIER NOT NULL,
    [LanguageGuid]  UNIQUEIDENTIFIER NOT NULL,
    [Title]         NVARCHAR (255)   NOT NULL,
    [Description]   NVARCHAR (1024)  NULL,
    CONSTRAINT [PK_Authorization.UserGroupCaptions] PRIMARY KEY CLUSTERED ([UserGroupGuid] ASC, [LanguageGuid] ASC),
    CONSTRAINT [FK_Authorization.UserGroupCaptions_Authorization.UserGroups_UserGroupGuid] FOREIGN KEY ([UserGroupGuid]) REFERENCES [Authorization].[UserGroups] ([Guid]) ON DELETE CASCADE,
    CONSTRAINT [FK_Authorization.UserGroupCaptions_Globalization.Languages_LanguageGuid] FOREIGN KEY ([LanguageGuid]) REFERENCES [Globalization].[Languages] ([Guid]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_LanguageGuid]
    ON [Authorization].[UserGroupCaptions]([LanguageGuid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserGroupGuid]
    ON [Authorization].[UserGroupCaptions]([UserGroupGuid] ASC);

