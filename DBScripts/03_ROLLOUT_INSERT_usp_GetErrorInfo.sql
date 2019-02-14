USE [LoanDB]
GO


IF OBJECT_ID (N'usp_GetErrorInfo', N'P') IS NOT NULL  
    DROP PROCEDURE usp_GetErrorInfo;  
GO  
 

/****** Object:  StoredProcedure [dbo].[UDP_GetLoadDetails]    Script Date: 2/15/2019 2:06:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[UDP_GetLoadDetails] 
@userID nvarchar(50)  -- User ID 
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
		WHERE 
			u_info.id  = @LocaluserID

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




