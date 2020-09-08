USE [GroceryContext]
GO

/****** Object:  Table [dbo].[ProductGroceryList]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductGroceryList](
	[ProductID] [int] NOT NULL,
	[GroceryListID] [int] NOT NULL,
	[Tagged] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProductGroceryList] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[GroceryListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductGroceryList]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductGroceryList_dbo.GroceryList_GroceryListID] FOREIGN KEY([GroceryListID])
REFERENCES [dbo].[GroceryList] ([GroceryListID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductGroceryList] CHECK CONSTRAINT [FK_dbo.ProductGroceryList_dbo.GroceryList_GroceryListID]
GO

ALTER TABLE [dbo].[ProductGroceryList]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductGroceryList_dbo.Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductGroceryList] CHECK CONSTRAINT [FK_dbo.ProductGroceryList_dbo.Product_ProductID]
GO