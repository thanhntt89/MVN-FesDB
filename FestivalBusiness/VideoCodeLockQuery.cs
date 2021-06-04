using System;
using System.Data;

namespace FestivalBusiness
{
    public class VideoCodeLockQuery
    {
        public static string GetDropTableWorkQuery()
        {
            string query = string.Format("USE [WiiTmp]; IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Wrk_VideoCodeLock_{0}') AND type in (N'U')) BEGIN drop table Wrk_VideoCodeLock_{0} END; ", Environment.MachineName.Replace(" -", "_"));
            return query;
        }

        internal static string GetCreateTmpQuery()
        {
            string query = string.Format("USE [WiiTmp]; IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'WiiTmp.dbo.[Wrk_VideoCodeLock_{0}]') AND type in (N'U')) BEGIN CREATE TABLE WiiTmp.dbo.[Wrk_VideoCodeLock_{0}]([VideoCode][nvarchar](7) NOT NULL,[MaterialID][int] NULL,[Contents][nvarchar](250) NULL,[MaterialEndDate][varchar](8) NULL,[BackgroundVideoLock][int] NULL, PRIMARY KEY CLUSTERED([VideoCode] ASC) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] END; ", Environment.MachineName.Replace(" -", "_"));

            return query;
        }

        internal static string GetDeleteVideoCodeLockQuery(string videoLockId, ref Parameters paramters)
        {
            paramters.Add(new Parameter()
            {
                Name = string.Format("@VideoCode"),
                Values = videoLockId
            });

            string query = string.Format("DELETE FROM Wii.[dbo].[VideoCodeLock] WHERE VideoCode=@VideoCode");
            return query;
        }

        internal static string GetVideoCodeLockQuery()
        {
            string query = string.Format("SELECT 0 as Choice, VideoCode,MaterialID,Contents,CONVERT(datetime,CONVERT(varchar(8), MaterialEndDate),111) as MaterialEndDate,BackgroundVideoLock,VideoCode as OldVideoCode,MaterialID as OldMaterialID,Contents as OldContents, CONVERT(datetime,CONVERT(varchar(8), MaterialEndDate),111) as OldMaterialEndDate,BackgroundVideoLock as OldBackgroundVideoLock, CONVERT(DATETIME, NULL) as UpdateDate, NEWID () as VideoCodeId FROM Wii.[dbo].[VideoCodeLock] order by Case When IsNumeric(VideoCode) = 1 then Right(Replicate('0',21) + VideoCode, 20) When IsNumeric(VideoCode) = 0 then Left(VideoCode + Replicate('', 21), 20) Else VideoCode End");
            return query;
        }

        internal static string GetInsertQuery(DataTable dataUpdte, ref Parameters paramters)
        {
            DataRow row = dataUpdte.Rows[0];
            string columnValue = string.Empty;
            string values = string.Empty;
            string columns = string.Empty;

            foreach (DataColumn col in dataUpdte.Columns)
            {
                if (col.ColumnName.Contains("Old"))
                    continue;

                columns += string.Format("[{0}],", col.ColumnName);
                values += string.Format("@{0},", col.ColumnName);

                paramters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = row[col]
                });
            }

            values = values.Remove(values.Length - 1, 1);
            columns = columns.Remove(columns.Length - 1, 1);

            string query = string.Format("INSERT INTO [Wii].[dbo].[VideoCodeLock] ({0}) VALUES({1})", columns, values);
            return query;
        }

        internal static string GetDataImportQuery()
        {
            string query = string.Format("SELECT 1 as Choice, tmp.VideoCode,tmp.MaterialID,tmp.Contents,CONVERT(datetime,CONVERT(varchar(8), tmp.MaterialEndDate),111) as MaterialEndDate, tmp.BackgroundVideoLock, t1.VideoCode as OldVideoCode, t1.MaterialID as OldMaterialID, t1.Contents as OldContents,CONVERT(datetime,CONVERT(varchar(8), t1.MaterialEndDate),111) as OldMaterialEndDate, t1.BackgroundVideoLock as OldBackgroundVideoLock, CONVERT(DATETIME,GetDate()) as UpdateDate, NEWID () as VideoCodeId FROM Wii.[dbo].[VideoCodeLock] as t1 right join WiiTmp.[dbo].[Wrk_VideoCodeLock_{0}] as tmp on t1.VideoCode = tmp.VideoCode order by Case When IsNumeric(tmp.VideoCode) = 1 then Right(Replicate('0',21) + tmp.VideoCode, 20) When IsNumeric(tmp.VideoCode) = 0 then Left(tmp.VideoCode + Replicate('', 21), 20) Else tmp.VideoCode End", Environment.MachineName.Replace("-", "_"));

            return query;
        }

        internal static string GetTruncateTmpQuery()
        {
            string query = string.Format("truncate table WiiTmp.dbo.[Wrk_VideoCodeLock_{0}] ", Environment.MachineName.Replace("-", "_"));
            return query;
        }

        internal static string GetUpdateQuery(DataTable dtUpdate, ref Parameters paramters)
        {
            DataRow row = dtUpdate.Rows[0];
            string values = string.Empty;

            foreach (DataColumn col in dtUpdate.Columns)
            {
                if (!col.ColumnName.Contains("Old"))
                    values += string.Format("{0}=@{0}, ", col.ColumnName);

                paramters.Add(new Parameter()
                {
                    Name = string.Format("@{0}", col.ColumnName),
                    Values = row[col]
                });
            }

            values = values.Trim();
            values = values.Remove(values.Length - 1, 1);

            string query = string.Format("UPDATE [Wii].[dbo].[VideoCodeLock] SET {0} WHERE VideoCode = @OldVideoCode", values);
            return query;
        }

        internal static string GetVideoCodeLockByVideoCodeQuery(string videoCode, ref Parameters paramters)
        {
            paramters.Add(new Parameter()
            {
                Name = "@VideoCode",
                Values = videoCode
            });
            string query = string.Format("SELECT * FROM [Wii].[dbo].[VideoCodeLock] WHERE VideoCode = @VideoCode", videoCode);
            return query;
        }

        internal static string GetVideoCodeLockedQuery()
        {
            string query = string.Format("SELECT VideoCode,MaterialID,Contents,MaterialEndDate,BackgroundVideoLock FROM [Wii].[dbo].[VideoCodeLock] where BackgroundVideoLock = 1");
            return query;
        }      
    }
}
