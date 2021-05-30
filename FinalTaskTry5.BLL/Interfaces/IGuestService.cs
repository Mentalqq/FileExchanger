using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalTaskTry5.BLL.Interfaces
{
    /// <summary>
    /// IGuestService
    /// </summary>
    public interface IGuestService : IDisposable
    {
        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="userDto">userDto</param>
        /// <returns>OperationDetail</returns>
        Task<OperationDetail> CreateUserAsync(UserDto userDto);

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userDto">userDto</param>
        /// <returns>ClaimsIdentity</returns>
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
    }
}
