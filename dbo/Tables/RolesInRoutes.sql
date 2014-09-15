CREATE TABLE [dbo].[RolesInRoutes] (
    [IdRole]  INT NOT NULL,
    [IdRoute] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdRole] ASC, [IdRoute] ASC),
    CONSTRAINT [FK_Role_ToRoute] FOREIGN KEY ([IdRole]) REFERENCES [dbo].[webpages_Roles] ([RoleId]),
    CONSTRAINT [FK_Route_ToRole] FOREIGN KEY ([IdRoute]) REFERENCES [dbo].[routes] ([Id])
);

