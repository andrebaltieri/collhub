using IdentityAccess.Core.Application;
using IdentityAccess.Core.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collhub.Mvc.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityApplicationService _identityApplicationService;

        public IdentityController(IIdentityApplicationService identityApplicationService)
        {
            _identityApplicationService = identityApplicationService;
        }

        // GET: Identity
        public ActionResult Index()
        {
            var register = new RegisterUserCommand("Yan de Lima Justino", "yanjustino", "yanlimaj@gmail.com", "master", "master");
            _identityApplicationService.Register(register);

            return View();
        }
    }
}