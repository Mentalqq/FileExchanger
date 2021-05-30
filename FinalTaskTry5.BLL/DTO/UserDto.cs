using FinalTaskTry5.DAL.Entities;
using System.Collections.Generic;

namespace FinalTaskTry5.BLL.DTO
{
    /// <summary>
    /// UserDto class
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        public ICollection<File> Files { get; set; }

        public ICollection<AccessMessage> AccessMessages { get; set; }

        public ICollection<Request> Requests { get; set; }

        /// <summary>
        /// Folders
        /// </summary>
        public ICollection<Folder> Folders { get; set; }

        /// <summary>
        /// ExceptionDetails
        /// </summary>
        public ICollection<ExceptionLogger> ExceptionDetails { get; set; }

        
    }
}
