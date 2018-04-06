using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]        
        public int CategoriaId { get; set; }

        public string CategoriaNome { get; set; }

        public List<ListItem> Categorias { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; }
    }
}