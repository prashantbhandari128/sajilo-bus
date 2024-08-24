using Microsoft.AspNetCore.Mvc;
using WebService.Common.Helper.Interface;
using WebService.Common.Models.Toastr;

namespace WebService.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        private readonly IToastrHelper _toastrHelper;

        public DashboardController(IToastrHelper toastrHelper)
        {
            _toastrHelper = toastrHelper;
        }

        public IActionResult Index()
        {
            _toastrHelper.SendMessage(this, "SajiloBus", "Welcome to Admin Dashboard", MessageType.Info);
            return View();
        }
    }
}
