CREATE TABLE [dbo].[Vol] (
    [VolOwnId] INT          IDENTITY (1, 1) NOT NULL,
    [VolNam]   VARCHAR (50) NOT NULL,
    [VolSur]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([VolOwnId] ASC)
);

