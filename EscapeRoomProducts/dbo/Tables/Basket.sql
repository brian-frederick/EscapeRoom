﻿CREATE TABLE [dbo].[Basket]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[SessionID] int Not Null,
	[UserID] int not null, 
    CONSTRAINT [FK_Basket_ToSession] FOREIGN KEY (SessionID) REFERENCES [Session](Id),
	CONSTRAINT [FK_Basket_ToUser] FOREIGN KEY (UserID) REFERENCES [User](Id), 
    CONSTRAINT [PK_Basket] PRIMARY KEY ([ID])
)
