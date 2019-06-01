
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

