using FinalTaskTry5.DAL.EF;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Repositories
{
    /// <summary>
    /// FileRepository
    /// </summary>
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationContext db;

        /// <summary>
        /// FileRepository ctor
        /// </summary>
        /// <param name="_db">db context</param>
        public FileRepository(ApplicationContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="file">class file</param>
        public void AddFile(File file)
        {
            db.Files.Add(file);
            db.SaveChanges();
        }

        /// <summary>
        /// DeleteFileByIdAsync 
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>Task</returns>
        public async Task DeleteFileByIdAsync(int fileId)
        {
            var dbforadmin = new ApplicationContext(); //(A second operation started on this context before a previous asynchronous operation completed.)
            var file = await dbforadmin.Files.FindAsync(fileId);
            dbforadmin.Files.Remove(file);
            await dbforadmin.SaveChangesAsync();
        }

        /*/// <summary>
        /// Error (A second operation started on this context before a previous asynchronous operation completed.)
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns></returns>
        public async Task DeleteFileByIdForAdminAsync(int fileId)
        {
            var dbforadmin = new ApplicationContext();
            var file = await dbforadmin.Files.FindAsync(fileId);
            dbforadmin.Files.Remove(file);
            await dbforadmin.SaveChangesAsync();
        }*/

        /// <summary>
        /// GetFileByIdAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>Task<File></returns>
        public async Task<File> GetFileByIdAsync(int fileId)
        {
            return await db.Files.FindAsync(fileId);
        }

        /// <summary>
        /// ChangeAccessAsync
        /// </summary>
        /// <param name="fileId">fileId</param>
        /// <returns>Task<bool></returns>
        public async Task<bool> ChangeAccessAsync(int fileId)
        {
            File file = db.Files.Find(fileId);
            file.Access = !file.Access;
            await db.SaveChangesAsync();
            return file.Access;
        }

        public async Task ChangeFolderName(Folder folder, string NewFolderName)
        {
            folder.Name = NewFolderName;
            await db.SaveChangesAsync();
        }

        public async Task MoveToTrash(int fileId)
        {
            File file = db.Files.Find(fileId);
            file.Trash = !file.Trash;
            file.Access = false;
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// GetFolderByName
        /// </summary>
        /// <param name="folderName">folderName</param>
        /// <param name="userId">userId</param>
        /// <returns>Folder</returns>
        public Folder GetFolderByName(string folderName, string userId)
        {
            return db.Folders.Where(fo => fo.Name == folderName && fo.User.Id == userId).FirstOrDefault();
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
