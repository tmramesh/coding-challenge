USE [LoanDB]
GO
/****** Object:  Table [dbo].[accountinfo]    Script Date: 2/15/2019 2:21:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountinfo](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[acc_no] [bigint] NOT NULL,
	[acc_typ] [nvarchar](100) NOT NULL,
	[crt_un] [nvarchar](50) NOT NULL,
	[crt_ts] [datetime] NOT NULL,
	[upd_un] [nvarchar](50) NULL,
	[upd_ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanAccountInfo]    Script Date: 2/15/2019 2:21:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanAccountInfo](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[acc_id] [bigint] NULL,
	[loan_id] [bigint] NULL,
	[loan_amnt] [int] NOT NULL,
	[loan_bal] [int] NOT NULL,
	[Pay_carryOver] [int] NOT NULL,
	[crt_un] [nvarchar](50) NOT NULL,
	[crt_ts] [datetime] NOT NULL,
	[upd_un] [nvarchar](50) NULL,
	[upd_ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loandetails]    Script Date: 2/15/2019 2:21:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loandetails](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[loan_name] [nvarchar](50) NOT NULL,
	[loan_typ] [nvarchar](50) NOT NULL,
	[early_fee] [int] NOT NULL,
	[loan_intrst] [float] NOT NULL,
	[crt_un] [nvarchar](50) NOT NULL,
	[crt_ts] [datetime] NOT NULL,
	[upd_un] [nvarchar](50) NULL,
	[upd_ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userdetails]    Script Date: 2/15/2019 2:21:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userdetails](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[crt_un] [nvarchar](50) NOT NULL,
	[crt_ts] [datetime] NOT NULL,
	[upd_un] [nvarchar](50) NULL,
	[upd_ts] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accountinfo]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[userdetails] ([id])
GO
ALTER TABLE [dbo].[LoanAccountInfo]  WITH CHECK ADD FOREIGN KEY([acc_id])
REFERENCES [dbo].[accountinfo] ([id])
GO
ALTER TABLE [dbo].[LoanAccountInfo]  WITH CHECK ADD FOREIGN KEY([loan_id])
REFERENCES [dbo].[loandetails] ([id])
GO
/****** Object:  StoredProcedure [dbo].[UDP_GetLoadDetails]    Script Date: 2/15/2019 2:21:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[UDP_GetLoadDetails] @userID nvarchar(50)
AS
   
BEGIN TRY  
     
	 -- To Avoid Parameter Sniffing
	 DECLARE @LocaluserID nvarchar(50) 
	 SET @LocaluserID = @userID
	 
		SELECT 
				u_info.User_name  as UserName, 
				l_info.loan_name as LoanName ,  
				l_info.id As LoanID, 
				l_a_info.loan_bal as Balance,
				l_info.loan_intrst as Interest, 
				l_info.early_fee as EarlyFee,
				l_a_info.Pay_carryOver as PayCarryOver
		FROM LoanAccountInfo as l_a_info
			INNER JOIN accountinfo a_info
				ON l_a_info.acc_id = a_info.id
			INNER JOIN loandetails l_info
				ON l_a_info.loan_id = l_info.id
			INNER JOIN userdetails u_info
				ON a_info.user_id = u_info.id
		WHERE u_info.id  = @LocaluserID

END TRY  
BEGIN CATCH  
   -- Throw error 
   SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
  
END CATCH;  


 
GO
