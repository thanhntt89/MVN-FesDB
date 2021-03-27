using System.Collections.Generic;
using System.Linq;

namespace FestivalCommon
{
    public class FesInputNumberTypeFunctionCollection
    {
        private List<FunctionEntity> FunctionList;

        public FesInputNumberTypeFunctionCollection()
        {
            FunctionList = new List<FunctionEntity>();
            FunctionList.Add(new FunctionEntity { FunctionText = "選曲番号入力", FunctionName = EnumInputTypeName.選曲番号入力 });
            FunctionList.Add(new FunctionEntity { FunctionText = "選曲番号入力　カラオケ", FunctionName = EnumInputTypeName.選曲番号入力カラオケ });
            FunctionList.Add(new FunctionEntity { FunctionText = "背景映像コード入力", FunctionName = EnumInputTypeName.背景映像コード入力 });
            FunctionList.Add(new FunctionEntity { FunctionText = "Fes_DISCID入力", FunctionName = EnumInputTypeName.Fes_DISCID });
            FunctionList.Add(new FunctionEntity { FunctionText = "ファイル照合", FunctionName = EnumInputTypeName.ファイル照合 });
            FunctionList.Add(new FunctionEntity { FunctionText = "背景ファイル名入力", FunctionName = EnumInputTypeName.背景ファイル名入力 });
        }

        public FunctionEntity GetFunctionInfo(EnumInputTypeName functioName)
        {
            var exist = FunctionList.Where(r => r.FunctionName == functioName).FirstOrDefault();
            if (exist == null)
                return null;
            return exist;
        }
    }

    public class FunctionEntity
    {
        public string FunctionText { get; set; }
        public EnumInputTypeName FunctionName { get; set; }
    }

    public enum EnumInputTypeName { 選曲番号入力, 選曲番号入力カラオケ, 背景映像コード入力, Fes_DISCID , ファイル照合, 背景ファイル名入力 }
}
