using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BAL_IK.UI.Filters
{
    public class SiteYoneticisiAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var guid = context.HttpContext.Session.GetString("siteYoneticisi");
            if (string.IsNullOrEmpty(guid))
            {
                guid = context.HttpContext.Request.Cookies["siteYoneticisi"];
                if (string.IsNullOrEmpty(guid))
                {
                    context.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
                }
            }
        }
    }
}
