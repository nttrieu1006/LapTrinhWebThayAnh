using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebDocTruyenOnline.Common;

namespace WebDocTruyenOnline.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = ErrorMessage.Required)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = ErrorMessage.Required)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Chưa nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Xin kiểm tra lại.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        public string FullName { get; set; }
        
        public string ConfirmPassword { get; set; }
        [Display(Name = "Nhớ mật khẩu")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Chưa nhập Email.")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ. Xin kiểm tra lại.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập mật khẩu.")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải tối đa {0} ký tự và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác thực không khớp.")]
        public string ConfirmPassword { get; set; }
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="Họ tên không được để trống")]
        public string FullName { get; set; }
        [Display(Name ="Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name="Role")]
        public string Name { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Chưa nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Xin kiểm tra lại.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải tối đa {0} ký tự và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác thực không khớp.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Chưa nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Xin kiểm tra lại.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
