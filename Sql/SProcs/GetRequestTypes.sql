
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Doug Allan
-- Create date: 5/26/18
-- Description:	Get all request types
-- =============================================
CREATE PROCEDURE GetRequestTypes
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT RequestTypeId, RequestTypeName
	FROM WorkRequestType

END
GO
