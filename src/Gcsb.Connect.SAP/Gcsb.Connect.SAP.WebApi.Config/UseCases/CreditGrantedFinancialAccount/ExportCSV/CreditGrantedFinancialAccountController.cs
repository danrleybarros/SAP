using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore;
using Gcsb.Connect.SAP.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using System.Text;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.ExportCSV
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditGrantedFinancialAccountController : ControllerBase
    {
        private readonly IGetByStoreUseCase getByStoreUseCase;
        private readonly IGetAllUseCase getAllUseCase;

        public CreditGrantedFinancialAccountController(IGetByStoreUseCase getByStoreUseCase,
            IGetAllUseCase getAllUseCase)
        {
            this.getByStoreUseCase = getByStoreUseCase;
            this.getAllUseCase = getAllUseCase;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("ExportCSV")]
        public FileResult ExportCSV([FromBody] ExportCSVInput input)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Loja;AJU;Débito(Passivo a restituir);Crédito(car)");

            if (input.StoreAcronym == null)
            {
                var request = new GetAllRequest();
                getAllUseCase.Execute(request);

                foreach (Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount account in request.Output.CreditGrantedFinancialAccounts)
                {
                    sb.AppendLine($"{account.StoreAcronym.GetAttributeOfType<EnumMemberAttribute>().Value};{account.CreditGrantedAJU};{account.AccountingAccountCred};{account.AccountingAccountDeb}");
                }
            }
            else
            {
                var request = new GetByStoreRequest(input.StoreAcronym.Value);
                getByStoreUseCase.Execute(request);

                sb.AppendLine($"{request.Output.CreditGrantedFinancialAccount.StoreAcronym.GetAttributeOfType<EnumMemberAttribute>().Value};{request.Output.CreditGrantedFinancialAccount.CreditGrantedAJU};{request.Output.CreditGrantedFinancialAccount.AccountingAccountCred};{request.Output.CreditGrantedFinancialAccount.AccountingAccountDeb}");
            }

            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "CreditGrantedFinancialAccount.csv");
        }
    }
}
