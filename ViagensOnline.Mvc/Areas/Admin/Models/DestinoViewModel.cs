using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ViagensOnline.Mvc.Areas.Admin.Models
{
    public class DestinoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string CaminhoFoto { get; set; }

        [Required]
        [RegularExpression(@"(.png|.jpg|.gif)$", ErrorMessage = "Apenas arquivos de imagens são permitidos.")]
        public HttpPostedFileBase ArquivoFoto { get; set; }
    }
}