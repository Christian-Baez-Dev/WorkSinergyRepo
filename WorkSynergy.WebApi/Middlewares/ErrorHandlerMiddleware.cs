using System.Net;
using System.Text.Json;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<String>() { Succeeded = false, Message = ex.Message};

                switch (ex)
                {
                    case ApiException e:
                        switch (e.ErrorCode)
                        {
                            case (int)HttpStatusCode.BadRequest:
                                responseModel.StatusCode = (int)HttpStatusCode.BadRequest;
                                response.StatusCode = (int)HttpStatusCode.BadRequest;
                                break;
                            case (int)HttpStatusCode.Forbidden:
                                responseModel.StatusCode = (int)HttpStatusCode.Forbidden;
                                response.StatusCode = (int)HttpStatusCode.Forbidden;
                                break;
                            case (int)HttpStatusCode.NotFound:
                                responseModel.StatusCode = (int)HttpStatusCode.NotFound;
                                response.StatusCode = (int)HttpStatusCode.NotFound;
                                break;
                            case (int)HttpStatusCode.InternalServerError:
                                responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                            default:
                                responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                        }
                        break;
                    case KeyNotFoundException e:
                        responseModel.StatusCode = (int)HttpStatusCode.NotFound;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
