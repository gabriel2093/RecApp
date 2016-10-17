using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecApp_2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "El correo es un campo requerido*")]
        [Display(Name = "Correo electrónico")]
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
        [Required(ErrorMessage = "Campo requerido*")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "¿Recordar este explorador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es un campo requerido*")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Formato incorrecto*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo requerido*")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Campo requerido*")]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [EmailAddress(ErrorMessage = "Formato incorrecto*")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    } 

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Campo requerido*")]
        [EmailAddress(ErrorMessage = "Formato incorrecto*")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido*")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Campo requerido*")]
        [EmailAddress(ErrorMessage = "Formato incorrecto*")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}
