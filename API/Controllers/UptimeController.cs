using Microsoft.AspNetCore.Mvc;
using DaceloApi.Handlers;

namespace DaceloApi.Controllers;

[ApiController]
[Route("/api/uptime")]
public class UptimeController : ControllerBase
{
    [HttpGet]
    [Route("getuptime")]
    public int GetUptime()
    {
        if(UptimeHandler.stopwatch.IsRunning)
        {
            return UptimeHandler.stopwatch.Elapsed.Seconds;
        }

        return 60; //not possible if the watch is running
    }

    [HttpGet]
    [Route("gethtml")]
    public string GetHtml()
    {
        string html = "<h>Hello World!</h>";
        return html;
    }
}
