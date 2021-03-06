/*
   2016年2月24日8:29:28
   用户: sa
   服务器: DESKTOP-E1QUQMA\SQLEXPRESS
   数据库: WifiCheckIn
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.T_User.UserPhoneNum', N'Tmp_UserPhoneIMEI', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.T_User.Tmp_UserPhoneIMEI', N'UserPhoneIMEI', 'COLUMN' 
GO
ALTER TABLE dbo.T_User SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.T_User', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_User', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_User', 'Object', 'CONTROL') as Contr_Per 