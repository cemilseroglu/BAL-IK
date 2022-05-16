using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BAL_IK.UI.Filters
{
    public class SirketYoneticisiAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var guid = context.HttpContext.Session.GetString("sirketYoneticisi");
            if (string.IsNullOrEmpty(guid))
            {
                guid = context.HttpContext.Request.Cookies["sirketYoneticisi"];
                if (string.IsNullOrEmpty(guid))
                {
                    context.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
                }
            }
        }
    }
}
