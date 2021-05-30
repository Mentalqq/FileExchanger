using FinalTaskTry5.DAL.EF;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly ApplicationContext db;

        /// <summary>
        /// LoggerRepository ctor
        /// </summary>
        /// <param name="_db"></param>
        public LoggerRepository(ApplicationContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="exceptionLogger">class logger</param>
        public void Create(ExceptionLogger exceptionLogger)
        {
            db.ExceptionDetails.Add(exceptionLogger);
            db.SaveChanges();
        }

        /// <summary>
        /// GetUserExeptionsAsync
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>ApplicationUser</returns>
        public async Task<ApplicationUser> GetUserExAsync(string userId)
        {
            return await Task.Run(() => db.Users.Include(ex => ex.ExceptionDetails).FirstOrDefault(u => u.Id == userId));
        }

        public ApplicationUser GetAccessMessage(string userId)
        {
            return db.Users.Include(me => me.AccessMessages).FirstOrDefault(u => u.Id == userId);
        }

        public ApplicationUser GetMyAccessMessage(string userId)
        {
            return db.Users.Include(me => me.Requests).FirstOrDefault(u => u.Id == userId);
        }

        public void AccessMessage(string userId, int fileId, string currentUserId)
        {
            var user = db.Users.Find(currentUserId);
            var otherUser = db.Users.Find(userId);
            var file = db.Files.Find(fileId);
            AccessMessage accessMessage = new AccessMessage() { Message = $"Пользователь {user.Email} запросил доступ к файлу ({file.Id}){file.FileName}",
                ApplicationUser = db.Users.Find(userId) };
            Request request = new Request() { Message = $"Вы запросили доступ к файлу ({file.Id}){file.FileName} у пользователя {otherUser.Email}", 
                ApplicationUser = db.Users.Find(currentUserId) };
            db.AccessMessages.Add(accessMessage);
            db.Requests.Add(request);
            db.SaveChanges();
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
