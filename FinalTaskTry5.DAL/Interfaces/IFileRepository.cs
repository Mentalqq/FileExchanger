using FinalTaskTry5.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Interfaces
{
    /// <summary>
    /// IFileRepository
    /// </summary>
    public interface IFileRepository : IDisposable
    {
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="file">file</param>
        void AddFile(File file);

        Task ChangeFolderName(Folder folder, string NewFolderName);

        /// <summary>
        /// DeleteFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns></returns>
        Task DeleteFileByIdAsync(int fileId);

        Task MoveToTrash(int fileId);

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns>File</returns>
        Task<File> GetFileByIdAsync(int fileId);

        /// <summary>
        /// ChangeAccessAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>bool</returns>
        Task<bool> ChangeAccessAsync(int fileId);

        /// <summary>
        /// GetFolderByName
        /// </summary>
        /// <param name="folderName">folderName</param>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        Folder GetFolderByName(string folderName, string userId);
    }
}
