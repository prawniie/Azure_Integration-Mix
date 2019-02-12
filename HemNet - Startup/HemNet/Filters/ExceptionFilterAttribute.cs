using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace HemNet.Filters
{
    public class ExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            // todo: gör detta endast vid utvecklingsmiljön (annars säkerhetsrisk)
            //context.Result = new BadRequestObjectResult("Oväntat fel: " + context.Exception.Message);

            File.AppendAllText("error.txt", $"{Environment.NewLine}{DateTime.Now} Message: {context.Exception.Message}");

            // todo: oavsett fel, logga felet

        }
    }
}