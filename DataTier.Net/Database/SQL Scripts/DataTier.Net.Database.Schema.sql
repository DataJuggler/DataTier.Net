Use [DataTier.Net.Database]

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


/****** Object:  Table [dbo].[DTNProcedure]    Script Date: 6/1/2019 9:24:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DTNProcedure](
	[ProcedureId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_DTNProcedure] PRIMARY KEY CLUSTERED 
(
	[ProcedureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DTNProcedure] ADD  CONSTRAINT [DF_DTNProcedure_Active]  DEFAULT ((1)) FOR [Active]
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



/****** Object:  StoredProcedure [dbo].[CustomReader_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CustomReader_Delete]

    -- Primary Key Paramater
    @CustomReaderId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [CustomReader]

    -- Delete Matching Record
    Where [CustomReaderId] = @CustomReaderId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[CustomReader_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CustomReader_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassName],[CustomReaderId],[FieldSetId],[FileName],[ReaderName],[TableId]

    -- From tableName
    From [CustomReader]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[CustomReader_FetchAllForTable]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[CustomReader_FetchAllForTable]

	-- Parameter for TableId
	@TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [ClassName],[CustomReaderId],[FieldSetId],[FileName],[ReaderName],[TableId]
    
    -- From tableName
    From [CustomReader]

	-- Only return readers for the Table given
	Where [TableId] = @TableId

	-- Order by ReaderName
	Order By [ReaderName]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[CustomReader_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CustomReader_Find]

    -- Primary Key Paramater
    @CustomReaderId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassName],[CustomReaderId],[FieldSetId],[FileName],[ReaderName],[TableId]

    -- From tableName
    From [CustomReader]

    -- Find Matching Record
    Where [CustomReaderId] = @CustomReaderId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[CustomReader_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CustomReader_Insert]

    -- Add the parameters for the stored procedure here
    @ClassName nvarchar(40),
    @FieldSetId int,
    @FileName nvarchar(255),
    @ReaderName nvarchar(40),
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [CustomReader]
    ([ClassName],[FieldSetId],[FileName],[ReaderName],[TableId])

    -- Begin Values List
    Values(@ClassName, @FieldSetId, @FileName, @ReaderName, @TableId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[CustomReader_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CustomReader_Update]

    -- Add the parameters for the stored procedure here
    @ClassName nvarchar(40),
    @CustomReaderId int,
    @FieldSetId int,
    @FileName nvarchar(255),
    @ReaderName nvarchar(40),
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [CustomReader]

    -- Update Each field
    Set [ClassName] = @ClassName,
    [FieldSetId] = @FieldSetId,
    [FileName] = @FileName,
    [ReaderName] = @ReaderName,
    [TableId] = @TableId

    -- Update Matching Record
    Where [CustomReaderId] = @CustomReaderId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNDatabase_Delete]

    -- Primary Key Paramater
    @DatabaseId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DTNDatabase]

    -- Delete Matching Record
    Where [DatabaseId] = @DatabaseId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNDatabase_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AuthenticationType],[ConnectionString],[DatabaseId],[DatabaseName],[DatabaseType],[DBPassword],[Exclude],[Path],[ProjectId],[Serializable],[ServerName],[UserId]

    -- From tableName
    From [DTNDatabase]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_FetchAllForProject]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [dbo].[DTNDatabase_FetchAllForProject]

	-- Parameter For ProjectID
	@ProjectID int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AuthenticationType],[ConnectionString],[DatabaseID],[DatabaseName],[DatabaseType],[DBPassword],[Exclude],[Path],[ProjectID],[Serializable],[ServerName],[UserID]

    -- From tableName
    From [DTNDatabase]
    
    -- Only Return Databases For This Project
    Where [ProjectID] = @ProjectID

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNDatabase_Find]

    -- Primary Key Paramater
    @DatabaseId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AuthenticationType],[ConnectionString],[DatabaseId],[DatabaseName],[DatabaseType],[DBPassword],[Exclude],[Path],[ProjectId],[Serializable],[ServerName],[UserId]

    -- From tableName
    From [DTNDatabase]

    -- Find Matching Record
    Where [DatabaseId] = @DatabaseId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNDatabase_Insert]

    -- Add the parameters for the stored procedure here
    @AuthenticationType int,
    @ConnectionString nvarchar(255),
    @DatabaseName nvarchar(50),
    @DatabaseType int,
    @DBPassword nvarchar(50),
    @Exclude int,
    @Path nvarchar(255),
    @ProjectId int,
    @Serializable bit,
    @ServerName nvarchar(50),
    @UserId nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DTNDatabase]
    ([AuthenticationType],[ConnectionString],[DatabaseName],[DatabaseType],[DBPassword],[Exclude],[Path],[ProjectId],[Serializable],[ServerName],[UserId])

    -- Begin Values List
    Values(@AuthenticationType, @ConnectionString, @DatabaseName, @DatabaseType, @DBPassword, @Exclude, @Path, @ProjectId, @Serializable, @ServerName, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNDatabase_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNDatabase_Update]

    -- Add the parameters for the stored procedure here
    @AuthenticationType int,
    @ConnectionString nvarchar(255),
    @DatabaseId int,
    @DatabaseName nvarchar(50),
    @DatabaseType int,
    @DBPassword nvarchar(50),
    @Exclude int,
    @Path nvarchar(255),
    @ProjectId int,
    @Serializable bit,
    @ServerName nvarchar(50),
    @UserId nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DTNDatabase]

    -- Update Each field
    Set [AuthenticationType] = @AuthenticationType,
    [ConnectionString] = @ConnectionString,
    [DatabaseName] = @DatabaseName,
    [DatabaseType] = @DatabaseType,
    [DBPassword] = @DBPassword,
    [Exclude] = @Exclude,
    [Path] = @Path,
    [ProjectId] = @ProjectId,
    [Serializable] = @Serializable,
    [ServerName] = @ServerName,
    [UserId] = @UserId

    -- Update Matching Record
    Where [DatabaseId] = @DatabaseId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNField_Delete]

    -- Primary Key Paramater
    @FieldId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DTNField]

    -- Delete Matching Record
    Where [FieldId] = @FieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNField_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AccessMode],[Caption],[DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[Exclude],[FieldId],[FieldName],[FieldOrdinal],[FieldSize],[IsEnumeration],[IsNullable],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId]

    -- From tableName
    From [DTNField]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_FetchAllForTableId]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DTNField_FetchAllForTableId]

	-- Parameter for @TableId
	@TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [AccessMode],[Caption],[DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[Exclude],[FieldId],[FieldName],[FieldOrdinal],[FieldSize],[IsEnumeration],[IsNullable],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId]
    
    -- From tableName
    From [DTNField]

	-- Only return fields for this Table
	Where [TableId] = @TableId

	-- Sort by FieldName
	Order By [FieldName]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNField_Find]

    -- Primary Key Paramater
    @FieldId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AccessMode],[Caption],[DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[Exclude],[FieldId],[FieldName],[FieldOrdinal],[FieldSize],[IsEnumeration],[IsNullable],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId]

    -- From tableName
    From [DTNField]

    -- Find Matching Record
    Where [FieldId] = @FieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNField_Insert]

    -- Add the parameters for the stored procedure here
    @AccessMode int,
    @Caption nvarchar(50),
    @DatabaseId int,
    @DataType int,
    @DecimalPlaces int,
    @DefaultValue nvarchar(50),
    @EnumDataTypeName nvarchar(40),
    @Exclude bit,
    @FieldName nvarchar(50),
    @FieldOrdinal int,
    @FieldSize int,
    @IsEnumeration bit,
    @IsNullable int,
    @PrimaryKey bit,
    @ProjectId int,
    @Required bit,
    @Scope int,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DTNField]
    ([AccessMode],[Caption],[DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[Exclude],[FieldName],[FieldOrdinal],[FieldSize],[IsEnumeration],[IsNullable],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId])

    -- Begin Values List
    Values(@AccessMode, @Caption, @DatabaseId, @DataType, @DecimalPlaces, @DefaultValue, @EnumDataTypeName, @Exclude, @FieldName, @FieldOrdinal, @FieldSize, @IsEnumeration, @IsNullable, @PrimaryKey, @ProjectId, @Required, @Scope, @TableId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNField_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNField_Update]

    -- Add the parameters for the stored procedure here
    @AccessMode int,
    @Caption nvarchar(50),
    @DatabaseId int,
    @DataType int,
    @DecimalPlaces int,
    @DefaultValue nvarchar(50),
    @EnumDataTypeName nvarchar(40),
    @Exclude bit,
    @FieldId int,
    @FieldName nvarchar(50),
    @FieldOrdinal int,
    @FieldSize int,
    @IsEnumeration bit,
    @IsNullable int,
    @PrimaryKey bit,
    @ProjectId int,
    @Required bit,
    @Scope int,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DTNField]

    -- Update Each field
    Set [AccessMode] = @AccessMode,
    [Caption] = @Caption,
    [DatabaseId] = @DatabaseId,
    [DataType] = @DataType,
    [DecimalPlaces] = @DecimalPlaces,
    [DefaultValue] = @DefaultValue,
    [EnumDataTypeName] = @EnumDataTypeName,
    [Exclude] = @Exclude,
    [FieldName] = @FieldName,
    [FieldOrdinal] = @FieldOrdinal,
    [FieldSize] = @FieldSize,
    [IsEnumeration] = @IsEnumeration,
    [IsNullable] = @IsNullable,
    [PrimaryKey] = @PrimaryKey,
    [ProjectId] = @ProjectId,
    [Required] = @Required,
    [Scope] = @Scope,
    [TableId] = @TableId

    -- Update Matching Record
    Where [FieldId] = @FieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNProcedure_Delete]

    -- Primary Key Paramater
    @ProcedureId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DTNProcedure]

    -- Delete Matching Record
    Where [ProcedureId] = @ProcedureId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNProcedure_FetchAll]    Script Date: 6/1/2019 9:25:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[DTNProcedure_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[Name],[ProcedureId],[ProjectId],[TableId]

    -- From tableName
    From [DTNProcedure]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNProcedure_Find]    Script Date: 6/1/2019 9:25:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[DTNProcedure_Find]

    -- Primary Key Paramater
    @ProcedureId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[Name],[ProcedureId],[ProjectId],[TableId]

    -- From tableName
    From [DTNProcedure]

    -- Find Matching Record
    Where [ProcedureId] = @ProcedureId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNProcedure_Insert]    Script Date: 6/1/2019 9:25:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[DTNProcedure_Insert]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @Name nvarchar(50),
    @ProjectId int,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DTNProcedure]
    ([Active],[Name],[ProjectId],[TableId])

    -- Begin Values List
    Values(@Active, @Name, @ProjectId, @TableId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNProcedure_Update]    Script Date: 6/1/2019 9:25:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[DTNProcedure_Update]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @Name nvarchar(50),
    @ProcedureId int,
    @ProjectId int,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DTNProcedure]

    -- Update Each field
    Set [Active] = @Active,
    [Name] = @Name,
    [ProjectId] = @ProjectId,
    [TableId] = @TableId

    -- Update Matching Record
    Where [ProcedureId] = @ProcedureId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



/****** Object:  StoredProcedure [dbo].[DTNTable_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNTable_Delete]

    -- Primary Key Paramater
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DTNTable]

    -- Delete Matching Record
    Where [TableId] = @TableId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_DeleteAllForProject]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[DTNTable_DeleteAllForProject]

    -- ProjectId Paramater
    @ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DTNTable]

    -- Delete All Tables For This Project
    Where [ProjectID] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNTable_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassFileName],[ClassName],[DatabaseId],[Exclude],[IsView],[ProjectId],[Scope],[Serializable],[TableId],[TableName]

    -- From tableName
    From [DTNTable]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_FetchAllForProjectId]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DTNTable_FetchAllForProjectId]

	-- parameter for ProjectId
	@ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [ClassFileName],[ClassName],[DatabaseId],[Exclude],[IsView],[ProjectId],[Scope],[Serializable],[TableId],[TableName]
    
    -- From tableName
    From [DTNTable]

	-- Only return tables for this project
	Where [ProjectId] = @ProjectId

	-- Order By TableName
	Order By TableName

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNTable_Find]

    -- Primary Key Paramater
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassFileName],[ClassName],[DatabaseId],[Exclude],[IsView],[ProjectId],[Scope],[Serializable],[TableId],[TableName]

    -- From tableName
    From [DTNTable]

    -- Find Matching Record
    Where [TableId] = @TableId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNTable_Insert]

    -- Add the parameters for the stored procedure here
    @ClassFileName nvarchar(255),
    @ClassName nvarchar(50),
    @DatabaseId int,
    @Exclude bit,
    @IsView bit,
    @ProjectId int,
    @Scope int,
    @Serializable bit,
    @TableName nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DTNTable]
    ([ClassFileName],[ClassName],[DatabaseId],[Exclude],[IsView],[ProjectId],[Scope],[Serializable],[TableName])

    -- Begin Values List
    Values(@ClassFileName, @ClassName, @DatabaseId, @Exclude, @IsView, @ProjectId, @Scope, @Serializable, @TableName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[DTNTable_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[DTNTable_Update]

    -- Add the parameters for the stored procedure here
    @ClassFileName nvarchar(255),
    @ClassName nvarchar(50),
    @DatabaseId int,
    @Exclude bit,
    @IsView bit,
    @ProjectId int,
    @Scope int,
    @Serializable bit,
    @TableId int,
    @TableName nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DTNTable]

    -- Update Each field
    Set [ClassFileName] = @ClassFileName,
    [ClassName] = @ClassName,
    [DatabaseId] = @DatabaseId,
    [Exclude] = @Exclude,
    [IsView] = @IsView,
    [ProjectId] = @ProjectId,
    [Scope] = @Scope,
    [Serializable] = @Serializable,
    [TableName] = @TableName

    -- Update Matching Record
    Where [TableId] = @TableId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Enumeration_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Enumeration_Delete]

    -- Primary Key Paramater
    @EnumerationId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Enumeration]

    -- Delete Matching Record
    Where [EnumerationId] = @EnumerationId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Enumeration_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Enumeration_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [EnumerationId],[EnumerationName],[FieldName],[ProjectId]

    -- From tableName
    From [Enumeration]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Enumeration_FetchAllForProject]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [dbo].[Enumeration_FetchAllForProject]

	-- Parameter for ProjectID
	@ProjectID int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [EnumerationID],[EnumerationName],[FieldName],[ProjectID]

    -- From tableName
    From [Enumeration]
    
    -- Only Return Enumerations for this project
    Where [ProjectID] = @ProjectID
    
    -- Order By EnumerationName
    Order By [EnumerationName]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

GO

/****** Object:  StoredProcedure [dbo].[Enumeration_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Enumeration_Find]

    -- Primary Key Paramater
    @EnumerationId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [EnumerationId],[EnumerationName],[FieldName],[ProjectId]

    -- From tableName
    From [Enumeration]

    -- Find Matching Record
    Where [EnumerationId] = @EnumerationId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Enumeration_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Enumeration_Insert]

    -- Add the parameters for the stored procedure here
    @EnumerationName nvarchar(255),
    @FieldName nvarchar(50),
    @ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Enumeration]
    ([EnumerationName],[FieldName],[ProjectId])

    -- Begin Values List
    Values(@EnumerationName, @FieldName, @ProjectId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Enumeration_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Enumeration_Update]

    -- Add the parameters for the stored procedure here
    @EnumerationId int,
    @EnumerationName nvarchar(255),
    @FieldName nvarchar(50),
    @ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Enumeration]

    -- Update Each field
    Set [EnumerationName] = @EnumerationName,
    [FieldName] = @FieldName,
    [ProjectId] = @ProjectId

    -- Update Matching Record
    Where [EnumerationId] = @EnumerationId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSet_Delete]

    -- Primary Key Paramater
    @FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [FieldSet]

    -- Delete Matching Record
    Where [FieldSetId] = @FieldSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSet_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [DatabaseId],[FieldSetId],[Name],[OrderByMode],[ParameterMode],[ProjectId],[ReaderMode],[TableId]

    -- From tableName
    From [FieldSet]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_FetchAllForTable]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[FieldSet_FetchAllForTable]

	-- Parameter for TableId
	@TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [DatabaseId],[FieldSetId],[Name],[OrderByMode],[ParameterMode],[ProjectId],[ReaderMode],[TableId]
	
    -- From tableName
    From [FieldSet]

	-- Only return FieldSets for the TableId given
	Where [TableId] = @TableId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_FetchAllInParameterModeForTable]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[FieldSet_FetchAllInParameterModeForTable]

	-- Parameter for TableId
	@TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [DatabaseId],[FieldSetId],[Name],[OrderByMode],[ParameterMode],[ProjectId],[ReaderMode],[TableId]
	
    -- From tableName
    From [FieldSet]

	-- Only return FieldSets for the TableId given
	Where [TableId] = @TableId And [ParameterMode] = 1

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSet_Find]

    -- Primary Key Paramater
    @FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [DatabaseId],[FieldSetId],[Name],[OrderByMode],[ParameterMode],[ProjectId],[ReaderMode],[TableId]

    -- From tableName
    From [FieldSet]

    -- Find Matching Record
    Where [FieldSetId] = @FieldSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSet_Insert]

    -- Add the parameters for the stored procedure here
    @DatabaseId int,
    @Name nvarchar(50),
    @OrderByMode bit,
    @ParameterMode bit,
    @ProjectId int,
    @ReaderMode bit,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [FieldSet]
    ([DatabaseId],[Name],[OrderByMode],[ParameterMode],[ProjectId],[ReaderMode],[TableId])

    -- Begin Values List
    Values(@DatabaseId, @Name, @OrderByMode, @ParameterMode, @ProjectId, @ReaderMode, @TableId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSet_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSet_Update]

    -- Add the parameters for the stored procedure here
    @DatabaseId int,
    @FieldSetId int,
    @Name nvarchar(50),
    @OrderByMode bit,
    @ParameterMode bit,
    @ProjectId int,
    @ReaderMode bit,
    @TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [FieldSet]

    -- Update Each field
    Set [DatabaseId] = @DatabaseId,
    [Name] = @Name,
    [OrderByMode] = @OrderByMode,
    [ParameterMode] = @ParameterMode,
    [ProjectId] = @ProjectId,
    [ReaderMode] = @ReaderMode,
    [TableId] = @TableId

    -- Update Matching Record
    Where [FieldSetId] = @FieldSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_Delete]

    -- Primary Key Paramater
    @FieldSetFieldId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [FieldSetField]

    -- Delete Matching Record
    Where [FieldSetFieldId] = @FieldSetFieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_DeleteAllForFieldSetId]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_DeleteAllForFieldSetId]

    -- FieldSetId
    @FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [FieldSetField]

    -- Delete Matching Record
    Where [FieldSetId] = @FieldSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [FieldId],[FieldOrdinal],[FieldSetFieldId],[FieldSetId]

    -- From tableName
    From [FieldSetField]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_FetchAllForFieldSet]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[FieldSetField_FetchAllForFieldSet]

	-- Parameter for FieldSetId
	@FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [FieldId],[FieldOrdinal],[FieldSetFieldId],[FieldSetId]

    -- From tableName
    From [FieldSetField]

	-- Only return items for this FieldSet
	Where [FieldSetId] = @FieldSetId

	-- Order by the FieldOrdinal
	Order By [FieldOrdinal]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_Find]

    -- Primary Key Paramater
    @FieldSetFieldId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [FieldId],[FieldOrdinal],[FieldSetFieldId],[FieldSetId]

    -- From tableName
    From [FieldSetField]

    -- Find Matching Record
    Where [FieldSetFieldId] = @FieldSetFieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_Insert]

    -- Add the parameters for the stored procedure here
    @FieldId int,
    @FieldOrdinal int,
    @FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [FieldSetField]
    ([FieldId],[FieldOrdinal],[FieldSetId])

    -- Begin Values List
    Values(@FieldId, @FieldOrdinal, @FieldSetId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetField_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetField_Update]

    -- Add the parameters for the stored procedure here
    @FieldId int,
    @FieldOrdinal int,
    @FieldSetFieldId int,
    @FieldSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [FieldSetField]

    -- Update Each field
    Set [FieldId] = @FieldId,
    [FieldOrdinal] = @FieldOrdinal,
    [FieldSetId] = @FieldSetId

    -- Update Matching Record
    Where [FieldSetFieldId] = @FieldSetFieldId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetFieldView_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[FieldSetFieldView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[FieldId],[FieldName],[FieldOrdinal],[FieldSetFieldId],[FieldSetId],[FieldSetName],[FieldSize],[IsEnumeration],[IsNullable],[ParameterMode],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId]

    -- From tableName
    From [FieldSetFieldView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[FieldSetFieldView_FetchAllByFieldSetId]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FieldSetFieldView_FetchAllByFieldSetId]

    -- Create @FieldSetId Paramater
    @FieldSetId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [DatabaseId],[DataType],[DecimalPlaces],[DefaultValue],[EnumDataTypeName],[FieldId],[FieldName],[FieldOrdinal],[FieldSetFieldId],[FieldSetId],[FieldSetName],[FieldSize],[IsEnumeration],[IsNullable],[ParameterMode],[PrimaryKey],[ProjectId],[Required],[Scope],[TableId]
	
    -- From tableName
    From [FieldSetFieldView]

    -- Load Matching Records
    Where [FieldSetId] = @FieldSetId

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO

/****** Object:  StoredProcedure [dbo].[Method_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Method_Delete]

    -- Primary Key Paramater
    @MethodId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Method]

    -- Delete Matching Record
    Where [MethodId] = @MethodId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Method_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Method_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CustomReaderId],[MethodId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader]

    -- From tableName
    From [Method]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Method_FetchAllByProjectId]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Method_FetchAllByProjectId]

    -- Create @ProjectId Paramater
    @ProjectId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [Active],[CustomReaderId],[MethodId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader]
	
    -- From tableName
    From [Method]

    -- Load Matching Records
    Where [ProjectId] = @ProjectId

END
GO

/****** Object:  StoredProcedure [dbo].[Method_FetchAllForTable]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[Method_FetchAllForTable]

	-- Parameter for TableId
	@TableId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [Active],[CustomReaderId],[MethodId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader]
	
    -- From tableName
    From [Method]

	-- Only return items for this TableId
	Where [TableId] = @TableId

	-- Order by the Method Name
	Order By [Name]
	

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Method_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Method_Find]

    -- Primary Key Paramater
    @MethodId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CustomReaderId],[MethodId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader]

    -- From tableName
    From [Method]

    -- Find Matching Record
    Where [MethodId] = @MethodId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Method_FindByName]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Method_FindByName]

    -- Create @Name Paramater
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
	Select [Active],[CustomReaderId],[MethodId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader]
    
    -- From tableName
    From [Method]

    -- Find Matching Record
    Where [Name] = @Name

END
GO

/****** Object:  StoredProcedure [dbo].[Method_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Method_Insert]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CustomReaderId int,
    @MethodType int,
    @Name nvarchar(50),
    @OrderByFieldId int,
    @OrderByFieldSetId int,
    @OrderByType int,
    @ParameterFieldId int,
    @Parameters nvarchar(255),
    @ParametersFieldSetId int,
    @ParameterType int,
    @ProcedureName nvarchar(128),
    @ProcedureText nvarchar(max),
    @ProjectId int,
    @PropertyName nvarchar(32),
    @TableId int,
    @UpdateProcedureOnBuild bit,
    @UseCustomReader bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Method]
    ([Active],[CustomReaderId],[MethodType],[Name],[OrderByFieldId],[OrderByFieldSetId],[OrderByType],[ParameterFieldId],[Parameters],[ParametersFieldSetId],[ParameterType],[ProcedureName],[ProcedureText],[ProjectId],[PropertyName],[TableId],[UpdateProcedureOnBuild],[UseCustomReader])

    -- Begin Values List
    Values(@Active, @CustomReaderId, @MethodType, @Name, @OrderByFieldId, @OrderByFieldSetId, @OrderByType, @ParameterFieldId, @Parameters, @ParametersFieldSetId, @ParameterType, @ProcedureName, @ProcedureText, @ProjectId, @PropertyName, @TableId, @UpdateProcedureOnBuild, @UseCustomReader)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Method_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Method_Update]

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CustomReaderId int,
    @MethodId int,
    @MethodType int,
    @Name nvarchar(50),
    @OrderByFieldId int,
    @OrderByFieldSetId int,
    @OrderByType int,
    @ParameterFieldId int,
    @Parameters nvarchar(255),
    @ParametersFieldSetId int,
    @ParameterType int,
    @ProcedureName nvarchar(128),
    @ProcedureText nvarchar(max),
    @ProjectId int,
    @PropertyName nvarchar(32),
    @TableId int,
    @UpdateProcedureOnBuild bit,
    @UseCustomReader bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Method]

    -- Update Each field
    Set [Active] = @Active,
    [CustomReaderId] = @CustomReaderId,
    [MethodType] = @MethodType,
    [Name] = @Name,
    [OrderByFieldId] = @OrderByFieldId,
    [OrderByFieldSetId] = @OrderByFieldSetId,
    [OrderByType] = @OrderByType,
    [ParameterFieldId] = @ParameterFieldId,
    [Parameters] = @Parameters,
    [ParametersFieldSetId] = @ParametersFieldSetId,
    [ParameterType] = @ParameterType,
    [ProcedureName] = @ProcedureName,
    [ProcedureText] = @ProcedureText,
    [ProjectId] = @ProjectId,
    [PropertyName] = @PropertyName,
    [TableId] = @TableId,
    [UpdateProcedureOnBuild] = @UpdateProcedureOnBuild,
    [UseCustomReader] = @UseCustomReader

    -- Update Matching Record
    Where [MethodId] = @MethodId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Delete]

    -- Primary Key Paramater
    @ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Project]

    -- Delete Matching Record
    Where [ProjectId] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassFileOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectId],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder]

    -- From tableName
    From [Project]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Find]

    -- Primary Key Paramater
    @ProjectId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClassFileOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectId],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder]

    -- From tableName
    From [Project]

    -- Find Matching Record
    Where [ProjectId] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Insert]

    -- Add the parameters for the stored procedure here
    @ClassFileOption int,
    @ControllerFolder nvarchar(255),
    @ControllerNamespace nvarchar(100),
    @ControllerReferencesSetId int,
    @DataManagerFolder nvarchar(255),
    @DataManagerNamespace nvarchar(100),
    @DataManagerReferencesSetId int,
    @DataOperationsFolder nvarchar(255),
    @DataOperationsNamespace nvarchar(100),
    @DataOperationsReferencesSetId int,
    @DataWriterFolder nvarchar(255),
    @DataWriterNamespace nvarchar(100),
    @DataWriterReferencesSetId int,
    @DateModified datetime,
    @ObjectFolder nvarchar(255),
    @ObjectNamespace nvarchar(100),
    @ObjectReferencesSetId int,
    @ProjectFolder nvarchar(255),
    @ProjectName nvarchar(50),
    @ReaderFolder nvarchar(255),
    @ReaderNamespace nvarchar(100),
    @ReaderReferencesSetId int,
    @StoredProcedureObjectFolder nvarchar(255),
    @StoredProcedureObjectNamespace nvarchar(100),
    @StoredProcedureReferencesSetId int,
    @StoredProcsFolder nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Project]
    ([ClassFileOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder])

    -- Begin Values List
    Values(@ClassFileOption, @ControllerFolder, @ControllerNamespace, @ControllerReferencesSetId, @DataManagerFolder, @DataManagerNamespace, @DataManagerReferencesSetId, @DataOperationsFolder, @DataOperationsNamespace, @DataOperationsReferencesSetId, @DataWriterFolder, @DataWriterNamespace, @DataWriterReferencesSetId, @DateModified, @ObjectFolder, @ObjectNamespace, @ObjectReferencesSetId, @ProjectFolder, @ProjectName, @ReaderFolder, @ReaderNamespace, @ReaderReferencesSetId, @StoredProcedureObjectFolder, @StoredProcedureObjectNamespace, @StoredProcedureReferencesSetId, @StoredProcsFolder)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Update]

    -- Add the parameters for the stored procedure here
    @ClassFileOption int,
    @ControllerFolder nvarchar(255),
    @ControllerNamespace nvarchar(100),
    @ControllerReferencesSetId int,
    @DataManagerFolder nvarchar(255),
    @DataManagerNamespace nvarchar(100),
    @DataManagerReferencesSetId int,
    @DataOperationsFolder nvarchar(255),
    @DataOperationsNamespace nvarchar(100),
    @DataOperationsReferencesSetId int,
    @DataWriterFolder nvarchar(255),
    @DataWriterNamespace nvarchar(100),
    @DataWriterReferencesSetId int,
    @DateModified datetime,
    @ObjectFolder nvarchar(255),
    @ObjectNamespace nvarchar(100),
    @ObjectReferencesSetId int,
    @ProjectFolder nvarchar(255),
    @ProjectId int,
    @ProjectName nvarchar(50),
    @ReaderFolder nvarchar(255),
    @ReaderNamespace nvarchar(100),
    @ReaderReferencesSetId int,
    @StoredProcedureObjectFolder nvarchar(255),
    @StoredProcedureObjectNamespace nvarchar(100),
    @StoredProcedureReferencesSetId int,
    @StoredProcsFolder nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Project]

    -- Update Each field
    Set [ClassFileOption] = @ClassFileOption,
    [ControllerFolder] = @ControllerFolder,
    [ControllerNamespace] = @ControllerNamespace,
    [ControllerReferencesSetId] = @ControllerReferencesSetId,
    [DataManagerFolder] = @DataManagerFolder,
    [DataManagerNamespace] = @DataManagerNamespace,
    [DataManagerReferencesSetId] = @DataManagerReferencesSetId,
    [DataOperationsFolder] = @DataOperationsFolder,
    [DataOperationsNamespace] = @DataOperationsNamespace,
    [DataOperationsReferencesSetId] = @DataOperationsReferencesSetId,
    [DataWriterFolder] = @DataWriterFolder,
    [DataWriterNamespace] = @DataWriterNamespace,
    [DataWriterReferencesSetId] = @DataWriterReferencesSetId,
    [DateModified] = @DateModified,
    [ObjectFolder] = @ObjectFolder,
    [ObjectNamespace] = @ObjectNamespace,
    [ObjectReferencesSetId] = @ObjectReferencesSetId,
    [ProjectFolder] = @ProjectFolder,
    [ProjectName] = @ProjectName,
    [ReaderFolder] = @ReaderFolder,
    [ReaderNamespace] = @ReaderNamespace,
    [ReaderReferencesSetId] = @ReaderReferencesSetId,
    [StoredProcedureObjectFolder] = @StoredProcedureObjectFolder,
    [StoredProcedureObjectNamespace] = @StoredProcedureObjectNamespace,
    [StoredProcedureReferencesSetId] = @StoredProcedureReferencesSetId,
    [StoredProcsFolder] = @StoredProcsFolder

    -- Update Matching Record
    Where [ProjectId] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ProjectReference_Delete]

    -- Primary Key Paramater
    @ReferencesId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ProjectReference]

    -- Delete Matching Record
    Where [ReferencesId] = @ReferencesId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ProjectReference_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ReferenceName],[ReferencesId],[ReferencesSetId]

    -- From tableName
    From [ProjectReference]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_FetchAllForReferencesSet]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [dbo].[ProjectReference_FetchAllForReferencesSet]

	-- Parameter For ReferencesSet
	@ReferencesSetID int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ReferenceName],[ReferencesID],[ReferencesSetID]

    -- From tableName
    From [ProjectReference]
    
    -- Return ReferencesSet
    Where [ReferencesSetID] = @ReferencesSetID
    
    -- Order By ReferenceName
    Order By [ReferenceName]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ProjectReference_Find]

    -- Primary Key Paramater
    @ReferencesId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ReferenceName],[ReferencesId],[ReferencesSetId]

    -- From tableName
    From [ProjectReference]

    -- Find Matching Record
    Where [ReferencesId] = @ReferencesId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ProjectReference_Insert]

    -- Add the parameters for the stored procedure here
    @ReferenceName nvarchar(128),
    @ReferencesSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ProjectReference]
    ([ReferenceName],[ReferencesSetId])

    -- Begin Values List
    Values(@ReferenceName, @ReferencesSetId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ProjectReference_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ProjectReference_Update]

    -- Add the parameters for the stored procedure here
    @ReferenceName nvarchar(128),
    @ReferencesId int,
    @ReferencesSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ProjectReference]

    -- Update Each field
    Set [ReferenceName] = @ReferenceName,
    [ReferencesSetId] = @ReferencesSetId

    -- Update Matching Record
    Where [ReferencesId] = @ReferencesId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ReferencesSet_Delete]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ReferencesSet_Delete]

    -- Primary Key Paramater
    @ReferencesSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ReferencesSet]

    -- Delete Matching Record
    Where [ReferencesSetId] = @ReferencesSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ReferencesSet_FetchAll]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ReferencesSet_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ProjectId],[ReferencesSetId],[ReferencesSetName]

    -- From tableName
    From [ReferencesSet]

END

-- Thank you for using DataTier.Net.

GO

/****** Object:  StoredProcedure [dbo].[ReferencesSet_Find]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ReferencesSet_Find]

    -- Primary Key Paramater
    @ReferencesSetId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ProjectId],[ReferencesSetId],[ReferencesSetName]

    -- From tableName
    From [ReferencesSet]

    -- Find Matching Record
    Where [ReferencesSetId] = @ReferencesSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ReferencesSet_Insert]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ReferencesSet_Insert]

    -- Add the parameters for the stored procedure here
    @ProjectId int,
    @ReferencesSetName nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ReferencesSet]
    ([ProjectId],[ReferencesSetName])

    -- Begin Values List
    Values(@ProjectId, @ReferencesSetName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ReferencesSet_Update]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[ReferencesSet_Update]

    -- Add the parameters for the stored procedure here
    @ProjectId int,
    @ReferencesSetId int,
    @ReferencesSetName nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ReferencesSet]

    -- Update Each field
    Set [ProjectId] = @ProjectId,
    [ReferencesSetName] = @ReferencesSetName

    -- Update Matching Record
    Where [ReferencesSetId] = @ReferencesSetId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[UpdateProcPermissions]    Script Date: 3/22/2019 6:28:01 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[UpdateProcPermissions]

	-- parameter for the procedure
	@UserName as varchar(50)

AS

declare @sql as varchar(250)

declare @procName as varchar(100)

DECLARE cursorSP CURSOR FOR

	select name from sysobjects where xtype='P' AND category!=2

	OPEN cursorSP 

		FETCH NEXT FROM CursorSP

			INTO @procName

			WHILE @@FETCH_STATUS = 0

			BEGIN
     
				set @sql = 'GRANT EXECUTE ON [dbo].[' + @procName + '] TO [' + @UserName + ']'
		
				exec (@sql)
		
				FETCH NEXT FROM CursorSP
			  
				INTO @procName
				
				

			END
			
			close CursorSP

			Deallocate CursorSP




GO

