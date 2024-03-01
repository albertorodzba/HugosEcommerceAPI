using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hugosEcommerce_api.Filters
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("ejecutado desde global filter excepetion");
            Console.WriteLine(context.Exception.Message);
            // context.HttpContext.Response.WriteAsJsonAsync( new { status= 400, message = context.Exception.Message.ToString() });
            // context.HttpContext.Response.Write("status= 400, message = There is an error, report to the system admin");
            context.Result = new JsonResult(new {status = 500, message ="There is an error, report to the system admin"});
            Console.WriteLine("RESPUESTA ENVIADA");
        }
    }
}