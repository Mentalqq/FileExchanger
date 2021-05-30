using FinalTaskTry5.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalTaskTry5.DAL.Identity
{
    /// <summary>
    /// ApplicationRoleManager class
    /// </summary>
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        /// <summary>
        /// ApplicationRoleManager ctor
        /// </summary>
        /// <param name="store">RoleStore<ApplicationRole> store</param>
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}