using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoList.Application.Filters;

public  class ApiLoggingFilter: IActionFilter
{
    private readonly ILogger<ApiLoggingFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)// depois da action
    {
        _logger.LogInformation("### Executando -> OnActionExecuting");
        _logger.LogInformation("----------------------------------------------------------------");
        _logger.LogInformation($"{DateTime.UtcNow.ToLongDateString()} - StatusCode: {filterContext.HttpContext.Response.StatusCode}");
        _logger.LogInformation($"Response: {filterContext.HttpContext.Response.Body.ToString()}");
        _logger.LogInformation("----------------------------------------------------------------");
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) // antes da action
    {
        _logger.LogInformation("### Executando -> OnActionExecuting");
        _logger.LogInformation("----------------------------------------------------------------");
        _logger.LogInformation($"{DateTime.UtcNow.ToLongDateString()}");
        _logger.LogInformation($"ModelState: {filterContext.ModelState.IsValid}");
        _logger.LogInformation("----------------------------------------------------------------");
    }
}
