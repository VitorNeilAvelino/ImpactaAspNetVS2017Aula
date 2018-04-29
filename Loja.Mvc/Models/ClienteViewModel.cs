using Loja.Mvc.Validacoes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        //@Html.EditorFor(model => model.Nome, new { htmlAttributes = new { @class = "form-control", maxlength = "10" } })
        public string Nome { get; set; }

        [Required]
        [IdadeMinima(18)]
        //[DataType(DataType.Date)] // HTML 5: date picker
        [DisplayName("Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        //[RegularExpression("^[a-zA-Z0-9-._]{1,50}$")]
        //[RegularExpression(@"^[^\W_][a-zA-Z0-9-._]+@[\w-]+(\.[a-zA-Z]{2,3}){1,2}$", ErrorMessage = "Email com formato inválido.")]
        [EmailAddress]
        [Remote("VerificarDisponibilidadeEmail", "Clientes", HttpMethod = "POST", ErrorMessage = "Email já utilizado." )]
        public string Email { get; set; }
    }
}