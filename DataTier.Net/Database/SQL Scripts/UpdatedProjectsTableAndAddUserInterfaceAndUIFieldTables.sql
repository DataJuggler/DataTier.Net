Alter Table Project
Add UIFolderPath nvarchar(255) null

go

/****** Object:  Table [dbo].[UserInterface]    Script Date: 12/24/2020 12:10:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserInterface](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UIType] [int] NOT NULL,
	[TableName] [nvarchar](64) NOT NULL,
	[Path] [nvarchar](255) NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_UserInterfaces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UIField]    Script Date: 12/24/2020 12:13:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UIField](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserInterfaceId] [int] NOT NULL,
	[DTNFieldId] [int] NOT NULL,
	[FieldOrdinal] [int] NOT NULL,
	[DataType] [int] NOT NULL,
	[Caption] [nvarchar](40) NULL,
	[Required] [bit] NOT NULL,
	[MaxLength] [int] NOT NULL,
	[MinLength] [int] NOT NULL,
	[MaxRange] [decimal](8, 2) NOT NULL,
	[MinRange] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_UIField] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO








