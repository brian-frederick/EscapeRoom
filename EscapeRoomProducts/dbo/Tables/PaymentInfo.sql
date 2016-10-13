CREATE TABLE [dbo].[PaymentInfo]
(
	[Id] INT identity(1,1) NOT NULL ,
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
	[UserID] int not null, 
    CONSTRAINT [FK_PaymentInfo_ToUser] FOREIGN KEY ([UserID]) REFERENCES [User](Id), 
    CONSTRAINT [PK_PaymentInfo] PRIMARY KEY ([Id])
)
