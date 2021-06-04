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


--Create module values
Use[Wii]
GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes機能ID] where 機能ID = 220)
begin
insert into [Wii].[dbo].[Fes機能ID] (プロジェクトID,機能ID,	機能名) values (1,220,'背景映像メンテ'); 
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes権限グループ機能割当] where 機能ID = 220 AND プロジェクトID = 1 AND 権限グループ='SystemAdmin')
begin
insert into [Wii].[dbo].[Fes権限グループ機能割当] (権限グループ,プロジェクトID,機能ID,	更新タイプ) values ('SystemAdmin',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes権限グループ機能割当] where 機能ID = 220 AND プロジェクトID =1 AND 権限グループ='SeisakuUser')
begin
insert into [Wii].[dbo].[Fes権限グループ機能割当] (権限グループ,プロジェクトID,機能ID,	更新タイプ) values ('SeisakuUser',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes権限グループ機能割当] where 機能ID = 220 AND プロジェクトID =1 AND 権限グループ='HenseiUser')
begin
insert into [Wii].[dbo].[Fes権限グループ機能割当] (権限グループ,プロジェクトID,機能ID,	更新タイプ) values ('HenseiUser',1,220,2);
end

GO
if NOT EXISTS(select top 1 * from [Wii].[dbo].[Fes権限グループ機能割当] where 機能ID = 220 AND プロジェクトID =1 AND 権限グループ='__Guest__')
begin
insert into [Wii].[dbo].[Fes権限グループ機能割当] (権限グループ,プロジェクトID,機能ID,	更新タイプ)  values ('__Guest__',1,220,0);
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
--Add column 個別映像ロック in table Fesサービス,
IF COL_LENGTH('[dbo].[Fesサービス]', '個別映像ロック') IS NULL BEGIN ALTER TABLE [dbo].[Fesサービス] ADD 個別映像ロック INT; END;

GO
--Add column 個別映像ロック in table Fes映像コード管理
IF COL_LENGTH('[Wii].[dbo].[Fes映像コード管理]', '個別映像ロック') IS NULL BEGIN ALTER TABLE [Wii].[dbo].[Fes映像コード管理] ADD 個別映像ロック INT; END;

GO

--Add column [演奏時間NULL] in table [dbo].[tbl_Fesコンテンツ_演奏時間追加]
IF COL_LENGTH('[WiiTmp].[dbo].[tbl_Fesコンテンツ_演奏時間追加]', '演奏時間NULL') IS NULL BEGIN ALTER TABLE [WiiTmp].[dbo].[tbl_Fesコンテンツ_演奏時間追加] ADD 演奏時間NULL INT; END;
GO

