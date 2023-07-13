using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookCollection.Middlewares
{
    public class BookIdFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!int.TryParse(context.HttpContext.Request.RouteValues["bookId"]?.ToString(), out _))
            {
                context.Result = new NotFoundObjectResult(null);
            }
        }
    }
}
