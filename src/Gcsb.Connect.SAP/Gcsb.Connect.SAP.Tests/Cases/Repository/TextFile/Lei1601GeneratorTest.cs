using System.Text.RegularExpressions;
using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.TextFile
{
    public class Lei1601GeneratorTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly string identificationFormat = @"^(GW_SI_1601)_(\d{8})_(\d{8})_INST_(\d{3}).TXT$";
        private readonly string launchFormat = @"^(TBRA|TLF2)(\d{4})(\d{8})(CL)(\s{10})(\d{10})(\s{9})(\s{9})(\s{17})(\d{17})(\s{17})((\w|\s){60})((\w|\s){30})";
        private readonly IFileGenerator<SAP.Domain.LEI1601.Lei1601> fileGenerator;

        public Lei1601GeneratorTest(Fixture.ApplicationFixture fixture)
        {
            fileGenerator = fixture.Container.Resolve<IFileGenerator<SAP.Domain.LEI1601.Lei1601>>();
        }

        [Fact]
        public void ShoudIsValidIdentification()
        {
            var model = Builders.LEIS.Lei1601.IdentificationRegisterBuilder.New().Build();

            Regex r = new Regex(identificationFormat);
            Match m = r.Match(model.FileName);
            Assert.True(m.Success);
        }

        [Fact]       
        public void ShoudIsValidLaunch()
        {
            var model = Builders.LEIS.Lei1601.Lei1601Builder.New().Build();

            model.Launches.ForEach(f => f.SetParticipantCode("3012393"));
            
            var strFile = fileGenerator.Generate(model);

            Regex r = new Regex(launchFormat, RegexOptions.Singleline);
            Match m = r.Match(strFile);
            Assert.True(m.Success);
        }
    }
}
