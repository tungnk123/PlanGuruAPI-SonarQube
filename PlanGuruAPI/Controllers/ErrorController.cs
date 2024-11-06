using Domain.Error;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PlanGuruAPI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        [HttpPost]
        public IActionResult HandleError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return exception switch
            {
                ValidationException => Problem(
                    detail: exception.Message,
                    statusCode: 400,
                    title: "Validation failed"
                    ),
                InvalidCredentialException => Problem(
                    detail: exception.Message,
                    statusCode: 401,
                    title: "Invalid Credential"
                    ),
                _ => Problem(
                    detail: exception.Message,
                    statusCode: 500,
                    title: "Internal server error")
            };
        }
    }
}
