CREATE TABLE [dbo].[BasketPlayers]
(
	[PlayerId] Int NOT NULL, 
    [BasketID] INT NOT NULL, 
    CONSTRAINT [PK_BasketPlayers] PRIMARY KEY ([PlayerId], [BasketID]), 
    CONSTRAINT [FK_BasketPlayers_Basket] FOREIGN KEY (BasketID) REFERENCES Basket(ID), 
    CONSTRAINT [FK_BasketPlayers_Player] FOREIGN KEY (PlayerId) REFERENCES Player(Id) 
)
