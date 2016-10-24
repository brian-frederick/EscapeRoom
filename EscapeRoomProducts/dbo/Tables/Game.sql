CREATE TABLE [dbo].[Game] (
    [Title]       NVARCHAR (50)   NOT NULL,
	[Tag]		  NVARCHAR (1000) Null,
    [Description] NVARCHAR (4000) NULL,
    [Capacity]    INT             Not NULL,
    [Length]      INT             NULL,
    [RunStart]    DATETIME        NULL,
    [RunEnd]      DATETIME        NULL,
	[Banner]	NVARCHAR(500)		Null,
    [Button] NCHAR(10) NULL, 
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Title] ASC)
);


