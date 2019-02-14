USE [LoanDB]
GO
 
 -- Please execute only once.  I didn't write condition to valaidate


-- 01 User Details

INSERT INTO [dbo].[userdetails]
           ([user_name]
           ,[address]
           ,[city]
           ,[crt_un],[crt_ts],[upd_un],[upd_ts])
     VALUES
           ( 'Ramesh', 'Medavakkam', 'Chennai',  'ADMIN', GETUTCDATE(), NULL, NULL)  
GO


-- 02 - Load Details
INSERT INTO [dbo].[loandetails]
           ([loan_name]
           ,[loan_typ]
           ,[early_fee]
           ,[loan_intrst]
           ,[crt_un]
           ,[crt_ts]
           ,[upd_un]
           ,[upd_ts])
     VALUES
           ( 'Loan 1','Loan Type',123, 12, 'ADMIN', GETUTCDATE(), NULL, NULL)  
 

 INSERT INTO [dbo].[loandetails]
           ([loan_name]
           ,[loan_typ]
           ,[early_fee]
           ,[loan_intrst]
           ,[crt_un]
           ,[crt_ts]
           ,[upd_un]
           ,[upd_ts])
     VALUES
           ( 'Loan 2','Loan Type 2',200, 20, 'ADMIN', GETUTCDATE(), NULL, NULL)  
GO



-- 03 Account Info


INSERT INTO [dbo].[accountinfo]
           ([user_id]
           ,[acc_no]
           ,[acc_typ]
           ,[crt_un]
           ,[crt_ts]
           ,[upd_un]
           ,[upd_ts])
     VALUES
           ( 1, 123453, 'ADMIN', GETUTCDATE(), NULL, NULL)  
GO


--04 Loan Account Info

INSERT INTO [dbo].[LoanAccountInfo]
           ([acc_id]
           ,[loan_id]
           ,[loan_amnt]
           ,[loan_bal]
           ,[Pay_carryOver]
           ,[crt_un]
           ,[crt_ts]
           ,[upd_un]
           ,[upd_ts])
     VALUES
           (1,1, 1000,200,22,'ADMIN', GETUTCDATE(), NULL, NULL) 
		   
		   
INSERT INTO [dbo].[LoanAccountInfo]
           ([acc_id]
           ,[loan_id]
           ,[loan_amnt]
           ,[loan_bal]
           ,[Pay_carryOver]
           ,[crt_un]
           ,[crt_ts]
           ,[upd_un]
           ,[upd_ts])
     VALUES
           (1,2, 2000,220,10,'ADMIN', GETUTCDATE(), NULL, NULL)   