using Loja.Mvc.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [RequiredAttribute]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Nascimento")]
        //[DisplayName("Nascimento")]
        //[DataType(DataType.Date)]
        [IdadeMinima(18)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Remote("VerificarDisponibilidadeEmail", "Clientes", 
            HttpMethod = "POST", ErrorMessage = "Email não disponível.")]
        [RegularExpression(@"^[a-zA-Z0-9.-_]{1,50}@[\w]+(\.[a-zA-Z]{2,3}){1,2}$", 
            ErrorMessage = "Email no formato inválido.")]
        //[EmailAddress]
        public string Email { get; set; }
    }
}