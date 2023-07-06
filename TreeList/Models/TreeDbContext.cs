using System.Data.Entity;

namespace TreeList.Models
{
    public class TreeDbContext : DbContext
    {
        public TreeDbContext() : base("TreeDbContext")
        {
        }
        public DbSet<TreeItem> TreeItems { get; set; }

    }

}