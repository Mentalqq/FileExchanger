using System;

namespace FinalTaskTry5.BLL.DTO
{
    /// <summary>
    /// ExceptionLoggerDto class
    /// </summary>
    public class ExceptionLoggerDto
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
        /// ControllerName
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
        /// ApplicationUserName
        /// </summary>
        public string ApplicationUserName { get; set; }
    }
}
