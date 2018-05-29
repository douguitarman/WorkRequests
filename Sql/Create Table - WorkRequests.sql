USE [DougDGM]
GO

/****** Object:  Table [dbo].[ContentKeys]    Script Date: 2017-04-06 8:57:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkRequests](
	[WorkRequestId] [int] IDENTITY(1,1) NOT NULL,
	[WorkRequestTitle] [nvarchar](256) NOT NULL,
	[WorkRequestDescription] [nvarchar](2000) NOT NULL,
	[IssueReportedBy] [nvarchar](128) NOT NULL,
	[IssueReportedDate] [datetime] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[StatusId] [int] NOT NULL DEFAULT 1,
	[PriorityId] [int] NOT NULL,
	[RequestTypeId] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT getDate(),
	[LastUpdateBy] [nvarchar](128) NULL,
	[LastUpdateDate] [datetime] NULL DEFAULT getDate(),
PRIMARY KEY CLUSTERED 
(
	[WorkRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- FK: Department ID
ALTER TABLE [dbo].[WorkRequests] WITH CHECK ADD CONSTRAINT [FK_WorkRequests_WorkRequestDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[WorkRequestDepartment] ([DepartmentId])
GO

ALTER TABLE [dbo].[WorkRequests] CHECK CONSTRAINT [FK_WorkRequests_WorkRequestDepartment]
GO

-- FK: Status ID
ALTER TABLE [dbo].[WorkRequests] WITH CHECK ADD CONSTRAINT [FK_WorkRequests_WorkRequestStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[WorkRequestStatus] ([StatusId])
GO

ALTER TABLE [dbo].[WorkRequests] CHECK CONSTRAINT [FK_WorkRequests_WorkRequestStatus]
GO

-- FK: Priority ID
ALTER TABLE [dbo].[WorkRequests] WITH CHECK ADD CONSTRAINT [FK_WorkRequests_WorkRequestPriority] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[WorkRequestPriority] ([PriorityId])
GO

ALTER TABLE [dbo].[WorkRequests] CHECK CONSTRAINT [FK_WorkRequests_WorkRequestPriority]
GO

-- FK: Request Type ID
ALTER TABLE [dbo].[WorkRequests] WITH CHECK ADD CONSTRAINT [FK_WorkRequests_WorkRequestType] FOREIGN KEY([RequestTypeId])
REFERENCES [dbo].[WorkRequestType] ([RequestTypeId])
GO

ALTER TABLE [dbo].[WorkRequests] CHECK CONSTRAINT [FK_WorkRequests_WorkRequestType]
GO

