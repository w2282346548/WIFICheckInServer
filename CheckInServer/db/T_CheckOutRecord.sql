/*
   2016年2月23日13:08:00
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
CREATE TABLE dbo.T_CheckOutRecord
	(
	ID int NOT NULL IDENTITY (1, 1),
	UserID int NOT NULL,
	CheckOutTime nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.T_CheckOutRecord ADD CONSTRAINT
	PK_T_CheckOutRecord PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.T_CheckOutRecord SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.T_CheckOutRecord', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.T_CheckOutRecord', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.T_CheckOutRecord', 'Object', 'CONTROL') as Contr_Per 