CREATE VIEW [dbo].[v_Fesコンテンツ_21]
AS
SELECT                      dbo.[v_デジ・ドココンテンツ].デジドココンテンツID, dbo.[v_デジ・ドココンテンツ].選曲番号 AS [Wii(デジドコ)選曲番号], dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.配信マーク, dbo.v_二次コンテンツ向けカラオケ情報.アレンジコード AS カラオケアレンジコード, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.アレンジ表記名 AS アレンジ名, (CASE WHEN dbo.Fes初期設定アレンジコードマスタ.[Fesアレンジコード] IS NOT NULL 
                                      THEN dbo.Fes初期設定アレンジコードマスタ.[Fesアレンジコード] ELSE 1 END) AS 表示用Fesアレンジコード, dbo.Fesサービス.Fesアレンジコード, dbo.v_二次コンテンツ向けカラオケ情報.発売日, 
                                      (CASE WHEN dbo.Fesアレンジ表記設定マスタ.[アレンジコード] IS NOT NULL THEN iv3.[SONG_TITLE] + dbo.[v_二次コンテンツ向けカラオケ情報].[アレンジ表記名] ELSE iv3.[SONG_TITLE] END) AS 楽曲名,
                                       iv1.SINGER_NAME AS 歌手名, ISNULL(dbo.v_二次コンテンツ向けカラオケ情報.曲名よみがな, N'') + ISNULL(dbo.v_二次コンテンツ向けカラオケ情報.曲名邦題よみがな, N'') AS 楽曲名検索用カナ, 
                                      dbo.Fesサービス.曲名よみがな補正, ISNULL(iv3.SONG_TITLE_RUBY_0, N'') + ISNULL(iv3.SONG_TITLE_RUBY_3, N'') AS 楽曲名ソート用かな, iv3.SONG_TITLE_RUBY_2 AS 楽曲名検索ソート英字, 
                                      dbo.Fesサービス.曲名ソート英字補正, WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id, (CASE WHEN WiiTmp.dbo.[tbl_Pu_Artist_prev].[GroupArtist_Id] IS NOT NULL THEN CONVERT(nvarchar, 
                                      WiiTmp.dbo.[tbl_Pu_Artist_prev].[GroupArtist_Id]) + replicate('0', 2 - len(CONVERT(nvarchar, WiiTmp.dbo.[tbl_Pu_Artist_prev].[Artist_Seq]))) + CONVERT(nvarchar, WiiTmp.dbo.[tbl_Pu_Artist_prev].[Artist_Seq]) 
                                      ELSE NULL END) AS PU_ARTIST_ID, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSearch_Kna AS 歌手名検索用カナ, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSort_Kna AS 歌手名ソート用カナ, 
                                      iv1.SINGER_NAME_RUBY AS 歌手名検索ソート英字, dbo.v_二次コンテンツ向けカラオケ情報.歌唱可能日, dbo.Fesサービス.アップ予定日, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.完パケ期限日 AS カラオケ完パケ期限日, dbo.v_二次コンテンツ向けカラオケ情報.完パケ日 AS カラオケ完パケ日, dbo.Fesサービス.サービス発表日, 
                                      dbo.Fesサービス.ライツ用サービス発表日, dbo.Fesサービス.検索表示可否フラグ, dbo.Fesサービス.取消フラグ, dbo.Fesサービス.停止日, dbo.Fesサービス.削除情報, FesDISC収録管理1.FesDISCID, 
                                      FesDISC収録管理2.FesDISCID AS [FesDISCID(Ver2)], FesDISC収録管理1.NET利用フラグ, FesDISC収録管理2.NET利用フラグ AS [NET利用フラグ(Ver2)], dbo.Fesサービス.録画可否フラグ, 
                                      dbo.Fesサービス.録音可否フラグ, dbo.Fesサービス.有料コンテンツフラグ, dbo.Fesサービス.チャプターフラグ, iv3.INTRO_TYPE, iv3.SONG_GROUP_INTRO_TYPE, iv3.COUNTRY_CODE, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.歌い出し AS 歌いだし, iv3.PLAY_TIME AS 演奏時間, dbo.Fesサービス.演奏時間補正, dbo.Fesサービス.支援レベル, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.原曲比, dbo.v_二次コンテンツ向けカラオケ情報.原曲比2, dbo.v_二次コンテンツ向けカラオケ情報.[情報欄J-STYLE] AS 情報欄_JSTYLE, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.JV映像区分 AS [JV映像区分(背景映像区分)], dbo.Fes映像ジャンル読替マスタ.映像ジャンル, dbo.Fesサービス.映像区分, 
                                      dbo.Fes映像コード管理.背景映像コード, dbo.Fesサービス.個別映像ロック, dbo.v_二次コンテンツ向けカラオケ情報.親選曲番号, dbo.Fesサービス.著作権備考, dbo.Fesサービス.備考, 
                                      dbo.[v_デジ・ドココンテンツ].登録日時, dbo.v_二次コンテンツ向けカラオケ情報.コンテンツ種類, dbo.v_二次コンテンツ向けカラオケ情報.曲名邦題 AS 楽曲名邦題, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.曲名邦題よみがな AS 楽曲名邦題かな, dbo.v_二次コンテンツ向けカラオケ情報.曲名よみがな AS カラオケ楽曲名かな, 
                                      dbo.v_二次コンテンツ向けカラオケ情報.曲名 AS カラオケ楽曲名, dbo.Fesサービス.邦題優先フラグ, dbo.Fesサービス.曲名補正, dbo.Fesサービス.かなNULLフラグ, dbo.Fesサービス.曲名ソート補正, 
                                      dbo.Fesサービス.歌手ID補正, dbo.Fesサービス.INTRO_TYPE補正, dbo.Fesサービス.新譜本扱月, dbo.v_二次コンテンツ向けカラオケ情報.削除情報 AS カラオケ削除情報
