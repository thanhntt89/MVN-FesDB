using System;
using System.Collections.Generic;
using System.Data;
using Festival.Common;
using FestivalCommon;

namespace FestivalBusiness
{
    public class FesChapterInputSongNumberBusiness : BusinessBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public DataTable GetRegisteredConditionData(string data)
        {
            return commonBusiness.GetComboxRegisteredConditions(data);
        }

        public DataTable GetAddtinalDeleteCategory()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1", typeof(int));
                dt.Columns.Add("Column2", typeof(string));
                dt.Rows.Add(null, string.Empty);
                dt.Rows.Add(0, "0");
                dt.Rows.Add(1, "1");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TruncateChapterManagementWorkTmp()
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetTruncateChapterManagementWorkTmpQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteSearch(List<string> slqParameters)
        {
            try
            {
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesChapterAddDeleQuery.GetExecuteSearchQuery(slqParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetChapterFlag()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1", typeof(string));
                dt.Columns.Add("Column2", typeof(string));
                dt.Rows.Add(null, string.Empty);
                dt.Rows.Add("null", "null");
                dt.Rows.Add("not null", "not null");
                dt.Rows.Add(0, "0");
                dt.Rows.Add(1, "1");

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertInputNumberToWorkTable(EnumInputTypeName inputTypeName, EnumInputNumberType inputNumberType, List<string> songNumberList)
        {
            try
            {
                TruncateChapterManagementWorkTmp();
                commonBusiness.InsertInputNumerWorkTable(inputNumberType, songNumberList);

                string query = FesChapterAddDeleQuery.GetInsertInputNumberToWorkTableQuery(inputTypeName , inputNumberType);
                SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
