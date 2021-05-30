namespace FinalTaskTry5.BLL.Interfaces
{
    /// <summary>
    /// IServiceCreator
    /// </summary>
    public interface IServiceCreator
    {
        /// <summary>
        /// CreateGuestService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IGuestService</returns>
        IGuestService CreateGuestService(string connection);

        /// <summary>
        /// CreateUserService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IUserService</returns>
        IUserService CreateUserService(string connection);

        /// <summary>
        /// CreateAdminService
        /// </summary>
        /// <param name="connection">connection</param>
        /// <returns>IAdminService</returns>
        IAdminService CreateAdminService(string connection);
    }
}
