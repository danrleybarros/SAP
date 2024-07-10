using Autofac.Features.Indexed;
using Gcsb.Connect.SAP.Application;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed;
using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData.PaymentFeedResponse;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.PaymentFeedData.PaymentFeedRequest;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.PaymentFeedData.Cycle
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IIndex<FileType, IPaymentFeedDataUseCase> paymentFeedDataUseCase;
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly PaymentFeedPresenter presenter;
        private string[] permissions;

        public FeedController(IIndex<FileType, IPaymentFeedDataUseCase> paymentFeedDataUseCase, IIdentityParser<UserInfo> identityParser, PaymentFeedPresenter presenter, string[] permissions)
        {
            this.paymentFeedDataUseCase = paymentFeedDataUseCase;
            this.identityParser = identityParser;
            this.presenter = presenter;
            this.permissions = permissions;
        }

        [HttpPost]
        [Authorize]
        [Route("GetPaymentFeedData")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(OutputPaymentFeed), 200)]
        public IActionResult PaymentFeedData([FromBody]InputPayRequest input)
        {
            var user = identityParser.Parse(HttpContext.User);
            var userPermissions = Environment.GetEnvironmentVariable("USER_PERMISSIONS");

            permissions = userPermissions != null ? userPermissions.Split('|') : new string[0];

            if (!permissions.Contains(user.RoleName.RemoveAccents()))
                return Unauthorized();

            paymentFeedDataUseCase[input.Type].Execute(new Application.UseCases.Config.PaymentFeed.PaymentFeedRequest(input.BillFromDate, input.BillToDate, input.Type));

            return presenter.ViewModel;
        }
    }
}