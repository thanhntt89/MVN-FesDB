using System;
using System.Data;
using System.Data.SqlClient;

namespace FestivalBusiness
{
    public class FesAuthorityBusiness : BusinessBase
    {
        private FesAuthGroupBusiness authGroupBusiness = new FesAuthGroupBusiness();

        public DataTable GetFunctionList()
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesAuthorityQuery.GetFunctionListQuery()).Tables[0];
                if (dtData.Rows.Count > 0)
                {
                    foreach (DataRow row in dtData.Rows)
                    {
                        foreach (DataColumn col in dtData.Columns)
                        {
                            if (col.ColumnName.Equals("プロジェクトID") || col.ColumnName.Equals("機能ID"))
                                continue;

                            row["機能名"] = string.Format("{0} | {1}", row["機能ID"], row["機能名"]);
                        }
                    }
                }

                return dtData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAuthorityAll()
        {
            try
            {
                return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesAuthorityQuery.GetAuthorityAllQuery()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRoleType()
        {
            // 0;権限なし;1;参照権限;2;更新権限
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1", typeof(int));
            dt.Columns.Add("Column2", typeof(string));
            dt.Rows.Add(0, "0 | 権限なし");
            dt.Rows.Add(1, "1 | 参照権限");
            dt.Rows.Add(2, "2 | 更新権限");
            return dt;
        }

        public void Save(DataTable dtSave, ref int updateCount)
        {
            try
            {
                DataTable dtInsert = new DataTable();
                dtInsert.Columns.Add("権限グループ");
                dtInsert.Columns.Add("プロジェクトID");
                dtInsert.Columns.Add("機能ID");
                dtInsert.Columns.Add("更新タイプ");
                dtInsert.Columns.Add("Old権限グループ");
                dtInsert.Columns.Add("OldプロジェクトID");
                dtInsert.Columns.Add("Old機能ID");

                connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlTransac = connection.BeginTransaction();
                string query = string.Empty;

                foreach (DataRow row in dtSave.Rows)
                {
                    dtInsert.Rows.Clear();
                    dtInsert.Rows.Add(row["権限グループ"], row["プロジェクトID"], row["機能ID"], row["更新タイプ"], row["Old権限グループ"], row["OldプロジェクトID"], row["Old機能ID"] );
                    query = string.Empty;

                    if (row["Old権限グループ"] == DBNull.Value)
                    {
                        query = FesAuthorityQuery.GetInsertAuthorityQuery(dtInsert);
                    }
                    else
                    {
                        query = FesAuthorityQuery.GetUpdateAuthorityQuery(dtInsert);
                       
                    }

                    SqlHelpers.ExecuteNonQuery(sqlTransac, CommandType.Text, query);
                    updateCount++;
                }

                sqlTransac.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                sqlTransac.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public DataTable GetAuthorityGroupAll()
        {
            return authGroupBusiness.GetGroupAuthorityAll();
        }

        public void DeleteById(string userId, string functionId, string roleId)
        {
            SqlHelpers.ExecuteNonQuery(connectionString, CommandType.Text, FesAuthorityQuery.GetDeleteQuery(userId, functionId, roleId));
        }

        public DataTable GetAuthority(string userId, string functionId, string roleId)
        {
            return SqlHelpers.ExecuteDataset(connectionString, CommandType.Text, FesAuthorityQuery.GetGetAuthorityQuery(userId, functionId, roleId)).Tables[0];
        }
    }
}
