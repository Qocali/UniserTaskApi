using Domain.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task.Rest.Api.Filters
{
    public class ActioFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = context.ActionArguments["id"];
            }
            else
            {
                context.Result= new BadRequestObjectResult("") { StatusCode = 1, Value = "have any error" };
                return;
            }
        }
    }
}
