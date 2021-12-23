Alter Table Project
Add TargetFramework int null
Go

Alter Table Project
Drop Column DotNet5
Go

/****** Object:  StoredProcedure [dbo].[Project_Update]    Script Date: 12/23/2021 3:43:52 PM ******/
DROP PROCEDURE [dbo].[Project_Update]
GO

/****** Object:  StoredProcedure [dbo].[Project_Insert]    Script Date: 12/23/2021 3:43:52 PM ******/
DROP PROCEDURE [dbo].[Project_Insert]
GO

/****** Object:  StoredProcedure [dbo].[Project_Find]    Script Date: 12/23/2021 3:43:52 PM ******/
DROP PROCEDURE [dbo].[Project_Find]
GO

/****** Object:  StoredProcedure [dbo].[Project_FetchAll]    Script Date: 12/23/2021 3:43:52 PM ******/
DROP PROCEDURE [dbo].[Project_FetchAll]
GO

/****** Object:  StoredProcedure [dbo].[Project_FetchAll]    Script Date: 12/23/2021 3:43:52 PM ******/
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
    Select [BindingCallbackOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[EnableBlazorFeatures],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectId],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[ServicesFolder],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder],[TargetFramework],[UIFolderPath]

    -- From tableName
    From [Project]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Find]    Script Date: 12/23/2021 3:43:52 PM ******/
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
    Select [BindingCallbackOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[EnableBlazorFeatures],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectId],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[ServicesFolder],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder],[TargetFramework],[UIFolderPath]

    -- From tableName
    From [Project]

    -- Find Matching Record
    Where [ProjectId] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Insert]    Script Date: 12/23/2021 3:43:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Insert]

    -- Add the parameters for the stored procedure here
    @BindingCallbackOption int,
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
    @EnableBlazorFeatures bit,
    @ObjectFolder nvarchar(255),
    @ObjectNamespace nvarchar(100),
    @ObjectReferencesSetId int,
    @ProjectFolder nvarchar(255),
    @ProjectName nvarchar(50),
    @ReaderFolder nvarchar(255),
    @ReaderNamespace nvarchar(100),
    @ReaderReferencesSetId int,
    @ServicesFolder nvarchar(512),
    @StoredProcedureObjectFolder nvarchar(255),
    @StoredProcedureObjectNamespace nvarchar(100),
    @StoredProcedureReferencesSetId int,
    @StoredProcsFolder nvarchar(255),
    @TargetFramework int,
    @UIFolderPath nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Project]
    ([BindingCallbackOption],[ControllerFolder],[ControllerNamespace],[ControllerReferencesSetId],[DataManagerFolder],[DataManagerNamespace],[DataManagerReferencesSetId],[DataOperationsFolder],[DataOperationsNamespace],[DataOperationsReferencesSetId],[DataWriterFolder],[DataWriterNamespace],[DataWriterReferencesSetId],[DateModified],[EnableBlazorFeatures],[ObjectFolder],[ObjectNamespace],[ObjectReferencesSetId],[ProjectFolder],[ProjectName],[ReaderFolder],[ReaderNamespace],[ReaderReferencesSetId],[ServicesFolder],[StoredProcedureObjectFolder],[StoredProcedureObjectNamespace],[StoredProcedureReferencesSetId],[StoredProcsFolder],[TargetFramework],[UIFolderPath])

    -- Begin Values List
    Values(@BindingCallbackOption, @ControllerFolder, @ControllerNamespace, @ControllerReferencesSetId, @DataManagerFolder, @DataManagerNamespace, @DataManagerReferencesSetId, @DataOperationsFolder, @DataOperationsNamespace, @DataOperationsReferencesSetId, @DataWriterFolder, @DataWriterNamespace, @DataWriterReferencesSetId, @DateModified, @EnableBlazorFeatures, @ObjectFolder, @ObjectNamespace, @ObjectReferencesSetId, @ProjectFolder, @ProjectName, @ReaderFolder, @ReaderNamespace, @ReaderReferencesSetId, @ServicesFolder, @StoredProcedureObjectFolder, @StoredProcedureObjectNamespace, @StoredProcedureReferencesSetId, @StoredProcsFolder, @TargetFramework, @UIFolderPath)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Project_Update]    Script Date: 12/23/2021 3:43:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Project_Update]

    -- Add the parameters for the stored procedure here
    @BindingCallbackOption int,
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
    @EnableBlazorFeatures bit,
    @ObjectFolder nvarchar(255),
    @ObjectNamespace nvarchar(100),
    @ObjectReferencesSetId int,
    @ProjectFolder nvarchar(255),
    @ProjectId int,
    @ProjectName nvarchar(50),
    @ReaderFolder nvarchar(255),
    @ReaderNamespace nvarchar(100),
    @ReaderReferencesSetId int,
    @ServicesFolder nvarchar(512),
    @StoredProcedureObjectFolder nvarchar(255),
    @StoredProcedureObjectNamespace nvarchar(100),
    @StoredProcedureReferencesSetId int,
    @StoredProcsFolder nvarchar(255),
    @TargetFramework int,
    @UIFolderPath nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Project]

    -- Update Each field
    Set [BindingCallbackOption] = @BindingCallbackOption,
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
    [EnableBlazorFeatures] = @EnableBlazorFeatures,
    [ObjectFolder] = @ObjectFolder,
    [ObjectNamespace] = @ObjectNamespace,
    [ObjectReferencesSetId] = @ObjectReferencesSetId,
    [ProjectFolder] = @ProjectFolder,
    [ProjectName] = @ProjectName,
    [ReaderFolder] = @ReaderFolder,
    [ReaderNamespace] = @ReaderNamespace,
    [ReaderReferencesSetId] = @ReaderReferencesSetId,
    [ServicesFolder] = @ServicesFolder,
    [StoredProcedureObjectFolder] = @StoredProcedureObjectFolder,
    [StoredProcedureObjectNamespace] = @StoredProcedureObjectNamespace,
    [StoredProcedureReferencesSetId] = @StoredProcedureReferencesSetId,
    [StoredProcsFolder] = @StoredProcsFolder,
    [TargetFramework] = @TargetFramework,
    [UIFolderPath] = @UIFolderPath

    -- Update Matching Record
    Where [ProjectId] = @ProjectId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO



