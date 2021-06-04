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


--Create module values
Use[Wii]
GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes�@�\ID] where �@�\ID = 220)
begin
insert into [Wii].[dbo].[Fes�@�\ID] (�v���W�F�N�gID,�@�\ID,	�@�\��) values (1,220,'�w�i�f�������e'); 
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes�����O���[�v�@�\����] where �@�\ID = 220 AND �v���W�F�N�gID = 1 AND �����O���[�v='SystemAdmin')
begin
insert into [Wii].[dbo].[Fes�����O���[�v�@�\����] (�����O���[�v,�v���W�F�N�gID,�@�\ID,	�X�V�^�C�v) values ('SystemAdmin',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes�����O���[�v�@�\����] where �@�\ID = 220 AND �v���W�F�N�gID =1 AND �����O���[�v='SeisakuUser')
begin
insert into [Wii].[dbo].[Fes�����O���[�v�@�\����] (�����O���[�v,�v���W�F�N�gID,�@�\ID,	�X�V�^�C�v) values ('SeisakuUser',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes�����O���[�v�@�\����] where �@�\ID = 220 AND �v���W�F�N�gID =1 AND �����O���[�v='HenseiUser')
begin
insert into [Wii].[dbo].[Fes�����O���[�v�@�\����] (�����O���[�v,�v���W�F�N�gID,�@�\ID,	�X�V�^�C�v) values ('HenseiUser',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes�����O���[�v�@�\����] where �@�\ID = 220 AND �v���W�F�N�gID =1 AND �����O���[�v='__Guest__')
begin
insert into [Wii].[dbo].[Fes�����O���[�v�@�\����] (�����O���[�v,�v���W�F�N�gID,�@�\ID,	�X�V�^�C�v)  values ('__Guest__',1,220,0);
end

--Create festa video lock table
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'FestaVideoLock') AND type in (N'U')) 
BEGIN 
CREATE TABLE [Wii].[dbo].[FestaVideoLock]( [ContentType][int] NULL) ON[PRIMARY] 
END;

--Create table VideoCodeLock
USE [Wii];
GO 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'VideoCodeLock') AND type in (N'U'))
BEGIN 
CREATE TABLE Wii.[dbo].[VideoCodeLock]([VideoCode][nvarchar](7) NOT NULL,[MaterialID][int] NULL,[Contents][nvarchar](250) NULL,[MaterialEndDate][varchar](8) NULL,[BackgroundVideoLock] [int] NULL, CONSTRAINT[PK_VideoCodeLock] PRIMARY KEY CLUSTERED([VideoCode] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] 
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0: NULL/ 1 Not Change' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VideoCodeLock', @level2type=N'COLUMN',@level2name=N'BackgroundVideoLock' 
END;

GO
--Add column �ʉf�����b�N in table Fes�T�[�r�X,
IF COL_LENGTH('[dbo].[Fes�T�[�r�X]', '�ʉf�����b�N') IS NULL BEGIN ALTER TABLE [dbo].[Fes�T�[�r�X] ADD �ʉf�����b�N INT; END;

GO
--Add column �ʉf�����b�N in table Fes�f���R�[�h�Ǘ�
IF COL_LENGTH('[Wii].[dbo].[Fes�f���R�[�h�Ǘ�]', '�ʉf�����b�N') IS NULL BEGIN ALTER TABLE [Wii].[dbo].[Fes�f���R�[�h�Ǘ�] ADD �ʉf�����b�N INT; END;

GO

--Add column [���t����NULL] in table [dbo].[tbl_Fes�R���e���c_���t���Ԓǉ�]
IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Fes�R���e���c_���t���Ԓǉ�]', '���t����NULL') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Fes�R���e���c_���t���Ԓǉ�] ADD ���t����NULL INT; END;
GO

CREATE VIEW [dbo].[v_Fes�R���e���c_21]
AS
SELECT                      dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID, dbo.[v_�f�W�E�h�R�R���e���c].�I�Ȕԍ� AS [Wii(�f�W�h�R)�I�Ȕԍ�], dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ�, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�z�M�}�[�N, dbo.v_�񎟃R���e���c�����J���I�P���.�A�����W�R�[�h AS �J���I�P�A�����W�R�[�h, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�A�����W�\�L�� AS �A�����W��, (CASE WHEN dbo.Fes�����ݒ�A�����W�R�[�h�}�X�^.[Fes�A�����W�R�[�h] IS NOT NULL 
                                      THEN dbo.Fes�����ݒ�A�����W�R�[�h�}�X�^.[Fes�A�����W�R�[�h] ELSE 1 END) AS �\���pFes�A�����W�R�[�h, dbo.Fes�T�[�r�X.Fes�A�����W�R�[�h, dbo.v_�񎟃R���e���c�����J���I�P���.������, 
                                      (CASE WHEN dbo.Fes�A�����W�\�L�ݒ�}�X�^.[�A�����W�R�[�h] IS NOT NULL THEN iv3.[SONG_TITLE] + dbo.[v_�񎟃R���e���c�����J���I�P���].[�A�����W�\�L��] ELSE iv3.[SONG_TITLE] END) AS �y�Ȗ�,
                                       iv1.SINGER_NAME AS �̎薼, ISNULL(dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ���݂���, N'') + ISNULL(dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ��M���݂���, N'') AS �y�Ȗ������p�J�i, 
                                      dbo.Fes�T�[�r�X.�Ȗ���݂��ȕ␳, ISNULL(iv3.SONG_TITLE_RUBY_0, N'') + ISNULL(iv3.SONG_TITLE_RUBY_3, N'') AS �y�Ȗ��\�[�g�p����, iv3.SONG_TITLE_RUBY_2 AS �y�Ȗ������\�[�g�p��, 
                                      dbo.Fes�T�[�r�X.�Ȗ��\�[�g�p���␳, WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id, (CASE WHEN WiiTmp.dbo.[tbl_Pu_Artist_prev].[GroupArtist_Id] IS NOT NULL THEN CONVERT(nvarchar, 
                                      WiiTmp.dbo.[tbl_Pu_Artist_prev].[GroupArtist_Id]) + replicate('0', 2 - len(CONVERT(nvarchar, WiiTmp.dbo.[tbl_Pu_Artist_prev].[Artist_Seq]))) + CONVERT(nvarchar, WiiTmp.dbo.[tbl_Pu_Artist_prev].[Artist_Seq]) 
                                      ELSE NULL END) AS PU_ARTIST_ID, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSearch_Kna AS �̎薼�����p�J�i, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSort_Kna AS �̎薼�\�[�g�p�J�i, 
                                      iv1.SINGER_NAME_RUBY AS �̎薼�����\�[�g�p��, dbo.v_�񎟃R���e���c�����J���I�P���.�̏��\��, dbo.Fes�T�[�r�X.�A�b�v�\���, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.���p�P������ AS �J���I�P���p�P������, dbo.v_�񎟃R���e���c�����J���I�P���.���p�P�� AS �J���I�P���p�P��, dbo.Fes�T�[�r�X.�T�[�r�X���\��, 
                                      dbo.Fes�T�[�r�X.���C�c�p�T�[�r�X���\��, dbo.Fes�T�[�r�X.�����\���ۃt���O, dbo.Fes�T�[�r�X.����t���O, dbo.Fes�T�[�r�X.��~��, dbo.Fes�T�[�r�X.�폜���, FesDISC���^�Ǘ�1.FesDISCID, 
                                      FesDISC���^�Ǘ�2.FesDISCID AS [FesDISCID(Ver2)], FesDISC���^�Ǘ�1.NET���p�t���O, FesDISC���^�Ǘ�2.NET���p�t���O AS [NET���p�t���O(Ver2)], dbo.Fes�T�[�r�X.�^��ۃt���O, 
                                      dbo.Fes�T�[�r�X.�^���ۃt���O, dbo.Fes�T�[�r�X.�L���R���e���c�t���O, dbo.Fes�T�[�r�X.�`���v�^�[�t���O, iv3.INTRO_TYPE, iv3.SONG_GROUP_INTRO_TYPE, iv3.COUNTRY_CODE, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�̂��o�� AS �̂�����, iv3.PLAY_TIME AS ���t����, dbo.Fes�T�[�r�X.���t���ԕ␳, dbo.Fes�T�[�r�X.�x�����x��, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.���Ȕ�, dbo.v_�񎟃R���e���c�����J���I�P���.���Ȕ�2, dbo.v_�񎟃R���e���c�����J���I�P���.[���J-STYLE] AS ���_JSTYLE, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.JV�f���敪 AS [JV�f���敪(�w�i�f���敪)], dbo.Fes�f���W�������Ǒփ}�X�^.�f���W������, dbo.Fes�T�[�r�X.�f���敪, 
                                      dbo.Fes�f���R�[�h�Ǘ�.�w�i�f���R�[�h, dbo.Fes�T�[�r�X.�ʉf�����b�N, dbo.v_�񎟃R���e���c�����J���I�P���.�e�I�Ȕԍ�, dbo.Fes�T�[�r�X.���쌠���l, dbo.Fes�T�[�r�X.���l, 
                                      dbo.[v_�f�W�E�h�R�R���e���c].�o�^����, dbo.v_�񎟃R���e���c�����J���I�P���.�R���e���c���, dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ��M�� AS �y�Ȗ��M��, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ��M���݂��� AS �y�Ȗ��M�肩��, dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ���݂��� AS �J���I�P�y�Ȗ�����, 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ� AS �J���I�P�y�Ȗ�, dbo.Fes�T�[�r�X.�M��D��t���O, dbo.Fes�T�[�r�X.�Ȗ��␳, dbo.Fes�T�[�r�X.����NULL�t���O, dbo.Fes�T�[�r�X.�Ȗ��\�[�g�␳, 
                                      dbo.Fes�T�[�r�X.�̎�ID�␳, dbo.Fes�T�[�r�X.INTRO_TYPE�␳, dbo.Fes�T�[�r�X.�V���{����, dbo.v_�񎟃R���e���c�����J���I�P���.�폜��� AS �J���I�P�폜���
FROM                         dbo.[v_�f�W�E�h�R�R���e���c] LEFT OUTER JOIN
                                      dbo.v_�񎟃R���e���c�����J���I�P��� ON dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ� = dbo.v_�񎟃R���e���c�����J���I�P���.�I�Ȕԍ� LEFT OUTER JOIN
                                      dbo.Fes�����ݒ�A�����W�R�[�h�}�X�^ ON dbo.v_�񎟃R���e���c�����J���I�P���.�R���e���c��� = dbo.Fes�����ݒ�A�����W�R�[�h�}�X�^.�R���e���c��� LEFT OUTER JOIN
                                          (SELECT                      t1.SONG_CODE, t2.SONG_TITLE, t2.INTRO_TYPE, iv7.INTRO_TYPE AS SONG_GROUP_INTRO_TYPE, t2.COUNTRY_CODE, t2.PLAY_TIME, t3.SONG_TITLE_RUBY AS SONG_TITLE_RUBY_0, 
                                                                                      t4.SONG_TITLE_RUBY AS SONG_TITLE_RUBY_2, t5.SONG_TITLE_RUBY AS SONG_TITLE_RUBY_3
                                                FROM                         WiiTmp.dbo.tbl_SONG_CODE AS t1 INNER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG AS t2 ON t1.SONG_ID = t2.SONG_ID LEFT OUTER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG_RUBY AS t3 ON t1.SONG_GROUPID = t3.SONG_GROUPID AND t3.LANG_SEARCH_TYPE = 'J' AND t3.SONG_RUBY_NUM = 0 LEFT OUTER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG_RUBY AS t4 ON t1.SONG_GROUPID = t4.SONG_GROUPID AND t4.LANG_SEARCH_TYPE = 'J' AND t4.SONG_RUBY_NUM = 2 LEFT OUTER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG_RUBY AS t5 ON t1.SONG_GROUPID = t5.SONG_GROUPID AND t5.LANG_SEARCH_TYPE = 'J' AND t5.SONG_RUBY_NUM = 3 LEFT OUTER JOIN
                                                                                          (SELECT                      SONG_GROUPID, INTRO_TYPE
                                                                                                FROM                         WiiTmp.dbo.tbl_SONG
                                                                                                WHERE                       (ARRANGE_CODE = 0)) AS iv7 ON t1.SONG_GROUPID = iv7.SONG_GROUPID) AS iv3 ON 
                                      dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ� = iv3.SONG_CODE LEFT OUTER JOIN
                                      dbo.Fes�T�[�r�X WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = dbo.Fes�T�[�r�X.�f�W�h�R�R���e���cID LEFT OUTER JOIN
                                      dbo.FesDISC���^�Ǘ� AS FesDISC���^�Ǘ�1 WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = FesDISC���^�Ǘ�1.�f�W�h�R�R���e���cID AND 
                                      FesDISC���^�Ǘ�1.�폜�t���O = 0 AND FesDISC���^�Ǘ�1.�o�[�W����NO = 1 LEFT OUTER JOIN
                                      dbo.FesDISC���^�Ǘ� AS FesDISC���^�Ǘ�2 WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = FesDISC���^�Ǘ�2.�f�W�h�R�R���e���cID AND 
                                      FesDISC���^�Ǘ�2.�폜�t���O = 0 AND FesDISC���^�Ǘ�2.�o�[�W����NO = 2 LEFT OUTER JOIN
                                      dbo.Fes�f���R�[�h�Ǘ� WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = dbo.Fes�f���R�[�h�Ǘ�.�f�W�h�R�R���e���cID LEFT OUTER JOIN
                                          (SELECT                      t1.SINGER_ID, t1.SINGER_NAME, iv5.SINGER_NAME_RUBY
                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME AS t1 LEFT OUTER JOIN
                                                                                          (SELECT                      t2.SINGER_ID, iv6.SINGER_NAME_RUBY
                                                                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME AS t2 INNER JOIN
                                                                                                                                          (SELECT                      SINGER_NAME_ID, SINGER_NAME_RUBY
                                                                                                                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME_RUBY AS t3
                                                                                                                                                WHERE                       (SINGER_NAME_ID < 80000 OR
                                                                                                                                                                                      SINGER_NAME_ID > 4000000) AND (SINGER_RUBY_NUM = 1)
                                                                                                                                                UNION ALL
                                                                                                                                                SELECT                      SINGER_NAME_ID, SINGER_NAME_RUBY
                                                                                                                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME_RUBY AS t4
                                                                                                                                                WHERE                       (SINGER_NAME_ID BETWEEN 100000 AND 199999) AND (LANG_SEARCH_TYPE = 'E') AND (SINGER_RUBY_NUM = 0)) AS iv6 ON 
                                                                                                                                      t2.SINGER_NAME_ID = iv6.SINGER_NAME_ID) AS iv5 ON t1.SINGER_ID = iv5.SINGER_ID
                                                WHERE                       EXISTS
                                                                                          (SELECT                      'x' AS Expr1
                                                                                                FROM                         WiiTmp.dbo.tbl_SONG AS t2
                                                                                                WHERE                       (t1.SINGER_NAME_ID = SINGER_NAME_ID))) AS iv1 ON dbo.v_�񎟃R���e���c�����J���I�P���.Pu�A�[�e�B�X�gID = iv1.SINGER_ID LEFT OUTER JOIN
                                      WiiTmp.dbo.tbl_Pu_Artist_prev ON dbo.v_�񎟃R���e���c�����J���I�P���.Pu�A�[�e�B�X�gID = WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id LEFT OUTER JOIN
                                      dbo.Fes�A�����W�\�L�ݒ�}�X�^ WITH (NOLOCK) ON dbo.v_�񎟃R���e���c�����J���I�P���.�A�����W�R�[�h = dbo.Fes�A�����W�\�L�ݒ�}�X�^.�A�����W�R�[�h LEFT OUTER JOIN
                                      dbo.Fes�f���W�������Ǒփ}�X�^ WITH (NOLOCK) ON dbo.v_�񎟃R���e���c�����J���I�P���.JV�f���敪 = dbo.Fes�f���W�������Ǒփ}�X�^.JV�f���敪
WHERE                       (dbo.[v_�f�W�E�h�R�R���e���c].BX�����t���O = 0) OR
                                      (dbo.[v_�f�W�E�h�R�R���e���c].BX�����t���O IS NULL)


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[21] 4[9] 2[51] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "v_�f�W�E�h�R�R���e���c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_�񎟃R���e���c�����J���I�P���"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 136
               Right = 556
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�����ݒ�A�����W�R�[�h�}�X�^"
            Begin Extent = 
               Top = 6
               Left = 594
               Bottom = 102
               Right = 770
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "iv3"
            Begin Extent = 
               Top = 6
               Left = 808
               Bottom = 136
               Right = 1043
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�T�[�r�X"
            Begin Extent = 
               Top = 102
               Left = 594
               Bottom = 232
               Right = 804
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FesDISC���^�Ǘ�1"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FesDISC���^�Ǘ�2"
            Begin Extent = 
               Top = 138
               Left = 265
               Bottom = 268
               Right = 454
            End
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�R���e���c_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�f���R�[�h�Ǘ�"
            Begin Extent = 
               Top = 138
               Left = 842
               Bottom = 268
               Right = 1031
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "iv1"
            Begin Extent = 
               Top = 234
               Left = 492
               Bottom = 347
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_Pu_Artist_prev (WiiTmp.dbo)"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�A�����W�\�L�ݒ�}�X�^"
            Begin Extent = 
               Top = 270
               Left = 306
               Bottom = 366
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�f���W�������Ǒփ}�X�^"
            Begin Extent = 
               Top = 270
               Left = 731
               Bottom = 366
               Right = 901
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�R���e���c_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�R���e���c_21'
GO


GO

CREATE VIEW [dbo].[v_Fes�R���e���c_WiiU_21]
AS
SELECT                      dbo.v_Fes�R���e���c_21.�f�W�h�R�R���e���cID, dbo.v_Fes�R���e���c_21.[Wii(�f�W�h�R)�I�Ȕԍ�], dbo.v_Fes�R���e���c_21.�J���I�P�I�Ȕԍ�, dbo.v_Fes�R���e���c_21.�z�M�}�[�N, 
                                      dbo.v_Fes�R���e���c_21.�J���I�P�A�����W�R�[�h, dbo.v_Fes�R���e���c_21.�A�����W��, dbo.v_Fes�R���e���c_21.�\���pFes�A�����W�R�[�h, dbo.v_Fes�R���e���c_21.Fes�A�����W�R�[�h, 
                                      dbo.v_Fes�R���e���c_21.������, dbo.v_Fes�R���e���c_21.�y�Ȗ�, dbo.v_Fes�R���e���c_21.�̎薼, dbo.v_Fes�R���e���c_21.�y�Ȗ������p�J�i, dbo.v_Fes�R���e���c_21.�Ȗ���݂��ȕ␳, 
                                      dbo.v_Fes�R���e���c_21.�y�Ȗ��\�[�g�p����, dbo.v_Fes�R���e���c_21.�y�Ȗ������\�[�g�p��, dbo.v_Fes�R���e���c_21.�Ȗ��\�[�g�p���␳, dbo.v_Fes�R���e���c_21.Artist_Id, 
                                      dbo.v_Fes�R���e���c_21.PU_ARTIST_ID, dbo.v_Fes�R���e���c_21.�̎薼�����p�J�i, dbo.v_Fes�R���e���c_21.�̎薼�\�[�g�p�J�i, dbo.v_Fes�R���e���c_21.�̎薼�����\�[�g�p��, 
                                      dbo.v_Fes�R���e���c_21.�̏��\��, dbo.v_Fes�R���e���c_21.�A�b�v�\���, dbo.v_Fes�R���e���c_21.�J���I�P���p�P������, dbo.v_Fes�R���e���c_21.�J���I�P���p�P��, CONVERT(NCHAR(8), 
                                      XDigi.xdb.XDB_T_DIGIDOCO_SEISAKU.KANPAKE_DATE, 112) AS Wii_U_���슮����, dbo.v_Fes�R���e���c_21.�T�[�r�X���\��, dbo.v_Fes�R���e���c_21.���C�c�p�T�[�r�X���\��, 
                                      dbo.v_Fes�R���e���c_21.�����\���ۃt���O, dbo.v_Fes�R���e���c_21.����t���O, dbo.v_Fes�R���e���c_21.��~��, dbo.v_Fes�R���e���c_21.�폜���, dbo.v_Fes�R���e���c_21.FesDISCID, 
                                      dbo.v_Fes�R���e���c_21.[FesDISCID(Ver2)], dbo.v_Fes�R���e���c_21.NET���p�t���O, dbo.v_Fes�R���e���c_21.[NET���p�t���O(Ver2)], dbo.v_Fes�R���e���c_21.�^��ۃt���O, 
                                      dbo.v_Fes�R���e���c_21.�^���ۃt���O, dbo.v_Fes�R���e���c_21.�L���R���e���c�t���O, dbo.v_Fes�R���e���c_21.�`���v�^�[�t���O, dbo.Wii�T�[�r�X_WiiU.Wii_U_�T�[�r�X���\��, 
                                      dbo.Wii�T�[�r�X_WiiU.Wii_U_����t���O, dbo.Wii�T�[�r�X_WiiU.Wii_U_��~��, dbo.Wii�T�[�r�X_WiiU.Wii_U_�폜���, dbo.Wii�T�[�r�X_WiiU.Wii_U_�^��ۃt���O, 
                                      dbo.Wii�T�[�r�X_WiiU.Wii_U_�^���ۃt���O, dbo.Wii�T�[�r�X_WiiU.Wii_U_�����z�M�t���O, dbo.v_Fes�R���e���c_21.INTRO_TYPE, dbo.v_Fes�R���e���c_21.SONG_GROUP_INTRO_TYPE, 
                                      dbo.v_Fes�R���e���c_21.COUNTRY_CODE, dbo.v_Fes�R���e���c_21.�̂�����, dbo.v_Fes�R���e���c_21.���t����, dbo.v_Fes�R���e���c_21.���t���ԕ␳, dbo.v_Fes�R���e���c_21.�x�����x��, 
                                      dbo.v_Fes�R���e���c_21.���Ȕ�, dbo.v_Fes�R���e���c_21.���Ȕ�2, dbo.v_Fes�R���e���c_21.���_JSTYLE, dbo.v_Fes�R���e���c_21.[JV�f���敪(�w�i�f���敪)], 
                                      dbo.v_Fes�R���e���c_21.�f���W������, dbo.v_Fes�R���e���c_21.�f���敪, dbo.v_Fes�R���e���c_21.�w�i�f���R�[�h, dbo.v_Fes�R���e���c_21.�ʉf�����b�N, dbo.v_Fes�R���e���c_21.�e�I�Ȕԍ�, 
                                      dbo.v_Fes�R���e���c_21.���쌠���l, dbo.v_Fes�R���e���c_21.���l, dbo.v_Fes�R���e���c_21.�o�^����, dbo.v_Fes�R���e���c_21.�R���e���c���, dbo.v_Fes�R���e���c_21.�y�Ȗ��M��, 
                                      dbo.v_Fes�R���e���c_21.�y�Ȗ��M�肩��, dbo.v_Fes�R���e���c_21.�J���I�P�y�Ȗ�����, dbo.v_Fes�R���e���c_21.�J���I�P�y�Ȗ�, dbo.v_Fes�R���e���c_21.�M��D��t���O, 
                                      dbo.v_Fes�R���e���c_21.�Ȗ��␳, dbo.v_Fes�R���e���c_21.����NULL�t���O, dbo.v_Fes�R���e���c_21.�Ȗ��\�[�g�␳, dbo.v_Fes�R���e���c_21.�̎�ID�␳, dbo.v_Fes�R���e���c_21.INTRO_TYPE�␳, 
                                      dbo.v_Fes�R���e���c_21.�V���{����, dbo.v_Fes�R���e���c_21.�J���I�P�폜���
FROM                         dbo.v_Fes�R���e���c_21 LEFT OUTER JOIN
                                      dbo.Wii�T�[�r�X_WiiU WITH (NOLOCK) ON dbo.v_Fes�R���e���c_21.�f�W�h�R�R���e���cID = dbo.Wii�T�[�r�X_WiiU.�f�W�h�R�R���e���cID LEFT OUTER JOIN
                                      XBase.xdb.XDB_T_CONTENT_KIHON ON dbo.v_Fes�R���e���c_21.�f�W�h�R�R���e���cID = XBase.xdb.XDB_T_CONTENT_KIHON.DIGIDOCO_CONTENT_ID LEFT OUTER JOIN
                                      XDigi.xdb.XDB_T_DIGIDOCO_SEISAKU ON XBase.xdb.XDB_T_CONTENT_KIHON.XDB_CONTENT_ID = XDigi.xdb.XDB_T_DIGIDOCO_SEISAKU.XDB_CONTENT_ID AND 
                                      XDigi.xdb.XDB_T_DIGIDOCO_SEISAKU.SEISAKU_TYPE_KBN = 15


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[3] 2[48] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Wii�T�[�r�X_WiiU"
            Begin Extent = 
               Top = 6
               Left = 314
               Bottom = 136
               Right = 518
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "XDB_T_CONTENT_KIHON (XBase.xdb)"
            Begin Extent = 
               Top = 6
               Left = 556
               Bottom = 136
               Right = 775
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "XDB_T_DIGIDOCO_SEISAKU (XDigi.xdb)"
            Begin Extent = 
               Top = 6
               Left = 813
               Bottom = 136
               Right = 1025
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_Fes�R���e���c_21"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�R���e���c_WiiU_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�R���e���c_WiiU_21'
GO

CREATE VIEW [dbo].[v_Fes�f���R�[�h�Ǘ�_21]
AS
SELECT                      dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID, dbo.[v_�f�W�E�h�R�R���e���c].�I�Ȕԍ� AS [Wii(�f�W�h�R)�I�Ȕԍ�], dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ�, 
                                      (CASE WHEN dbo.Fes�A�����W�\�L�ݒ�}�X�^.[�A�����W�R�[�h] IS NOT NULL THEN iv2.[SONG_TITLE] + dbo.[v_�񎟃R���e���c�����J���I�P���].[�A�����W�\�L��] ELSE iv2.[SONG_TITLE] END) AS �y�Ȗ�,
                                       iv1.SINGER_NAME AS �̎薼, ISNULL(dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ���݂���, '') + ISNULL(dbo.v_�񎟃R���e���c�����J���I�P���.�Ȗ��M���݂���, '') AS �y�Ȗ������p�J�i, 
                                      dbo.Fes�T�[�r�X.�Ȗ���݂��ȕ␳, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSearch_Kna AS �̎薼�����p�J�i, dbo.Fes�f���R�[�h�Ǘ�.�w�i�f���R�[�h, dbo.Fes�f���R�[�h�Ǘ�.�ʉf�����b�N, 
                                      dbo.Fes�T�[�r�X.�A�b�v�\���, dbo.Fes�T�[�r�X.�T�[�r�X���\��, dbo.Fes�T�[�r�X.����t���O, dbo.v_�񎟃R���e���c�����J���I�P���.JV�f���敪 AS [JV�f���敪(�w�i�f���敪)], 
                                      dbo.v_�񎟃R���e���c�����J���I�P���.�R���e���c���, dbo.Fes�f���R�[�h�Ǘ�.���l
FROM                         dbo.[v_�f�W�E�h�R�R���e���c] LEFT OUTER JOIN
                                          (SELECT                      t1.SONG_CODE, t2.SONG_TITLE
                                                FROM                         WiiTmp.dbo.tbl_SONG_CODE AS t1 INNER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG AS t2 ON t1.SONG_ID = t2.SONG_ID) AS iv2 ON dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ� = iv2.SONG_CODE LEFT OUTER JOIN
                                      dbo.Fes�T�[�r�X WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = dbo.Fes�T�[�r�X.�f�W�h�R�R���e���cID LEFT OUTER JOIN
                                      dbo.v_�񎟃R���e���c�����J���I�P��� ON dbo.[v_�f�W�E�h�R�R���e���c].�J���I�P�I�Ȕԍ� = dbo.v_�񎟃R���e���c�����J���I�P���.�I�Ȕԍ� LEFT OUTER JOIN
                                      WiiTmp.dbo.tbl_Pu_Artist_prev ON dbo.v_�񎟃R���e���c�����J���I�P���.Pu�A�[�e�B�X�gID = WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id LEFT OUTER JOIN
                                          (SELECT                      SINGER_ID, SINGER_NAME
                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME AS t1
                                                WHERE                       EXISTS
                                                                                          (SELECT                      'x' AS Expr1
                                                                                                FROM                         WiiTmp.dbo.tbl_SONG AS t2
                                                                                                WHERE                       (t1.SINGER_NAME_ID = SINGER_NAME_ID))) AS iv1 ON dbo.v_�񎟃R���e���c�����J���I�P���.Pu�A�[�e�B�X�gID = iv1.SINGER_ID LEFT OUTER JOIN
                                      dbo.Fes�f���R�[�h�Ǘ� WITH (NOLOCK) ON dbo.[v_�f�W�E�h�R�R���e���c].�f�W�h�R�R���e���cID = dbo.Fes�f���R�[�h�Ǘ�.�f�W�h�R�R���e���cID LEFT OUTER JOIN
                                      dbo.Fes�A�����W�\�L�ݒ�}�X�^ WITH (NOLOCK) ON dbo.v_�񎟃R���e���c�����J���I�P���.�A�����W�R�[�h = dbo.Fes�A�����W�\�L�ݒ�}�X�^.�A�����W�R�[�h
WHERE                       (dbo.[v_�f�W�E�h�R�R���e���c].BX�����t���O = 0) OR
                                      (dbo.[v_�f�W�E�h�R�R���e���c].BX�����t���O IS NULL)


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[18] 4[3] 2[50] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "v_�f�W�E�h�R�R���e���c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "iv2"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 102
               Right = 482
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�T�[�r�X"
            Begin Extent = 
               Top = 6
               Left = 520
               Bottom = 136
               Right = 730
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_�񎟃R���e���c�����J���I�P���"
            Begin Extent = 
               Top = 6
               Left = 768
               Bottom = 136
               Right = 1012
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_Pu_Artist_prev (WiiTmp.dbo)"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "iv1"
            Begin Extent = 
               Top = 102
               Left = 312
               Bottom = 198
               Right = 482
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�f���R�[�h�Ǘ�"
            Begin Extent = 
               Top = 138
               Left = 520
               Bottom = 268
               Right = 709
            End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�f���R�[�h�Ǘ�_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes�A�����W�\�L�ݒ�}�X�^"
            Begin Extent = 
               Top = 138
               Left = 747
               Bottom = 234
               Right = 917
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�f���R�[�h�Ǘ�_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes�f���R�[�h�Ǘ�_21'
GO

--Create store 

GO

CREATE  Procedure [dbo].[usp_CreateFesContentsTable_AddPlayTime_21]
	(
		@target_date nchar( 8 )
	)
As
	set nocount on

	truncate table WiiTmp.dbo.[tbl_Fes�R���e���c_���t���Ԓǉ�]

	insert into
		WiiTmp.dbo.[tbl_Fes�R���e���c_���t���Ԓǉ�]
	(
		[�I�Ȕԍ�],
		[�y�Ȗ�],
		[�y�Ȗ������p�J�i],
		[���������t���O],
		[�y�Ȗ��\�[�g�p�J�i],
		[�̎�ID],
		[�A�����W�R�[�h],
		[���̃t���O],
		[�J���I�P�I�Ȕԍ�],
		[���],
		[�f���W������],
		[���Ȕ�],
		[���t����NULL],
		[���t����],
		[�R���e���c�x�����x��]
	)
	select 
		v1.[Wii(�f�W�h�R)�I�Ȕԍ�],
		IsNull(v1.[�Ȗ��␳],
			(CASE
				WHEN v1.[�M��D��t���O] = 1 THEN
					v1.[�y�Ȗ��M��] + '[' + v1.[�J���I�P�y�Ȗ�] + ']'
				ELSE
					v1.[�y�Ȗ�]
			END)
		) AS [�y�Ȗ�],
		(CASE
			WHEN v1.[����NULL�t���O] = 1 THEN
				NULL
			ELSE
				IsNull(v1.[�Ȗ���݂��ȕ␳],
					(CASE
						WHEN v1.[�M��D��t���O] = 1 THEN
							v1.[�y�Ȗ��M�肩��] + v1.[�J���I�P�y�Ȗ�����]
						ELSE
							v1.[�y�Ȗ������p�J�i]
					END)
				)
		END) AS [�y�Ȗ������p�J�i],
		(CASE
			WHEN v1.[�Ȗ��\�[�g�␳] IS NOT NULL THEN
				1
			WHEN v1.[�M��D��t���O] = 1 THEN
				1
			ELSE
				0
		END) AS [���������t���O],
		IsNull(v1.[�Ȗ��\�[�g�␳],
			(CASE
				WHEN v1.[�M��D��t���O] = 1 THEN
					v1.[�y�Ȗ��M�肩��] + v1.[�J���I�P�y�Ȗ�����]
				ELSE
					v1.[�y�Ȗ��\�[�g�p����]
			END)
		) AS [�y�Ȗ��\�[�g�p�J�i],
		IsNull(v1.[�̎�ID�␳], v1.[PU_ARTIST_ID]) as [�̎�ID],
		v1.[Fes�A�����W�R�[�h],
		iv1.[���̃t���O],
		v1.[�J���I�P�I�Ȕԍ�],
		v1.[���_JSTYLE] as [���],
		IsNull(v1.[�f���敪], v1.[�f���W������]) as [�f���W������],
		IsNull(v1.[���Ȕ�2], v1.[���Ȕ�]) as [���Ȕ�],
		IIF(DATALENGTH(CONCAT(v1.[���t���ԕ␳],v1.[���t����])) = 0,270,NULL) as [���t����NULL],		
		IIF(DATALENGTH(CONCAT(v1.[���t���ԕ␳],v1.[���t����])) = 0,270, IsNull(v1.[���t���ԕ␳], v1.[���t����])) as [���t����],
		--IsNull(v1.[���t���ԕ␳], v1.[���t����]) as [���t����],		
		v1.[�x�����x��] as [�R���e���c�x�����x��]
	from
		dbo.[v_Fes�R���e���c] as v1
	left outer join
		(select distinct
			t2.[�I�Ȕԍ�],
			1 as [���̃t���O]
		 from
			WiiTmp.dbo.[tbl_Fes�W������] as t2
		 where
			t2.[���̃t���O] = 1
		 and t2.[�o�[�W����NO] = '2' ) as iv1 on v1.[Wii(�f�W�h�R)�I�Ȕԍ�] = iv1.[�I�Ȕԍ�]
	where
		v1.[�T�[�r�X���\��] <= @target_date
	and
		v1.[Wii(�f�W�h�R)�I�Ȕԍ�] is not null
	return
GO

--Create [usp_SelectFesContentsAll_AddPlayTime_21]
CREATE Procedure [dbo].[usp_SelectFesContentsAll_AddPlayTime_21]
/*	(
	)
*/
As
	set nocount on

	select 
		t1.[�I�Ȕԍ�],
		t1.[�y�Ȗ�],
		t1.[�y�Ȗ������p�J�i],
		t1.[���������t���O],
		t1.[�y�Ȗ��\�[�g�p�J�i],
		t1.[�̎�ID],
		t1.[�A�����W�R�[�h],
		IsNull(t1.[���̃t���O],0),
		t1.[�J���I�P�I�Ȕԍ�],
		t1.[���],
		t1.[�f���W������], 
		t1.[���Ȕ�],
		t1.[���t����],
		t1.[���t����NULL],
		IsNull(t1.[�R���e���c�x�����x��], (select [�x�����x��] from dbo.[Fes�x�����x��] as t3 where t3.[�f�t�H���g�t���O] = 1)) as [�R���e���c�x�����x��]
	from
		WiiTmp.dbo.[tbl_Fes�R���e���c_���t���Ԓǉ�] as t1
	order by
		t1.[�I�Ȕԍ�]

	return

GO

