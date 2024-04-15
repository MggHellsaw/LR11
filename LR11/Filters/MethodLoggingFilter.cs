using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace LR11.Filters
{
    public class MethodLoggingFilter : Attribute, IActionFilter
    {
        private readonly string _filePath;

        public MethodLoggingFilter(string filePath)
        {
            _filePath = filePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var currentTime = DateTime.Now;

            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"Метод: {actionName}, Час: {currentTime}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
