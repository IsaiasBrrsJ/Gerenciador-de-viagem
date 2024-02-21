using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciadorDeViagem.API.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public static Task<HttpResponseExceptionFilter> Create()
        => Task.FromResult(new HttpResponseExceptionFilter());

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messageErro = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(messageErro);
            }
        }
    }
}
