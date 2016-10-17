CREATE TABLE [dbo].[Session]
(
	[id] INT identity(1,1) NOT NULL ,
	[start] datetime not null,
	[price] dec not null,
	[soldOut] bit not null, 
    [title] NVARCHAR(50) NULL, 
	[color] nvarchar(50) Null,
    CONSTRAINT [FK_Session_ToGame] FOREIGN KEY ([title]) REFERENCES Game(Title), 
    CONSTRAINT [PK_Session] PRIMARY KEY ([id])
)