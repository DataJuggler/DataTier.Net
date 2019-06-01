Use [DataTier.Net.Website.Database]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: GitHubFollower_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Insert a new GitHubFollower
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('GitHubFollower_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure GitHubFollower_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.GitHubFollower_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure GitHubFollower_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure GitHubFollower_Insert >>>'

    End

GO

Create PROCEDURE GitHubFollower_Insert

    -- Add the parameters for the stored procedure here
    @Active bit,
    @EmailAddress nvarchar(80),
    @FollowerName nvarchar(50),
    @FollowerSince datetime,
    @NotificationId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [GitHubFollower]
    ([Active],[EmailAddress],[FollowerName],[FollowerSince],[NotificationId])

    -- Begin Values List
    Values(@Active, @EmailAddress, @FollowerName, @FollowerSince, @NotificationId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: GitHubFollower_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Update an existing GitHubFollower
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('GitHubFollower_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure GitHubFollower_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.GitHubFollower_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure GitHubFollower_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure GitHubFollower_Update >>>'

    End

GO

Create PROCEDURE GitHubFollower_Update

    -- Add the parameters for the stored procedure here
    @Active bit,
    @EmailAddress nvarchar(80),
    @FollowerName nvarchar(50),
    @FollowerSince datetime,
    @Id int,
    @NotificationId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [GitHubFollower]

    -- Update Each field
    Set [Active] = @Active,
    [EmailAddress] = @EmailAddress,
    [FollowerName] = @FollowerName,
    [FollowerSince] = @FollowerSince,
    [NotificationId] = @NotificationId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: GitHubFollower_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Find an existing GitHubFollower
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('GitHubFollower_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure GitHubFollower_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.GitHubFollower_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure GitHubFollower_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure GitHubFollower_Find >>>'

    End

GO

Create PROCEDURE GitHubFollower_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[EmailAddress],[FollowerName],[FollowerSince],[Id],[NotificationId]

    -- From tableName
    From [GitHubFollower]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: GitHubFollower_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Delete an existing GitHubFollower
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('GitHubFollower_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure GitHubFollower_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.GitHubFollower_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure GitHubFollower_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure GitHubFollower_Delete >>>'

    End

GO

Create PROCEDURE GitHubFollower_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [GitHubFollower]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: GitHubFollower_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Returns all GitHubFollower objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('GitHubFollower_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure GitHubFollower_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.GitHubFollower_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure GitHubFollower_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure GitHubFollower_FetchAll >>>'

    End

GO

Create PROCEDURE GitHubFollower_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[EmailAddress],[FollowerName],[FollowerSince],[Id],[NotificationId]

    -- From tableName
    From [GitHubFollower]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Notification_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Insert a new Notification
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Notification_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Notification_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Notification_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Notification_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Notification_Insert >>>'

    End

GO

Create PROCEDURE Notification_Insert

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @GitHubUserName nvarchar(30),
    @LastSentDate bit,
    @NotificationType int,
    @Verified bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Notification]
    ([Active],[CreatedDate],[EmailAddress],[GitHubUserName],[LastSentDate],[NotificationType],[Verified])

    -- Begin Values List
    Values(@Active, @CreatedDate, @EmailAddress, @GitHubUserName, @LastSentDate, @NotificationType, @Verified)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Notification_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Update an existing Notification
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Notification_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Notification_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Notification_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Notification_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Notification_Update >>>'

    End

GO

Create PROCEDURE Notification_Update

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @GitHubUserName nvarchar(30),
    @Id int,
    @LastSentDate bit,
    @NotificationType int,
    @Verified bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Notification]

    -- Update Each field
    Set [Active] = @Active,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [GitHubUserName] = @GitHubUserName,
    [LastSentDate] = @LastSentDate,
    [NotificationType] = @NotificationType,
    [Verified] = @Verified

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Notification_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Find an existing Notification
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Notification_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Notification_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Notification_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Notification_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Notification_Find >>>'

    End

GO

Create PROCEDURE Notification_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[GitHubUserName],[Id],[LastSentDate],[NotificationType],[Verified]

    -- From tableName
    From [Notification]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Notification_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Delete an existing Notification
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Notification_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Notification_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Notification_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Notification_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Notification_Delete >>>'

    End

GO

Create PROCEDURE Notification_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Notification]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Notification_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Returns all Notification objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Notification_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Notification_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Notification_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Notification_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Notification_FetchAll >>>'

    End

GO

Create PROCEDURE Notification_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[GitHubUserName],[Id],[LastSentDate],[NotificationType],[Verified]

    -- From tableName
    From [Notification]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: NotificationHistory_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Insert a new NotificationHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('NotificationHistory_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure NotificationHistory_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.NotificationHistory_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure NotificationHistory_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure NotificationHistory_Insert >>>'

    End

GO

Create PROCEDURE NotificationHistory_Insert

    -- Add the parameters for the stored procedure here
    @Delivered bit,
    @Id int,
    @NotificationId int,
    @SendDate datetime

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [NotificationHistory]
    ([Delivered],[Id],[NotificationId],[SendDate])

    -- Begin Values List
    Values(@Delivered, @Id, @NotificationId, @SendDate)

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: NotificationHistory_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Update an existing NotificationHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('NotificationHistory_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure NotificationHistory_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.NotificationHistory_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure NotificationHistory_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure NotificationHistory_Update >>>'

    End

GO

Create PROCEDURE NotificationHistory_Update

    -- Add the parameters for the stored procedure here
    @Delivered bit,
    @Id int,
    @NotificationId int,
    @SendDate datetime

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [NotificationHistory]

    -- Update Each field
    Set [Delivered] = @Delivered,
    [Id] = @Id,
    [NotificationId] = @NotificationId,
    [SendDate] = @SendDate

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: NotificationHistory_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Find an existing NotificationHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('NotificationHistory_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure NotificationHistory_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.NotificationHistory_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure NotificationHistory_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure NotificationHistory_Find >>>'

    End

GO

Create PROCEDURE NotificationHistory_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Delivered],[Id],[NotificationId],[SendDate]

    -- From tableName
    From [NotificationHistory]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: NotificationHistory_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Delete an existing NotificationHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('NotificationHistory_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure NotificationHistory_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.NotificationHistory_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure NotificationHistory_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure NotificationHistory_Delete >>>'

    End

GO

Create PROCEDURE NotificationHistory_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [NotificationHistory]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: NotificationHistory_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/8/2019
-- Description:    Returns all NotificationHistory objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('NotificationHistory_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure NotificationHistory_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.NotificationHistory_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure NotificationHistory_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure NotificationHistory_FetchAll >>>'

    End

GO

Create PROCEDURE NotificationHistory_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Delivered],[Id],[NotificationId],[SendDate]

    -- From tableName
    From [NotificationHistory]

END

-- Thank you for using DataTier.Net.

