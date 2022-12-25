USE [BaseDB]
GO
/****** Object:  Table [dbo].[BaseClass]    Script Date: 12/21/2022 3:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseClass](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_BaseClass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaseClass] ON 

INSERT [dbo].[BaseClass] ([ID], [Name], [Active]) VALUES (1, N'test', 1)
INSERT [dbo].[BaseClass] ([ID], [Name], [Active]) VALUES (2, N'aulona', 1)
INSERT [dbo].[BaseClass] ([ID], [Name], [Active]) VALUES (3, N'string', 1)
INSERT [dbo].[BaseClass] ([ID], [Name], [Active]) VALUES (4, N'hi', 1)
SET IDENTITY_INSERT [dbo].[BaseClass] OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateBase]    Script Date: 12/21/2022 3:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBase]
	-- Add the parameters for the stored procedure here
	
	@name NVARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.BaseClass
	(
	    Name,
	    Active
	)
	VALUES
	(   @name, -- Name - nvarchar(50)
	    1 -- Active - bit
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 12/21/2022 3:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll]
AS
BEGIN
	SELECT * FROM dbo.BaseClass
END
GO
