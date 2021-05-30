using FinalTaskTry5.DAL.Entities;

namespace FinalTaskTry5.BLL.DTO
{
    /// <summary>
    /// UserProfileDto class
    /// </summary>
    public class UserProfileDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// ApplicationUser
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }
    }
}
