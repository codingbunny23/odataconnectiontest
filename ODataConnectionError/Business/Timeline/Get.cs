using System.Linq;
using TimelineModel = ODataConnectionError.Models.Domain.Timeline;

namespace ODataConnectionError.Business;

public partial class Timeline
{
    public IQueryable<TimelineModel> GetTimelines()
    {
        return Context.Timeline;
    }
}