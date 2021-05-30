using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Entities
{
    /// <summary>
    /// Folder
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        public ICollection<File> Files { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public ApplicationUser User { get; set; }
    }
}
