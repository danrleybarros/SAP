using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public class IdentificationRegisterBuilder
    {
        public string TypeLine;
        public string SystemCode;
        public string FileCode;
        public string CompanyCode;
        public string DivisionCode;
        public string GenerationYear;
        public int Sequential;
        public string SequentialFile;
        public string FileName;
        public string GenerationDate;
        public string GenerationHour;
        public StoreType SType;

        public static IdentificationRegisterBuilder New()
        {
            return new IdentificationRegisterBuilder()
            {
                TypeLine = "ID",
                SystemCode = "ARR",
                FileCode = "21",
                CompanyCode = "TB",
                DivisionCode = "29",
                GenerationYear = "19",
                Sequential = 1,
                SequentialFile = "1",
                FileName = "ARR21TB29190001",
                GenerationDate = "",
                GenerationHour = "",
                SType = StoreType.TBRA
            };
        }

        public IdentificationRegisterBuilder WithTypeLine(string typeLine)
        {
            TypeLine = typeLine;
            return this;
        }

        public IdentificationRegisterBuilder WithSystemCode(string systemCode)
        {
            SystemCode = systemCode;
            return this;
        }

        public IdentificationRegisterBuilder WithFileCode(string fileCode)
        {
            FileCode = fileCode;
            return this;
        }

        public IdentificationRegisterBuilder WithCompanyCode(string companyCode)
        {
            CompanyCode = companyCode;
            return this;
        }

        public IdentificationRegisterBuilder WithDivisionCode(string divisionCode)
        {
            DivisionCode = divisionCode;
            return this;
        }

        public IdentificationRegisterBuilder WithGenerationYear(string generationYear)
        {
            GenerationYear = generationYear;
            return this;
        }

        public IdentificationRegisterBuilder WithSequential(int sequential)
        {
            Sequential = sequential;
            return this;
        }

        public IdentificationRegisterBuilder WithSequentialFile(string sequentialFile)
        {
            SequentialFile = sequentialFile;
            return this;
        }

        public IdentificationRegisterBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public IdentificationRegisterBuilder WithGenerationDate(string generationDate)
        {
            GenerationDate = generationDate;
            return this;
        }

        public IdentificationRegisterBuilder WithGenerationHour(string generationHour)
        {
            GenerationHour = generationHour;
            return this;
        }

        public IdentificationRegisterBuilder WithStoreType(StoreType storeType)
        {
            SType = storeType;
            return this;
        }

        public IdentificationRegisterCreditCard Build()
            => new IdentificationRegisterCreditCard(Sequential, SType);
    }
}
