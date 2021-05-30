using System.Data.Entity;
using FinalTaskTry5.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalTaskTry5.DAL.EF
{
    /// <summary>
    /// Application Context class
    /// </summary>
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
            : base("DefaultConnection", throwIfV1Schema: false) { }
        public ApplicationContext(string connectionString) : base(connectionString) { }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<ExceptionLogger> ExceptionDetails { get; set; }

        public DbSet<AccessMessage> AccessMessages { get; set; }

        public DbSet<Request> Requests { get; set; }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}