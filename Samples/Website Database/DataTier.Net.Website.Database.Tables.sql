USE [DataTier.Net.Website.Database]
GO

ALTER TABLE [dbo].[Notification] DROP CONSTRAINT [DF_Notification_Verified]
GO

ALTER TABLE [dbo].[GitHubFollower] DROP CONSTRAINT [DF_GitHubFollower_NotificationId]
GO

/****** Object:  Table [dbo].[NotificationHistory]    Script Date: 5/7/2019 6:38:43 PM ******/
DROP TABLE [dbo].[NotificationHistory]
GO

/****** Object:  Table [dbo].[Notification]    Script Date: 5/7/2019 6:38:43 PM ******/
DROP TABLE [dbo].[Notification]
GO

/****** Object:  Table [dbo].[GitHubFollower]    Script Date: 5/7/2019 6:38:43 PM ******/
DROP TABLE [dbo].[GitHubFollower]
GO

/****** Object:  Table [dbo].[GitHubFollower]    Script Date: 5/7/2019 6:38:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GitHubFollower](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FollowerName] [nvarchar](50) NOT NULL,
	[FollowerSince] [datetime] NOT NULL,
	[EmailAddress] [nvarchar](80) NOT NULL,
	[NotificationId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_GitHubFollower] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Notification]    Script Date: 5/7/2019 6:38:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Notification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](80) NOT NULL,
	[GitHubUserName] [nvarchar](30) NOT NULL,
	[Verified] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[NotificationType] [int] NOT NULL,
	[LastSentDate] [bit] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotificationHistory]    Script Date: 5/7/2019 6:38:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotificationHistory](
	[Id] [int] NOT NULL,
	[NotificationId] [int] NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[Delivered] [bit] NOT NULL,
 CONSTRAINT [PK_NotificationHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GitHubFollower] ADD  CONSTRAINT [DF_GitHubFollower_NotificationId]  DEFAULT ((0)) FOR [NotificationId]
GO

ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_Verified]  DEFAULT ((0)) FOR [Verified]
GO

