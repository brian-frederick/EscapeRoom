CREATE TABLE [dbo].[Basket]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[SessionID] int Not Null,
	[PlayerEmail] nvarchar(250) not null,
	[PaymentInfoID] int not null,
	[UserID] int not null, 
    CONSTRAINT [FK_Basket_ToSession] FOREIGN KEY (SessionID) REFERENCES [Session](ID),
	constraint [FK_Basket_ToPlayer] foreign key (PlayerEmail) references Player(Email),
	CONSTRAINT [FK_Basket_ToUser] FOREIGN KEY (UserID) REFERENCES [User](ID),
	constraint [FK_Basket_ToPaymentInfo] foreign key (PaymentInfoID) references PaymentInfo(ID)
)
