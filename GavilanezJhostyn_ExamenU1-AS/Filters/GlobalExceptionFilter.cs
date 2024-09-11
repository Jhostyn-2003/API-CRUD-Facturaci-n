using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GavilanezJhostyn_ExamenU1_AS.Filters
{
    public class GlobalExceptionFilter:  IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "Ha ocurrido un error inesperado en la aplicación.";

            if (context.Exception is DbUpdateException)
            {
                status = HttpStatusCode.BadRequest;
                message = "No se puede completar la operación debido a restricciones de la base de datos.";
            }

            context.Result = new ObjectResult(message)
            {
                StatusCode = (int)status
            };
            context.ExceptionHandled = true;
        }
    }
}
