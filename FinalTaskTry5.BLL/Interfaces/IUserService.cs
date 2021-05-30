using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using System;
using System.Threading.Tasks;

namespace FinalTaskTry5.BLL.Interfaces
{
    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService : IDisposable
    {
        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="fileDto">fileDto</param>
        /// <returns>OperationDetail</returns>
        OperationDetail AddFile(FileDto fileDto);

        void AccessMessage(string currentUserId, int fileId, string userId);

        Task ChangeFolderNameAsync(string FolderName, string userId, string NewFolderName);

        UserDto GetMyAccessMessage(string userId);

        UserDto GetAccessMessage(string userId);

        Task MoveToTrash(int fileId, string userId);

        /// <summary>
        /// DeleteFileAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> DeleteFileAsync(int fileId, string userId);

        /// <summary>
        /// DeleteFolderAsync 
        /// </summary>
        /// <param name="folderId">folderId</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> DeleteFolderAsync(int folderId, string userId);

        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>FileDto</returns>
        Task<FileDto> DownloadFileAsync(int fileId, string userId);

        /// <summary>
        /// UserFilesAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserDto</returns>
        Task<UserDto> UserFilesAsync(string userId);

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>FileDto</returns>
        Task<FileDto> GetFileByIdAsync(int fileId);

        /// <summary>
        /// AddFolder
        /// </summary>
        /// <param name="folderName">folderName</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        OperationDetail AddFolder(string folderName, string userId);

        /// <summary>
        /// GetUserFoldersAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserDto</returns>
        Task<UserDto> GetUserFoldersAsync(string userId);

        /// <summary>
        /// UserFilesInFolderAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="folderName">folderName</param>
        /// <returns>UserDto</returns>
        Task<UserDto> UserFilesInFolderAsync(string userId, string folderName);

        /// <summary>
        /// AddFileInFolder
        /// </summary>
        /// <param name="fileDto">fileDto</param>
        /// <returns>OperationDetail</returns>
        OperationDetail AddFileInFolder(FileDto fileDto);

        /// <summary>
        /// ChangeUserNameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserName">newUserName</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> ChangeUserNameAsync(string userId, string newUserName);

        /// <summary>
        /// ChangeUserSurnameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserSurname">newUserSurname</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> ChangeUserSurnameAsync(string userId, string newUserSurname);

        /// <summary>
        /// GetUserInfoAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserProfileDto</returns>
        Task<UserProfileDto> GetUserInfoAsync(string userId);

        /// <summary>
        /// ChangeAccessAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> ChangeAccessAsync(int fileId, string userId);

        /// <summary>
        /// ChangePasswordAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> ChangePasswordAsync(string userId, string oldPassword, string newPassword);

        /// <summary>
        /// GetUserExceptionAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserDto</returns>
        Task<UserDto> GetUserExceptionAsync(string userId);

        /// <summary>
        /// HasPassword
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>bool</returns>
        Task<bool> HasPassword(string userId);
    }
}
