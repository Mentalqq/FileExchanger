using FinalTaskTry5.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace FinalTaskTry5.DAL.Identity
{
    /// <summary>
    /// ApplicationUserManager class
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// ApplicationUserManager
        /// </summary>
        /// <param name="store">IUserStore<ApplicationUser> store</param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}