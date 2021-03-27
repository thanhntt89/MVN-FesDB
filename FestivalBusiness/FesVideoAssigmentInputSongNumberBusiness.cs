using System;
using FestivalCommon;
using System.Data;
using System.Collections.Generic;

namespace FestivalBusiness
{
    public class FesVideoAssigmentInputSongNumberBusiness : BusinessBase
    {       
        public void TruncateFesVideoAssigmentWorkTable()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentInputSongNumberQuery.GetTruncateFesVideoAssigmentWorkTableQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertFesVideoAssigmentWorkTable(FunctionEntity function)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentInputSongNumberQuery.GetInsertFesVideoAssigmentWorkTableQuery(function));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateInputSongNumberTableTmp(FunctionEntity function)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentInputSongNumberQuery.GetTruncateInputSongNumberTableTmpQuery(function));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSongNumberTableTmp(FunctionEntity function, List<string> songNumberList)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesVideoAssigmentInputSongNumberQuery.GetInsertSongNumberTableTmpQuery(function, songNumberList));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
