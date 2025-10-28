using Microsoft.AspNetCore.Mvc;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Api.Extensions
{
    public static class ActionResultConverter
    {
        public static IActionResult Convert<T>(T result)
        {
            try
            {
                if (result == null)
                {
                    return new NotFoundObjectResult(new
                    {
                        Message = "Recurso não encontrado."
                    });
                }

                if (typeof(T).Equals(typeof(PostResponse)))
                    return new CreatedResult(string.Empty, result);

                return new OkObjectResult(result);
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new
                {
                    Message = "Ocorreu um erro interno no servidor.",
                    Detail = ex.Message
                })
                { StatusCode = 500 };
            }
        }

        public static async Task<IActionResult> Convert<T>(Task<T> resultTask)
        {
            var result = await resultTask;
            return Convert(result);
        }
    }
}
