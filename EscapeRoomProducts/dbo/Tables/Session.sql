CREATE TABLE [dbo].[Session]
(
	[Id] INT identity(1,1) NOT NULL ,
	[Start] datetime not null,
	[Price] dec not null,
	[SoldOut] bit not null, 
    [Title] NVARCHAR(50) NULL, 
	[Color] nvarchar(50) Null,
    CONSTRAINT [FK_Session_ToGame] FOREIGN KEY (Title) REFERENCES Game(Title), 
    CONSTRAINT [PK_Session] PRIMARY KEY ([Id])
)