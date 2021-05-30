using AutoMapper;
using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTaskTry5.BLL.Services
{
    /// <summary>
    /// AdminService
    /// </summary>
    public class AdminService : IAdminService
    {
        IUnitOfWork db { get; set; }

        /// <summary>
        /// AdminService ctor
        /// </summary>
        /// <param name="uow">IUnitOfWork uow</param>
        public AdminService(IUnitOfWork uow)
        {
            db = uow;
        }

        /// <summary>
        /// GetAllUsersWithDetailAsync
        /// </summary>
        /// <returns>IEnumerable<UserDto></returns>
        public async Task<IEnumerable<UserDto>> GetAllUsersWithDetailAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto>>(await db.ApplicationUserRepository.GetAllWithDetailAsync());
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersWithDetailAsync(string fileName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDto>>(await db.ApplicationUserRepository.GetAllWithDetailAsync());
        }

        /// <summary>
        /// GetUserWithDetailAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserDto</returns>
        public async Task<UserDto> GetUserWithDetailAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(await db.ApplicationUserRepository.GetByIdWithDetailAsync(userId));
        }

        /// <summary>
        /// GetFileByNameAsync
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>IEnumerable<FileDto></returns>
        public async Task<IEnumerable<FileDto>> GetFileByNameAsync(string fileName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<File, FileDto>()).CreateMapper();
            return mapper.Map<IEnumerable<File>, IEnumerable<FileDto>>(await db.ApplicationUserRepository.GetFileByNameAsync(fileName));
        }

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>FileDto</returns>
        public async Task<FileDto> GetFileByIdAsync(int fileId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<File, FileDto>()).CreateMapper();
            return mapper.Map<File, FileDto>(await db.FileRepository.GetFileByIdAsync(fileId));
        }

        /// <summary>
        /// DeleteFileAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>OperationDetail</returns>
        public async Task<OperationDetail> DeleteFileAsync(int fileId)
        {
            if (db.FileRepository.GetFileByIdAsync(fileId) != null)
            {
                var file = await db.FileRepository.GetFileByIdAsync(fileId);
                string fileName = file.FileName;
                await db.FileRepository.DeleteFileByIdAsync(fileId);
                return new OperationDetail(true, $"Файл: {fileName } удален.", "");
            }
            else return null;
        }

        /// <summary>
        /// GetUserInfoAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>UserProfileDto</returns>
        public async Task<UserProfileDto> GetUserInfoAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserProfile, UserProfileDto>()).CreateMapper();
            return mapper.Map<UserProfile, UserProfileDto>(await db.ApplicationUserRepository.GetUserInfoAsync(userId));
        }

        /// <summary>
        /// ChangeUserNameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserName">newUserName</param>
        /// <returns>OperationDetail</returns>
        public async Task<OperationDetail> ChangeUserNameAsync(string userId, string newUserName)
        {
            if (userId != null && newUserName != null)
            {
                var user = await db.ApplicationUserRepository.GetUserInfoAsync(userId);
                if (user.Name == newUserName)
                    return new OperationDetail(true, $"Новое имя должно отличатся от старого.", "Name");
                else
                    await db.ApplicationUserRepository.ChangeUserNameAsync(userId, newUserName);
                return new OperationDetail(true, $"Имя изменено.", "");
            }
            else return null;
        }

        /// <summary>
        /// ChangeUserSurnameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserSurname">newUserSurname</param>
        /// <returns>OperationDetail</returns>
        public async Task<OperationDetail> ChangeUserSurnameAsync(string userId, string newUserSurname)
        {
            if (userId != null && newUserSurname != null)
            {
                var user = await db.ApplicationUserRepository.GetUserInfoAsync(userId);
                if (user.Surname == newUserSurname)
                    return new OperationDetail(true, $"Новая фамилия должна отличатся от старой.", "Surname");
                else
                    await db.ApplicationUserRepository.ChangeUserSurnameAsync(userId, newUserSurname);
                return new OperationDetail(true, $"Фамилия изменена.", "");
            }
            else return null;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
