CREATE TABLE [dbo].[Game]
(
	[Title] nvarchar(50) NOT NULL ,
	[Description] nvarchar(1000) Null, 
	[Capacity] int Not Null, 
	[Length] int Not Null,
	[RunStart] datetime Not Null,
	[RunEnd] datetime Not Null, 
    CONSTRAINT [PK_Game] PRIMARY KEY ([Title])
)
