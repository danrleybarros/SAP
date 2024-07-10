using FluentAssertions;
using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.GetOpenInvoices
{
    public class GetOpenInvoicesRequestTest
    {
        [Theory]
        [InlineData(SearchType.CNPJ, "12345678901234")]
        [InlineData(SearchType.CPF, "12345678912")]
        [InlineData(SearchType.CustomerCode, "7001234567")]
        [InlineData(SearchType.CustomerCode, "1234567")]
        public void ShouldGetDocument(SearchType searchType, string document)
        {
            var request = new GetOpenInvoicesRequest(searchType, document);

            var doc = searchType == SearchType.CustomerCode && document.Length == 10 ? document.Substring(3) : document;

            request.Document.Should().Be(doc);
        }
    }
}
