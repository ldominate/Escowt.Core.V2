CREATE TABLE [Authorization].[UserGroupSet] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
    [Caption]     NVARCHAR (255)   NOT NULL,
    [Description] NVARCHAR (1024)  NOT NULL,
    [IsDeleted]   BIT              NOT NULL,
    CONSTRAINT [PK_UserGroupSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

