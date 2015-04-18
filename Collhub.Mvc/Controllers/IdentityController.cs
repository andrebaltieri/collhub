using IdentityAccess.Core.Application;
using IdentityAccess.Core.Application.Commands;
using SharedKernel.Domain.Model.Event;
using System.Web.Mvc;

namespace Collhub.Mvc.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityApplicationService service;
        private readonly IDomainNotificationHandle<DomainNotification> notification;

        public IdentityController(
            IIdentityApplicationService identityApplicationService,
            IDomainNotificationHandle<DomainNotification> iDomainNotificationHandle)
        {
            service = identityApplicationService;
            notification = iDomainNotificationHandle;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email)
        {
            var command = new RegisterUserCommand(
                fullName: "Yan de Lima Justino", 
                username: "yanjustino",
                email: email, 
                password: "master", 
                confirmpass: "master"
            );

            service.Register(command);

            if (notification.HasNotifications())
            {
                foreach (var item in notification.Notify())
                    ModelState.AddModelError("", item.Value);

                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}