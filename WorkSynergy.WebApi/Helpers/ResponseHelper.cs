using Microsoft.AspNetCore.Mvc;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.WebApi.Helpers
{
    public static class ResponseHelper
    {
        public static IActionResult CreateResponse<T>(Response<T> response, ControllerBase controller)
        {
            return response.StatusCode switch
            {
                StatusCodes.Status201Created => controller.CreatedAtAction(
                    "Get", // Asume que tienes un endpoint de "Get" para CreatedAtAction
                    new { id = response.Data },
                    response),
                StatusCodes.Status204NoContent => controller.NoContent(),
                StatusCodes.Status400BadRequest => controller.BadRequest(response.Message),
                StatusCodes.Status500InternalServerError => controller.StatusCode(StatusCodes.Status500InternalServerError, response.Message),
                _ => controller.Ok(response)
            };
        }
    }
}