FROM                         dbo.[v_デジ・ドココンテンツ] LEFT OUTER JOIN
                                      dbo.v_二次コンテンツ向けカラオケ情報 ON dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号 = dbo.v_二次コンテンツ向けカラオケ情報.選曲番号 LEFT OUTER JOIN
                                      dbo.Fes初期設定アレンジコードマスタ ON dbo.v_二次コンテンツ向けカラオケ情報.コンテンツ種類 = dbo.Fes初期設定アレンジコードマスタ.コンテンツ種類 LEFT OUTER JOIN
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
                                      dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号 = iv3.SONG_CODE LEFT OUTER JOIN
                                      dbo.Fesサービス WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = dbo.Fesサービス.デジドココンテンツID LEFT OUTER JOIN
                                      dbo.FesDISC収録管理 AS FesDISC収録管理1 WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = FesDISC収録管理1.デジドココンテンツID AND 
                                      FesDISC収録管理1.削除フラグ = 0 AND FesDISC収録管理1.バージョンNO = 1 LEFT OUTER JOIN
                                      dbo.FesDISC収録管理 AS FesDISC収録管理2 WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = FesDISC収録管理2.デジドココンテンツID AND 
                                      FesDISC収録管理2.削除フラグ = 0 AND FesDISC収録管理2.バージョンNO = 2 LEFT OUTER JOIN
                                      dbo.Fes映像コード管理 WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = dbo.Fes映像コード管理.デジドココンテンツID LEFT OUTER JOIN
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
                                                                                                WHERE                       (t1.SINGER_NAME_ID = SINGER_NAME_ID))) AS iv1 ON dbo.v_二次コンテンツ向けカラオケ情報.PuアーティストID = iv1.SINGER_ID LEFT OUTER JOIN
                                      WiiTmp.dbo.tbl_Pu_Artist_prev ON dbo.v_二次コンテンツ向けカラオケ情報.PuアーティストID = WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id LEFT OUTER JOIN
                                      dbo.Fesアレンジ表記設定マスタ WITH (NOLOCK) ON dbo.v_二次コンテンツ向けカラオケ情報.アレンジコード = dbo.Fesアレンジ表記設定マスタ.アレンジコード LEFT OUTER JOIN
                                      dbo.Fes映像ジャンル読替マスタ WITH (NOLOCK) ON dbo.v_二次コンテンツ向けカラオケ情報.JV映像区分 = dbo.Fes映像ジャンル読替マスタ.JV映像区分
WHERE                       (dbo.[v_デジ・ドココンテンツ].BX試聴フラグ = 0) OR
                                      (dbo.[v_デジ・ドココンテンツ].BX試聴フラグ IS NULL)


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
         Begin Table = "v_デジ・ドココンテンツ"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_二次コンテンツ向けカラオケ情報"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 136
               Right = 556
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes初期設定アレンジコードマスタ"
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
         Begin Table = "Fesサービス"
            Begin Extent = 
               Top = 102
               Left = 594
               Bottom = 232
               Right = 804
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FesDISC収録管理1"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FesDISC収録管理2"
            Begin Extent = 
               Top = 138
               Left = 265
               Bottom = 268
               Right = 454
            End
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fesコンテンツ_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes映像コード管理"
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
         Begin Table = "Fesアレンジ表記設定マスタ"
            Begin Extent = 
               Top = 270
               Left = 306
               Bottom = 366
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fes映像ジャンル読替マスタ"
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fesコンテンツ_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fesコンテンツ_21'
GO


GO

