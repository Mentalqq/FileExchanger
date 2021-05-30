using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Entities
{
    /// <summary>
    /// ExceptionLogger
    /// </summary>
    public class ExceptionLogger
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ExceptionMessage
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// ControllerName (user not used this field)
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// ActionName
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ApplicationUser
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }
    }
}
