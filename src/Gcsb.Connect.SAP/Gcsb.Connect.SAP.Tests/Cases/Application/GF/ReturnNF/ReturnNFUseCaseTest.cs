using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("E")]
    public class ReturnNFUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IReturnNFUseCase ReturnNFUC;
        private readonly IReturnNFReadCsvRepository returnNFReadCsvRepository;
        private readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IBillFeedUseCase billFeedUC;

        public ReturnNFUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.ReturnNFUC = fixture.Container.Resolve<IReturnNFUseCase>();
            this.returnNFReadCsvRepository = fixture.Container.Resolve<IReturnNFReadCsvRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/Sample_BillFeed.csv")]
        [TestPriority(0)]
        public void BillFeedIngestPrepare(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ReturnNFUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            string base64 = billFeedReadCsvRepository.ReadCsvFile(pathShortSample);
            DocFeedRequest request = new DocFeedRequest(TypeRegister.BILLCSV, "Sample_BillFeed", base64);
            var count = billFeedUC.Execute(request);
            Assert.True(count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("InputFiles/Sample_ReturnNF.csv", "01012021000000")]
        [TestPriority(1)]
        public void ReturnNFUseCaseTestShouldExecute(string relativePath, string fileDateStr)
        {
            var dir = Path.GetDirectoryName(typeof(ReturnNFUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = returnNFReadCsvRepository.ReadCsvFile(pathShortSample);
            var dicFiles = new Dictionary<string, string>
            {
                { "IOTCo", base64 }
            };

            var request = new ReturnNFRequest(TypeRegister.RETURNNF, fileDateStr, dicFiles);
            var count = ReturnNFUC.Execute(request);

            Assert.True(count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void ReturnNFUseCaseNullTest()
        {
            Assert.Throws<System.ArgumentNullException>(() => ReturnNFUC.Execute(null));
        }

        [Fact]
        [Trait("Action", "None")]
        [InlineData("InputFiles/Sample_ReturnNF.csv", "01012021000000")]
        [TestPriority(2)]
        public void ReturnNFUseCaseTestInvalidFileMissingSomeFields()
        {
            var dicFiles = new Dictionary<string, string>
            {
                { "IOTCo", "U2VxdWVuY2U7IE1hcmtldHBsYWNlOyBSZXNlbGxlciBOYW1lOyBSZXNlbGxlciBDb250YWN0IE5hbWU7IFJlc2VsbGVyIFBob25lIE51bWJlcjsgT3JkZXIgSWQ7IFN1YnNjcmlwdGlvbiBJZDsgQWN0aXZpdHkgVHlwZTsgU2VydmljZSBUeXBlOyBPcmRlciBDcmVhdGlvbiBEYXRlOyBBY3RpdmF0aW9uIERhdGU7U3Vic2NyaXB0aW9uIFR5cGU7VGVybSBTdGFydCBEYXRlO1Rlcm0gRW5kIERhdGU7VGVybSBEdXJhdGlvbjtOZXh0IFJlbmV3YWwgRGF0ZTsgU2VydmljZSBDYW5jZWxsYXRpb24gRGF0ZTsgQmlsbCBGcm9tOyBCaWxsIFRvOyBDb21wYW55IE5hbWU7IENvbXBhbnkgQWNyb255bTsgQWNjb3VudCBDcmVhdGlvbiBEYXRlOyBGaXJzdCBOYW1lOyBMYXN0IE5hbWU7IEN1c3RvbWVyIEVtYWlsIEFkZHJlc3M7IEN1c3RvbWVyIFBob25lIE51bWJlcjtBZGRyZXNzIExpbmUxO0FkZHJlc3MgTGluZTI7IENpdHk7IFN0YXRlL1Byb3ZpbmNlOyBaSVAgQ29kZTsgQ291bnRyeTsgQ291bnRyeSBDb2RlOyBTZXJ2aWNlIE5hbWU7IE9mZmVyIE5hbWU7IE9mZmVyIENvZGU7IFNhbGVzIFJlZmVyZW5jZSBDb2RlOyBVbml0IE9mIE1lYXN1cmU7IFF0eTsgUHJvLXJhdGUgU2NhbGU7IFJldGFpbCBVbml0IFByaWNlOyBQcm8tcmF0ZWQgUmV0YWlsIFByaWNlIFVuaXQgUHJpY2U7IEdyb3NzIFJldGFpbCBQcmljZTsgUmV0YWlsIFByaWNlIERpc2NvdW50ICglKTsgUHJvLVJhdGVkIFJldGFpbCBVbml0IERpc2NvdW50ZWQgUHJpY2UgKEFtb3VudCk7IFRvdGFsIFJldGFpbCBQcmljZSBEaXNjb3VudCAoQW1vdW50KTsgVG90YWwgUmV0YWlsIFByaWNlOyBUYXggb24gVG90YWwgUmV0YWlsIFByaWNlOyBHcmFuZCBUb3RhbDogUmV0YWlsIFByaWNlOyBQcm9tb3Rpb24gQ29kZTsgUHJvbW90aW9uIGR1cmF0aW9uOyBXaG9sZXNhbGUgVW5pdCBQcmljZTsgUHJvLXJhdGVkIFdob2xlc2FsZSBVbml0IFByaWNlOyBDdXN0b21lciBUcmFuc2FjdGlvbiBDdXJyZW5jeTsgVmVuZG9yIEN1cnJlbmN5OyBHcm9zcyBXaG9sZXNhbGUgUHJpY2U7IFdob2xlc2FsZSBQcmljZSBEaXNjb3VudCAoJSk7IFByby1SYXRlZCBXaG9sZXNhbGUgVW5pdCBEaXNjb3VudGVkIFByaWNlIChBbW91bnQpOyBUb3RhbCBXaG9sZXNhbGUgUHJpY2UgRGlzY291bnQgKEFtb3VudCk7IFRvdGFsIFdob2xlc2FsZSBQcmljZTsgVGF4IG9uIFRvdGFsIFdob2xlc2FsZSBQcmljZTsgR3JhbmQgVG90YWw6IFdob2xlc2FsZSBQcmljZTsgVmVuZG9yIE5hbWU7IFZlbmRvciBVbml0IFByaWNlOyBQcm8tcmF0ZWQgVmVuZG9yIFVuaXQgUHJpY2U7IFRvdGFsIFZlbmRvciBQcmljZTsgVGF4IG9uIFRvdGFsIFZlbmRvciBQcmljZTsgR3JhbmQgVG90YWw6IFZlbmRvciBQcmljZTsgQmlsbGluZyBDeWNsZTsgUHJvcmF0ZSBUeXBlOyBQcm9yYXRlIE9uIENhbmNlbGxhdGlvbjsgVXNhZ2UgQXR0cmlidXRlczsgUGF5bWVudCBNZXRob2Q7IFBheW1lbnQgU3RhdHVzOyBSZWZ1bmQgVHlwZTsgUmVmdW5kIEFtb3VudDsgSW52b2ljZSBOdW1iZXI7IFJlc291cmNlIElkOyBDaGFyZ2UgVHlwZQ0KYzI2MzM0OWEtNWJkOS0xMWU4LWI5MjctMDA1MDU2YTcwMDA5O2Nscm1wO2NscnN0b3JlO2NscnN0b3JlIGFkbWluOzM0MzU0MzY1NDc7NDAxMDUwNzs4OWVhMTYxZi05ODY3LTQyN2UtYTI4Yy0zYjc3MjQ2YTM5ZjA7VXNhZ2U7SUFBUzs7MTUvMDUvMjAxODtVU0FHRTsxNS8wNS8yMDE4OzE1LzA1LzIwMTg7NzM7MTUvMDUvMjAxODsxNS8wNS8yMDE4OzE1LzA1LzIwMTg7MTcvMDUvMjAxODtjdXN0b21lciBGTjtjdXN0b21lckZOOzE0LzA1LzIwMTg7Y3VzdG9tZXIgRk47YWRtaW4gTE47Y3VzdDI0MzJAZ21haWwuY29tOzM0MjU0MztzZHNmc2FkZnM7MDthc2Zkc2dmc2Q7Q2FsaWZvcm5pYTszNDM1NDM2NTtVbml0ZWQgU3RhdGVzO1VTO0FtYXpvbiBTdWJzY3JpcHRpb24gU2VydmljZV8xO0FXUyBTdWJzY3JpcHRpb24gT2ZmZXI7YXdzc3Vic2NyaXB0aW9ub2ZmZXI7MDswOzczOzA7MDswOzA7MDswOzA7MDswOzA7MDswOzA7MDtVU0Q7VVNEOzA7MDswOzA7MDswOzA7QW1hem9uIFdlYiBTZXJ2aWNlczswOzA7MDswOzA7TW9udGg7MDswO2F3c2ttczt1cy1lYXN0LTEtS01TLVJlcXVlc3RzO1ByZS1BcHByb3ZlZCBDcmVkaXQ7UGFpZDswO2NyZS0xLTAwMDAwMDI4O05BO1VzYWdlDQpjMzBjZWEzYS01YmQ5LTExZTgtYjkyNy0wMDUwNTZhNzAwMDk7Y2xybXA7Y2xyc3RvcmU7Y2xyc3RvcmUgYWRtaW47MzQzNTQzNjU0Nzs0MDEwNTA3Ozg5ZWExNjFmLTk4NjctNDI3ZS1hMjhjLTNiNzcyNDZhMzlmMDtVc2FnZTtJQUFTOzE1LzA1LzIwMTg7MTUvMDUvMjAxODtVU0FHRTs7Ozs7OzE1LzA1LzIwMTg7MTcvMDUvMjAxODtjdXN0b21lciBGTjtjdXN0b21lckZOOzE0LzA1LzIwMTg7Y3VzdG9tZXIgRk47YWRtaW4gTE47Y3VzdDI0MzJAZ21haWwuY29tOzM0MjU0MztzZHNmc2FkZnM7O2FzZmRzZ2ZzZDtDYWxpZm9ybmlhOzM0MzU0MzY1O1VuaXRlZCBTdGF0ZXM7VVM7QW1hem9uIFN1YnNjcmlwdGlvbiBTZXJ2aWNlXzE7QVdTIFN1YnNjcmlwdGlvbiBPZmZlcjthd3NzdWJzY3JpcHRpb25vZmZlcjs7R0ItTW87MCwwMDQ0MjcyNzs7OzswOzs7OzA7OzA7Ozs7O1VTRDtVU0Q7MDs7OzswOzswO0FtYXpvbiBXZWIgU2VydmljZXM7OzswOzswO01vbnRoOzs7QW1hem9uRUMyO0VCUzpWb2x1bWVVc2FnZS5ncDI7UHJlLUFwcHJvdmVkIENyZWRpdDtQYWlkOztjcmUtMS0wMDAwMDAyODt2b2wtMGIwMjU4NDRjNDQwOTdjYWU7VXNhZ2UNCmMyOGM1N2VlLTViZDktMTFlOC1iOTI3LTAwNTA1NmE3MDAwOTtjbHJtcDtjbHJzdG9yZTtjbHJzdG9yZSBhZG1pbjszNDM1NDM2NTQ3OzQwMTA1MDc7ODllYTE2MWYtOTg2Ny00MjdlLWEyOGMtM2I3NzI0NmEzOWYwO1VzYWdlO0lBQVM7MTUvMDUvMjAxODsxNS8wNS8yMDE4O1VTQUdFOzs7Ozs7MTUvMDUvMjAxODsxNy8wNS8yMDE4O2N1c3RvbWVyIEZOO2N1c3RvbWVyRk47MTQvMDUvMjAxODtjdXN0b21lciBGTjthZG1pbiBMTjtjdXN0MjQzMkBnbWFpbC5jb207MzQyNTQzO3Nkc2ZzYWRmczs7YXNmZHNnZnNkO0NhbGlmb3JuaWE7MzQzNTQzNjU7VW5pdGVkIFN0YXRlcztVUztBbWF6b24gU3Vic2NyaXB0aW9uIFNlcnZpY2VfMTtBV1MgU3Vic2NyaXB0aW9uIE9mZmVyO2F3c3N1YnNjcmlwdGlvbm9mZmVyOztHQjswLDAwMDE2MDY5Mjs7OzswOzs7OzA7OzA7Ozs7O1VTRDtVU0Q7MDs7OzswOzswO0FtYXpvbiBXZWIgU2VydmljZXM7OzswOzswO01vbnRoOzs7QW1hem9uRUMyO1VTRTEtVVNXMS1BV1MtSW4tQnl0ZXM7UHJlLUFwcHJvdmVkIENyZWRpdDtQYWlkOztjcmUtMS0wMDAwMDAyODtpLTBiNWY1MDg3OWQwODU3MmZkO1VzYWdlDQo=" }
            };

            var request = new ReturnNFRequest(TypeRegister.RETURNNF, "01012021000000", dicFiles);

            Assert.True(ReturnNFUC.Execute(request) == 0);
        }

        [Theory]
        [Trait("Action", "none")]
        [InlineData("InputFiles/FilesError/Sample_Feed_null.csv")]
        [TestPriority(3)]
        public void ReturnNFUseCaseWithNullValuesInCSV(string relativePath)
        {
            var dir = Path.GetDirectoryName(typeof(ReturnNFUseCaseTest).Assembly.Location);
            var pathShortSample = Path.Combine(dir, relativePath);
            var base64 = returnNFReadCsvRepository.ReadCsvFile(pathShortSample);
            var dicFiles = new Dictionary<string, string>
            {
                { "IOTCo", base64 }
            };

            var request = new ReturnNFRequest(TypeRegister.RETURNNF, "01012021000000", dicFiles);

            Assert.True(ReturnNFUC.Execute(request) == 0);
        }
        [Fact]
        [Trait("Action", "None")]
        [TestPriority(4)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}
