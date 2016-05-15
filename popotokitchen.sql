USE MASTER
GO

IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'popotokitchen')
BEGIN

DROP DATABASE popotokitchen
END
GO

CREATE DATABASE popotokitchen
GO

USE [popotokitchen]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cooks] (
    [CookID]        [int] IDENTITY(100,1)       NOT NULL,
    [FirstName]     [varchar](50)               NOT NULL,
    [LastName]      [varchar](50)               NOT NULL,
    [Username]      [varchar](50)               NOT NULL,
    [LocalPhone]    [varchar](10)               NOT NULL,
    [EmailAddress]  [varchar](100)              NOT NULL,
    [PasswordHash]  [nvarchar](100) DEFAULT '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8'  NOT NULL,
    [Active]        [bit] DEFAULT 0             NOT NULL
    
    CONSTRAINT [PK_Cooks] PRIMARY KEY CLUSTERED ([CookID] ASC),
    CONSTRAINT [AK_Username] UNIQUE ([Username] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CookHistory] (
    [CookID]        [int]                       NOT NULL,
    [FirstName]     [varchar](50)               NOT NULL,
    [LastName]      [varchar](50)               NOT NULL,
    [Username]      [varchar](50)               NOT NULL,
    [LocalPhone]    [varchar](10)               NOT NULL,
    [EmailAddress]  [varchar](100)              NOT NULL,
    [PasswordHash]  [varchar](100) DEFAULT 111  NOT NULL,
    [Active]        [bit] DEFAULT 0             NOT NULL,
    [DateDeleted]   [datetime]                  NOT NULL
    
    CONSTRAINT [PK_CookHistory] PRIMARY KEY CLUSTERED ([CookID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Messages] (
    [MessageID]     [int] IDENTITY(1,1)         NOT NULL,
    [CookID]        [int]                       NOT NULL,
    [MessageSubject][varchar](50)               NULL,
    [Message]       [varchar](1000)              NULL,
    [MessageDate]   [datetime]                  NULL,
    [Active]        [bit] DEFAULT 1             NOT NULL,
    [HasRead]       [bit] DEFAULT 0             NOT NULL
    
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([MessageID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Roles] (
    [RoleID]        [varchar](50)               NOT NULL,
    [Description]   [varchar](100)              NOT NULL
    
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Assignments] (
    [CookID]        [int]                       NOT NULL,
    [RoleID]        [varchar](50)               NOT NULL,
    [Active]        [bit]                       NOT NULL
    
    CONSTRAINT [PK_Assignments] PRIMARY KEY ( [CookID],[RoleID] ASC )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)  ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Customers] (
    [CustomerID]    [int] IDENTITY (1000,1)     NOT NULL,
    [FirstName]     [varchar](50)               NOT NULL,
    [LastName]      [varchar](100)              NOT NULL,
    [LocalPhone]    [varchar](10) DEFAULT ''    NOT NULL,
    [EmailAddress]  [varchar](100) DEFAULT ''   NOT NULL,
    [FreeCompany]   [varchar](100)              NOT NULL,
    [Active]        [bit] DEFAULT 1             NOT NULL
    
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CustomerDeleteHistory] (
    [CustomerID]    [int]                       NOT NULL,
    [FirstName]     [varchar](50)               NOT NULL,
    [LastName]      [varchar](100)              NOT NULL,
    [LocalPhone]    [varchar](10)               NOT NULL,
    [EmailAddress]  [varchar](100)              NOT NULL,
    [FreeCompany]   [varchar](100)              NOT NULL,
    [Active]        [bit]                       NOT NULL,
    [DateDeleted]   [date]                      NOT NULL
    
    CONSTRAINT [pk_DeletedCustomers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Orders] (
    [OrderID]       [int] IDENTITY (1,1)        NOT NULL,
    [CustomerID]    [int]                       NOT NULL,
    [CookID]        [int]                       NOT NULL,
    [OrderDate]     [datetime]                  NOT NULL,
    [Completed]     [bit] DEFAULT 0             NOT NULL,
    [Paid]          [bit] DEFAULT 0             NOT NULL,
    [Traded]        [bit] DEFAULT 0             NOT NULL,
    [Active]        [bit] DEFAULT 1             NOT NULL,
    [DateCompleted] [datetime]                  NULL
    
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE TABLE [dbo].[OrderHistory] (
    [OrderID]       [int]                       NOT NULL,
    [CustomerID]    [int]                       NOT NULL,
    [CookID]        [int]                       NOT NULL,
    [OrderDate]     [datetime]                  NOT NULL,
    [Completed]     [bit] DEFAULT 0             NOT NULL,
    [Paid]          [bit] DEFAULT 0             NOT NULL,
    [Traded]        [bit] DEFAULT 0             NOT NULL,
    [Active]        [bit] DEFAULT 1             NOT NULL,
    [DateDeleted]   [datetime]                  NOT NULL
    
    CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED ([OrderID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

CREATE TABLE [dbo].[OrderLines] (
    [OrderID]       [int]                       NOT NULL,
    [RecipeID]      [varchar](100)              NOT NULL,
    [Price]         [int]                       NULL,
    [Quantity]      [int]                       NOT NULL,
    [Completed]     [bit] DEFAULT 0         NOT NULL,
    [Active]        [bit] DEFAULT 1             NOT NULL,
    [DateCompleted] [datetime]                  NULL
    
    CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED ([OrderID],[RecipeID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Recipes] (
    [RecipeID]      [varchar](100)              NOT NULL,
    [ItemLevel]     [int] DEFAULT 1             NOT NULL,
    [ImagePath]     [varchar](100)              NULL,
    [Mind]          [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [MindStack]     [int] DEFAULT 0             NOT NULL,
    [Acc]           [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [AccStack]      [int] DEFAULT 0             NOT NULL,
    [Crit]          [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [CritStack]     [int] DEFAULT 0             NOT NULL,
    [Det]           [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [DetStack]      [int] DEFAULT 0             NOT NULL,
    [Spell]         [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [SpellStack]    [int] DEFAULT 0             NOT NULL,
    [Vit]           [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [VitStack]      [int] DEFAULT 0             NOT NULL,
    [Piety]         [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [PietyStack]    [int] DEFAULT 0             NOT NULL,
    [Dex]           [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [DexStack]      [int] DEFAULT 0             NOT NULL,
    [Strength]      [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [StrengthStack] [int] DEFAULT 0             NOT NULL,
    [Intel]         [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [IntelStack]    [int] DEFAULT 0             NOT NULL,
    [Parry]         [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [ParryStack]    [int] DEFAULT 0             NOT NULL,
    [Skill]         [decimal](3,2) DEFAULT 0.00 NOT NULL,
    [SkillStack]    [int] DEFAULT 0             NOT NULL
    
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([RecipeID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RecipeIngredients] (
    [RecipeID]      [varchar](100)              NOT NULL,
    [IngredientID]  [varchar](100)              NOT NULL,
    [Qty]           [int]                       NOT NULL
    
    CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY ( [RecipeID],[IngredientID] ASC )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)  ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RecipeCatalysts] (
    [RecipeID]      [varchar](100)              NOT NULL,
    [Crystal]       [varchar](100)              NOT NULL,
    [CrystalQty]    [int] DEFAULT 1             NOT NULL
    
    CONSTRAINT [PK_RecipeCatalysts] PRIMARY KEY ( [RecipeID],[Crystal] ASC )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)  ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Crystals] (
    [Crystal]       [varchar](100)              NOT NULL,
    [ImagePath]     [varchar](100)              NULL
    
    CONSTRAINT [PK_Crystals] PRIMARY KEY CLUSTERED ([Crystal] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ingredients] (
    [IngredientID]  [varchar](100)              NOT NULL,
    [LocationID]    [int] DEFAULT 100           NOT NULL,
    [ItemLevel]     [int] DEFAULT 1             NOT NULL,
    [Cooking]       [bit] DEFAULT 0             NOT NULL,
    [MobDrop]       [bit] DEFAULT 0             NOT NULL,
    [Fishing]       [bit] DEFAULT 0             NOT NULL,
    [Vendor]        [bit] DEFAULT 0             NOT NULL,
    [ImagePath]     [varchar](100)              NULL
    
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([IngredientID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Locations] (
    [LocationID]    [int]                       NOT NULL,
    [LocationName]  [varchar](100)              NOT NULL,
    [LocationLocale][varchar](100)              NULL,
    [LocationLevel] [int] DEFAULT 1             NOT NULL,
    [Coordinates]   [varchar](9)                NULL,
    [TimeOpen]      [time]                      NULL,
    [ImagePath]     [varchar](100)              NULL
    
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([LocationID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LogLogins] (
    [LoginID]         [int] IDENTITY(1,1)         NOT NULL,
    [CookID]        [int]                       NOT NULL,
    [LoginDate]     [datetime]                  NOT NULL
    
    CONSTRAINT [PK_LogLogins] PRIMARY KEY CLUSTERED ([LoginID] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*RELATIONSHIPS*/

ALTER TABLE [dbo].[Assignments] WITH NOCHECK ADD CONSTRAINT
[FK_Assignments_Cooks] FOREIGN KEY([CookID])
REFERENCES [dbo].[Cooks] ([CookID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT
[FK_Assignments_Cooks]

ALTER TABLE [dbo].[Assignments] WITH NOCHECK ADD CONSTRAINT
[FK_Assignments_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT
[FK_Assignments_Roles]
GO

ALTER TABLE [dbo].[Orders] WITH NOCHECK ADD CONSTRAINT
[FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT
[FK_Orders_Customers]
GO

ALTER TABLE [dbo].[Orders] WITH NOCHECK ADD CONSTRAINT
[FK_Orders_Cooks] FOREIGN KEY([CookID])
REFERENCES [dbo].[Cooks] ([CookID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT
[FK_Orders_Cooks]
GO

/*ALTER TABLE [dbo].[OrderLines] WITH NOCHECK ADD CONSTRAINT
[FK_OrderLines_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT
[FK_OrderLines_Orders]
GO*/

ALTER TABLE [dbo].[OrderLines] WITH NOCHECK ADD CONSTRAINT
[FK_OrderLines_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT
[FK_OrderLines_Recipes]
GO

ALTER TABLE [dbo].[RecipeIngredients] WITH NOCHECK ADD CONSTRAINT
[FK_RecipeIngredients_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT
[FK_RecipeIngredients_Recipes]
GO

ALTER TABLE [dbo].[RecipeIngredients] WITH NOCHECK ADD CONSTRAINT
[FK_RecipeIngredients_Ingredients] FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredients] ([IngredientID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT
[FK_RecipeIngredients_Ingredients]
GO

ALTER TABLE [dbo].[RecipeCatalysts] WITH NOCHECK ADD CONSTRAINT
[FK_RecipeCatalysts_Crystals] FOREIGN KEY([Crystal])
REFERENCES [dbo].[Crystals] ([Crystal])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RecipeCatalysts] CHECK CONSTRAINT
[FK_RecipeCatalysts_Crystals]
GO

ALTER TABLE [dbo].[Messages] WITH NOCHECK ADD CONSTRAINT
[FK_Messages_Cooks] FOREIGN KEY([CookID])
REFERENCES [dbo].[Cooks] ([CookID])
ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT
[FK_Messages_Cooks]
GO

/*11/4/2015--database created without Assignments FK constraints added*/

INSERT INTO [dbo].[Cooks] ([FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[Active])
VALUES ('Ashe','Almaren','ashealmaren','5152982104','nomnompopotos@gmail.com',1),
       ('Osatsu','Nyan','osatsunyan','6035453159','catmusic@gmail.com',1),
       ('Evalara','Fayth','evalarafayth','5045426842','niftythings@gmail.com',0),
       ('Kayli','Hassebrock','kaylihassebrock','5158462549','kaylihassebrock@gmail.com',1),
       ('Cold','Blooded','coldblooded','9194561234','cold@somestuff.com',1)
GO

INSERT INTO [dbo].[Roles] ([RoleID],[Description])
VALUES ('Chef Popoto','Leader of the Free World of Popoto Cooks'),
       ('Sous Popoto','Director of the Tinier Cooking Things'),
       ('Popoto','Cooker of Tiny Cooking Things')
GO

INSERT INTO [dbo].[Assignments] ([CookID],[RoleID],[Active])
VALUES (100,'Chef Popoto',1),
       (101,'Sous Popoto',1),
       (102,'Popoto',0),
       (103,'Sous Popoto',1),
       (104,'Popoto',1)
GO

INSERT INTO [dbo].[Customers] ([FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active])
VALUES ('Aeri','Heartfelt','4566254896','ma@gmail.com','SF',1),
       ('Angelus','Surana','1234567890','poothings@gmail.com','SF',1),
       ('David','Anderson','1234567890','mranderson@yahoo.com','Nyoom',1),
       ('Sanada','Akihiko','1234567890','scrubmaster@gmail.com','Deno',1),
       ('Ashby','Woulds','1234567890','scholar9000@gmail.com','Deno',1),
       ('Poco','Volante','1234567890','pocopoco390@gmail.com','GR8B8',1),
       ('May','Day','8242468165','awesomesauce@gmail.com','STAR',1),
       ('Cold','Blooded','5455044556','popotosrock@gmail.com','Deno',1),
       ('Ashe','Almaren','5152654892','ash@popoto.com','Deno',0)
GO

INSERT INTO [dbo].[Crystals] ([Crystal])
VALUES ('Fire Shard'),
       ('Earth Shard'),
       ('Wind Shard'),
       ('Lightning Shard'),
       ('Water Shard'),
       ('Ice Shard'),
       ('Fire Crystal'),
       ('Earth Crystal'),
       ('Wind Crystal'),
       ('Lightning Crystal'),
       ('Water Crystal'),
       ('Ice Crystal'),
       ('Fire Cluster'),
       ('Earth Cluster'),
       ('Wind Cluster'),
       ('Lightning Cluster'),
       ('Water Cluster'),
       ('Ice Cluster')
GO

INSERT INTO [dbo].[Locations] ([LocationID],[LocationName],[LocationLocale],[LocationLevel],[Coordinates],[TimeOpen])
VALUES (1,'North Shroud','Mature Tree',5,'(x28,y26)',NULL),
       (2,'North Shroud','Mature Tree',5,'(x25,x27)',NULL),
       (3,'Central Shroud','Mature Tree',5,'(x23,y18)',NULL),
       (4,'Central Thanalan','Mature Tree',10,'(x22,y26)',NULL),
       (5,'Central Shroud','Mature Tree',10,'(x25,y20)',NULL),
       (6,'North Shroud','Mature Tree',10,'(x27,y24)',NULL),
       (7,'Lower La Noscea','Mature Tree',10,'(x32,y16)',NULL),
       (8,'Central Shroud','Lush Vegetation Patch',15,'(x18,y19)',NULL),
       (9,'Central Shroud','Lush Vegetation Patch',15,'(x22,y24)',NULL),
       (10,'Middle La Noscea','Lush Vegetation Patch',15,'(x22,y19)',NULL),
       (11,'Central Thanalan','Lush Vegetation Patch',15,'(x25,y20)',NULL),
       (12,'Central Shroud','Mature Tree',15,'(x20,y20)',NULL),
       (13,'Lower La Noscea','Lush Vegetation Patch',15,'(x26,y22)',NULL),
       (14,'Western Thanalan','Lush Vegetation Patch',15,'(x23,y18)',NULL),
       (15,'Western Thanalan','Lush Vegetation Patch',15,'(x23,y23)',NULL),
       (16,'Central Thanalan','Mature Tree',20,'(x21,y20)',NULL),
       (17,'Western La Noscea','Mature Tree',20,'(x26,23)',NULL),
       (18,'Lower La Noscea','Mature Tree',20,'(x34,y17)',NULL),
       (19,'Western La Noscea','Lush Vegetation Patch',20,'(x31,y28)',NULL),
       (20,'Eastern Thanalan','Lush Vegetation Patch',20,'(x16,y27)',NULL),
       (21,'East Shroud','Lush Vegetation Patch',20,'(x18,y28)',NULL),
       (22,'East Shroud','Mature Tree',20,'(x15,y27)',NULL),
       (23,'South Shroud','Mature Tree',25,'(x23,y21)',NULL),
       (24,'Eastern Thanalan','Lush Vegetation Patch',25,'(x14,y20)',NULL),
       (25,'Upper La Noscea','Lush Vegetation Patch',25,'(x14,y24)',NULL),
       (26,'South Shroud','Mature Tree',30,'(16,y21)',NULL),
       (27,'North Shroud','Mature Tree',30,'(x27,y22)',NULL),
       (28,'Central Shroud','Mature Tree',30,'(x24,y30)',NULL),
       (29,'Central Thanalan','Mature Tree',30,'(x24,y31)',NULL),
       (30,'Middle La Noscea','Mature Tree',30,'(x16,y13)',NULL),
       (31,'Eastern La Noscea','Mature Tree',30,'(x28,y33)',NULL),
       (32,'South Shroud','Mature Tree',30,'(x26,y19)',NULL),
       (33,'North Shroud','Lush Vegetation Patch',30,'(x22,y25)',NULL),
       (34,'Southern Thanalan','Lush Vegetation Patch',35,'(x22,y25)',NULL),
       (35,'Eastern La Noscea','Lush Vegetation Patch',35,'(x26,y30)',NULL),
       (36,'South Shroud','Lush Vegetation Patch',35,'(x17,y28)',NULL),
       (37,'South Shroud','Mature Tree',35,'(x16,y30)',NULL),
       (38,'Eastern La Noscea','Mature Tree',40,'(x19,y25)',NULL),
       (39,'Eastern La Noscea','Lush Vegetation Patch',40,'(x21,y29)',NULL),
       (40,'South Shroud','Lush Vegetation Patch',40,'(x21,y29)',NULL),
       (41,'Coerthas Central Highlands','Mature Tree',45,'(x23,y17)',NULL),
       (42,'Upper La Noscea','Lush Vegetation Patch',45,'(x35,y24)',NULL),
       (43,'East Shroud','Mature Tree',50,'(x16,y23)',NULL),
       (44,'Southern Thanalan','Lush Vegetation Patch',50,'(x13,y31)',NULL),
       (45,'Eastern La Noscea','Mature Tree',50,'(x17,y32)',NULL),
       (46,'Central Thanalan','Mature Tree',50,'(x29,y19)',NULL),
       (47,'Middle La Noscea','Mature Tree',50,'(x19,y21)',NULL),
       (48,'Coerthas Western Highlands','Mature Tree',50,'(x30,y32)',NULL),
       (49,'Coerthas Western Highlands','Lush Vegetation Patch',55,'(x17,y16)',NULL),
       (50,'The Dravanian Forelands','Lush Vegetatino Patch',55,'(x36,y20)',NULL),
       (51,'The Dravanian Forelands','Mature Tree',55,'(x25,y25)',NULL),
       (52,'The Churning Mists','Lush Vegetation Patch',55,'(x20,y21)',NULL),
       (53,'The Dravanian Forelands','Lush Vegetation Patch',60,'(x10,y33)',NULL),
       (54,'Coerthas Western Highlands','Lush Vegetation Patch',60,'(x12,y14)',NULL),
       (55,'The Churning Mists','Lush Vegetation Patch',60,'(x20,y31)',NULL),
       (56,'Sea of Clouds','Mature Tree',60,'(x25,y34)',NULL),
       (57,'Sea of Clouds','Lush Vegetation Patch',60,'(x23,y10)',NULL),
       (58,'Dravanian Hinterlands','Lush Vegetation Patch',60,'(x14,y19)',NULL),
       (59,'Middle La Noscea','Unspoiled Node',50,'(x19,y16)',NULL),
       (60,'Coerthas Western Highlands','Unspoiled Node',53,'(x31,y20)',NULL),
       (61,'The Dravanian Forelands','Unspoiled Node',55,'(x26,y12)',NULL),
       (62,'The Dravanian Hinterlands','Unspoiled Node',60,'(x19,y36)',NULL),
       (63,'Coerthas Western Highlands','Folklore Node',60,'(x23,y21)',NULL),
       (100,'N/A VIA GATHERING','N/A',0,'(x00,y00)',NULL)
GO

INSERT INTO [dbo].[Ingredients] ([IngredientID],[LocationID],[ItemLevel],[Cooking],[MobDrop])
VALUES ('Ala Mhigan Mustard',24,23,0,0),
       ('Alligator Pear',32,30,0,0),
       ('Alpine Parsnip',11,15,0,0),
       ('Apricot',59,50,0,0),
       ('Black Pepper',11,14,0,0),
       ('Black Truffle',100,51,0,0),
       ('Blood Currants',40,36,0,0),
       ('Buffalo Beans',8,12,0,0),
       ('Button Mushroom',24,22,0,0),
       ('Chamomile',25,24,0,0),
       ('Chanterelle',9,11,0,0),
       ('Cieldalaes Spinach',13,14,0,0),
       ('Cinderfoot Olive',13,13,0,0),
       ('Cinnamon',2,4,0,0),
       ('Cloves',4,10,0,0),
       ('Coerthas Carrot',14,13,0,0),
       ('Desert Saffron',34,35,0,0),
       ('Dragon Pepper',35,35,0,0),
       ('Dzemael Tomato',100,51,0,0),
       ('Faerie Apple',22,16,0,0),
       ('Galago Mint',21,16,0,0),
       ('Garlean Garlic',15,11,0,0),
       ('Gil Bun',21,19,0,0),
       ('Highland Parsley',13,15,0,0),
       ('Honey Lemon',100,51,0,0),
       ('Jade Peas',33,26,0,0),
       ('Kukuru Bean',7,9,0,0),
       ('La Noscean Lettuce',10,13,0,0),
       ('La Noscean Orange',7,7,0,0),
       ('Laurel',34,34,0,0),
       ('Lalafellin Lentil',19,17,0,0),
       ('Lavender',9,12,0,0),
       ('Lowland Grapes',13,11,0,0),
       ('Maiden Artichoke',39,38,0,0),
       ('Maple Sugar',100,2,1,0),
       ('Midland Basil',35,32,0,0),
       ('Midland Cabbage',33,28,0,0),
       ('Millioncorn',24,25,0,0),
       ('Mirror Apple',41,42,0,0),
       ('Mugwort',39,37,0,0),
       ('Noble Grapes',25,22,0,0),
       ('Nopales',16,18,0,0),
       ('Nutmeg',38,39,0,0),
       ('Ogre Pumpkin',15,13,0,0),
       ('Paprika',19,16,0,0),
       ('Pearl Ginger',24,24,0,0),
       ('Pixie Plums',25,21,0,0),
       ('Popoto',20,18,0,0),
       ('Prickly Pineapple',100,51,0,0),
       ('Raisins',100,3,1,0),
       ('Ramhorn Zucchini',39,39,0,0),
       
       ('Rolanberry',42,43,0,0),
       ('Ruby Tomato',10,15,0,0),
       ('Sagolii Sage',42,41,0,0),
       ('Salt Leek',35,34,0,0),
       ('Sun Lemon',18,17,0,0),
       ('Table Salt',100,1,1,0),
       ('Thyme',40,39,0,0),
       ('White Truffle',36,33,0,0),
       ('Wild Onion',15,12,0,0),
       ('Wizard Eggplant',33,27,0,0),
       ('Aldgoat Chuck',100,1,0,1),
       ('Allagan Snail',3,2,0,0),
       ('Antelope Shank',100,1,0,1),
       ('Buffalo Sirloin',100,1,0,1),
       ('Chicken Breast',100,1,0,1),
       ('Coeurl Meat',100,1,0,1),
       ('Dodo Tenderloin',100,1,0,1),
       ('Eft Tail',100,1,0,1),
       ('Lava Toad',44,49,0,0),
       ('Marmot Meat',100,1,0,1),
       ('Megalocrab Leg',100,1,0,1),
       ('Mole Meat',100,1,0,1),
       ('Mutton Loin',100,1,0,1),
       ('Orobon Liver',100,1,0,1),
       ('Raptor Shank',100,1,0,1),
       ('Tree Toad',8,11,0,0),
       ('Almonds',38,40,0,0),
       ('Gridanian Chestnut',12,14,0,0),
       ('Gridanian Walnut',23,21,0,0),
       ('Iron Acorn',38,36,0,0),
       ('Aloe',34,32,0,0),
       ('Apkallu Egg',100,1,0,1),
       ('Rye',14,11,0,0),
       ('Sticky Rice',25,25,0,0),
       ('Highland Wheat',50,130,0,0),
       ('Sesame Seeds',57,142,0,0),
       ('Cyclops Onion',50,130,0,0),
       ('Old World Fig',61,115,0,0),
       ('Cloud Banana',62,145,0,0),
       ('Vanilla Beans',63,160,0,0)
GO

INSERT INTO [dbo].[Ingredients] ([IngredientID],[ItemLevel],[Cooking],[Fishing],[LocationID])
VALUES ('Ash Tuna',32,0,1,100),
       ('Bianaq Bream',27,0,1,100),
       ('Black Eel',25,0,1,100),
       ('Black Sole',28,0,1,100),
       ('Bluebell Salmon',20,0,1,100),
       ('Brass Loach',9,0,1,100),
       ('Cloud Cutter',45,0,1,100),
       ('Crimson Crayfish',8,0,1,100),
       ('Dark Bass',25,0,1,100),
       ('Dusk Goby',6,0,1,100),
       ('Finger Shrimp',4,0,1,100),
       ('Fullmoon Sardine',34,0,1,100),
       ('Helmet Crab',16,0,1,100),
       ('Indigo Herring',31,0,1,100),
       ('Mahi Mahi',50,0,1,100),
       ('Maiden Bass',10,0,1,100),
       ('Navigator''s Dagger',18,0,1,100),
       ('Northern Pike',40,0,1,100),
       ('Pipira',7,0,1,100),
       ('Princess Trout',5,0,1,100),
       ('Raincaller',40,0,1,100),
       ('Razor Clam',20,0,1,100),
       ('Rothlyt Oyster',17,0,1,100),
       ('Salt Cod',15,1,0,100),
       ('Tiger Cod',15,0,1,100),
       ('Velodyna Carp',37,0,1,100),
       ('Warmwater Trout',23,0,1,100),
       ('Lake Urchin',125,0,1,100),
       ('Spring Urchin',180,0,1,100),
       ('Sweetfish',136,0,0,100)
GO

INSERT INTO [dbo].[Ingredients] ([IngredientID],[ItemLevel],[Cooking],[Vendor],[MobDrop],[LocationID])
VALUES ('Aldgoat Milk',1,0,1,0,100),
       ('Blue Cheese',1,0,1,0,100),
       ('Buffalo Milk',1,0,1,0,100),
       ('Cottage Cheese',17,1,0,0,100),
       ('Cream Cheese',35,1,0,0,100),
       ('Night Milk',1,0,0,1,100),
       ('Rolanberry Cheese',43,1,0,0,100),
       ('Sweet Cream',6,1,0,0,100),
       ('Bat Wing',1,0,1,1,100),
       ('Blue Landtrap Leaf',1,0,0,1,100),
       ('Chicken Egg',1,0,1,0,100),
       ('Cornmeal',29,1,0,0,100),
       ('Dodo Egg',1,0,0,1,100),
       ('Gelatin',14,1,0,0,100),
       ('Flatbread',5,1,1,0,100),
       ('Knight''s Bread',38,1,0,0,100),
       ('Kukuru Butter',10,1,0,0,100),
       ('Kukuru Powder',11,1,0,0,100),
       ('Natron',25,0,1,0,100),
       ('Pie Dough',14,1,0,0,100),
       ('Puk Egg',1,0,0,1,100),
       ('Ragstone',13,0,1,0,100),
       ('Rock Salt',12,0,1,0,100),
       ('Rye Flour',5,1,1,0,100),
       ('Smooth Butter',7,1,0,0,100),
       ('Royal Kukuru Bean',90,0,1,0,100),
       ('Dalamud Popoto',90,0,1,0,100),
       ('Yak Milk',120,0,0,1,100),
       ('Cockatrice Thigh',145,0,0,1,100),
       ('Okeanis Tail',145,0,0,1,100),
       ('Okeanis Egg',142,0,0,1,100),
       ('Birch Syrup',148,1,0,0,100)
GO

INSERT INTO [dbo].[Ingredients] ([IngredientID],[LocationID],[ItemLevel],[Cooking],[Vendor])
VALUES ('Chicken Stock',100,28,1,0),
       ('Cider Vinegar',100,16,0,0),
       ('Clove Oil',100,14,0,1),
       ('Cooking Sherry',100,1,0,1),
       ('Dark Vinegar',100,31,1,0),
       ('Distilled Water',100,1,0,1),
       ('Honey',100,4,0,1),
       ('Lavender Oil',100,16,1,0),
       ('Maple Sap',100,2,0,1),
       ('Maple Syrup',100,1,1,0),
       ('Olive Oil',100,11,1,0),
       ('Sour Red',100,1,0,1),
       ('Tomato Sauce',100,12,1,0),
       ('Beehive Chip',2,5,0,1),
       ('Sunset Wheat',10,11,0,1),
       ('Sunset Wheat Flour',100,7,1,1),
       ('Thanalan Tea Leaves',44,38,0,0),
       ('Tiny Crown',100,1,0,1),
       ('Volcanic Rock Salt',100,51,0,1),
       ('Walnut Bread',100,18,1,1),
       ('Mineral Water',100,1,0,1),
       ('Filtered Water',100,1,0,1),
       ('Roasted Coffee Beans',100,1,0,1),
       ('Bubble Chocolate',100,11,1,1),
       ('Smoked Bacon',100,110,0,1),
       ('Coerthan Tea Leaves',60,125,0,1),
       ('Abalathian Rock Salt',100,139,0,1),
       ('Kaiser Roll',100,139,1,1),
       ('Highland Flour',100,133,1,0),
       ('Duskborne Aethersand',100,139,0,1),
       ('Morel',100,148,0,1),
       ('Heavenly Kukuru Powder',100,160,0,1),
       ('Sour Cream',100,120,1,0)
GO

INSERT INTO [dbo].[Recipes] ([RecipeID],[ItemLevel],[Mind],[MindStack],[Acc],[AccStack],[Crit],[CritStack],[Det],[DetStack],[Spell],[SpellStack],[Vit],[VitStack],[Piety],[PietyStack],[Dex],[DexStack],[Strength],[StrengthStack],[Intel],[IntelStack],[Parry],[ParryStack],[Skill],[SkillStack])
VALUES ('Black Truffle Risotto',50,0.00,0,0.00,0,0.02,9,0.04,14,0.00,0,0.04,15,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Deviled Eggs',46,0.00,0,0.02,8,0.04,19,0.00,0,0.00,0,0.03,11,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Mulled Tea',47,0.00,0,0.00,0,0.00,0,0.00,0,0.02,8,0.03,12,0.04,11,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Buttons in a Blanket',49,0.00,0,0.00,0,0.02,8,0.04,13,0.00,0,0.03,12,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Eft Steak',50,0.00,0,0.02,8,0.00,0,0.00,0,0.00,0,0.03,12,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.04,21),
       ('Pineapple Juice',70,0.00,0,0.00,0,0.00,0,0.00,0,0.02,9,0.04,15,0.04,14,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Sauteed Coeurl',70,0.00,0,0.02,9,0.00,0,0.00,0,0.00,0,0.04,15,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.04,22),
       ('Lava Toad Legs',70,0.00,0,0.04,22,0.02,9,0.00,0,0.00,0,0.04,15,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Finger Sandwich',70,0.00,0,0.02,9,0.00,0,0.00,0,0.00,0,0.04,15,0.00,0,0.00,0,0.00,0,0.00,0,0.04,22,0.00,0),
       ('Apkallu Omelette',70,0.00,0,0.02,9,0.04,22,0.00,0,0.00,0,0.04,15,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Pineapple Ponzecake',70,0.00,0,0.00,0,0.00,0,0.00,0,0.04,22,0.04,15,0.02,6,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Sachertorte',90,0.00,0,0.00,0,0.00,0,0.02,6,0.04,24,0.04,18,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Popoto Pancakes',90,0.00,0,0.02,10,0.00,0,0.00,0,0.00,0,0.04,18,0.00,0,0.00,0,0.00,0,0.00,0,0.04,24,0.00,0),
       ('Bacon Bread',110,0.00,0,0.00,0,0.02,13,0.00,0,0.00,0,0.04,22,0.00,0,0.00,0,0.00,0,0.00,0,0.04,26,0.00,0),
       ('Triple Cream Coffee',110,0.00,0,0.00,0,0.00,0,0.02,9,0.00,0,0.05,20,0.04,18,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Sour Cream',120,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Highland Flour',125,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Ishgardian Muffin',130,0.00,0,0.02,11,0.00,0,0.00,0,0.00,0,0.04,26,0.00,0,0.00,0,0.00,0,0.00,0,0.04,28,0.00,0),
       ('Ishgardian Tea',130,0.00,0,0.00,0,0.00,0,0.00,0,0.02,11,0.04,26,0.04,19,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Grilled Sweetfish',133,0.00,0,0.04,29,0.02,11,0.00,0,0.00,0,0.04,26,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Kaiser Roll',136,0.00,0,0.00,0,0.02,13,0.00,0,0.00,0,0.04,27,0.00,0,0.00,0,0.00,0,0.00,0,0.04,30,0.00,0),
       ('Cockatrice Meatballs',145,0.00,0,0.00,0,0.02,12,0.00,0,0.00,0,0.04,25,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.04,28),
       ('Frozen Spirits',145,0.00,0,0.00,0,0.00,0,0.02,9,0.00,0,0.04,27,0.04,21,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Liver-Cheese Sandwich',148,0.00,0,0.02,12,0.00,0,0.00,0,0.00,0,0.04,28,0.00,0,0.00,0,0.00,0,0.00,0,0.04,30,0.00,0),
       ('Deep-Fried Okeanis',150,0.00,0,0.00,0,0.00,0,0.02,10,0.00,0,0.04,28,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.04,30),
       ('Creme Brulee',160,0.00,0,0.00,0,0.00,0,0.02,10,0.05,32,0.05,30,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Urchin Loaf',160,0.00,0,0.05,32,0.00,0,0.02,10,0.00,0,0.05,30,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0),
       ('Hot Chocolate',160,0.00,0,0.00,0,0.00,0,0.00,0,0.02,13,0.05,30,0.04,24,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0)
GO

INSERT INTO [dbo].[RecipeIngredients] ([RecipeID],[IngredientID],[Qty])
VALUES ('Black Truffle Risotto','Black Truffle',1),
       ('Black Truffle Risotto','Sticky Rice',1),
       ('Black Truffle Risotto','Cottage Cheese',1),
       ('Black Truffle Risotto','Wild Onion',1),
       ('Deviled Eggs','Apkallu Egg',1),
       ('Deviled Eggs','Highland Parsley',1),
       ('Deviled Eggs','Paprika',1),
       ('Deviled Eggs','Sun Lemon',1),
       ('Deviled Eggs','Ala Mhigan Mustard',1),
       ('Deviled Eggs','Fullmoon Sardine',1),
       ('Mulled Tea','Mineral Water',1),
       ('Mulled Tea','Cinnamon',1),
       ('Mulled Tea','Cloves',1),
       ('Mulled Tea','Pearl Ginger',1),
       ('Mulled Tea','Thanalan Tea Leaves',1),
       ('Buttons in a Blanket','Ruby Tomato',1),
       ('Buttons in a Blanket','Midland Cabbage',1),
       ('Buttons in a Blanket','Button Mushroom',3),
       ('Buttons in a Blanket','Desert Saffron',1),
       ('Buttons in a Blanket','Table Salt',1),
       ('Buttons in a Blanket','Tomato Sauce',1),
       ('Eft Steak','Eft Tail',1),
       ('Eft Steak','Garlean Garlic',1),
       ('Eft Steak','Black Pepper',1),
       ('Eft Steak','Laurel',1),
       ('Eft Steak','Cider Vinegar',1),
       ('Eft Steak','Sour Red',1),
       ('Pineapple Juice','Prickly Pineapple',4),
       ('Sauteed Coeurl','Garlean Garlic',1),
       ('Sauteed Coeurl','Smooth Butter',1),
       ('Sauteed Coeurl','Coeurl Meat',1),
       ('Sauteed Coeurl','Cooking Sherry',1),
       ('Sauteed Coeurl','Volcanic Rock Salt',1),
       ('Lava Toad Legs','Wild Onion',1),
       ('Lava Toad Legs','Sunset Wheat Flour',1),
       ('Lava Toad Legs','Midland Basil',1),
       ('Lava Toad Legs','Dragon Pepper',1),
       ('Lava Toad Legs','Allagan Snail',1),
       ('Lava Toad Legs','Lava Toad',1),
       ('Finger Sandwich','Walnut Bread',1),
       ('Finger Sandwich','Apkallu Egg',1),
       ('Finger Sandwich','La Noscean Lettuce',1),
       ('Finger Sandwich','Smooth Butter',1),
       ('Finger Sandwich','Volcanic Rock Salt',1),
       ('Apkallu Omelette','Mineral Water',1),
       ('Apkallu Omelette','Apkallu Egg',1),
       ('Apkallu Omelette','Black Truffle',1),
       ('Apkallu Omelette','Table Salt',1),
       ('Apkallu Omelette','Sweet Cream',1),
       ('Apkallu Omelette','Smooth Butter',1),
       ('Pineapple Ponzecake','Apkallu Egg',1),
       ('Pineapple Ponzecake','Prickly Pineapple',1),
       ('Pineapple Ponzecake','Sunset Wheat Flour',1),
       ('Pineapple Ponzecake','Maple Syrup',1),
       ('Pineapple Ponzecake','Night Milk',1),
       ('Sachertorte','Bubble Chocolate',1),
       ('Sachertorte','Sunset Wheat Flour',1),
       ('Sachertorte','Sweet Cream',1),
       ('Sachertorte','Smooth Butter',1),
       ('Sachertorte','Apricot',1),
       ('Sachertorte','Royal Kukuru Bean',1),
       ('Popoto Pancakes','Apkallu Egg',1),
       ('Popoto Pancakes','Sunset Wheat Flour',1),
       ('Popoto Pancakes','Nutmeg',1),
       ('Popoto Pancakes','Table Salt',1),
       ('Popoto Pancakes','Mirror Apple',1),
       ('Popoto Pancakes','Dalamud Popoto',1),
       ('Bacon Bread','Mineral Water',1),
       ('Bacon Bread','Sunset Wheat',1),
       ('Bacon Bread','Night Milk',1),
       ('Bacon Bread','Volcanic Rock Salt',2),
       ('Bacon Bread','Smoked Bacon',1),
       ('Triple Cream Coffee','Mineral Water',1),
       ('Triple Cream Coffee','Cinnamon',1),
       ('Triple Cream Coffee','Maple Sugar',1),
       ('Triple Cream Coffee','Sweet Cream',1),
       ('Triple Cream Coffee','Filtered Water',1),
       ('Triple Cream Coffee','Roasted Coffee Beans',1),
       ('Sour Cream','Yak Milk',3),
       ('Highland Flour','Highland Wheat',5),
       ('Ishgardian Muffin','Sunset Wheat Flour',3),
       ('Ishgardian Muffin','Cornmeal',1),
       ('Ishgardian Muffin','Yak Milk',1),
       ('Ishgardian Tea','Maple Sugar',1),
       ('Ishgardian Tea','Coerthan Tea Leaves',3),
       ('Ishgardian Tea','Yak Milk',2),
       ('Grilled Sweetfish','Volcanic Rock Salt',2),
       ('Grilled Sweetfish','Sweetfish',1),
       ('Kaiser Roll','Highland Flour',3),
       ('Kaiser Roll','Sesame Seeds',2),
       ('Kaiser Roll','Yak Milk',1),
       ('Cockatrice Meatballs','Flatbread',1),
       ('Cockatrice Meatballs','Tomato Sauce',1),
       ('Cockatrice Meatballs','Cockatrice Thigh',3),
       ('Cockatrice Meatballs','Cyclops Onion',2),
       ('Cockatrice Meatballs','Abalathian Rock Salt',1),
       ('Frozen Spirits','Yak Milk',2),
       ('Frozen Spirits','Old World Fig',2),
       ('Frozen Spirits','Cloud Banana',2),
       ('Liver-Cheese Sandwich','Cream Cheese',1),
       ('Liver-Cheese Sandwich','Kaiser Roll',1),
       ('Liver-Cheese Sandwich','Cockatrice Thigh',2),
       ('Deep-Fried Okeanis','Olive Oil',1),
       ('Deep-Fried Okeanis','Dalamud Popoto',1),
       ('Deep-Fried Okeanis','Okeanis Tail',3),
       ('Deep-Fried Okeanis','Highland Flour',1),
       ('Deep-Fried Okeanis','Abalathian Rock Salt',1),
       ('Creme Brulee','Vanilla Beans',2),
       ('Creme Brulee','Okeanis Egg',1),
       ('Creme Brulee','Yak Milk',1),
       ('Creme Brulee','Birch Syrup',1),
       ('Creme Brulee','Duskborne Aethersand',1),
       ('Urchin Loaf','Lake Urchin',1),
       ('Urchin Loaf','Spring Urchin',2),
       ('Urchin Loaf','Okeanis Egg',1),
       ('Urchin Loaf','Sour Cream',1),
       ('Urchin Loaf','Morel',1),
       ('Urchin Loaf','Duskborne Aethersand',1),
       ('Hot Chocolate','Heavenly Kukuru Powder',1),
       ('Hot Chocolate','Yak Milk',1),
       ('Hot Chocolate','Birch Syrup',1),
       ('Hot Chocolate','Duskborne Aethersand',1)
GO

INSERT INTO [dbo].[RecipeCatalysts] ([RecipeID],[Crystal],[CrystalQty])
VALUES ('Black Truffle Risotto','Fire Cluster',1),
       ('Black Truffle Risotto','Water Cluster',1),
       ('Deviled Eggs','Fire Shard',6),
       ('Deviled Eggs','Water Shard',5),
       ('Mulled Tea','Fire Shard',6),
       ('Mulled Tea','Water Shard',5),
       ('Buttons in a Blanket','Fire Shard',6),
       ('Buttons in a Blanket','Water Shard',6),
       ('Eft Steak','Fire Shard',6),
       ('Eft Steak','Water Shard',6),
       ('Pineapple Juice','Fire Cluster',1),
       ('Pineapple Juice','Water Cluster',1),
       ('Sauteed Coeurl','Fire Cluster',1),
       ('Sauteed Coeurl','Water Cluster',1),
       ('Lava Toad Legs','Fire Cluster',1),
       ('Lava Toad Legs','Water Cluster',1),
       ('Finger Sandwich','Fire Cluster',1),
       ('Finger Sandwich','Water Cluster',1),
       ('Apkallu Omelette','Fire Cluster',1),
       ('Apkallu Omelette','Water Cluster',1),
       ('Pineapple Ponzecake','Fire Cluster',1),
       ('Pineapple Ponzecake','Water Cluster',1),
       ('Sachertorte','Fire Cluster',2),
       ('Sachertorte','Water Cluster',1),
       ('Popoto Pancakes','Fire Cluster',2),
       ('Popoto Pancakes','Water Cluster',1),
       ('Bacon Bread','Fire Cluster',2),
       ('Bacon Bread','Water Cluster',2),
       ('Triple Cream Coffee','Fire Cluster',2),
       ('Triple Cream Coffee','Water Cluster',2),
       ('Sour Cream','Fire Shard',7),
       ('Highland Flour','Fire Shard',7),
       ('Ishgardian Muffin','Fire Crystal',4),
       ('Ishgardian Muffin','Water Crystal',3),
       ('Ishgardian Tea','Fire Crystal',4),
       ('Ishgardian Tea','Water Crystal',3),
       ('Grilled Sweetfish','Fire Crystal',4),
       ('Grilled Sweetfish','Water Crystal',3),
       ('Kaiser Roll','Fire Crystal',4),
       ('Kaiser Roll','Water Crystal',4),
       ('Cockatrice Meatballs','Fire Crystal',5),
       ('Cockatrice Meatballs','Water Crystal',5),
       ('Frozen Spirits','Fire Crystal',5),
       ('Frozen Spirits','Water Crystal',5),
       ('Liver-Cheese Sandwich','Fire Crystal',5),
       ('Liver-Cheese Sandwich','Water Crystal',5),
       ('Deep-Fried Okeanis','Fire Crystal',6),
       ('Deep-Fried Okeanis','Water Crystal',5),
       ('Creme Brulee','Fire Cluster',2),
       ('Creme Brulee','Water Cluster',1),
       ('Urchin Loaf','Fire Cluster',2),
       ('Urchin Loaf','Water Cluster',1),
       ('Hot Chocolate','Fire Cluster',2),
       ('Hot Chocolate','Water Cluster',1)
GO

INSERT INTO [dbo].[Orders] ([CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active])
VALUES  (1000,101,'11/07/2015 12:00:00 AM',1,1,1,1),
        (1001,100,'11/08/2015 12:00:00 AM',0,1,0,1),
        (1001,100,'11/08/2015 12:00:00 AM',1,1,0,1),
        (1002,101,'11/09/2015 12:00:00 AM',1,1,1,1),
        (1003,101,'11/10/2015 12:00:00 AM',1,0,0,0),
        (1003,101,'11/10/2015 12:00:00 AM',1,1,1,1),
        (1004,102,'11/13/2015 12:00:00 AM',1,0,0,0),
        (1005,101,'11/16/2015 12:00:00 AM',0,1,0,1),
        (1007,100,'11/20/2015 12:00:00 AM',1,1,1,1),
        (1007,100,'11/20/2015 12:00:00 AM',0,0,0,0)
GO

INSERT INTO [dbo].[OrderLines] ([OrderID],[RecipeID],[Price],[Quantity],[Completed],[Active])
VALUES  (1,'Frozen Spirits',10000,5,1,1),
        (1,'Creme Brulee',5000,10,1,1),
        (2,'Ishgardian Muffin',200,20,0,1),
        (2,'Kaiser Roll',5000,5,1,1),
        (2,'Cockatrice Meatballs',300,10,1,1),
        (3,'Deep-fried Okeanis',4000,5,1,1),
        (4,'Hot Chocolate',300,20,1,1),
        (4,'Triple Cream Coffee',5000,10,1,1),
        (5,'Bacon Bread',500,5,1,1),
        (5,'Liver-Cheese Sandwich',1000,2,1,1),
        (6,'Popoto Pancakes',2000,10,1,1),
        (6,'Finger Sandwich',1500,5,1,1),
        (6,'Buttons in a Blanket',2500,5,1,1),
        (7,'Sachertorte',15000,1,1,1),
        (7,'Sour Cream',7000,7,1,1),
        (8,'Black Truffle Risotto',20000,10,1,1),
        (9,'Apkallu Omelette',9000,10,1,1),
        (9,'Pineapple Juice',8000,5,1,1),
        (10,'Liver-Cheese Sandwich',900,1,1,1)
GO

INSERT INTO [dbo].[Messages] ([CookID],[MessageSubject],[Message],[MessageDate])
VALUES (101,'SF Orders due Fri Dec 18th','Hi Osatsu, please remember to finish your assigned orders by Friday Dec. 18th for SF! They have already paid but will not have inventory space until then. Please complete them so we can trade them early that morning. Thanks! - AA','12/11/2015 11:30:45 AM'),
       (101,'Meeting 12/11','Osu - Will you be attending the meeting tomorrow? It''s at 10AM. - AA','12/10/2015 09:45:20 AM'),
       (101,'Customer Delete','Osu - You deleted a customer the other day, can you tell me what happened? Thanks! - AA','12/05/2015 01:27:30 PM'),
       (103,'Welcome, Kayli!','Kayli - Welcome to Popoto''s Kitchen! Thank you for joining us and I will catch up with you soon to complete your training! - AD','12/09/15 10:45:20 AM'),
       (104,'Welcome, Cold!','Cold - Welcome to our Kitchen! We''re glad to have you! I''ll touch base with you momentarily to complete some paperwork but in the meantime I have assigned you orders to complete. Happy cooking! - AA','12/11/15 10:23:38 AM')
GO
                           
/*INSERT INTO [dbo].[Orders] ([CustomerID],[CookID],[OrderDate],[Paid],[Traded])
VALUES  (1000,100,'2015-11-01',1,1),
        (1001,100,'2015-11-02',1,1),
        (1001,100,'2015-11-02',0,0)
GO
        
INSERT INTO [dbo].[OrderLines] ([OrderID],[RecipeID],[Quantity],[PricePerItem])
VALUES  (1,'Black Truffle Risotto',5,'8000'),
        (2,'Black Truffle Risotto',10,'8000'),
        (3,'Frozen Spirits',5,'10000')
GO*/

/*STORED PROCEDURES*/

    /*CUSTOMERS*/
    /*keep*/
    CREATE PROCEDURE sp_add_customer
        @FirstName      [varchar](50),
        @LastName       [varchar](100),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100),
        @FreeCompany    [varchar](100)
    AS
        BEGIN
            INSERT INTO [dbo].[Customers] ([FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany])
            VALUES (@FirstName,@LastName,@LocalPhone,@EmailAddress,@FreeCompany)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_admin_save_deleted_customer
        @CustomerID     [int],
        @FirstName      [varchar](50),
        @LastName       [varchar](100),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100),
        @FreeCompany    [varchar](100),
        @Active         [bit],
        @DateDeleted    [date]
    AS
        BEGIN
            INSERT INTO [dbo].[CustomerDeleteHistory] ([CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active],[DateDeleted])
            VALUES (@CustomerID,@FirstName,@LastName,@LocalPhone,@EmailAddress,@FreeCompany,@Active,@DateDeleted)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_admin_delete_customer
        @CustomerID     [int]
    AS
        BEGIN
            DELETE FROM [dbo].[Customers]
            WHERE [CustomerID] = @CustomerID AND
                  [Active] = 0
                  
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_delete_customer
        @CustomerID     [int]
    AS
        BEGIN
            UPDATE [dbo].[Customers]
            SET [Active] = 0
            WHERE [CustomerID] = @CustomerID
                  
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_reactivate_customer
        @CustomerID     [int]
    AS
        BEGIN
            UPDATE [dbo].[Customers]
            SET [Active] = 1
            WHERE [CustomerID] = @CustomerID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_edit_customer
        @CustomerID     [int],
        @FirstName      [varchar](50),
        @LastName       [varchar](100),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100),
        @FreeCompany    [varchar](100)
    AS
        BEGIN
            UPDATE [dbo].[Customers]
            SET [FirstName] = @FirstName,
                [LastName] = @LastName,
                [LocalPhone] = @LocalPhone,
                [EmailAddress] = @EmailAddress,
                [FreeCompany] = @FreeCompany
            WHERE [CustomerID] = @CustomerID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_customers
        @Active         [bit]
    AS
        BEGIN
            SELECT [CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active]
            FROM [dbo].[Customers]
            WHERE [Active] = @Active
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_customer_all
        @SearchTerm     [varchar](100),
        @Active         [bit] 
    AS
        BEGIN
            SELECT [CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active]
            FROM [dbo].[Customers]
            WHERE (([CustomerID] LIKE '%'+@SearchTerm+'%') OR ([FirstName] LIKE '%'+@SearchTerm+'%') OR ([LastName] LIKE '%'+@SearchTerm+'%') OR ([LocalPhone] LIKE '%'+@SearchTerm+'%') OR ([EmailAddress] LIKE '%'+@SearchTerm+'%') OR ([FreeCompany] LIKE '%'+@SearchTerm+'%') OR ([FirstName]+' '+[LastName] LIKE '%'+@SearchTerm+'%')) AND [Active] = @Active
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_customer_customerID
        @SearchTerm     [varchar](50),
        @Active         [bit]
    AS
        BEGIN
            SELECT [CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active]
            FROM [dbo].[Customers]
            WHERE [CustomerID] LIKE '%'+@SearchTerm+'%' AND [Active] = @Active
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_customer_freecompany
        @SearchTerm     [varchar](100),
        @Active         [bit]
    AS
        BEGIN
            SELECT [CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active]
            FROM [dbo].[Customers]
            WHERE [FreeCompany] LIKE '%'+@SearchTerm+'%' AND [Active] = @Active
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_customer_fullname
        @SearchTerm     [varchar](100),
        @Active         [bit]
    AS
        BEGIN
            SELECT [CustomerID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[FreeCompany],[Active]
            FROM [dbo].[Customers]
            WHERE ([FirstName]+' '+[LastName]) LIKE '%'+@SearchTerm+'%' AND [Active] = @Active
        END
    GO
    
    /*COOKS*/
    CREATE PROCEDURE sp_select_cook
        @CookID         [int],
        @Active         [bit]
    AS
        BEGIN
            SELECT [CookID],[FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[Active]
            FROM [dbo].[Cooks]
            WHERE [CookID] = @CookID AND
                  [Active] = @Active
        END
    GO
    
    CREATE PROCEDURE sp_select_last_added_cook
        @FirstName      [varchar](50),
        @LastName       [varchar](50),
        @Username       [varchar](50),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100)
    AS
        BEGIN
            SELECT TOP 1 [CookID]
            FROM [dbo].[Cooks]
            WHERE [FirstName] = @FirstName AND
                  [LastName] = @LastName AND
                  [Username] = @Username AND
                  [LocalPhone] = @LocalPhone AND
                  [EmailAddress] = @EmailAddress
        END
    GO
    
    CREATE PROCEDURE sp_select_all_cooks
        @Active         [bit]
    AS
        BEGIN
            SELECT [CookID],[FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[Active]
            FROM [dbo].[Cooks]
            WHERE [Active] = @Active
        END
    GO
    
    CREATE PROCEDURE sp_search_cook_all
        @SearchTerm     [varchar](100),
        @Active         [bit]
    AS
        BEGIN
            SELECT [CookID],[FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[Active]
            FROM [dbo].[Cooks]
            WHERE (([CookID] LIKE '%'+@SearchTerm+'%') OR ([FirstName] LIKE '%'+@SearchTerm+'%') OR ([LastName] LIKE '%'+@SearchTerm+'%') OR ([Username] LIKE '%'+@SearchTerm+'%') OR ([LocalPhone] LIKE '%'+@SearchTerm+'%') OR ([EmailAddress] LIKE '%'+@SearchTerm+'%'))
            AND [Active] = @Active
        END
    GO
    
    CREATE PROCEDURE sp_add_cook
        @FirstName      [varchar](50),
        @LastName       [varchar](50),
        @Username       [varchar](50),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100)
    AS
        BEGIN
            INSERT INTO [dbo].[Cooks] ([FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[Active])
            VALUES (@FirstName,@LastName,@Username,@LocalPhone,@EmailAddress,1)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_save_deleted_cook
        @CookID         [int],
        @FirstName      [varchar](50),
        @LastName       [varchar](50),
        @Username       [varchar](50),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100),
        @PasswordHash   [varchar](100),
        @Active         [bit],
        @DateDeleted    [datetime]
    AS
        BEGIN
            INSERT INTO [dbo].[CookHistory] ([FirstName],[LastName],[Username],[LocalPhone],[EmailAddress],[PasswordHash],[Active],[DateDeleted])
            VALUES (@FirstName,@LastName,@Username,@LocalPhone,@EmailAddress,@PasswordHash,@Active,@DateDeleted)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_edit_cook
        @CookID         [int],
        @FirstName      [varchar](50),
        @LastName       [varchar](50),
        @Username       [varchar](50),
        @LocalPhone     [varchar](10),
        @EmailAddress   [varchar](100),
        @Active         [bit]
    AS
        BEGIN
            UPDATE [dbo].[Cooks]
            SET [FirstName] = @FirstName,
                [LastName] = @LastName,
                [Username] = @Username,
                [LocalPhone] = @LocalPhone,
                [EmailAddress] = @EmailAddress,
                [Active] = @Active
            WHERE [CookID] = @CookID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_delete_cook
        @CookID         [int]
    AS
        BEGIN
            DELETE FROM [dbo].[Cooks]
            WHERE [CookID] = @CookID
                  
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_delete_cook
        @CookID         [int],
        @Active         [bit]
    AS
        BEGIN
            UPDATE [dbo].[Cooks]
            SET [Active] = @Active
            WHERE [CookID] = @CookID
        
            RETURN @@ROWCOUNT
        END
    GO
    
    /*ROLES*/
    
    CREATE PROCEDURE sp_admin_add_role
        @RoleID         [varchar](50),
        @Description    [varchar](100)
    AS 
        BEGIN
            INSERT INTO [dbo].[Roles] ([RoleID],[Description])
            VALUES (@RoleID,@Description)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_delete_role
        @RoleID         [varchar](50)
    AS
        BEGIN
            DELETE FROM [dbo].[Roles]
            WHERE [RoleID] = @RoleID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_edit_role
        @RoleID         [varchar](50),
        @Description    [varchar](100)
    AS
        BEGIN
            UPDATE [dbo].[Roles]
            SET [Description] = @Description
            WHERE [RoleID] = @RoleID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*ASSIGNMENTS*/
    
    CREATE PROCEDURE sp_admin_add_assignment
        @CookID         [int],
        @RoleID         [varchar](50),
        @Active         [bit]
    AS 
        BEGIN
            INSERT INTO [dbo].[Assignments] ([CookID],[RoleID],[Active])
            VALUES (@CookID,@RoleID,@Active)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_edit_assignment
        @CookID         [int],
        @RoleID         [varchar](50),
        @Active         [bit]
    AS 
        BEGIN
            UPDATE [dbo].[Assignments]
            SET [CookID] = @CookID,
                [RoleID] = @RoleID,
                [Active] = @Active
            WHERE [CookID] = @CookID AND
                  [RoleID] = @RoleID
                
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_set_assignment_activesetting
        @CookID         [int],
        @RoleID         [varchar](50),
        @Active         [bit]
    AS
        BEGIN
            UPDATE [dbo].[Assignments]
            SET [Active] = @Active
            WHERE [CookID] = @CookID AND
                  [RoleID] = @RoleID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_delete_assignment_perma
        @CookID         [int],
        @RoleID         [varchar](50)
    AS
        BEGIN
            DELETE FROM [dbo].[Assignments]
            WHERE [CookID] = @CookID AND
                  [RoleID] = @RoleID
                
            RETURN @@ROWCOUNT
        END
    GO
    
    /*ORDERS*/
    
    /*keep*/
    CREATE PROCEDURE sp_add_order
        @CustomerID     [int],
        @CookID         [int],
        @OrderDate      [datetime]
    AS
        BEGIN
            INSERT INTO [dbo].[Orders] ([CustomerID],[CookID],[OrderDate])
            VALUES (@CustomerID,@CookID,@OrderDate)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_last_order
        @CustomerID     [int],
        @CookID         [int],
        @OrderDate      [datetime]
    AS
        BEGIN
            SELECT TOP 1 [OrderID]
            FROM [dbo].[orders]
            WHERE [CustomerID] = @CustomerID AND
                  [CookID] = @CookID AND
                  [OrderDate] = @OrderDate
            ORDER BY [OrderID] DESC
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_edit_order
        @OrderID        [int],
        @CustomerID     [int],
        @CookID         [int],
        @OrderDate      [datetime],
        @Completed      [bit],
        @Paid           [bit],
        @Traded         [bit],
        @Active         [bit]
    AS
        BEGIN
            UPDATE [dbo].[Orders]
            SET [CustomerID] = @CustomerID,
                [CookID] = @CookID,
                [OrderDate] = @OrderDate,
                [Completed] = @Completed,
                [Paid] = @Paid,
                [Traded] = @Traded,
                [Active] = @Active            
            WHERE [OrderID] = @OrderID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_admin_delete_order
        @OrderID        [int],
        @CustomerID     [int]
    AS
        BEGIN
            DELETE FROM [dbo].[Orders]
            WHERE [OrderID] = @OrderID AND
                  [CustomerID] = @CustomerID AND
                  [Active] = 0
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_admin_save_deleted_order
        @OrderID        [int],
        @CustomerID     [int],
        @CookID         [int],
        @OrderDate      [datetime],
        @Completed      [bit],
        @Paid           [bit],
        @Traded         [bit],
        @Active         [bit],
        @DateDeleted    [datetime]
    AS
        BEGIN
            INSERT INTO [dbo].[OrderHistory] ([OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active],[DateDeleted])
            VALUES (@OrderID, @CustomerID, @CookID, @OrderDate, @Completed, @Paid, @Traded, @Active, @DateDeleted)
        
            RETURN @@ROWCOUNT
        END
    GO
            
    /*keep*/
    CREATE PROCEDURE sp_delete_order
        @OrderID        [int],
        @CustomerID     [int],
        @Active         [bit]
    AS
        BEGIN
            UPDATE [dbo].[Orders]
            SET [Active] = @Active
            WHERE [OrderID] = @OrderID AND
                  [CustomerID] = @CustomerID
                  
            RETURN @@ROWCOUNT
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_order_by_id
        @OrderID        [int]
    AS
        BEGIN
            SELECT [OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active]
            FROM [dbo].[Orders]
            WHERE [OrderID] = @OrderID AND
                  [Active] = 1
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_order_by_cook
        @CookID         [int]
    AS
        BEGIN
            SELECT [OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active]
            FROM [dbo].[Orders]
            WHERE [CookID] = @CookID AND
                  [Active] = 1
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_order_by_date_range
        @BeginDate      [datetime],
        @EndDate        [datetime]
    AS
        BEGIN
            SELECT [OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active]
            FROM [dbo].[Orders]
            WHERE [OrderDate] BETWEEN @BeginDate AND @EndDate
        END
    GO

    
    /*keep*/
    CREATE PROCEDURE sp_select_all_orders
        @Active         [bit]
    AS
        BEGIN
            SELECT [OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active]
            FROM [dbo].[Orders]
            WHERE [Active] = @Active
        END
    GO

    /*keep*/
    CREATE PROCEDURE sp_select_order_all
        @SearchTerm     [varchar](100),
        @Active         [bit] 
    AS
        BEGIN
            SELECT [OrderID],[CustomerID],[CookID],[OrderDate],[Completed],[Paid],[Traded],[Active]
            FROM [dbo].[Orders]
            WHERE (([OrderID] LIKE '%'+@SearchTerm+'%') OR ([CustomerID] LIKE '%'+@SearchTerm+'%') OR ([CookID] LIKE '%'+@SearchTerm+'%') OR ([OrderDate] LIKE '%'+@SearchTerm+'%') OR ([Paid] LIKE '%'+@SearchTerm+'%') OR ([Traded] LIKE '%'+@SearchTerm+'%')) AND ([Active] = @Active)
        END
    GO
    
    /*ORDER LINES*/
    
    /*keep*/
    CREATE PROCEDURE sp_add_order_lines
        @OrderID        [int],
        @RecipeID       [varchar](100),
        @Price          [int],
        @Quantity       [int]
    AS
        BEGIN
            INSERT INTO [dbo].[OrderLines] ([OrderID],[RecipeID],[Price],[Quantity])
            VALUES (@OrderID,@RecipeID,@Price,@Quantity)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_admin_delete_order_lines
        @OrderID        [int],
        @RecipeID       [varchar](100)
    AS
        BEGIN
            DELETE FROM [dbo].[OrderLines]
            WHERE [OrderID] = @OrderID AND
                  [RecipeID] = @RecipeID AND
                  [Active] = 0
                
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_delete_order_lines
        @OrderID        [int],
        @RecipeID       [varchar](100)
    AS
        BEGIN
            UPDATE [dbo].[OrderLines]
            SET [Active] = 0
            WHERE [OrderID] = @OrderID AND
                  [RecipeID] = @RecipeID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_edit_order_lines
        @OrderID        [int],
        @RecipeID       [varchar](100),
        @Price          [int],
        @Quantity       [int],
        @Active         [bit],
        @Completed      [bit]
    AS
        BEGIN
            UPDATE [dbo].[OrderLines]
            SET [Quantity] = @Quantity,
                [Price] = @Price,
                [Active] = @Active,
                [Completed] = @Completed
            WHERE [OrderID] = @OrderID AND
                  [RecipeID] = @RecipeID
                  
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_complete_order_lines
        @OrderID        [int],
        @RecipeID       [varchar](100),
        @Completed      [bit]
    AS
        BEGIN
            UPDATE [dbo].[OrderLines]
            SET [Completed] = @Completed
            WHERE [OrderID] = @OrderID AND
                  [RecipeID] = @RecipeID
                  
            RETURN @@ROWCOUNT
        END
    GO

    /*ORDER LINE DISPLAY*/
    CREATE PROCEDURE sp_select_current_order_and_items
        @OrderID        [int],
        @Active         [bit]
    AS
        BEGIN
            SELECT [OrderID],[RecipeID],[Price],[Quantity],[Price]*[Quantity] AS [Total],[Active],[Completed]
            FROM [dbo].[OrderLines]
            WHERE [OrderID] = @OrderID AND
                  [Active] = @Active
        END
    GO
    
        CREATE PROCEDURE sp_select_current_order_and_items_datecompleted
        @OrderID        [int],
        @Active         [bit]
    AS
        BEGIN
            SELECT [OrderID],[RecipeID],[Price],[Quantity],[Price]*[Quantity],[Active],[Completed],[DateCompleted]
            FROM [dbo].[OrderLines]
            WHERE [OrderID] = @OrderID AND
                  [Active] = @Active
        END
    GO
    
    /*RECIPES*/
    CREATE PROCEDURE sp_select_recipe
        @RecipeName     [varchar](100)
    AS
        BEGIN
            SELECT [RecipeID]
            FROM [dbo].[Recipes]
            WHERE [RecipeID] LIKE '%'+@RecipeName+'%'
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_recipe_list
    AS
        BEGIN
            SELECT [RecipeID]
            FROM [dbo].[Recipes]
            ORDER BY [RecipeID] ASC
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_recipe_and_item_level
    AS
        BEGIN
            SELECT [RecipeID],[ItemLevel]
            FROM [dbo].[Recipes]
            ORDER BY [RecipeID] ASC
        END
    GO
    
    /*keep*/
    CREATE PROCEDURE sp_select_recipe_stats_by_id
        @RecipeID       [varchar](100)
    AS
        BEGIN
            SELECT [RecipeID],[ItemLevel],[Mind],[MindStack],[Acc],[AccStack],[Crit],[CritStack],[Det],[DetStack],[Spell],[SpellStack],[Vit],[VitStack],[Piety],[PietyStack],[Dex],[DexStack],[Strength],[StrengthStack],[Intel],[IntelStack],[Parry],[ParryStack],[Skill],[SkillStack]
            FROM [dbo].[Recipes]
            WHERE [RecipeID] = @RecipeID
        END
    GO
    
    /*INGREDIENTS/CRYSTALS*/
    /*keep*/
    CREATE PROCEDURE sp_select_ingredients_by_recipe_id
        @RecipeID       [varchar](100)
    AS
        BEGIN
            SELECT [IngredientID],[Qty]
            FROM [dbo].[RecipeIngredients]
            WHERE [RecipeID] = @RecipeID
        END
    GO
    
    /*KEEP*/
    CREATE PROCEDURE sp_select_catalyst_by_recipe_id
        @RecipeID       [varchar](100)
    AS
        BEGIN
            SELECT [Crystal],[CrystalQty]
            FROM [dbo].[RecipeCatalysts]
            WHERE [RecipeID] = @RecipeID
        END
    GO
    
    CREATE PROCEDURE sp_select_ingredient_details
        @IngredientID   [varchar](100)
    AS
        BEGIN
            SELECT [Ingredients].[IngredientID],[Ingredients].[ItemLevel],[Ingredients].[Cooking],[Ingredients].[MobDrop],[Ingredients].[Fishing],[Ingredients].[Vendor],[Locations].[LocationName],[Locations].[LocationLocale],[Locations].[LocationLevel],[Locations].[Coordinates]
            FROM [dbo].[Ingredients] JOIN [dbo].[Locations] ON [Ingredients].[LocationID] = [Locations].[LocationID]
            WHERE [IngredientID] = @IngredientID
        END
    GO
    
    /*PASSWORDS AND STUFF*/
    
    CREATE PROCEDURE sp_validate_active_username_and_password
        @Username       [varchar](100),
        @Password       [varchar](256)
    AS
        BEGIN
            SELECT COUNT([Username])
            FROM [dbo].[Cooks]
            WHERE [Username] = @Username AND
                  [PasswordHash] = @Password AND
                  [Active] = 1
        END
    GO

    CREATE PROCEDURE sp_update_password_for_username
        @Username       [varchar](100),
        @OldPassword    [nvarchar](256),
        @NewPassword    [nvarchar](256)
    AS
        BEGIN
            UPDATE [dbo].[Cooks]
            SET [PasswordHash] = @NewPassword
            WHERE [Username] = @Username AND
                  [PasswordHash] = @OldPassword AND
                  [Active] = 1
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_select_roles_by_cook
        @CookID         [int]
    AS
        BEGIN
            SELECT [Assignments].[RoleID],[Roles].[Description]
            FROM [dbo].[Assignments] JOIN [dbo].[Roles] ON [Assignments].[RoleID] = [Roles].[RoleID]
            WHERE [CookID] = @CookID
        END
    GO
    
    CREATE PROCEDURE sp_select_cook_by_username
        @Username       [varchar](100)
    AS
        BEGIN
            SELECT [CookID],[FirstName],[LastName],[LocalPhone],[EmailAddress],[Username],[PasswordHash],[Active]
            FROM [dbo].[Cooks]
            WHERE [Username] = @Username
        END
    GO
    
    CREATE PROCEDURE sp_send_message
        @CookID         [int],
        @MessageSubject [varchar](50),
        @Message        [varchar](1000),
        @MessageDate    [datetime]
    AS
        BEGIN
            INSERT INTO [dbo].[Messages] ([CookID],[MessageSubject],[Message],[MessageDate])
            VALUES (@CookID,@MessageSubject,@Message,@MessageDate)
            
            RETURN @@ROWCOUNT
        END
    GO
    
    CREATE PROCEDURE sp_get_message_list
        @CookID         [int]
    AS
        BEGIN
            SELECT [MessageID],[MessageSubject],[Message],[MessageDate],[Active],[HasRead],[CookID]
            FROM [dbo].[Messages]
            WHERE [CookID] = @CookID
        END
    GO
    
    CREATE PROCEDURE sp_edit_message
        @CookID         [int],
        @MessageID      [int],
        @Active         [bit],
        @HasRead        [bit]
    AS
        BEGIN
            UPDATE [dbo].[Messages]
            SET [CookID] = @CookID,
                [Active] = @Active,
                [HasRead] = @HasRead
            WHERE [MessageID] = @MessageID
            
            RETURN @@ROWCOUNT
        END
    GO
    
    /*logs*/
    
    CREATE PROCEDURE sp_log_login
        @CookID         [int],
        @LoginDate      [datetime]
    AS
        BEGIN
            INSERT INTO [dbo].[LogLogins] ([CookID],[LoginDate])
            VALUES (@CookID,@LoginDate)
            
            RETURN @@ROWCOUNT
        END
    GO