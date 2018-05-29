
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Doug Allan
-- Create date: 5/26/18
-- Description:	Update a work request
-- =============================================
CREATE PROCEDURE UpdateWorkRequest
	@WorkRequestId int,
	@WorkRequestTitle	nvarchar(256),
	@WorkRequestDescription	nvarchar(2000),
	@DepartmentId	int,
	@StatusId	int,
	@PriorityId	int,
	@RequestTypeId	int,
	@DueDate	datetime,
	@LastUpdateBy	nvarchar(128)
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE WorkRequests
	SET WorkRequestTitle = @WorkRequestTitle,
		WorkRequestDescription = @WorkRequestDescription,
		DepartmentId = @DepartmentId,
		StatusId = @StatusId,
		PriorityId = @PriorityId,
		RequestTypeId = @RequestTypeId,
		DueDate = @DueDate,
		LastUpdateBy = @LastUpdateBy
	WHERE WorkRequestId = @WorkRequestId

END
GO
