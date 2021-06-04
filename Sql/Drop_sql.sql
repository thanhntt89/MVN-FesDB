--Drop table
Use[Wii]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Wii].[dbo].[FestaVideoLock]') AND type in (N'U')) 
BEGIN drop table [Wii].[dbo].[FestaVideoLock] END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Wii].[dbo].[VideoCodeLock]') AND type in (N'U')) 
BEGIN drop table [Wii].[dbo].[VideoCodeLock] END;

--Drop column 個別映像ロック => table 

IF COL_LENGTH('[dbo].[Fesサービス]', '個別映像ロック') IS NOT NULL BEGIN 
  ALTER TABLE [dbo].[Fesサービス]
        DROP COLUMN 個別映像ロック
END;

IF COL_LENGTH('[dbo].[Fes映像コード管理]', '個別映像ロック') IS NOT NULL BEGIN 
  ALTER TABLE [dbo].[Fes映像コード管理]
        DROP COLUMN 個別映像ロック
END;

IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Fesコンテンツ_演奏時間追加]', '演奏時間NULL') IS NOT NULL BEGIN 
ALTER TABLE [WiiTmp].[dbo].[tbl_Fesコンテンツ_演奏時間追加] 
DROP COLUMN 演奏時間NULL
END;
GO
--Drop Views

if exists(select 1 from sys.views where name='v_Fesコンテンツ_21' and type='V')
drop view v_Fesコンテンツ_21;
go

if exists(select 1 from sys.views where name='v_Fesコンテンツ_WiiU_21' and type='V')
drop view v_Fesコンテンツ_WiiU_21;
go

if exists(select 1 from sys.views where name='v_Fes映像コード管理_21' and type='V')
drop view v_Fes映像コード管理_21;
go

--Drop stored
IF OBJECT_ID('usp_CreateFesContentsTable_AddPlayTime_21','P') IS NOT NULL
    DROP PROC usp_CreateFesContentsTable_AddPlayTime_21
GO

IF OBJECT_ID('usp_SelectFesContentsAll_AddPlayTime_21','P') IS NOT NULL
    DROP PROC usp_SelectFesContentsAll_AddPlayTime_21
GO

