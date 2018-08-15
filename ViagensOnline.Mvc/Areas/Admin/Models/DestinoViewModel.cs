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
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }

        public string CaminhoImagem { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase ArquivoFoto { get; set; }
    }
}