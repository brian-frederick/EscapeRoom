CREATE TABLE [dbo].[BasketPlayers]
(
	[PlayerEmail] NVARCHAR(250) NOT NULL, 
    [BasketID] INT NOT NULL, 
    CONSTRAINT [PK_BasketPlayers] PRIMARY KEY ([PlayerEmail], [BasketID]), 
    CONSTRAINT [FK_BasketPlayers_Basket] FOREIGN KEY (BasketID) REFERENCES Basket(ID), 
    CONSTRAINT [FK_BasketPlayers_Player] FOREIGN KEY (PlayerEmail) REFERENCES Player(Email) 
)
