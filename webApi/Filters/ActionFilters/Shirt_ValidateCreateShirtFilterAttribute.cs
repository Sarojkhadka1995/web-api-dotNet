using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Filters;

public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        var shirt = context.ActionArguments["shirt"] as Shirt;


        if (shirt == null)
        {
            context.ModelState.AddModelError("Shirt","shirt object is null.");
            var problemDetail = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetail);
        }
        else
        {
            var existingShirt = ShirtRepository.GetShirtByProperites(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
            if (existingShirt != null)
            {
                context.ModelState.AddModelError("Shirt","Shirt already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}