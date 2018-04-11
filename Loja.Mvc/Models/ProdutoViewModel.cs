using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; } = true;
    }
}