CREATE VIEW [dbo].[v_Fesコンテンツ_WiiU_21]
AS
SELECT                      dbo.v_Fesコンテンツ_21.デジドココンテンツID, dbo.v_Fesコンテンツ_21.[Wii(デジドコ)選曲番号], dbo.v_Fesコンテンツ_21.カラオケ選曲番号, dbo.v_Fesコンテンツ_21.配信マーク, 
                                      dbo.v_Fesコンテンツ_21.カラオケアレンジコード, dbo.v_Fesコンテンツ_21.アレンジ名, dbo.v_Fesコンテンツ_21.表示用Fesアレンジコード, dbo.v_Fesコンテンツ_21.Fesアレンジコード, 
                                      dbo.v_Fesコンテンツ_21.発売日, dbo.v_Fesコンテンツ_21.楽曲名, dbo.v_Fesコンテンツ_21.歌手名, dbo.v_Fesコンテンツ_21.楽曲名検索用カナ, dbo.v_Fesコンテンツ_21.曲名よみがな補正, 
                                      dbo.v_Fesコンテンツ_21.楽曲名ソート用かな, dbo.v_Fesコンテンツ_21.楽曲名検索ソート英字, dbo.v_Fesコンテンツ_21.曲名ソート英字補正, dbo.v_Fesコンテンツ_21.Artist_Id, 
                                      dbo.v_Fesコンテンツ_21.PU_ARTIST_ID, dbo.v_Fesコンテンツ_21.歌手名検索用カナ, dbo.v_Fesコンテンツ_21.歌手名ソート用カナ, dbo.v_Fesコンテンツ_21.歌手名検索ソート英字, 
                                      dbo.v_Fesコンテンツ_21.歌唱可能日, dbo.v_Fesコンテンツ_21.アップ予定日, dbo.v_Fesコンテンツ_21.カラオケ完パケ期限日, dbo.v_Fesコンテンツ_21.カラオケ完パケ日, CONVERT(NCHAR(8), 
                                      XDigi.xdb.XDB_T_DIGIDOCO_SEISAKU.KANPAKE_DATE, 112) AS Wii_U_制作完了日, dbo.v_Fesコンテンツ_21.サービス発表日, dbo.v_Fesコンテンツ_21.ライツ用サービス発表日, 
                                      dbo.v_Fesコンテンツ_21.検索表示可否フラグ, dbo.v_Fesコンテンツ_21.取消フラグ, dbo.v_Fesコンテンツ_21.停止日, dbo.v_Fesコンテンツ_21.削除情報, dbo.v_Fesコンテンツ_21.FesDISCID, 
                                      dbo.v_Fesコンテンツ_21.[FesDISCID(Ver2)], dbo.v_Fesコンテンツ_21.NET利用フラグ, dbo.v_Fesコンテンツ_21.[NET利用フラグ(Ver2)], dbo.v_Fesコンテンツ_21.録画可否フラグ, 
                                      dbo.v_Fesコンテンツ_21.録音可否フラグ, dbo.v_Fesコンテンツ_21.有料コンテンツフラグ, dbo.v_Fesコンテンツ_21.チャプターフラグ, dbo.Wiiサービス_WiiU.Wii_U_サービス発表日, 
                                      dbo.Wiiサービス_WiiU.Wii_U_取消フラグ, dbo.Wiiサービス_WiiU.Wii_U_停止日, dbo.Wiiサービス_WiiU.Wii_U_削除情報, dbo.Wiiサービス_WiiU.Wii_U_録画可否フラグ, 
                                      dbo.Wiiサービス_WiiU.Wii_U_録音可否フラグ, dbo.Wiiサービス_WiiU.Wii_U_無料配信フラグ, dbo.v_Fesコンテンツ_21.INTRO_TYPE, dbo.v_Fesコンテンツ_21.SONG_GROUP_INTRO_TYPE, 
                                      dbo.v_Fesコンテンツ_21.COUNTRY_CODE, dbo.v_Fesコンテンツ_21.歌いだし, dbo.v_Fesコンテンツ_21.演奏時間, dbo.v_Fesコンテンツ_21.演奏時間補正, dbo.v_Fesコンテンツ_21.支援レベル, 
                                      dbo.v_Fesコンテンツ_21.原曲比, dbo.v_Fesコンテンツ_21.原曲比2, dbo.v_Fesコンテンツ_21.情報欄_JSTYLE, dbo.v_Fesコンテンツ_21.[JV映像区分(背景映像区分)], 
                                      dbo.v_Fesコンテンツ_21.映像ジャンル, dbo.v_Fesコンテンツ_21.映像区分, dbo.v_Fesコンテンツ_21.背景映像コード, dbo.v_Fesコンテンツ_21.個別映像ロック, dbo.v_Fesコンテンツ_21.親選曲番号, 
                                      dbo.v_Fesコンテンツ_21.著作権備考, dbo.v_Fesコンテンツ_21.備考, dbo.v_Fesコンテンツ_21.登録日時, dbo.v_Fesコンテンツ_21.コンテンツ種類, dbo.v_Fesコンテンツ_21.楽曲名邦題, 
                                      dbo.v_Fesコンテンツ_21.楽曲名邦題かな, dbo.v_Fesコンテンツ_21.カラオケ楽曲名かな, dbo.v_Fesコンテンツ_21.カラオケ楽曲名, dbo.v_Fesコンテンツ_21.邦題優先フラグ, 
                                      dbo.v_Fesコンテンツ_21.曲名補正, dbo.v_Fesコンテンツ_21.かなNULLフラグ, dbo.v_Fesコンテンツ_21.曲名ソート補正, dbo.v_Fesコンテンツ_21.歌手ID補正, dbo.v_Fesコンテンツ_21.INTRO_TYPE補正, 
                                      dbo.v_Fesコンテンツ_21.新譜本扱月, dbo.v_Fesコンテンツ_21.カラオケ削除情報
