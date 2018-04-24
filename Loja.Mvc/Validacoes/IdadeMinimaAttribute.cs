using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Mvc.Validacoes
{
    internal class IdadeMinimaAttribute : ValidationAttribute
    {
        private int _idadeMinima;
        private string _mensagemErro;

        public IdadeMinimaAttribute(int idadeMinima)
        {
            _idadeMinima = idadeMinima;
            _mensagemErro = $"A idade mínima é de {_idadeMinima} anos.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dataNascimento = (DateTime)value;

            if (dataNascimento.AddYears(_idadeMinima) > DateTime.Now)
            {
                return new ValidationResult(_mensagemErro);
            }

            return ValidationResult.Success;
        }
    }
}