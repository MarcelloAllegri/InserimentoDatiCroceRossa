
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/03/2019 12:08:22
-- Generated from EDMX file: C:\Users\Marcello\Documents\VS2019Pjts\InserimentoDatiCroceRossa\DbModel\CroceRossaDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CroceRossa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__CarTar__CarId__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarTar] DROP CONSTRAINT [FK__CarTar__CarId__60A75C0F];
GO
IF OBJECT_ID(N'[dbo].[FK__CarTar__TarId__619B8048]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarTar] DROP CONSTRAINT [FK__CarTar__TarId__619B8048];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsAutId__6D0D32F4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsAutId__6D0D32F4];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsCarTarId__6C190EBB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsCarTarId__6C190EBB];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsChrTo__6FE99F9F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsChrTo__6FE99F9F];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsPatId__6B24EA82]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsPatId__6B24EA82];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsPerId__693CA210]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsPerId__693CA210];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsSoc1Id__6E01572D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsSoc1Id__6E01572D];
GO
IF OBJECT_ID(N'[dbo].[FK__Ins__InsSoc2Id__6EF57B66]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ins] DROP CONSTRAINT [FK__Ins__InsSoc2Id__6EF57B66];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO
IF OBJECT_ID(N'[dbo].[CarTar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarTar];
GO
IF OBJECT_ID(N'[dbo].[Ent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ent];
GO
IF OBJECT_ID(N'[dbo].[Ind]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ind];
GO
IF OBJECT_ID(N'[dbo].[Ins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ins];
GO
IF OBJECT_ID(N'[dbo].[Loc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loc];
GO
IF OBJECT_ID(N'[dbo].[Pat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pat];
GO
IF OBJECT_ID(N'[dbo].[Per]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Per];
GO
IF OBJECT_ID(N'[dbo].[Tar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tar];
GO
IF OBJECT_ID(N'[dbo].[Usr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usr];
GO
IF OBJECT_ID(N'[dbo].[Vol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vol];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [CarOwnId] int IDENTITY(1,1) NOT NULL,
    [CarNam] varchar(6)  NOT NULL
);
GO

-- Creating table 'CarTar'
CREATE TABLE [dbo].[CarTar] (
    [CarTarOwnId] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NOT NULL,
    [TarId] int  NOT NULL,
    [CarTarEnb] bit  NOT NULL
);
GO

-- Creating table 'Ent'
CREATE TABLE [dbo].[Ent] (
    [EntOwnId] int IDENTITY(1,1) NOT NULL,
    [EntVal] varchar(50)  NOT NULL
);
GO

-- Creating table 'Ind'
CREATE TABLE [dbo].[Ind] (
    [IndOwnId] int IDENTITY(1,1) NOT NULL,
    [IndVal] varchar(100)  NOT NULL
);
GO

-- Creating table 'Ins'
CREATE TABLE [dbo].[Ins] (
    [InsOwnId] int IDENTITY(1,1) NOT NULL,
    [InsSvrDat] datetime  NOT NULL,
    [InsTyp] int  NOT NULL,
    [InsPerId] int  NOT NULL,
    [InsPatId] int  NOT NULL,
    [InsCarTarId] int  NOT NULL,
    [InsTimIn] time  NULL,
    [InsTimOut] time  NULL,
    [InsKmOut] int  NOT NULL,
    [InsKmInt] int  NOT NULL,
    [InsAutId] int  NOT NULL,
    [InsSoc1Id] int  NOT NULL,
    [InsSoc2Id] int  NULL,
    [InsChrTo] int  NOT NULL,
    [InsBilNum] int  NOT NULL,
    [InsCrtNum] int  NOT NULL,
    [InsIndFrom] varchar(100)  NULL,
    [InsPlcFrom] varchar(50)  NULL,
    [InsPlcTo] varchar(50)  NULL,
    [InsIndTo] varchar(100) NULL
);
GO

-- Creating table 'Loc'
CREATE TABLE [dbo].[Loc] (
    [LocOwnId] int IDENTITY(1,1) NOT NULL,
    [LocPlc] varchar(100)  NOT NULL
);
GO

-- Creating table 'Pat'
CREATE TABLE [dbo].[Pat] (
    [PatOwnId] int IDENTITY(1,1) NOT NULL,
    [PatNam] varchar(50)  NOT NULL
);
GO

-- Creating table 'Per'
CREATE TABLE [dbo].[Per] (
    [PerOwnId] int IDENTITY(1,1) NOT NULL,
    [PerFCd] varchar(16)  NULL,
    [PerNam] varchar(50)  NOT NULL,
    [PerSur] varchar(50)  NOT NULL,
    [PerSex] bit  NULL,
    [PerBir] datetime  NOT NULL
);
GO

-- Creating table 'Tar'
CREATE TABLE [dbo].[Tar] (
    [TarOwnId] int IDENTITY(1,1) NOT NULL,
    [TarVal] varchar(9)  NOT NULL
);
GO

-- Creating table 'Vol'
CREATE TABLE [dbo].[Vol] (
    [VolOwnId] int IDENTITY(1,1) NOT NULL,
    [VolNam] varchar(50)  NOT NULL,
    [VolSur] varchar(50)  NOT NULL
);
GO

-- Creating table 'Usr'
CREATE TABLE [dbo].[Usr] (
    [UsrOwnId] int IDENTITY(1,1) NOT NULL,
    [UsrNam] varchar(20)  NOT NULL,
    [UsrPsw] varchar(max)  NOT NULL,
    [UsrTyp] char(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CarOwnId] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([CarOwnId] ASC);
GO

-- Creating primary key on [CarTarOwnId] in table 'CarTar'
ALTER TABLE [dbo].[CarTar]
ADD CONSTRAINT [PK_CarTar]
    PRIMARY KEY CLUSTERED ([CarTarOwnId] ASC);
GO

-- Creating primary key on [EntOwnId] in table 'Ent'
ALTER TABLE [dbo].[Ent]
ADD CONSTRAINT [PK_Ent]
    PRIMARY KEY CLUSTERED ([EntOwnId] ASC);
GO

-- Creating primary key on [IndOwnId] in table 'Ind'
ALTER TABLE [dbo].[Ind]
ADD CONSTRAINT [PK_Ind]
    PRIMARY KEY CLUSTERED ([IndOwnId] ASC);
GO

-- Creating primary key on [InsOwnId] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [PK_Ins]
    PRIMARY KEY CLUSTERED ([InsOwnId] ASC);
GO

-- Creating primary key on [LocOwnId] in table 'Loc'
ALTER TABLE [dbo].[Loc]
ADD CONSTRAINT [PK_Loc]
    PRIMARY KEY CLUSTERED ([LocOwnId] ASC);
GO

-- Creating primary key on [PatOwnId] in table 'Pat'
ALTER TABLE [dbo].[Pat]
ADD CONSTRAINT [PK_Pat]
    PRIMARY KEY CLUSTERED ([PatOwnId] ASC);
GO

-- Creating primary key on [PerOwnId] in table 'Per'
ALTER TABLE [dbo].[Per]
ADD CONSTRAINT [PK_Per]
    PRIMARY KEY CLUSTERED ([PerOwnId] ASC);
GO

-- Creating primary key on [TarOwnId] in table 'Tar'
ALTER TABLE [dbo].[Tar]
ADD CONSTRAINT [PK_Tar]
    PRIMARY KEY CLUSTERED ([TarOwnId] ASC);
GO

-- Creating primary key on [VolOwnId] in table 'Vol'
ALTER TABLE [dbo].[Vol]
ADD CONSTRAINT [PK_Vol]
    PRIMARY KEY CLUSTERED ([VolOwnId] ASC);
GO

-- Creating primary key on [UsrOwnId] in table 'Usr'
ALTER TABLE [dbo].[Usr]
ADD CONSTRAINT [PK_Usr]
    PRIMARY KEY CLUSTERED ([UsrOwnId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarId] in table 'CarTar'
ALTER TABLE [dbo].[CarTar]
ADD CONSTRAINT [FK__CarTar__CarId__60A75C0F]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Car]
        ([CarOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CarTar__CarId__60A75C0F'
CREATE INDEX [IX_FK__CarTar__CarId__60A75C0F]
ON [dbo].[CarTar]
    ([CarId]);
GO

-- Creating foreign key on [TarId] in table 'CarTar'
ALTER TABLE [dbo].[CarTar]
ADD CONSTRAINT [FK__CarTar__TarId__619B8048]
    FOREIGN KEY ([TarId])
    REFERENCES [dbo].[Tar]
        ([TarOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CarTar__TarId__619B8048'
CREATE INDEX [IX_FK__CarTar__TarId__619B8048]
ON [dbo].[CarTar]
    ([TarId]);
GO

-- Creating foreign key on [InsCarTarId] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsCarTarId__6C190EBB]
    FOREIGN KEY ([InsCarTarId])
    REFERENCES [dbo].[CarTar]
        ([CarTarOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsCarTarId__6C190EBB'
CREATE INDEX [IX_FK__Ins__InsCarTarId__6C190EBB]
ON [dbo].[Ins]
    ([InsCarTarId]);
GO

-- Creating foreign key on [InsChrTo] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsChrTo__6FE99F9F]
    FOREIGN KEY ([InsChrTo])
    REFERENCES [dbo].[Ent]
        ([EntOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsChrTo__6FE99F9F'
CREATE INDEX [IX_FK__Ins__InsChrTo__6FE99F9F]
ON [dbo].[Ins]
    ([InsChrTo]);
GO

-- Creating foreign key on [InsAutId] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsAutId__6D0D32F4]
    FOREIGN KEY ([InsAutId])
    REFERENCES [dbo].[Vol]
        ([VolOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsAutId__6D0D32F4'
CREATE INDEX [IX_FK__Ins__InsAutId__6D0D32F4]
ON [dbo].[Ins]
    ([InsAutId]);
GO

-- Creating foreign key on [InsPatId] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsPatId__6B24EA82]
    FOREIGN KEY ([InsPatId])
    REFERENCES [dbo].[Pat]
        ([PatOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsPatId__6B24EA82'
CREATE INDEX [IX_FK__Ins__InsPatId__6B24EA82]
ON [dbo].[Ins]
    ([InsPatId]);
GO

-- Creating foreign key on [InsPerId] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsPerId__693CA210]
    FOREIGN KEY ([InsPerId])
    REFERENCES [dbo].[Per]
        ([PerOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsPerId__693CA210'
CREATE INDEX [IX_FK__Ins__InsPerId__693CA210]
ON [dbo].[Ins]
    ([InsPerId]);
GO

-- Creating foreign key on [InsSoc1Id] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsSoc1Id__6E01572D]
    FOREIGN KEY ([InsSoc1Id])
    REFERENCES [dbo].[Vol]
        ([VolOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsSoc1Id__6E01572D'
CREATE INDEX [IX_FK__Ins__InsSoc1Id__6E01572D]
ON [dbo].[Ins]
    ([InsSoc1Id]);
GO

-- Creating foreign key on [InsSoc2Id] in table 'Ins'
ALTER TABLE [dbo].[Ins]
ADD CONSTRAINT [FK__Ins__InsSoc2Id__6EF57B66]
    FOREIGN KEY ([InsSoc2Id])
    REFERENCES [dbo].[Vol]
        ([VolOwnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ins__InsSoc2Id__6EF57B66'
CREATE INDEX [IX_FK__Ins__InsSoc2Id__6EF57B66]
ON [dbo].[Ins]
    ([InsSoc2Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------