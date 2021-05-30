using FinalTaskTry5.DAL.Entities;

namespace FinalTaskTry5.BLL.DTO
{
    /// <summary>
    /// FileDto class
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Access(true/false)
        /// </summary>
        public bool Access { get; set; }

        public bool Trash { get; set; }

        /// <summary>
        /// userId
        /// </summary>
        public string UserId { get; set; }

        public string FolderName { get; set; }

        /// <summary>
        /// ApplicationUser
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }
    }
}
