CREATE TABLE [Authorization].[UserSet] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Login]            NVARCHAR (20)    NOT NULL,
    [Password]         NVARCHAR (20)    NOT NULL,
    [Name]             NVARCHAR (50)    NOT NULL,
    [UserGroupId]      UNIQUEIDENTIFIER NOT NULL,
    [RegistrationDate] DATETIME         NULL,
    [UserGroup_Id]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UserSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserGroupUser] FOREIGN KEY ([UserGroup_Id]) REFERENCES [Authorization].[UserGroupSet] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserGroupUser]
    ON [Authorization].[UserSet]([UserGroup_Id] ASC);

