using Microsoft.EntityFrameworkCore;

namespace NewPlannerAPI.Domain.Models
{
    public class AppDbContext:DbContext
    {
     
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PlannerHeader>?TrtPlannerHeader { get; set; }
        public DbSet<PlannerDetail>?TrtPlannerDetail { get; set; }
    }
}
