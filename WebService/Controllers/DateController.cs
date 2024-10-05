using NepDate;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class DateController : Controller
    {

        public IActionResult ToBs()
        {
            var nep = NepaliDate.Now;
            return Content(nep.ToLongDateString());
        }
    }
}
