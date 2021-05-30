using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Infrastructure;
using FinalTaskTry5.ViewModel;

namespace FinalTaskTry5.Controllers
{
    public class AccountController : Controller
    {
        private IGuestService GuestService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IGuestService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await GuestService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else if(model.Email == "adminUserNumber1@gmail.com")
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("ControlMenu", "Admin");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Disk", "User");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto{Email = model.Email, Password = model.Password, Name = model.Name, Surname = model.Surname, Role = "user" };
                OperationDetail operationDetails = await GuestService.CreateUserAsync(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Login", "Account");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}