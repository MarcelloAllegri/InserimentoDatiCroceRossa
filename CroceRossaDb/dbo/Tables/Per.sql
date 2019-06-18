CREATE TABLE [dbo].[Per] (
    [PerOwnId] INT          IDENTITY (1, 1) NOT NULL,
    [PerFCd]   VARCHAR (15) NOT NULL,
    [PerNam]   VARCHAR (50) NOT NULL,
    [PerSur]   VARCHAR (50) NOT NULL,
    [PerSex]   BIT          NULL,
    [PerBir]   DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([PerOwnId] ASC)
);

