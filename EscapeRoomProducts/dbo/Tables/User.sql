CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DateCreated] datetime not null,
	[FirstName] varchar(250) Not Null,
	[LastName] varchar(250) Not Null,
	[Phone] varchar(250) not null,
	[Email] varchar(250) not null,
	[BasketID] int null,
	[PaymentInfoID] int null, 
    CONSTRAINT [FK_User_ToBasket] FOREIGN KEY (BasketID) REFERENCES Basket(ID), 
    CONSTRAINT [FK_User_ToPaymentInfo] FOREIGN KEY (PaymentInfoID) REFERENCES PaymentInfo(ID),
)
