using System.Threading.Tasks;
using DETOWN.Domain.Core.Bus;
using DETOWN.Domain.Core.Notifications;
using DETOWN.Infra.CrossCutting.Identity.Models.RoleViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DETOWN.API.Controllers
{
    public class RoleController : ApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            // Add Role
            var role = new IdentityRole(model.Name);
            await _roleManager.CreateAsync(role);

            // Add RoleClaims
            // var roleClaim = new Claim("Customers", "Write");
            // await _roleManager.AddClaimAsync(role, roleClaim);

            return Response();
        }
    }
}
