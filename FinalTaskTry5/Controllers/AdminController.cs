using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.Filters;
using FinalTaskTry5.Helpers;
using FinalTaskTry5.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace FinalTaskTry5.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService AdminService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IAdminService>();
            }
        }
        private static string userId;

        /*[NotFoundException]*/
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            await AdminService.DeleteFileAsync(id);
            return RedirectToAction("ControlMenu");
        }

        /*[NotFoundException]*/
        [Authorize(Roles = "admin")]
        public async Task<FileContentResult> DownloadFile(int id)
        {
            var file = await AdminService.GetFileByIdAsync(id);
            return File(file.Content, MIMEAssistant.GetMIMEType(file.FileName), file.FileName);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ControlMenu()
        {
            var usersFiles = new AllFilesViewModel { Files = await AdminService.GetAllUsersWithDetailAsync() };
            return View(usersFiles);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> FindFile(string fileName)
        {
            var file = new FindFilesViewModel { FilesName = await AdminService.GetFileByNameAsync(fileName) };
            if(file != null)
            {
                return View(file);
            }
            else
            {
                return RedirectToAction("ControlMenu");
            }
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Manage(string id, string message)
        {
            ViewBag.StatusMessage = message;

            userId = id;
            var model = new IndexViewModel { User = await AdminService.GetUserInfoAsync(userId) };
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ChangeUserName()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeUserName(ChangeUserNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var detail = await AdminService.ChangeUserNameAsync(userId, model.NewUserName);
            if (detail.Succedeed)
            {
                ViewBag.Detail = detail.Message;
                return RedirectToAction("Manage", "Admin", new { id = userId, Message = ViewBag.Detail });
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
            var detail = await AdminService.ChangeUserSurnameAsync(userId, model.NewUserSurname);
            if (detail.Succedeed)
            {
                ViewBag.Detail = detail.Message;
                return RedirectToAction("Manage", "Admin", new { id = userId, Message = ViewBag.Detail });
            }
            return View(model);
        }
    }
}