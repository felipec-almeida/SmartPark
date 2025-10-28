using Microsoft.AspNetCore.Mvc;
using SmartPark.Borders.Shared.Messages;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Api.Extensions
{
    public class ActionResultConverter
    {
        public async Task<IActionResult> ExecuteActionAsync<T>(Task<T> responseTask, Type controllerType)
        {
            var controllerName = controllerType.Name;

            try
            {
                var response = await responseTask;

                if (response is null)
                {
                    return new NotFoundObjectResult(new BaseErrorResponse
                    {
                        Errors = new[] { ResponseMessages.GetMessage(controllerName, 404) }
                    });
                }

                return response switch
                {
                    BasePostResponse postResponse =>
                        new CreatedResult(string.Empty, postResponse with
                        {
                            Message = ResponseMessages.GetMessage(controllerName, 201)
                        }),

                    BaseResponse<T> baseResponse =>
                        new OkObjectResult(baseResponse with
                        {
                            Message = ResponseMessages.GetMessage(controllerName, 200)
                        }),

                    BaseErrorResponse errorResponse =>
                        new BadRequestObjectResult(errorResponse),

                    BasePatchResponse patchResponse =>
                        new OkObjectResult(patchResponse with
                        {
                            Message = ResponseMessages.GetMessage(controllerName, 204)
                        }),

                    BaseDeleteResponse deleteResponse =>
                    new OkObjectResult(deleteResponse),

                    _ => new OkObjectResult(new BaseResponse<T>
                    {
                        Result = response,
                        Message = ResponseMessages.GetMessage(controllerName, 200)
                    })
                };
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage);
                return new BadRequestObjectResult(new BaseErrorResponse
                {
                    Errors = errors
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new BaseErrorResponse
                {
                    Errors = new[] { ResponseMessages.GetMessage(controllerName, 500), ex.Message }
                })
                { StatusCode = 500 };
            }
        }
    }
}