FROM                         dbo.v_Fesコンテンツ_21 LEFT OUTER JOIN
                                      dbo.Wiiサービス_WiiU WITH (NOLOCK) ON dbo.v_Fesコンテンツ_21.デジドココンテンツID = dbo.Wiiサービス_WiiU.デジドココンテンツID LEFT OUTER JOIN
                                      XBase.xdb.XDB_T_CONTENT_KIHON ON dbo.v_Fesコンテンツ_21.デジドココンテンツID = XBase.xdb.XDB_T_CONTENT_KIHON.DIGIDOCO_CONTENT_ID LEFT OUTER JOIN
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
         Begin Table = "Wiiサービス_WiiU"
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
         Begin Table = "v_Fesコンテンツ_21"
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fesコンテンツ_WiiU_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fesコンテンツ_WiiU_21'
GO

CREATE VIEW [dbo].[v_Fes映像コード管理_21]
AS
SELECT                      dbo.[v_デジ・ドココンテンツ].デジドココンテンツID, dbo.[v_デジ・ドココンテンツ].選曲番号 AS [Wii(デジドコ)選曲番号], dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号, 
                                      (CASE WHEN dbo.Fesアレンジ表記設定マスタ.[アレンジコード] IS NOT NULL THEN iv2.[SONG_TITLE] + dbo.[v_二次コンテンツ向けカラオケ情報].[アレンジ表記名] ELSE iv2.[SONG_TITLE] END) AS 楽曲名,
                                       iv1.SINGER_NAME AS 歌手名, ISNULL(dbo.v_二次コンテンツ向けカラオケ情報.曲名よみがな, '') + ISNULL(dbo.v_二次コンテンツ向けカラオケ情報.曲名邦題よみがな, '') AS 楽曲名検索用カナ, 
                                      dbo.Fesサービス.曲名よみがな補正, WiiTmp.dbo.tbl_Pu_Artist_prev.ArtistNameSearch_Kna AS 歌手名検索用カナ, dbo.Fes映像コード管理.背景映像コード, dbo.Fes映像コード管理.個別映像ロック, 
                                      dbo.Fesサービス.アップ予定日, dbo.Fesサービス.サービス発表日, dbo.Fesサービス.取消フラグ, dbo.v_二次コンテンツ向けカラオケ情報.JV映像区分 AS [JV映像区分(背景映像区分)], 
                                      dbo.v_二次コンテンツ向けカラオケ情報.コンテンツ種類, dbo.Fes映像コード管理.備考
