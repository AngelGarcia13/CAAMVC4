CREATE TABLE [dbo].[Users] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (100) NULL,
    [DisplayName] NVARCHAR (150) NULL,
    [Country]     VARCHAR (150)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

