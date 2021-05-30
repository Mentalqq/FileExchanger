using FinalTaskTry5.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTaskTry5.ViewModel
{
    public class FileViewModel
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public string CurrenId { get; set; }
    }
    public class UserFilesViewModel
    {
        public string FolderName { get; set; }
        public UserDto User { get; set; }
    }
    public class AvailableFileViewModel
    {
        public FileDto AvailableFile { get; set; }
    }
    public class AllFilesViewModel : FileViewModel
    {
        public IEnumerable<UserDto> Files { get; set; }
    }
    public class FindFilesViewModel : FileViewModel
    {
        public IEnumerable<FileDto> FilesName { get; set; }
    }
}