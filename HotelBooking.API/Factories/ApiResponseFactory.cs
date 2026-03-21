using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Factories
{
    public static class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationResponse(ActionContext actionContext)
        {
            var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(ms => ms.Key, ms => ms.Value.Errors.Select(me => me.ErrorMessage).ToArray());
            var problem = new ProblemDetails
            {
                Title = "Validation Errors",
                Detail = "One or More Validation Errors Occurred",
                Instance = actionContext.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest,
                Extensions = { { "Errors", errors } }
            };

            return new BadRequestObjectResult(problem);
        }
    }
}
