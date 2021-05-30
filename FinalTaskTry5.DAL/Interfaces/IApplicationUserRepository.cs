using FinalTaskTry5.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Interfaces
{
    /// <summary>
    /// IApplicationUserRepository
    /// </summary>
    public interface IApplicationUserRepository : IDisposable
    {
        /// <summary>
        /// GetByIdWithDetailAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>ApplicationUser</returns>
        Task<ApplicationUser> GetByIdWithDetailAsync(string userId);

        ApplicationUser GetFoldersByIdWithDetail(string userId);

        /// <summary>
        ///  DeleteFolder
        /// </summary>
        /// <param name="folder">Folder folder</param>
        /// <returns></returns>
        Task DeleteFolder(Folder folder);

        /// <summary>
        /// GetByIdWithDetail
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ApplicationUser</returns>
        Task<Folder> GetFolderByIdAsync(int folderId);

        /// <summary>
        /// GetByIdWithDetail
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>ApplicationUser</returns>
        ApplicationUser GetByIdWithDetail(string userId);

        /// <summary>
        /// GetAllWithDetailAsync
        /// </summary>
        /// <returns>IQueryable<ApplicationUser></returns>
        Task<IQueryable<ApplicationUser>> GetAllWithDetailAsync();

        /// <summary>
        /// IQueryable<File>
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>IQueryable<File></returns>
        Task<IQueryable<File>> GetFileByNameAsync(string fileName);

        /// <summary>
        /// ChangeUserNameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserName">newUserName</param>
        /// <returns></returns>
        Task ChangeUserNameAsync(string userId, string newUserName);

        /// <summary>
        /// ChangeUserSurnameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserSurname">newUserSurname</param>
        /// <returns></returns>
        Task ChangeUserSurnameAsync(string userId, string newUserSurname);

        /// <summary>
        /// AddFolder
        /// </summary>
        /// <param name="folder">folder</param>
        void AddFolder(Folder folder);

        /// <summary>
        /// GetFoldersAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>ApplicationUser</returns>
        Task<ApplicationUser> GetUserFoldersAsync(string userId);

        /// <summary>
        ///  GetFolderFilesByUserIdWithDetailAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="folderName">folderName</param>
        /// <returns>ApplicationUser</returns>
        Task<ApplicationUser> GetFolderFilesByUserIdWithDetailAsync(string userId, string folderName);

        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserProfile</returns>
        UserProfile GetUserInfo(string userId);

        /// <summary>
        /// GetUserInfoAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserProfile</returns>
        Task<UserProfile> GetUserInfoAsync(string userId);

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>ApplicationUser</returns>
        ApplicationUser GetById(string userId);
    }
}
