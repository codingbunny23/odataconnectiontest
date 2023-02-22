using ODataConnectionError.Access;

namespace ODataConnectionError.Business;

public partial class Timeline
{
    private readonly OurDbContext Context;

    public Timeline(OurDbContext context)
    {
        Context = context;
    }
}