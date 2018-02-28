
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2017 22:40:29
-- Generated from EDMX file: C:\Users\xiazhaowei\Documents\GitHub\Sanatorium\Sanatorium\Models\hrEntitys.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sanatorium];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ManagerLoginLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginLogs] DROP CONSTRAINT [FK_ManagerLoginLog];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[LoginLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginLogs];
GO
IF OBJECT_ID(N'[dbo].[RedHeadFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RedHeadFiles];
GO
IF OBJECT_ID(N'[dbo].[Sanatoriums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sanatoriums];
GO
IF OBJECT_ID(N'[dbo].[Regions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regions];
GO
IF OBJECT_ID(N'[dbo].[Streets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Streets];
GO
IF OBJECT_ID(N'[dbo].[Communitys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Communitys];
GO
IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Password] nvarchar(100)  NOT NULL,
    [Role] nvarchar(100)  NOT NULL,
    [Status] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'LoginLogs'
CREATE TABLE [dbo].[LoginLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoginTime] datetime  NOT NULL,
    [Ip] nvarchar(100)  NOT NULL,
    [Client] nvarchar(100)  NOT NULL,
    [ManagerId] int  NOT NULL
);
GO

-- Creating table 'RedHeadFiles'
CREATE TABLE [dbo].[RedHeadFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(100)  NOT NULL,
    [PubTime] datetime  NOT NULL,
    [ZhiXingTime] datetime  NOT NULL,
    [Org] nvarchar(200)  NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [FilePath] nvarchar(300)  NULL,
    [CreateTime] datetime  NOT NULL
);
GO

-- Creating table 'Sanatoriums'
CREATE TABLE [dbo].[Sanatoriums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [Address] nvarchar(400)  NULL,
    [Pics] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [ShiShiOrg] nvarchar(max)  NULL,
    [ShiGongOrg] nvarchar(400)  NULL,
    [PredictFinishTime] datetime  NULL,
    [StructureArea] real  NOT NULL,
    [FinishArea] real  NOT NULL,
    [DoingArea] real  NOT NULL,
    [ToDoArea] real  NOT NULL,
    [CompletionYear] nvarchar(max)  NULL,
    [BuildingsCount] int  NOT NULL,
    [StagingCount] int  NOT NULL,
    [ShiGongScope] nvarchar(max)  NULL,
    [ShiGongContent] nvarchar(max)  NULL,
    [StartTime] datetime  NULL,
    [FinishTime] datetime  NULL,
    [BuildOrg] nvarchar(400)  NULL,
    [BuildOrgPrincipal] nvarchar(100)  NULL,
    [BuildOrgPhone] nvarchar(100)  NULL,
    [BuildOrgWeb] nvarchar(200)  NULL,
    [DesignOrg] nvarchar(400)  NULL,
    [DesignOrgPrincipal] nvarchar(100)  NULL,
    [DesignOrgPhone] nvarchar(100)  NULL,
    [DesignOrgWeb] nvarchar(200)  NULL,
    [SupervisionOrg] nvarchar(400)  NULL,
    [SupervisionOrgPrincipal] nvarchar(max)  NULL,
    [SupervisionOrgPhone] nvarchar(100)  NULL,
    [SupervisionOrgWeb] nvarchar(200)  NULL,
    [Remark] nvarchar(max)  NULL,
    [GongZiPhone] nvarchar(100)  NULL,
    [JuMinPhone] nvarchar(100)  NULL,
    [AnQuanZhiDu] nvarchar(max)  NULL,
    [ShiGongZhidu] nvarchar(max)  NULL,
    [XiaoFangZhidu] nvarchar(max)  NULL,
    [ZhiAnPrincipal] nvarchar(100)  NULL,
    [ZhiAnPrincipalPhone] nvarchar(100)  NULL,
    [ZhiAnMembers] nvarchar(max)  NULL,
    [XiaoFangPrincipal] nvarchar(100)  NULL,
    [XiaoFangPrincipalPhone] nvarchar(100)  NULL,
    [XiaoFangMembers] nvarchar(max)  NULL,
    [YingJiPrincipal] nvarchar(100)  NULL,
    [YingJiPrincipalPhone] nvarchar(100)  NULL,
    [YingJiMembers] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [Region] nvarchar(200)  NULL,
    [Street] nvarchar(200)  NULL,
    [Community] nvarchar(200)  NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'Streets'
CREATE TABLE [dbo].[Streets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegionName] nvarchar(200)  NOT NULL,
    [Name] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'Communitys'
CREATE TABLE [dbo].[Communitys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StreetName] nvarchar(200)  NULL,
    [Name] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(400)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [PK_LoginLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RedHeadFiles'
ALTER TABLE [dbo].[RedHeadFiles]
ADD CONSTRAINT [PK_RedHeadFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sanatoriums'
ALTER TABLE [dbo].[Sanatoriums]
ADD CONSTRAINT [PK_Sanatoriums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Streets'
ALTER TABLE [dbo].[Streets]
ADD CONSTRAINT [PK_Streets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Communitys'
ALTER TABLE [dbo].[Communitys]
ADD CONSTRAINT [PK_Communitys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ManagerId] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [FK_ManagerLoginLog]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerLoginLog'
CREATE INDEX [IX_FK_ManagerLoginLog]
ON [dbo].[LoginLogs]
    ([ManagerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------