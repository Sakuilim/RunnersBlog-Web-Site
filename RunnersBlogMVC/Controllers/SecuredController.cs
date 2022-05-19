using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        // GET: RandomController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
