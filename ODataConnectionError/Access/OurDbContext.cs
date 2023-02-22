using Microsoft.EntityFrameworkCore;
using ODataConnectionError.Models.Domain;

namespace ODataConnectionError.Access;

public class OurDbContext : DbContext
{
    public OurDbContext() : base() { }
    public OurDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Timeline> Timeline { get; set; }
}
