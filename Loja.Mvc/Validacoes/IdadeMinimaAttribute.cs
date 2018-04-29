using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Validacoes
{
    [AttributeUsage(AttributeTargets.Property /*| AttributeTargets.Method*/)]
    internal class IdadeMinimaAttribute : ValidationAttribute, IClientValidatable
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
            DateTime dataNascimento;
            var dataValida = DateTime.TryParse(Convert.ToString(value), out dataNascimento);

            if (!dataValida)
            {
                return new ValidationResult("Data no formato inválida.");
            }

            if (dataNascimento.AddYears(_idadeMinima) > DateTime.Now)
            {
                return new ValidationResult(_mensagemErro);
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var regra = new ModelClientValidationRule
            {
                ErrorMessage = _mensagemErro,
                ValidationType = "regraidademinima"
            };

            regra.ValidationParameters.Add("valoridademinima", _idadeMinima);

            return new List<ModelClientValidationRule> { regra };
        }
    }
}