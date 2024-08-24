using Microsoft.AspNetCore.Mvc;

namespace WebService.Common.Helper.Interface
{
    public interface IPaginationRedirectHelper
    {
        public RedirectResult RedirectToPage(string area, string controller, string action, string? search, int pageindex, int pagesize);
        public RedirectResult RedirectToPageAfterDelete(string area, string controller, string action, int sn, string? search, int pageindex, int pagesize);
    }
}
