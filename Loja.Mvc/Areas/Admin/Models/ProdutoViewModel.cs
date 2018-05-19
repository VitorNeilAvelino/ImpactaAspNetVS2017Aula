using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Loja.Resources;

namespace Loja.Mvc.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = nameof(Literal.NomeProdutoLabel), ResourceType = typeof(Literal))]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }
        //public Nullable<int> CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public bool Ativo { get; set; }
    }
}