using FinalTaskTry5.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Interfaces
{
    /// <summary>
    /// ILoggerRepository 
    /// </summary>
    public interface ILoggerRepository : IDisposable
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="exceptionLogger">ExceptionLogger exceptionLogger</param>
        void Create(ExceptionLogger exceptionLogger);

        ApplicationUser GetAccessMessage(string userId);
        void AccessMessage(string userId, int fileId, string currentUserId);

        ApplicationUser GetMyAccessMessage(string userId);

        /// <summary>
        /// GetUserExAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        Task<ApplicationUser> GetUserExAsync(string userId);
    }
}
