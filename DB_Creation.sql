CREATE DATABASE [ArcadisExam];
USE [ArcadisExam]
GO
/****** Object:  Table [dbo].[exampleWorkSheet]    Script Date: 8/7/2020 12:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exampleWorkSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[Cost] [numeric](10, 4) NULL,
	[Quantity] [int] NULL,
	[TotalCost]  AS ([Cost]*[Quantity]),
	[CostInd] [char](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
