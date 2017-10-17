using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Raven.Client.Documents.Session;

namespace Necro.Controllers
{
    public class SessionController : Controller
    {
        public IDocumentSession Session { get; set; }

        public override void OnActionExecuting(ActionExecutingContext Context)
        {
            Session = Startup.Store.OpenSession();
            base.OnActionExecuting(Context);
        }

        public override void OnActionExecuted(ActionExecutedContext Context)
        {
            if (Session != null)
                Session.SaveChanges();
            Session.Dispose();
            base.OnActionExecuted(Context);
        }
    }
}