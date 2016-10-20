CREATE TABLE [dbo].[Game] (
    [Title]       NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (1000) NULL,
    [Capacity]    INT             NOT NULL,
    [Length]      INT             NOT NULL,
    [RunStart]    DATETIME        NOT NULL,
    [RunEnd]      DATETIME        NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Title] ASC)
);


