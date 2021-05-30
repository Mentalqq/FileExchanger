using FinalTaskTry5.DAL.Identity;
using System;

namespace FinalTaskTry5.DAL.Interfaces
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// ApplicationUserManager UserManager
        /// </summary>
        ApplicationUserManager UserManager { get; }

        /// <summary>
        /// IGuestRepository GuestRepository
        /// </summary>
        IGuestRepository GuestRepository { get; }

        /// <summary>
        /// IApplicationUserRepository ApplicationUserRepository
        /// </summary>
        IApplicationUserRepository ApplicationUserRepository { get; }

        /// <summary>
        /// IFileRepository FileRepository
        /// </summary>
        IFileRepository FileRepository { get; }

        /// <summary>
        /// ILoggerRepository LoggerRepository { get; }
        /// </summary>
        ILoggerRepository LoggerRepository { get; }

        /// <summary>
        /// ApplicationRoleManager RoleManager { get; }
        /// </summary>
        ApplicationRoleManager RoleManager { get; }
    }
}