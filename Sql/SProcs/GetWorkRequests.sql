
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Doug Allan
-- Create date: 5/26/18
-- Description:	Get all work requests
-- =============================================
CREATE PROCEDURE GetWorkRequests
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT wr.WorkRequestId, wr.WorkRequestTitle, wr.WorkRequestDescription, wr.IssueReportedBy, wr.IssueReportedDate,
		   wr.DepartmentId, wrd.DepartmentName, wr.StatusId, wrs.StatusName, wr.PriorityId, wrp.PriorityName,
		   wr.RequestTypeId, wrt.RequestTypeName, wr.DueDate, wr.CreatedBy, wr.LastUpdateBy
	FROM WorkRequests wr
	INNER JOIN WorkRequestDepartment wrd ON wr.DepartmentId = wrd.DepartmentId
	INNER JOIN WorkRequestPriority wrp ON wr.PriorityId = wrp.PriorityId
	INNER JOIN WorkRequestStatus wrs ON wr.StatusId = wrs.StatusId
	INNER JOIN WorkRequestType wrt ON wr.RequestTypeId = wrt.RequestTypeId
END
GO