FROM                         dbo.[v_デジ・ドココンテンツ] LEFT OUTER JOIN
                                          (SELECT                      t1.SONG_CODE, t2.SONG_TITLE
                                                FROM                         WiiTmp.dbo.tbl_SONG_CODE AS t1 INNER JOIN
                                                                                      WiiTmp.dbo.tbl_SONG AS t2 ON t1.SONG_ID = t2.SONG_ID) AS iv2 ON dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号 = iv2.SONG_CODE LEFT OUTER JOIN
                                      dbo.Fesサービス WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = dbo.Fesサービス.デジドココンテンツID LEFT OUTER JOIN
                                      dbo.v_二次コンテンツ向けカラオケ情報 ON dbo.[v_デジ・ドココンテンツ].カラオケ選曲番号 = dbo.v_二次コンテンツ向けカラオケ情報.選曲番号 LEFT OUTER JOIN
                                      WiiTmp.dbo.tbl_Pu_Artist_prev ON dbo.v_二次コンテンツ向けカラオケ情報.PuアーティストID = WiiTmp.dbo.tbl_Pu_Artist_prev.Artist_Id LEFT OUTER JOIN
                                          (SELECT                      SINGER_ID, SINGER_NAME
                                                FROM                         WiiTmp.dbo.tbl_SINGER_NAME AS t1
                                                WHERE                       EXISTS
                                                                                          (SELECT                      'x' AS Expr1
                                                                                                FROM                         WiiTmp.dbo.tbl_SONG AS t2
                                                                                                WHERE                       (t1.SINGER_NAME_ID = SINGER_NAME_ID))) AS iv1 ON dbo.v_二次コンテンツ向けカラオケ情報.PuアーティストID = iv1.SINGER_ID LEFT OUTER JOIN
                                      dbo.Fes映像コード管理 WITH (NOLOCK) ON dbo.[v_デジ・ドココンテンツ].デジドココンテンツID = dbo.Fes映像コード管理.デジドココンテンツID LEFT OUTER JOIN
                                      dbo.Fesアレンジ表記設定マスタ WITH (NOLOCK) ON dbo.v_二次コンテンツ向けカラオケ情報.アレンジコード = dbo.Fesアレンジ表記設定マスタ.アレンジコード
WHERE                       (dbo.[v_デジ・ドココンテンツ].BX試聴フラグ = 0) OR
                                      (dbo.[v_デジ・ドココンテンツ].BX試聴フラグ IS NULL)


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
         Begin Table = "v_デジ・ドココンテンツ"
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
         Begin Table = "Fesサービス"
            Begin Extent = 
               Top = 6
               Left = 520
               Bottom = 136
               Right = 730
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_二次コンテンツ向けカラオケ情報"
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
         Begin Table = "Fes映像コード管理"
            Begin Extent = 
               Top = 138
               Left = 520
               Bottom = 268
               Right = 709
            End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes映像コード管理_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Fesアレンジ表記設定マスタ"
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes映像コード管理_21'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_Fes映像コード管理_21'
GO

--Create store 

GO

CREATE  Procedure [dbo].[usp_CreateFesContentsTable_AddPlayTime_21]
	(
		@target_date nchar( 8 )
	)
