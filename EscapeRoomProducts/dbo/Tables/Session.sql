CREATE TABLE [dbo].[Session]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[StartTime] datetime not null,
	[Price] dec not null,
	[SoldOut] bit not null, 
    [Game] NVARCHAR(50) NULL, 
	[PlayerEmail] nvarchar(250) null,
	[BasketID] int null,
    CONSTRAINT [FK_Session_ToGame] FOREIGN KEY (Game) REFERENCES Game(Title),
	CONSTRAINT [FK_Session_ToPlayer] FOREIGN KEY (PlayerEmail) REFERENCES Player(Email),
	CONSTRAINT [FK_Session_ToBasket] FOREIGN KEY (BasketID) REFERENCES Basket(ID)
)