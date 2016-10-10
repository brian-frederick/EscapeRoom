CREATE TABLE [dbo].[PaymentInfo]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[FirstName] varchar(250) Not Null,
	[LastName] varchar(250) Not Null,
	[FormOfPayment] varchar(50) Not Null,
	[CreditCardNumber] varchar(50) Null,
	[Expiration] datetime null,
	[SecCode] int null,
	[BillingStreet] nvarchar(250) null,
	[BillingUnit] nvarchar(250) null,
	[BillingCity] nvarchar(250) null,
	[BillingState] nvarchar(250) null,
	[BillingZip] nvarchar(250) null,
	[BasketID] int not null,
	[UserID] int not null, 
    CONSTRAINT [FK_PaymentInfo_ToBasket] FOREIGN KEY ([BasketID]) REFERENCES Basket(ID), 
    CONSTRAINT [FK_PaymentInfo_ToUser] FOREIGN KEY ([UserID]) REFERENCES [User](ID)
)
