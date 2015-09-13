
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2015 22:42:48
-- Generated from EDMX file: E:\Work\JGSolution\Escowt.Core.V2\Escowt.Core.V2\Escowt.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Escowt.Core];
GO
IF SCHEMA_ID(N'Authorization') IS NULL EXECUTE(N'CREATE SCHEMA [Authorization]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserGroupUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserGroupUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroupSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserGroupSet'
CREATE TABLE [Authorization].[UserGroupSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Caption] nvarchar(255)  NOT NULL,
    [Description] nvarchar(1024)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [Authorization].[UserSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(20)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [UserGroupId] uniqueidentifier  NOT NULL,
    [RegistrationDate] datetime  NULL,
    [UserGroup_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserGroupSet'
ALTER TABLE [Authorization].[UserGroupSet]
ADD CONSTRAINT [PK_UserGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [Authorization].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserGroup_Id] in table 'UserSet'
ALTER TABLE [Authorization].[UserSet]
ADD CONSTRAINT [FK_UserGroupUser]
    FOREIGN KEY ([UserGroup_Id])
    REFERENCES [Authorization].[UserGroupSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupUser'
CREATE INDEX [IX_FK_UserGroupUser]
ON [Authorization].[UserSet]
    ([UserGroup_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------