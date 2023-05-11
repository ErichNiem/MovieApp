USE [MovieApp]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 2023/05/10 17:28:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](60) NOT NULL UNIQUE,
	[Category] [nvarchar](60) NOT NULL,
	[Rating] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DateTimeAdded] [datetime] NULL,
	[DateTimeUpdated] [datetime] NULL,
	[DateTimeDeleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


