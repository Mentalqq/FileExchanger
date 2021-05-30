using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalTaskTry5.Controllers
{
    public class ManageController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IUserService>();
            }
        }

        [Authorize]
        public string CurrentUser()
        {
            string currentUserId = User.Identity.GetUserId();
            return currentUserId;
        }

        [Authorize]
        public async Task<ActionResult> Index(string message)
        {
            ViewBag.StatusMessage = message;

            var model = new IndexViewModel { HasPassword = await UserService.HasPassword(CurrentUser()), User = await UserService.GetUserInfoAsync(CurrentUser()) };
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var detail = await UserService.ChangePasswordAsync(CurrentUser(), model.OldPassword, model.NewPassword);
            if (detail.Succedeed)
            {
                ViewBag.Detail = detail.Message;
                return RedirectToAction("Index", new { Message = ViewBag.Detail });
            }
            return View(model);
        }

        [Authorize]
        public ActionResult ChangeUserName()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeUserName(ChangeUserNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var detail = await UserService.ChangeUserNameAsync(CurrentUser(), model.NewUserName);
            if (detail.Succedeed)
            {
                ViewBag.Detail = detail.Message;
                return RedirectToAction("Index", new { Message = ViewBag.Detail });
            }
            return View(model);
        }

        [Authorize]
        public ActionResult ChangeUserSurname()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeUserSurname(ChangeUserSurnameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var detail = await UserService.ChangeUserSurnameAsync(CurrentUser(), model.NewUserSurname);
            if (detail.Succedeed)
            {
                ViewBag.Detail = detail.Message;
                return RedirectToAction("Index", new { Message = ViewBag.Detail });
            }
            return View(model);
        }
    }
}