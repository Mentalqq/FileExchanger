using FinalTaskTry5.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTaskTry5.ViewModel
{
    public class IndexViewModel
    {
        public UserProfileDto User { get; set; }
        public bool HasPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangeUserNameViewModel
    {
        [Required]
        [Display(Name = "Новое имя")]
        public string NewUserName { get; set; }
    }

    public class ChangeFolderNameViewModel
    {
        [Required]
        [Display(Name = "Новое имя")]
        public string NewFolderName { get; set; }
    }

    public class ChangeUserSurnameViewModel
    {
        [Required]
        [Display(Name = "Новая фамилия")]
        public string NewUserSurname { get; set; }
    }
}