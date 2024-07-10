using Gcsb.Connect.SAP.Application;
using Gcsb.Connect.SAP.Application.UseCases.Config.BillFeed;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData.BillFeedRequest;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData.BillFeedResponse;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IIdentityParser<UserInfo> identityParser;
        private readonly IBillFeedDataUseCase billFeedDataUseCase;
        private readonly BillFeedPresenter presenter;
        private string[] permissions;

        public FeedController(IIdentityParser<UserInfo> identityParser, IBillFeedDataUseCase billFeedDataUseCase, BillFeedPresenter presenter)
        {
            this.identityParser = identityParser;
            this.billFeedDataUseCase = billFeedDataUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<OutputBillFeed>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize] 
        [Route("GetBillFeedData")]
        public IActionResult GetBillFeedData([FromBody]InputBillRequest input)
        {
            var user = identityParser.Parse(HttpContext.User);
            var userPermissions = Environment.GetEnvironmentVariable("USER_PERMISSIONS");

            permissions = userPermissions != null ? userPermissions.Split('|') : new string[0];

            if (!permissions.Contains(user.RoleName.RemoveAccents()))
                return Unauthorized();

            var request = new Application.UseCases.Config.BillFeed.BillFeedRequest(input.BillFromDate, input.BillToDate);

            billFeedDataUseCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}