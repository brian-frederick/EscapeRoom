CREATE TABLE [dbo].[Basket]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[SessionID] int Not Null,
	[UserID] int null, 
    [PurchaseDate] DATETIME NULL, 
    [ReservedUntilDate] DATETIME NULL, 
    CONSTRAINT [FK_Basket_ToSession] FOREIGN KEY (SessionID) REFERENCES [Session]([id]),
	CONSTRAINT [FK_Basket_ToUser] FOREIGN KEY (UserID) REFERENCES [User](Id), 
    CONSTRAINT [PK_Basket] PRIMARY KEY ([ID])
)
