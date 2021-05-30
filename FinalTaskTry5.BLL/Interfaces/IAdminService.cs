using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTaskTry5.BLL.Interfaces
{
    /// <summary>
    /// IAdminService
    /// </summary>
    public interface IAdminService : IDisposable
    {
        /// <summary>
        /// GetAllUsersWithDetailAsync
        /// </summary>
        /// <returns>IEnumerable<UserDto></returns>
        Task<IEnumerable<UserDto>> GetAllUsersWithDetailAsync();

        Task<IEnumerable<UserDto>> GetAllUsersWithDetailAsync(string fileName);

        /// <summary>
        /// GetFileByNameAsync
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>IEnumerable<FileDto></returns>
        Task<IEnumerable<FileDto>> GetFileByNameAsync(string fileName);

        /// <summary>
        /// DeleteFileAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> DeleteFileAsync(int fileId);

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>FileDto</returns>
        Task<FileDto> GetFileByIdAsync(int fileId);

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
        /// GetUserWithDetailAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserDto</returns>
        Task<UserDto> GetUserWithDetailAsync(string userId);
    }
}
