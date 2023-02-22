using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataConnectionError.Access;
using ODataConnectionError.Helpers;

namespace ODataConnectionError.Controllers;

public class TimelineController : Controller
{
    private readonly ContextFactory ContextFactory;

    public TimelineController(ContextFactory ctx) {
        ContextFactory = ctx;
    }

    [HttpGet]
    [Route("Timelines")]
    public async Task<ActionResult> GetTimelines()
    {
        await using var context = ContextFactory.Create<OurDbContext>();
        await context.Database.OpenConnectionAsync();
        
        var business = new Business.Timeline(context);
        var timelines = await business.GetTimelines().Take(10).ToListAsync();
        
        if (timelines != null && timelines.Count > 0)
        {
            return Ok(timelines);
        }

        return NoContent();
    }
}