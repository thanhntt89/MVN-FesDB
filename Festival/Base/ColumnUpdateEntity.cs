namespace Festival.Base
{
    public class ColumnUpdateEntity
    {
        public string ColumnKeyDataPropertyName { get; set; }      
        public string ColumnUpdateDateTimeDataPropertyName { get; set; }
        public string ColumnCurrentUpdateDataPropertyName { get; set; }
        public object DataUpdate { get; set; }
    }
}
