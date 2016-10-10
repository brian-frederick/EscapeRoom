CREATE TABLE [dbo].[Player]
(
	[Email] nvarchar(250) NOT NULL PRIMARY KEY,
	[FirstName] nvarchar(250) null,
	[LastName] nvarchar(250) null,
	[Measurements] nvarchar(250) null,
	[Phone] nvarchar(250),
	[SessionID] int not null, 
	[BasketID] int not null,
	CONSTRAINT [FK_Players_ToBasket] FOREIGN KEY (BasketID) REFERENCES Basket(ID),
	CONSTRAINT [FK_Players_ToSession] FOREIGN KEY (SessionID) REFERENCES [Session](ID)	
)
