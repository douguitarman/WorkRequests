
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Doug Allan
-- Create date: 5/26/18
-- Description:	Add a new work request
-- =============================================
CREATE PROCEDURE AddWorkRequest
	@WorkRequestTitle	nvarchar(256),
	@WorkRequestDescription	nvarchar(2000),
	@IssueReportedBy	nvarchar(128),
	@IssueReportedDate	datetime,
	@DepartmentId	int,
	@PriorityId	int,
	@RequestTypeId	int,
	@DueDate	datetime,
	@CreatedBy	nvarchar(128)
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO WorkRequests (WorkRequestTitle, WorkRequestDescription, IssueReportedBy, IssueReportedDate,
				DepartmentId, PriorityId, RequestTypeId, DueDate, CreatedBy)
	VALUES (@WorkRequestTitle, @WorkRequestDescription, @IssueReportedBy, @IssueReportedDate,
			@DepartmentId, @PriorityId,	@RequestTypeId, @DueDate, @CreatedBy)
END
GO
