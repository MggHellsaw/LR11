using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11.Filters
{
    public class UniqueUsersCountFilter : Attribute ,IActionFilter
    {
        private static HashSet<string> uniqueUsers = new HashSet<string>();
        private static readonly object lockObject = new object();

        private readonly string filePath;

        public UniqueUsersCountFilter(string filePath)
        {
            this.filePath = filePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            lock (lockObject)
            {
                string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
                if (!uniqueUsers.Contains(ipAddress))
                {
                    uniqueUsers.Add(ipAddress);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            lock (lockObject)
            {
                int uniqueUsersCount = uniqueUsers.Count;
                File.WriteAllText(filePath, "Кількість унікальних користувачів: " + uniqueUsersCount.ToString());
            }
        }
    }
}
