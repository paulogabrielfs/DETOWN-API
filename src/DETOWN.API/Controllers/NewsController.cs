using System;
using DETOWN.Application.Interfaces;
using DETOWN.Application.ViewModels;
using DETOWN.Domain.Core.Bus;
using DETOWN.Domain.Core.Notifications;
using DETOWN.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DETOWN.API.Controllers
{
    [Authorize]

    public class NewsController : ApiController
    {
        private readonly INewsAppService _newsAppService;

        public NewsController(
            INewsAppService newsAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _newsAppService = newsAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public IActionResult Get()
        {
            return Response(_newsAppService.GetAll());
        }
    }
}