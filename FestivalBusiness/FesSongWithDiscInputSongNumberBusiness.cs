using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalCommon;
using System.Data;

namespace FestivalBusiness
{
    public class FesSongWithDiscInputSongNumberBusiness:BusinessBase
    {
        public void TruncateInputSongNumberTableTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscInputSongNumberQuery.GetTruncateInputSongNumberTableTmpQuery());
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSongNumberTableTmp(FunctionEntity function, List<string> songNumberList)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscInputSongNumberQuery.GetInsertSongNumberTableTmpQuery(function, songNumberList));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateFesSongWithDiscWorkTable(FunctionEntity function , DisVersion currentVersion)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscInputSongNumberQuery.GetTruncateFesSongWithDiscWorkTableQuery(function, currentVersion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFesSongWithDiscWorkTable(FunctionEntity function, DisVersion currentVersion)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesSongWithDiscInputSongNumberQuery.GetInsertFesSongWithDiscWorkTableQuery(function, currentVersion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
