using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Filters.ExceptionFilters;

public class Shirt_HandleUpdateExceptionsFilterAttribute:ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        var strShirtId = context.RouteData.Values["id"] as string ;
        if (int.TryParse(strShirtId, out int shirtId))
        {
            if (!ShirtRepository.ShirtExists(shirtId))
            {
                context.ModelState.AddModelError("ShirtId","Shirt doesnot exists anymore");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new NotFoundObjectResult(problemDetails);
            }
        }
    }
}