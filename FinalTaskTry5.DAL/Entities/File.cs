namespace FinalTaskTry5.DAL.Entities
{
    /// <summary>
    /// File class
    /// </summary>
    public class File
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
        /// Access (true/false)
        /// </summary>
        public bool Access { get; set; }

        public bool Trash { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Folder
        /// </summary>
        public Folder Folder { get; set; }
    }
}
