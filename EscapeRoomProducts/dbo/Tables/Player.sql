CREATE TABLE [dbo].[Player]
(
	[Email] nvarchar(250) NOT NULL ,
	[FirstName] nvarchar(250) null,
	[LastName] nvarchar(250) null,
	[Measurements] nvarchar(250) null,
	[Phone] nvarchar(250), 
    CONSTRAINT [PK_Player] PRIMARY KEY ([Email])
)
