using FinalTaskTry5.DAL.EF;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Repositories
{
    /// <summary>
    /// ApplicationUserRepository
    /// </summary>
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationContext db;

        /// <summary>
        /// ApplicationUserRepository ctor
        /// </summary>
        /// <param name="_db">db context</param>
        public ApplicationUserRepository(ApplicationContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// GetByIdWithDetailAsync
        /// </summary>
        /// <param name="id">userId</param>
        /// <returns>Task<ApplicationUser></returns>
        public async Task<ApplicationUser> GetByIdWithDetailAsync(string userId)
        {
            return await Task.Run(() => db.Users.Include(f => f.Files).Include(fo => fo.Folders).FirstOrDefault(f => f.Id == userId));
        }

        /// <summary>
        /// GetFolderFilesByUserIdWithDetailAsync
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="folderName">folderName (not used)</param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetFolderFilesByUserIdWithDetailAsync(string userId, string folderName) //<<<<<<<<<<<<<<<<<<<<THIIIIIIIIISSSS>>>>>>>>>>>>>>>>>>>>>>>>
        {
            return await Task.Run(() => db.Users.Include(fo => fo.Folders).Include(f => f.Files).FirstOrDefault(f => f.Id == userId));
        }

        /// <summary>
        /// GetUserFoldersAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<ApplicationUser></returns>
        public async Task<ApplicationUser> GetUserFoldersAsync(string userId) //<<<<<<<<<<<<<<<<<<<<THIIIIIIIIISSSS>>>>>>>>>>>>>>>>>>>>>>>>
        {
            return await Task.Run(() => db.Users.Include(f => f.Folders).FirstOrDefault(u => u.Id == userId));
        }

        /// <summary>
        /// AddFolder
        /// </summary>
        /// <param name="folder">folder</param>
        public void AddFolder(Folder folder) //<<<<<<<<<<<<<<<<<<<<THIIIIIIIIISSSS>>>>>>>>>>>>>>>>>>>>>>>>
        {
            db.Folders.Add(folder);
            db.SaveChanges();
        }

        /// <summary>
        ///  DeleteFolder
        /// </summary>
        /// <param name="folder">Folder folder</param>
        /// <returns></returns>
        public async Task DeleteFolder(Folder folder) //<<<<<<<<<<<<<<<<<<<<THIIIIIIIIISSSS>>>>>>>>>>>>>>>>>>>>>>>>
        {
            db.Folders.Remove(folder);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// GetFolderByIdAsync
        /// </summary>
        /// <param name="folderId">folderId</param>
        /// <returns>Folder</returns>
        public async Task<Folder> GetFolderByIdAsync(int folderId) //<<<<<<<<<<<<<<<<<<<<THIIIIIIIIISSSS>>>>>>>>>>>>>>>>>>>>>>>>
        {
            return await Task.Run(() => db.Folders.FirstOrDefault(f => f.Id == folderId));
        }

        /// <summary>
        /// GetByIdWithDetail
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ApplicationUser</returns>
        public ApplicationUser GetByIdWithDetail(string userId)
        {
            return db.Users.Include(f => f.Files).FirstOrDefault(f => f.Id == userId);
        }

        public ApplicationUser GetFoldersByIdWithDetail(string userId)
        {
            return db.Users.Include(f => f.Folders).FirstOrDefault(f => f.Id == userId);
        }

        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserProfile</returns>
        public UserProfile GetUserInfo(string userId)
        {
            return db.UserProfiles.Include(u => u.ApplicationUser).FirstOrDefault(i => i.Id == userId);
        }

        /// <summary>
        /// GetUserInfoAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Task<UserProfile></returns>
        public async Task<UserProfile> GetUserInfoAsync(string userId)
        {
            return await Task.Run(() => db.UserProfiles.Include(u => u.ApplicationUser).FirstOrDefault(i => i.Id == userId));
        }

        /// <summary>
        ///  GetAllWithDetailAsync
        /// </summary>
        /// <returns>Task<IQueryable<ApplicationUser>></returns>
        public async Task<IQueryable<ApplicationUser>> GetAllWithDetailAsync()
        {
            return await Task.Run(() => db.Users.Where(u => u.Roles.Any(r => r.RoleId == "f26abde6-a05e-49a6-9fa0-cb1c7c77b116"))
                .Include(us => us.UserProfile).Include(f => f.Files));
        }


        /// <summary>
        /// GetFileByNameAsync
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>Task<IQueryable<File>></returns>
        public async Task<IQueryable<File>> GetFileByNameAsync(string fileName)
        {
            return await Task.Run(() => db.Files.Where(f => f.FileName == fileName)
                .Include(u => u.ApplicationUser));
        }

        /// <summary>
        /// ChangeUserNameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserName">newUserName</param>
        /// <returns>Task</returns>
        public async Task ChangeUserNameAsync(string userId, string newUserName)
        {
            var user = db.UserProfiles.Find(userId);
            user.Name = newUserName;
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// ChangeUserSurnameAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="newUserSurname"> newUserSurname</param>
        /// <returns>Task</returns>
        public async Task ChangeUserSurnameAsync(string userId, string newUserSurname)
        {
            var user = db.UserProfiles.Find(userId);
            user.Surname = newUserSurname;
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationUser GetById(string userId)
        {
            return db.Users.Find(userId);
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
