using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace FinalTaskTry5.DAL.Entities
{
    /// <summary>
    /// Application User class
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// UserProfile
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        public virtual ICollection<File> Files { get; set; }

        /// <summary>
        /// Folders
        /// </summary>
        public ICollection<Folder> Folders { get; set; }

        public ICollection<AccessMessage> AccessMessages { get; set; }

        public ICollection<Request> Requests { get; set; }

        /// <summary>
        /// ExceptionDetails
        /// </summary>
        public ICollection<ExceptionLogger> ExceptionDetails { get; set; }
    }
}