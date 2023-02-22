using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataConnectionError.Access;
using ODataConnectionError.Helpers;

namespace ODataConnectionError.Controllers;

public class TimelineControllerOData : ODataController
{
    private readonly ContextFactory ContextFactory;

    public TimelineControllerOData(ContextFactory ctx) {
        ContextFactory = ctx;
    }

    [HttpGet]
    [EnableQuery(PageSize = 50)]
    [Route("TimelinesOData")]
    public async Task<ActionResult> GetTimelines()
    {
        var context = ContextFactory.Create<OurDbContext>();
        await context.Database.OpenConnectionAsync();
        
        var business = new Business.Timeline(context);
        var timelines = business.GetTimelines();
        
        if (timelines != null && timelines.Any())
        {
            return Ok(timelines);
        }

        return NoContent();
    }
}