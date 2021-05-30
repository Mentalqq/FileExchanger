using FinalTaskTry5.DAL.EF;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Interfaces;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Repositories
{
    /// <summary>
    /// Guest Repository class
    /// </summary>
    public class GuestRepository : IGuestRepository
    {
        private readonly ApplicationContext db;

        /// <summary>
        /// GuestRepository ctor
        /// </summary>
        /// <param name="_db"></param>
        public GuestRepository(ApplicationContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="item">new user</param>
        public async Task CreateUserAsync(UserProfile user)
        {
            db.UserProfiles.Add(user);
            await db.SaveChangesAsync();
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