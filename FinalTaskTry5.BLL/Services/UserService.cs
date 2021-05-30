using AutoMapper;
using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using FinalTaskTry5.DAL.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskTry5.BLL.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    public class UserService : IUserService
    {
        IUnitOfWork db { get; set; }

        /// <summary>
        /// UserService ctor
        /// </summary>
        public UserService()
        {
            db = new UnitOfWork("DefaultConnection");
        }

        /// <summary>
        /// UserService ctor
        /// </summary>
        /// <param name="uow">IUnitOfWork uow</param>
        public UserService(IUnitOfWork uow)
        {
            db = uow;
        }

        /// <summary>
        /// AddFile
        /// </summary>
        /// <param name="fileDto">fileDto</param>
        /// <returns>OperationDetail</returns>
        public OperationDetail AddFile(FileDto fileDto)
        {
            if (fileDto != null)
            {
                File newFile = new File
                {
                    FileName = fileDto.FileName,
                    Content = fileDto.Content,
                    ApplicationUser = db.ApplicationUserRepository.GetById(fileDto.UserId)
                };
                db.FileRepository.AddFile(newFile);
                return new OperationDetail(true, $"Файл: {fileDto.FileName} добавлен.", "");
            }
            else return null;
        }

        public UserDto GetAccessMessage(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(db.LoggerRepository.GetAccessMessage(userId));
        }

        public UserDto GetMyAccessMessage(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(db.LoggerRepository.GetMyAccessMessage(userId));
        }

        public void AccessMessage(string currentUserId, int fileId, string userId)
        {
            db.LoggerRepository.AccessMessage(userId, fileId, currentUserId);
        }

        /// <summary>
        /// AddFileInFolder
        /// </summary>
        /// <param name="fileDto">fileDto</param>
        /// <returns>OperationDetail</returns>
        public OperationDetail AddFileInFolder(FileDto fileDto)
        {
            if (fileDto != null)
            {
                var folder = db.FileRepository.GetFolderByName(fileDto.FolderName, fileDto.UserId);
                if (folder != null) {
                    File newFile = new File
                    {
                        FileName = fileDto.FileName,
                        Content = fileDto.Content,
                        ApplicationUser = db.ApplicationUserRepository.GetById(fileDto.UserId),
                        Folder = folder
                    };
                    db.FileRepository.AddFile(newFile);
                    return new OperationDetail(true, $"Файл: {fileDto.FileName} добавлен.", "");
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// AddFolder 
        /// </summary>
        /// <param name="folderName">folderName</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        public OperationDetail AddFolder(string folderName,string userId)
        {
            if (folderName != null)
            {
                Folder newFolder = new Folder
                {
                    Name = folderName,
                    User = db.ApplicationUserRepository.GetById(userId)
                };
                db.ApplicationUserRepository.AddFolder(newFolder);
                return new OperationDetail(true, $"Папка: {folderName} добавлена.", "");
            }
            else return null;
        }

        /// <summary>
        /// DeleteFolderAsync 
        /// </summary>
        /// <param name="folderId">folderId</param>
        /// <param name="userId">userId</param>
        /// <returns>OperationDetail</returns>
        public async Task<OperationDetail> DeleteFolderAsync(int folderId, string userId)
        {
            int count = 0;
            var folders = await db.ApplicationUserRepository.GetUserFoldersAsync(userId);
            if (folders.Folders.Any(f => f.Id == folderId))
            {
                var user = await db.ApplicationUserRepository.GetFolderFilesByUserIdWithDetailAsync(userId, null);
                foreach (var item in user.Files)
                {
                    if (item.Folder != null && item.Folder.Id == folderId)
                    {
                        if (item != null)
                        {
                            count++;
                        }
                    }
                }
                Folder newFolder = await db.ApplicationUserRepository.GetFolderByIdAsync(folderId);
                string folderName = newFolder.Name;
                if (count == 0)
                {
                    await db.ApplicationUserRepository.DeleteFolder(newFolder);
                    return new OperationDetail(true, $"Папка: {folderName} удалена.", "");
                }
                else return new OperationDetail(true, $"Папка: {folderName} не может быть удалена.", "");
            }
            else return null;
        }

        /// <summary>
        /// OperationDetail
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>Task<OperationDetail></returns>
        public async Task<OperationDetail> DeleteFileAsync(int fileId, string userId)
        {
            var files = db.ApplicationUserRepository.GetByIdWithDetail(userId);
            if (files.Files.Any(f => f.Id == fileId))
            {
                string fileName = files.Files.FirstOrDefault(i => i.Id == fileId).FileName;
                await db.FileRepository.DeleteFileByIdAsync(fileId);
                return new OperationDetail(true, $"Файл: {fileName } удален.", "");
            }
            else return null;
        }

        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>Task<FileDto></returns>
        public async Task<FileDto> DownloadFileAsync(int fileId, string userId)
        {
            var files = db.ApplicationUserRepository.GetByIdWithDetail(userId);
            if (files.Files.Any(f => f.Id == fileId))
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<File, FileDto>()).CreateMapper();
                return mapper.Map<File, FileDto>(await db.FileRepository.GetFileByIdAsync(fileId));
            }
            else return null;
        }

        /// <summary>
        /// UserFilesAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<UserDto></returns>
        public async Task<UserDto> UserFilesAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(await db.ApplicationUserRepository.GetByIdWithDetailAsync(userId));
        }

        /// <summary>
        /// UserFilesInFolderAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="folderName">folderName</param>
        /// <returns>Task<UserDto></returns>
        public async Task<UserDto> UserFilesInFolderAsync(string userId,string folderName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(await db.ApplicationUserRepository.GetFolderFilesByUserIdWithDetailAsync(userId,folderName));
        }

        /// <summary>
        /// GetUserFoldersAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<UserDto></returns>
        public async Task<UserDto> GetUserFoldersAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(await db.ApplicationUserRepository.GetUserFoldersAsync(userId));
        }

        /// <summary>
        /// GetUserInfoAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<UserProfileDto></returns>
        public async Task<UserProfileDto> GetUserInfoAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserProfile, UserProfileDto>()).CreateMapper();
            return mapper.Map<UserProfile, UserProfileDto>(await db.ApplicationUserRepository.GetUserInfoAsync(userId));
        }

        /// <summary>
        /// ChangeAccessAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <param name="userId">userId</param>
        /// <returns>Task<OperationDetail></returns>
        public async Task<OperationDetail> ChangeAccessAsync(int fileId, string userId)
        {
            var files = db.ApplicationUserRepository.GetByIdWithDetail(userId);
            if (files.Files.Any(f => f.Id == fileId))
            {
                bool state = await db.FileRepository.ChangeAccessAsync(fileId);
                if (state is true)
                    return new OperationDetail(true, $"Доступ к файлу {files.Files.FirstOrDefault(i => i.Id == fileId).FileName} открыт.", "");
                else
                    return new OperationDetail(true, $"Доступ к файлу {files.Files.FirstOrDefault(i => i.Id == fileId).FileName} закрыт.", "");
            }
            else return null;
        }

        public async Task ChangeFolderNameAsync(string FolderName, string userId, string NewFolderName)
        {
            var folders = db.ApplicationUserRepository.GetFoldersByIdWithDetail(userId);
            Folder folder = null;
            if (folders.Folders.Any(f => f.Name == FolderName))
            {
                foreach (var item in folders.Folders)
                {
                    if (item.Name == FolderName)
                    {
                        folder = item;
                        break;
                    }
                }
                await db.FileRepository.ChangeFolderName(folder, NewFolderName);
            }
        }

        public async Task MoveToTrash(int fileId, string userId)
        {
            var files = db.ApplicationUserRepository.GetByIdWithDetail(userId);
            if (files.Files.Any(f => f.Id == fileId))
            {
                await db.FileRepository.MoveToTrash(fileId);
            }
        }

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>Task<FileDto></returns>
        public async Task<FileDto> GetFileByIdAsync(int fileId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<File, FileDto>()).CreateMapper();
            return mapper.Map<File, FileDto>(await db.FileRepository.GetFileByIdAsync(fileId));
        }

        /// <summary>
        /// ChangePasswordAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>Task<OperationDetail></returns>
        public async Task<OperationDetail> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            if(userId != null && (oldPassword == newPassword))
            {
                return new OperationDetail(true, $"Новый пароль должен отличатся от старого.", "Password");
            }
            else if (userId != null && newPassword != null)
            {
                await db.UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);
                return new OperationDetail(true, $"Пароль изменен.", "");
            }
            else return null;
        }

        /// <summary>
        /// ChangeUserNameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserName">newUserName</param>
        /// <returns>Task<OperationDetail></returns>
        public async Task<OperationDetail> ChangeUserNameAsync(string userId, string newUserName)
        {
            if (userId != null && newUserName != null)
            {
                var user = await db.ApplicationUserRepository.GetUserInfoAsync(userId);
                if(user.Name == newUserName)
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
        /// <param name="newUserSurname"></param>
        /// <returns>Task<OperationDetail>newUserSurname</returns>
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
        /// AddNewLog
        /// </summary>
        /// <param name="exceptionLoggerDto">exceptionLoggerDto</param>
        /// <returns>Task</returns>
        public async Task AddNewLog(ExceptionLoggerDto exceptionLoggerDto)
        {
            ExceptionLogger logger = new ExceptionLogger()
            {
                ExceptionMessage = exceptionLoggerDto.ExceptionMessage,
                ControllerName = exceptionLoggerDto.ControllerName,
                ActionName = exceptionLoggerDto.ActionName,
                Date = exceptionLoggerDto.Date,
                ApplicationUser = await db.UserManager.FindByEmailAsync(exceptionLoggerDto.ApplicationUserName)
            };
            db.LoggerRepository.Create(logger);
        }

        /// <summary>
        /// GetUserExceptionAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<UserDto></returns>
        public async Task<UserDto> GetUserExceptionAsync(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDto>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDto>(await db.LoggerRepository.GetUserExAsync(userId));
        }

        /// <summary>
        /// HasPassword
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<bool></returns>
        public async Task<bool> HasPassword(string userId)
        {
            var user = await db.UserManager.FindByIdAsync(userId);
            bool haspassord;
            if (user != null)
            {
                haspassord = true;
            }
            else haspassord = false;
            return haspassord;
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
