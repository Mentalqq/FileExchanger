using FinalTaskTry5.DAL.EF;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.DAL.Identity;
using FinalTaskTry5.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace FinalTaskTry5.DAL.Repositories
{
    /// <summary>
    /// Unit Of Work class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IGuestRepository guestRepository;
        private IApplicationUserRepository applicationUserRepository;
        private IFileRepository fileRepository;
        private ILoggerRepository loggerRepository;

        /// <summary>
        /// UnitOfWork ctor
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        public UnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            guestRepository = new GuestRepository(db);
            applicationUserRepository = new ApplicationUserRepository(db);
            fileRepository = new FileRepository(db);
            loggerRepository = new LoggerRepository(db);
        }

        /// <summary>
        /// ApplicationUserManager
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        /// <summary>
        /// IGuestRepository
        /// </summary>
        public IGuestRepository GuestRepository
        {
            get { return guestRepository; }
        }

        /// <summary>
        /// IApplicationUserRepository
        /// </summary>
        public IApplicationUserRepository ApplicationUserRepository
        {
            get { return applicationUserRepository; }
        }

        /// <summary>
        /// IFileRepository
        /// </summary>
        public IFileRepository FileRepository
        {
            get { return fileRepository; }
        }

        /// <summary>
        /// ILoggerRepository
        /// </summary>
        public ILoggerRepository LoggerRepository
        {
            get { return loggerRepository; }
        }

        /// <summary>
        /// ApplicationRoleManager
        /// </summary>
        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        /// <summary>
        /// virtual Dispose
        /// </summary>
        /// <param name="disposing">bool</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    guestRepository.Dispose();
                    applicationUserRepository.Dispose();
                    fileRepository.Dispose();
                    loggerRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}