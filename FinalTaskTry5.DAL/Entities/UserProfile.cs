using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskTry5.DAL.Entities
{
    /// <summary>
    /// UserProfile class
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [ForeignKey("ApplicationUser")]
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
        /// User
        /// </summary>
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}