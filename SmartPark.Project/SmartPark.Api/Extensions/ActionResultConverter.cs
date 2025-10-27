using Microsoft.AspNetCore.Mvc;

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
