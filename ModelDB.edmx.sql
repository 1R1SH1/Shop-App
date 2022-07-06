
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/06/2022 18:03:16
-- Generated from EDMX file: C:\Users\Rishat Murzyev\source\repos\Shop_Wpf_App_Entity_Framework\ModelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShopDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[Access]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[Access];
GO
IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[Clients]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[Clients];
GO
IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[ElectronicsProducts]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[ElectronicsProducts];
GO
IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[FoodsProducts]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[FoodsProducts];
GO
IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[Purchases];
GO
IF OBJECT_ID(N'[Хранилище ShopDBModelContainer].[SpaceProducts]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ShopDBModelContainer].[SpaceProducts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Access'
CREATE TABLE [dbo].[Access] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(50)  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [SurName] nvarchar(50)  NULL,
    [Patronymic] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [E_Mail] nvarchar(50)  NULL
);
GO

-- Creating table 'ElectronicsProducts'
CREATE TABLE [dbo].[ElectronicsProducts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductCode] nvarchar(50)  NULL,
    [ProductName] nvarchar(50)  NULL
);
GO

-- Creating table 'FoodsProducts'
CREATE TABLE [dbo].[FoodsProducts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductCode] nvarchar(50)  NULL,
    [ProductName] nvarchar(50)  NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [E_Mail] nvarchar(50)  NULL,
    [ProductCode] nvarchar(50)  NULL,
    [ProductName] nvarchar(50)  NULL
);
GO

-- Creating table 'SpaceProducts'
CREATE TABLE [dbo].[SpaceProducts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductCode] nvarchar(50)  NULL,
    [ProductName] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Access'
ALTER TABLE [dbo].[Access]
ADD CONSTRAINT [PK_Access]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ElectronicsProducts'
ALTER TABLE [dbo].[ElectronicsProducts]
ADD CONSTRAINT [PK_ElectronicsProducts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FoodsProducts'
ALTER TABLE [dbo].[FoodsProducts]
ADD CONSTRAINT [PK_FoodsProducts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpaceProducts'
ALTER TABLE [dbo].[SpaceProducts]
ADD CONSTRAINT [PK_SpaceProducts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

SET IDENTITY_INSERT [dbo].[Access] ON
INSERT INTO [dbo].[Access] ([UserId], [UserName], [Password]) VALUES (1, N'R2D2', N'R2D2')
SET IDENTITY_INSERT [dbo].[Access] OFF

SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT INTO [dbo].[Clients] ([id], [Name], [SurName], [Patronymic], [Phone], [E_Mail]) 
                           VALUES (1, N'Иван', N'Иванов', N'Иванович', '', 'ivanov@mail.ru')
SET IDENTITY_INSERT [dbo].[Clients] OFF

SELECT * FROM Clients

SET IDENTITY_INSERT [dbo].[Purchases] ON
INSERT INTO [dbo].[Purchases] ([Id], [E_Mail], [ProductCode], [ProductName]) VALUES (1, 'ivanov@mail.ru', 34, N'Iphone телефон')
INSERT INTO [dbo].[Purchases] ([Id], [E_Mail], [ProductCode], [ProductName]) VALUES (2, 'ivanov@mail.ru', 32, N'Samsung телевизор')
INSERT INTO [dbo].[Purchases] ([Id], [E_Mail], [ProductCode], [ProductName]) VALUES (3, 'ivanov@mail.ru', 23, N'Вентилятор')
SET IDENTITY_INSERT [dbo].[Purchases] OFF

SELECT * FROM Purchases

SET IDENTITY_INSERT [dbo].[ElectronicsProducts] ON
INSERT INTO [dbo].[ElectronicsProducts] ([Id], [ProductCode], [ProductName]) VALUES (1, 12, N'PS 5 игровая приставка')
INSERT INTO [dbo].[ElectronicsProducts] ([Id], [ProductCode], [ProductName]) VALUES (2, 21, N'Samsung 8к смарт телевизор')
INSERT INTO [dbo].[ElectronicsProducts] ([Id], [ProductCode], [ProductName]) VALUES (3, 37, N'Super Rishat Навигатор по Млечному пути')
SET IDENTITY_INSERT [dbo].[ElectronicsProducts] OFF

SELECT * FROM [ElectronicsProducts]

SET IDENTITY_INSERT [dbo].[SpaceProducts] ON
INSERT INTO [dbo].[SpaceProducts] ([Id], [ProductCode], [ProductName]) VALUES (1, 777, N'R2-D2 звездалёт')
INSERT INTO [dbo].[SpaceProducts] ([Id], [ProductCode], [ProductName]) VALUES (2, 33, N'Полёт до Альфа центавра В')
INSERT INTO [dbo].[SpaceProducts] ([Id], [ProductCode], [ProductName]) VALUES (3, 44, N'Полёт до Галлактики Андромеда')
SET IDENTITY_INSERT [dbo].[SpaceProducts] OFF

SELECT * FROM [SpaceProducts]

SET IDENTITY_INSERT [dbo].[FoodsProducts] ON
INSERT INTO [dbo].[FoodsProducts] ([Id], [ProductCode], [ProductName]) VALUES (1, 111, N'Скатерть Самобранка для длительных полётов')
INSERT INTO [dbo].[FoodsProducts] ([Id], [ProductCode], [ProductName]) VALUES (2, 47, N'Бургер')
INSERT INTO [dbo].[FoodsProducts] ([Id], [ProductCode], [ProductName]) VALUES (3, 55, N'Пельмени')
SET IDENTITY_INSERT [dbo].[FoodsProducts] OFF

SELECT * FROM [FoodsProducts]

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------