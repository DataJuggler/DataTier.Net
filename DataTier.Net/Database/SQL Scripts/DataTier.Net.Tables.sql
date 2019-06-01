
/****** Object:  Table [dbo].[CustomReader]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomReader](
	[CustomReaderId] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[ReaderName] [nvarchar](40) NOT NULL,
	[ClassName] [nvarchar](40) NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[FieldSetId] [int] NOT NULL,
 CONSTRAINT [PK_CustomReader] PRIMARY KEY CLUSTERED 
(
	[CustomReaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[DTNDatabase]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DTNDatabase](
	[DatabaseId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[DatabaseName] [nvarchar](50) NULL,
	[ServerName] [nvarchar](50) NULL,
	[DBPassword] [nvarchar](50) NULL,
	[ConnectionString] [nvarchar](255) NULL,
	[DatabaseType] [int] NULL,
	[AuthenticationType] [int] NULL,
	[Exclude] [int] NULL,
	[Path] [nvarchar](255) NULL,
	[Serializable] [bit] NOT NULL,
	[UserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_DTNDatabase] PRIMARY KEY CLUSTERED 
(
	[DatabaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[DTNField]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DTNField](
	[FieldId] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NULL,
	[DatabaseId] [int] NULL,
	[ProjectId] [int] NULL,
	[FieldName] [nvarchar](50) NULL,
	[AccessMode] [int] NULL,
	[Caption] [nvarchar](50) NULL,
	[DataType] [int] NULL,
	[DecimalPlaces] [int] NULL,
	[DefaultValue] [nvarchar](50) NULL,
	[FieldOrdinal] [int] NULL,
	[IsNullable] [int] NULL,
	[PrimaryKey] [bit] NULL,
	[Required] [bit] NULL,
	[Scope] [int] NULL,
	[FieldSize] [int] NULL,
	[Exclude] [bit] NULL,
	[IsEnumeration] [bit] NULL,
	[EnumDataTypeName] [nvarchar](40) NULL,
 CONSTRAINT [PK_DTNField] PRIMARY KEY CLUSTERED 
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[DTNTable]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DTNTable](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[DatabaseId] [int] NULL,
	[ProjectId] [int] NULL,
	[TableName] [nvarchar](50) NULL,
	[ClassFileName] [nvarchar](255) NULL,
	[ClassName] [nvarchar](50) NULL,
	[Scope] [int] NULL,
	[Serializable] [bit] NULL,
	[Exclude] [bit] NULL,
	[IsView] [bit] NULL,
 CONSTRAINT [PK_DTNTable] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Enumeration]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enumeration](
	[EnumerationId] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](50) NULL,
	[EnumerationName] [nvarchar](255) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_Enumeration] PRIMARY KEY CLUSTERED 
(
	[EnumerationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[FieldSet]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FieldSet](
	[FieldSetId] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[DatabaseId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParameterMode] [bit] NOT NULL,
	[OrderByMode] [bit] NOT NULL,
	[ReaderMode] [bit] NOT NULL,
 CONSTRAINT [PK_FieldSet] PRIMARY KEY CLUSTERED 
(
	[FieldSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[FieldSetField]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FieldSetField](
	[FieldSetFieldId] [int] IDENTITY(1,1) NOT NULL,
	[FieldSetId] [int] NOT NULL,
	[FieldId] [int] NOT NULL,
	[FieldOrdinal] [int] NOT NULL,
 CONSTRAINT [PK_FieldSetField] PRIMARY KEY CLUSTERED 
(
	[FieldSetFieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Method]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Method](
	[MethodId] [int] IDENTITY(1,1) NOT NULL,
	[MethodType] [int] NOT NULL,
	[TableId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parameters] [nvarchar](255) NULL,
	[PropertyName] [nvarchar](32) NOT NULL,
	[ProcedureName] [nvarchar](128) NOT NULL,
	[ProcedureText] [nvarchar](max) NULL,
	[ParameterType] [int] NOT NULL,
	[ParameterFieldId] [int] NULL,
	[ParametersFieldSetId] [int] NULL,
	[UseCustomReader] [bit] NOT NULL,
	[CustomReaderId] [int] NULL,
	[OrderByType] [int] NOT NULL,
	[OrderByFieldId] [int] NULL,
	[OrderByFieldSetId] [int] NULL,
	[UpdateProcedureOnBuild] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Method] PRIMARY KEY CLUSTERED 
(
	[MethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[ProjectFolder] [nvarchar](255) NULL,
	[ObjectFolder] [nvarchar](255) NULL,
	[ObjectNamespace] [nvarchar](100) NULL,
	[ObjectReferencesSetId] [int] NULL,
	[StoredProcedureObjectFolder] [nvarchar](255) NULL,
	[StoredProcedureObjectNamespace] [nvarchar](100) NULL,
	[StoredProcedureReferencesSetId] [int] NULL,
	[ReaderFolder] [nvarchar](255) NULL,
	[ReaderNamespace] [nvarchar](100) NULL,
	[ReaderReferencesSetId] [int] NULL,
	[ControllerFolder] [nvarchar](255) NULL,
	[ControllerNamespace] [nvarchar](100) NULL,
	[ControllerReferencesSetId] [int] NULL,
	[DataOperationsFolder] [nvarchar](255) NULL,
	[DataOperationsNamespace] [nvarchar](100) NULL,
	[DataOperationsReferencesSetId] [int] NULL,
	[DataManagerFolder] [nvarchar](255) NULL,
	[DataManagerNamespace] [nvarchar](100) NULL,
	[DataManagerReferencesSetId] [int] NULL,
	[StoredProcsFolder] [nvarchar](255) NULL,
	[DataWriterFolder] [nvarchar](255) NULL,
	[DataWriterNamespace] [nvarchar](100) NULL,
	[DataWriterReferencesSetId] [int] NULL,
	[ClassFileOption] [int] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ProjectReference]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectReference](
	[ReferencesId] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceName] [nvarchar](128) NULL,
	[ReferencesSetId] [int] NULL,
 CONSTRAINT [PK_ProjectReference] PRIMARY KEY CLUSTERED 
(
	[ReferencesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ReferencesSet]    Script Date: 3/25/2019 11:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReferencesSet](
	[ReferencesSetId] [int] IDENTITY(1,1) NOT NULL,
	[ReferencesSetName] [nvarchar](50) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_ReferencesSet] PRIMARY KEY CLUSTERED 
(
	[ReferencesSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  View [dbo].[FieldSetFieldView]    Script Date: 3/25/2019 11:36:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[FieldSetFieldView]
AS
SELECT dbo.FieldSetField.FieldSetFieldId, dbo.FieldSetField.FieldSetId, dbo.FieldSetField.FieldId, dbo.FieldSetField.FieldOrdinal, dbo.FieldSet.TableId, dbo.FieldSet.Name AS FieldSetName, dbo.FieldSet.ParameterMode, dbo.DTNField.DatabaseId, dbo.DTNField.ProjectId, dbo.DTNField.FieldName, 
        dbo.DTNField.DataType, dbo.DTNField.DecimalPlaces, dbo.DTNField.DefaultValue, dbo.DTNField.IsNullable, dbo.DTNField.PrimaryKey, dbo.DTNField.Required, dbo.DTNField.FieldSize, dbo.DTNField.IsEnumeration, dbo.DTNField.EnumDataTypeName, dbo.DTNField.Scope
FROM  dbo.FieldSetField INNER JOIN
        dbo.FieldSet ON dbo.FieldSetField.FieldSetId = dbo.FieldSet.FieldSetId INNER JOIN
        dbo.DTNField ON dbo.FieldSetField.FieldId = dbo.DTNField.FieldId
GO

ALTER TABLE [dbo].[DTNField] ADD  CONSTRAINT [DF__DTNField__IsEnum]  DEFAULT ((0)) FOR [IsEnumeration]
GO

ALTER TABLE [dbo].[FieldSet] ADD  CONSTRAINT [DF__FieldSet__ParameterMode]  DEFAULT ((0)) FOR [ParameterMode]
GO

ALTER TABLE [dbo].[FieldSet] ADD  CONSTRAINT [DF__FieldSet__OrderByMode]  DEFAULT ((0)) FOR [OrderByMode]
GO

ALTER TABLE [dbo].[FieldSet] ADD  CONSTRAINT [DF__FieldSet__ReaderMode]  DEFAULT ((0)) FOR [ReaderMode]
GO

ALTER TABLE [dbo].[Method] ADD  CONSTRAINT [DF_Method_UseCustomReader]  DEFAULT ((0)) FOR [UseCustomReader]
GO

ALTER TABLE [dbo].[Method] ADD  CONSTRAINT [DF_Method_OrderByType]  DEFAULT ((0)) FOR [OrderByType]
GO

ALTER TABLE [dbo].[Method] ADD  CONSTRAINT [DF_Method_UpdateProcedureOnBuild]  DEFAULT ((0)) FOR [UpdateProcedureOnBuild]
GO

ALTER TABLE [dbo].[Method] ADD  CONSTRAINT [DF_Method_Active]  DEFAULT ((0)) FOR [Active]
GO

ALTER TABLE [dbo].[CustomReader]  WITH CHECK ADD  CONSTRAINT [FK_DTNTable_TableId3] FOREIGN KEY([TableId])
REFERENCES [dbo].[DTNTable] ([TableId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CustomReader] CHECK CONSTRAINT [FK_DTNTable_TableId3]
GO

ALTER TABLE [dbo].[CustomReader]  WITH CHECK ADD  CONSTRAINT [FK_FieldSet_FieldSetId2] FOREIGN KEY([FieldSetId])
REFERENCES [dbo].[FieldSet] ([FieldSetId])
GO

ALTER TABLE [dbo].[CustomReader] CHECK CONSTRAINT [FK_FieldSet_FieldSetId2]
GO

ALTER TABLE [dbo].[DTNDatabase]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DTNDatabase] CHECK CONSTRAINT [FK_Project_ProjectId]
GO

ALTER TABLE [dbo].[DTNField]  WITH CHECK ADD  CONSTRAINT [FK_DTNTable_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[DTNTable] ([TableId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DTNField] CHECK CONSTRAINT [FK_DTNTable_TableId]
GO

ALTER TABLE [dbo].[DTNTable]  WITH CHECK ADD  CONSTRAINT [FK_Database_DatabaseId] FOREIGN KEY([DatabaseId])
REFERENCES [dbo].[DTNDatabase] ([DatabaseId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DTNTable] CHECK CONSTRAINT [FK_Database_DatabaseId]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [UC_DTNTable_DBIdAndTableName]    Script Date: 3/25/2019 11:50:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UC_DTNTable_DBIdAndTableName] ON [dbo].[DTNTable]
(
	[DatabaseId] ASC,
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [UC_DTNField_TableIdAndFieldName]    Script Date: 3/25/2019 11:51:43 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UC_DTNField_TableIdAndFieldName] ON [dbo].[DTNField]
(
	[TableId] ASC,
	[FieldName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enumeration]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectId2] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Enumeration] CHECK CONSTRAINT [FK_Project_ProjectId2]
GO

ALTER TABLE [dbo].[FieldSet]  WITH CHECK ADD  CONSTRAINT [FK_DTNTable_TableId2] FOREIGN KEY([TableId])
REFERENCES [dbo].[DTNTable] ([TableId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FieldSet] CHECK CONSTRAINT [FK_DTNTable_TableId2]
GO

ALTER TABLE [dbo].[FieldSetField]  WITH CHECK ADD  CONSTRAINT [FK_FieldSet_FieldSetId] FOREIGN KEY([FieldSetId])
REFERENCES [dbo].[FieldSet] ([FieldSetId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FieldSetField] CHECK CONSTRAINT [FK_FieldSet_FieldSetId]
GO

ALTER TABLE [dbo].[Method]  WITH CHECK ADD  CONSTRAINT [FK_DTNTable_TableId4] FOREIGN KEY([TableId])
REFERENCES [dbo].[DTNTable] ([TableId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Method] CHECK CONSTRAINT [FK_DTNTable_TableId4]
GO

ALTER TABLE [dbo].[Method]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectId4] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[Method] CHECK CONSTRAINT [FK_Project_ProjectId4]
GO

ALTER TABLE [dbo].[ProjectReference]  WITH CHECK ADD  CONSTRAINT [FK_ReferencesSet_ReferencesSetId] FOREIGN KEY([ReferencesSetId])
REFERENCES [dbo].[ReferencesSet] ([ReferencesSetId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProjectReference] CHECK CONSTRAINT [FK_ReferencesSet_ReferencesSetId]
GO

ALTER TABLE [dbo].[ReferencesSet]  WITH CHECK ADD  CONSTRAINT [FK_ProjectId_ProjectId3] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ReferencesSet] CHECK CONSTRAINT [FK_ProjectId_ProjectId3]
GO


