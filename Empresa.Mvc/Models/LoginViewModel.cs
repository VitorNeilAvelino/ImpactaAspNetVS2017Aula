using System.ComponentModel.DataAnnotations;

namespace Empresa.Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigaória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
    }
}