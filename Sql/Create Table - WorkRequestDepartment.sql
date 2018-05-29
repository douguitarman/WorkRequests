USE [DougDGM]
GO

/****** Object:  Table [dbo].[ContentKeys]    Script Date: 2017-04-06 8:57:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkRequestDepartment](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](150) NOT NULL,
	[InactiveFlag] [int] NOT NULL DEFAULT 0,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID(N'WorkRequestUsers.dbo.WorkRequestDepartment', N'U') IS NOT NULL
BEGIN
  
  Insert Into WorkRequestDepartment(DepartmentName)
  Values ('Sales');
  Insert Into WorkRequestDepartment(DepartmentName)
  Values ('Marketing');
  Insert Into WorkRequestDepartment(DepartmentName)
  Values ('IT');
  Insert Into WorkRequestDepartment(DepartmentName)
  Values ('Finance');
  Insert Into WorkRequestDepartment(DepartmentName)
  Values ('Customer Care');

END

--ALTER TABLE [dbo].[ContentKeys] ADD  DEFAULT ((0)) FOR [InactiveFlag]
--GO

--ALTER TABLE [dbo].[ContentKeys] ADD  DEFAULT (getdate()) FOR [CreatedDate]
--GO
