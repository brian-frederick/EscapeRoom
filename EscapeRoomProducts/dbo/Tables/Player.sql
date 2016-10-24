CREATE TABLE [dbo].[Player]
(
	[Id] int Identity(1,1) Not Null,
	[Email] nvarchar(250) NULL ,
	[FirstName] nvarchar(250) null,
	[LastName] nvarchar(250) null,
	[Measurements] nvarchar(250) null,
	[Phone] nvarchar(250), 
    CONSTRAINT [PK_Player] PRIMARY KEY ([Id])
)
