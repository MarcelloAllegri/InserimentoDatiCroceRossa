CREATE TABLE [dbo].[CarTar] (
    [CarTarOwnId] INT      IDENTITY (1, 1) NOT NULL,
    [CarId]       INT      NOT NULL,
    [TarId]       INT      NOT NULL,
    [CarTarDch]   DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([CarTarOwnId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Car] ([CarOwnId]),
    FOREIGN KEY ([TarId]) REFERENCES [dbo].[Tar] ([TarOwnId])
);

