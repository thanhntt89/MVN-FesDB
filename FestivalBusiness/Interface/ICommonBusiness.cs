using System.Data;

namespace FestivalBusiness.Interface
{
    public interface ICommonBusiness
    {
        DataTable GetData(string tableName);
        void Save(string queryCreateTableTmp, string queryUpdateTable, DataTable dataTable);
        void CreateTableTmp(DataTable dataTable);
        void ExecuteQuery(string query);
        void DropTable(string tableName);
        void TruncateTableTmp(string tableName);
        void InsertWorkTableTmp();
        void InsertWorkTableTmpBySongNumber();
        void InsertWorkTableMatchingKaraoke();
        void LockMenu();
        void DropTableFesWork();
        void CreateWorkTable();
        bool SetFesEditLock(string idFesMenu, bool status);
        string GetCurrentVersion();
        DataTable GetRole();
    }
}
