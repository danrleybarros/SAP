namespace Gcsb.Connect.SAP.Domain.GF.Nfe
{
    public class NfeFiles
    {
        public string FileName { get; private set; }
        public string StoreAcronym { get; private set; }
        public string DateFileStr { get; private set; }

        public NfeFiles(string fileName, string storeAcronym, string dateFileStr)
        {
            FileName = fileName;
            StoreAcronym = storeAcronym;
            DateFileStr = dateFileStr;
        }
    }
}