As
	set nocount on

	truncate table WiiTmp.dbo.[tbl_Fesコンテンツ_演奏時間追加]

	insert into
		WiiTmp.dbo.[tbl_Fesコンテンツ_演奏時間追加]
	(
		[選曲番号],
		[楽曲名],
		[楽曲名検索用カナ],
		[清音処理フラグ],
		[楽曲名ソート用カナ],
		[歌手ID],
		[アレンジコード],
		[演歌フラグ],
		[カラオケ選曲番号],
		[情報欄],
		[映像ジャンル],
		[原曲比],
		[演奏時間NULL],
		[演奏時間],
		[コンテンツ支援レベル]
	)
	select 
		v1.[Wii(デジドコ)選曲番号],
		IsNull(v1.[曲名補正],
			(CASE
				WHEN v1.[邦題優先フラグ] = 1 THEN
					v1.[楽曲名邦題] + '[' + v1.[カラオケ楽曲名] + ']'
				ELSE
					v1.[楽曲名]
			END)
		) AS [楽曲名],
		(CASE
			WHEN v1.[かなNULLフラグ] = 1 THEN
				NULL
			ELSE
				IsNull(v1.[曲名よみがな補正],
					(CASE
						WHEN v1.[邦題優先フラグ] = 1 THEN
							v1.[楽曲名邦題かな] + v1.[カラオケ楽曲名かな]
						ELSE
							v1.[楽曲名検索用カナ]
					END)
				)
		END) AS [楽曲名検索用カナ],
		(CASE
			WHEN v1.[曲名ソート補正] IS NOT NULL THEN
				1
			WHEN v1.[邦題優先フラグ] = 1 THEN
				1
			ELSE
				0
		END) AS [清音処理フラグ],
		IsNull(v1.[曲名ソート補正],
			(CASE
				WHEN v1.[邦題優先フラグ] = 1 THEN
					v1.[楽曲名邦題かな] + v1.[カラオケ楽曲名かな]
				ELSE
					v1.[楽曲名ソート用かな]
			END)
		) AS [楽曲名ソート用カナ],
		IsNull(v1.[歌手ID補正], v1.[PU_ARTIST_ID]) as [歌手ID],
		v1.[Fesアレンジコード],
		iv1.[演歌フラグ],
		v1.[カラオケ選曲番号],
		v1.[情報欄_JSTYLE] as [情報欄],
		IsNull(v1.[映像区分], v1.[映像ジャンル]) as [映像ジャンル],
		IsNull(v1.[原曲比2], v1.[原曲比]) as [原曲比],
		IIF(DATALENGTH(CONCAT(v1.[演奏時間補正],v1.[演奏時間])) = 0,270,NULL) as [演奏時間NULL],		
		IIF(DATALENGTH(CONCAT(v1.[演奏時間補正],v1.[演奏時間])) = 0,270, IsNull(v1.[演奏時間補正], v1.[演奏時間])) as [演奏時間],
		--IsNull(v1.[演奏時間補正], v1.[演奏時間]) as [演奏時間],		
		v1.[支援レベル] as [コンテンツ支援レベル]
	from
		dbo.[v_Fesコンテンツ] as v1
	left outer join
		(select distinct
			t2.[選曲番号],
			1 as [演歌フラグ]
		 from
			WiiTmp.dbo.[tbl_Fesジャンル] as t2
		 where
			t2.[演歌フラグ] = 1
		 and t2.[バージョンNO] = '2' ) as iv1 on v1.[Wii(デジドコ)選曲番号] = iv1.[選曲番号]
	where
		v1.[サービス発表日] <= @target_date
	and
		v1.[Wii(デジドコ)選曲番号] is not null
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
		t1.[選曲番号],
		t1.[楽曲名],
		t1.[楽曲名検索用カナ],
		t1.[清音処理フラグ],
		t1.[楽曲名ソート用カナ],
		t1.[歌手ID],
		t1.[アレンジコード],
		IsNull(t1.[演歌フラグ],0),
		t1.[カラオケ選曲番号],
		t1.[情報欄],
		t1.[映像ジャンル], 
		t1.[原曲比],
		t1.[演奏時間],
		t1.[演奏時間NULL],
		IsNull(t1.[コンテンツ支援レベル], (select [支援レベル] from dbo.[Fes支援レベル] as t3 where t3.[デフォルトフラグ] = 1)) as [コンテンツ支援レベル]
	from
		WiiTmp.dbo.[tbl_Fesコンテンツ_演奏時間追加] as t1
	order by
		t1.[選曲番号]

	return

GO

