CREATE TABLE [dbo].[User]
(
	[Id] INT identity(1,1) NOT NULL ,
	[DateCreated] datetime not null,
	[FirstName] varchar(250) Not Null,
	[LastName] varchar(250) Not Null,
	[Phone] varchar(250) not null,
	[Email] varchar(250) not null, 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
)
