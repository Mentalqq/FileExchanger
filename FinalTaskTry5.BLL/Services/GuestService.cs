using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.DAL.Interfaces;
using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.DAL.Entities;
using FinalTaskTry5.BLL.Infrastructure;

namespace FinalTaskTry5.BLL.Services
{
    /// <summary>
    /// GuestService
    /// </summary>
    public class GuestService : IGuestService
    {
        IUnitOfWork db { get; set; }

        /// <summary>
        /// GuestService ctor
        /// </summary>
        /// <param name="uow">IUnitOfWork uow</param>
        public GuestService(IUnitOfWork uow)
        {
            db = uow;
        }

        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="userDto">userDto</param>
        /// <returns>Task<OperationDetail></returns>
        public async Task<OperationDetail> CreateUserAsync(UserDto userDto)
        {
            ApplicationUser user = await db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await db.UserManager.CreateAsync(user, userDto.Password); // hz -_-

                await db.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                UserProfile userProfile = new UserProfile { Id = user.Id, Name = userDto.Name, Surname = userDto.Surname };
                await db.GuestRepository.CreateUserAsync(userProfile);
                return new OperationDetail(true, "Аккаунт создан", "");
            }
            else
            {
                return new OperationDetail(true, "Такой логин занят", "Email");
            }
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userDto">userDto</param>
        /// <returns>Task<ClaimsIdentity></returns>
        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await db.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await db.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
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