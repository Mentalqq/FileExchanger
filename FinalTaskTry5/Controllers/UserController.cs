using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.BLL.Services;
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
    public class UserController : Controller
    {
        private static string currentFolder;

        private IAdminService AdminService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IAdminService>();
            }
        }
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

        [Authorize(Roles = "user")]
        public async Task<ActionResult> Disk(string message)
        {
            ViewBag.StatusMessage = message;
            var files = new UserFilesViewModel { User = await UserService.UserFilesAsync(CurrentUser()) };
            return View(files);
        }

        [Authorize(Roles = "user")]
        public async Task<ActionResult> Trash(string message)
        {
            ViewBag.StatusMessage = message;
            var files = new UserFilesViewModel { User = await UserService.UserFilesAsync(CurrentUser()) };
            return View(files);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> FindFile(string fileName)
        {
            var usersFiles = new AllFilesViewModel { Files = await AdminService.GetAllUsersWithDetailAsync(), CurrenId = CurrentUser(), FileName = fileName };
            if (usersFiles != null)
            {
                return View(usersFiles);
            }
            else
            {
                return RedirectToAction("ControlMenu");
            }
        }

        [Authorize(Roles = "user")]
        public async Task<ActionResult> Folder(string message, string folder)
        {
            ViewBag.StatusMessage = message;
            ViewBag.Folder = folder;
            currentFolder = folder;
            var files = new UserFilesViewModel { User = await UserService.UserFilesInFolderAsync(CurrentUser(), folder) };
            return View(files);
        }

        [Authorize(Roles = "user")]
        public ActionResult ChangeFolderName()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> ChangeFolderName(string NewFolderName)
        {
            await UserService.ChangeFolderNameAsync(currentFolder,CurrentUser(), NewFolderName);
            return RedirectToAction("Disk", "User");
        }

        [Authorize(Roles = "user")]
        public async Task<ActionResult> Logger()
        {
            var logger = new LoggerViewModel() { User =  await UserService.GetUserExceptionAsync(CurrentUser()) };
            return View(logger);
        }

        [Authorize(Roles = "user")]
        public async Task<ActionResult> ControlMenu()
        {
            var usersFiles = new AllFilesViewModel { Files = await AdminService.GetAllUsersWithDetailAsync(), CurrenId = CurrentUser() };
            return View(usersFiles);
        }

        [Authorize(Roles = "user")]
        public ActionResult GetRequestAccessMessages()
        {
            var accessMessages = new AccessMessageViewModel { User = UserService.GetAccessMessage(CurrentUser()) };
            return View(accessMessages);
        }

        [Authorize(Roles = "user")]
        public ActionResult ListOfMyRequest()
        {
            var accessMessages = new AccessMessageViewModel { User = UserService.GetMyAccessMessage(CurrentUser()) };
            return View(accessMessages);
        }

        [Authorize(Roles = "user")]
        public ActionResult RequestAccess(int fileid, string userid)
        {
            UserService.AccessMessage(CurrentUser(), fileid, userid);
            return RedirectToAction("ControlMenu","User");
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult AddFile(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null && upload.ContentLength > 0)
            {
                var tempfile = new FileViewModel
                {
                    FileName = Path.GetFileName(upload.FileName)
                };
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    tempfile.Content = reader.ReadBytes(upload.ContentLength);
                }
                var fileDto = new FileDto { FileName = tempfile.FileName, Content = tempfile.Content, UserId = CurrentUser() };
                var detail = UserService.AddFile(fileDto);
                ViewBag.Detail = detail.Message;
            }
            return RedirectToAction("Disk", new { Message = ViewBag.Detail });
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult AddFileInFolder(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null && upload.ContentLength > 0)
            {
                var tempfile = new FileViewModel
                {
                    FileName = Path.GetFileName(upload.FileName)
                };
                using (var reader = new BinaryReader(upload.InputStream))
                {
                    tempfile.Content = reader.ReadBytes(upload.ContentLength);
                }
                var fileDto = new FileDto { FileName = tempfile.FileName, Content = tempfile.Content, UserId = CurrentUser(), FolderName = currentFolder };
                var detail = UserService.AddFileInFolder(fileDto);
                ViewBag.Detail = detail.Message;
            }
            return RedirectToAction("Folder", new { Message = ViewBag.Detail, Folder = currentFolder });
        }

        public ActionResult AddFolder()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult AddFolder(UserFilesViewModel folder)
        {
            var detail = UserService.AddFolder(folder.FolderName, CurrentUser());
            if (detail is null)
            {
                throw new Exception("ETOGO NE DOLJNO BIT");
            }
            ViewBag.Detail = detail.Message;
            return RedirectToAction("Disk", new { Message = ViewBag.Detail });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> MoveFileInOutTrash(int id)
        {
            await UserService.MoveToTrash(id, CurrentUser());
            return RedirectToAction("Disk", new { Message = ViewBag.Detail });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            var detail = await UserService.DeleteFileAsync(id, CurrentUser());
            if(detail is null)
            {
                throw new Exception("Данный файл не найден.");
            }
            ViewBag.Detail = detail.Message;
            return RedirectToAction("Trash", new { Message = ViewBag.Detail });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> DeleteFolder(int id)
        {
            var detail = await UserService.DeleteFolderAsync(id, CurrentUser());
            if (detail is null)
            {
                throw new Exception("Данная папка не найдена.");
            }
            ViewBag.Detail = detail.Message;
            return RedirectToAction("Folder", new { Message = ViewBag.Detail, Folder = currentFolder });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> ChangeAccess(int id)
        {
            var detail = await UserService.ChangeAccessAsync(id, CurrentUser());
            if (detail is null)
            {
                throw new Exception("Данный файл не найден.");
            }
            ViewBag.Detail = detail.Message;
            return RedirectToAction("Disk", new { Message = ViewBag.Detail });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<ActionResult> ChangeAccessInFolder(int id)
        {
            var detail = await UserService.ChangeAccessAsync(id, CurrentUser());
            if (detail is null)
            {
                throw new Exception("Данный файл не найден.");
            }
            ViewBag.Detail = detail.Message;
            return RedirectToAction("Folder", new { Message = ViewBag.Detail, Folder = currentFolder });
        }

        [ExceptionLogger]
        [NotFoundException]
        [Authorize(Roles = "user")]
        public async Task<FileContentResult> DownloadFile(int id)
        {
            var file = await UserService.DownloadFileAsync(id, CurrentUser());
            if(file is null)
            {
                throw new Exception("Данный файл не найден.");
            }
            return File(file.Content, MIMEAssistant.GetMIMEType(file.FileName), file.FileName);
        }

        [NotFoundException]
        public async Task<ActionResult> AvailableFile(int id)
        {
            var file = new AvailableFileViewModel { AvailableFile = await UserService.GetFileByIdAsync(id) };
            if(file is null)
            {
                throw new Exception("Данный файл не найден.");
            }
            if (file.AvailableFile.Access is true)
                return View(file);
            return View();
        }
    }
}