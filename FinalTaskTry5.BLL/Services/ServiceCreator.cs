using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.DAL.Repositories;

namespace FinalTaskTry5.BLL.Services
{
    /// <summary>
    /// Abstract Factory ServiceCreator
    /// </summary>
    public class ServiceCreator : IServiceCreator
    {
        /// <summary>
        /// CreateGuestService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IGuestServic</returns>
        public IGuestService CreateGuestService(string connection)
        {
            return new GuestService(new UnitOfWork(connection));
        }

        /// <summary>
        /// CreateUserService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IUserService</returns>
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }

        /// <summary>
        /// CreateAdminService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IAdminService</returns>
        public IAdminService CreateAdminService(string connection)
        {
            return new AdminService(new UnitOfWork(connection));
        }
    }
}