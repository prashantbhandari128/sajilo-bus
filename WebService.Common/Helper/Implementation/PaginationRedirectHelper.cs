using Microsoft.AspNetCore.Mvc;
using WebService.Common.Helper.Interface;

namespace WebService.Common.Helper.Implementation
{
    public class PaginationRedirectHelper : IPaginationRedirectHelper
    {
        //-------------[ Contants ]-------------
        public const int DEFAULT_PAGEINDEX = 1;
        public const int DEFAULT_PAGESIZE = 5;
        //--------------------------------------

        public RedirectResult RedirectToPage(string area, string controller, string action, string? search, int pageindex, int pagesize)
        {
            if (string.IsNullOrEmpty(search))
            {
                return new RedirectResult($"/{area}/{controller}/{action}?page={pageindex}&pagesize={pagesize}");
            }
            else
            {
                return new RedirectResult($"/{area}/{controller}/{action}?search={search}&page={pageindex}&pagesize={pagesize}");
            }
        }

        public RedirectResult RedirectToPageAfterDelete(string area, string controller, string action, int sn, string? search, int pageindex, int pagesize)
        {
            if (sn - 1 <= (pageindex - 1) * pagesize && sn - 1 != 0)
            {
                return RedirectToPage(area, controller, action, search, pageindex - 1, pagesize);
            }
            else
            {
                return RedirectToPage(area, controller, action, search, pageindex, pagesize);
            }
        }
    }
}
