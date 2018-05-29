
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Doug Allan
-- Create date: 5/26/18
-- Description:	Delete a work request
-- =============================================
CREATE PROCEDURE DeleteWorkRequest
	@WorkRequestId int
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM WorkRequests
	WHERE WorkRequestId = @WorkRequestId

END
GO
