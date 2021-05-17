
if exists ( select 1 from sysobjects where id = OBJECT_ID('T_Vote') and type = 'U')
drop table T_Vote
Go


if exists ( select 1 from sysobjects where id = OBJECT_ID('T_CatPicture') and type = 'U')
drop table T_Cat
Go


CREATE TABLE [T_CatPicture] (
    [Id] INT NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY ([Id]),
);
GO

CREATE TABLE [T_Vote] (
    [Id] int NOT NULL IDENTITY,
    [CatId] int NOT NULL,
    [CreationDate] datetime NULL
    CONSTRAINT [PK_Vote] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vote_WinCat_CatId] FOREIGN KEY ([CatId]) REFERENCES [T_CatPicture] ([Id]),
);
GO