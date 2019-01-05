using Keeper.Data.Projects;
using Keeper.Data.Users;
using System.Data.Entity;

namespace Keeper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(@"Server=.\SQLEXPRESS;Database=Keeper;User Id=Keeper;Password=zaq1@WSX")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
