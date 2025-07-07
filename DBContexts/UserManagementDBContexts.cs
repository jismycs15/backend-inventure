using inventure.Models;
using Microsoft.EntityFrameworkCore;
namespace inventure.DBContexts
{
    public class UserManagementDBContexts: DbContext
    {
        public UserManagementDBContexts(DbContextOptions<UserManagementDBContexts> options) : base(options) { }

        public DbSet<usermaster>usermasters { get; set; }
    }
}
