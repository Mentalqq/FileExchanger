using FinalTaskTry5.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Interfaces
{
    /// <summary>
    /// IGuestRepository
    /// </summary>
    public interface IGuestRepository : IDisposable
    {
        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="item">UserProfile item</param>
        /// <returns></returns>
        Task CreateUserAsync(UserProfile user);
    }
}
