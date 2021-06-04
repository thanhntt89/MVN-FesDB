--Drop table
Use[Wii]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Wii].[dbo].[FestaVideoLock]') AND type in (N'U')) 
BEGIN drop table [Wii].[dbo].[FestaVideoLock] END;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Wii].[dbo].[VideoCodeLock]') AND type in (N'U')) 
BEGIN drop table [Wii].[dbo].[VideoCodeLock] END;

--Drop column �ʉf�����b�N => table 

IF COL_LENGTH('[dbo].[Fes�T�[�r�X]', '�ʉf�����b�N') IS NOT NULL BEGIN 
  ALTER TABLE [dbo].[Fes�T�[�r�X]
        DROP COLUMN �ʉf�����b�N
END;

IF COL_LENGTH('[dbo].[Fes�f���R�[�h�Ǘ�]', '�ʉf�����b�N') IS NOT NULL BEGIN 
  ALTER TABLE [dbo].[Fes�f���R�[�h�Ǘ�]
        DROP COLUMN �ʉf�����b�N
END;

IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Fes�R���e���c_���t���Ԓǉ�]', '���t����NULL') IS NOT NULL BEGIN 
ALTER TABLE [WiiTmp].[dbo].[tbl_Fes�R���e���c_���t���Ԓǉ�] 
DROP COLUMN ���t����NULL
END;
GO
--Drop Views

if exists(select 1 from sys.views where name='v_Fes�R���e���c_21' and type='V')
drop view v_Fes�R���e���c_21;
go

if exists(select 1 from sys.views where name='v_Fes�R���e���c_WiiU_21' and type='V')
drop view v_Fes�R���e���c_WiiU_21;
go

if exists(select 1 from sys.views where name='v_Fes�f���R�[�h�Ǘ�_21' and type='V')
drop view v_Fes�f���R�[�h�Ǘ�_21;
go

--Drop stored
IF OBJECT_ID('usp_CreateFesContentsTable_AddPlayTime_21','P') IS NOT NULL
    DROP PROC usp_CreateFesContentsTable_AddPlayTime_21
GO

IF OBJECT_ID('usp_SelectFesContentsAll_AddPlayTime_21','P') IS NOT NULL
    DROP PROC usp_SelectFesContentsAll_AddPlayTime_21
GO

