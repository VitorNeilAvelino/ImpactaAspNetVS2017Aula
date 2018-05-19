using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CulturaHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string _linguagemSelecionada = LinguagemPadrao;
        private List<string> LinguagensSuportadas = new List<string> {"pt-BR", "en-US", "es" };

        public CulturaHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }

        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(_linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }

        internal static CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current.Request.Cookies["linguagemSelecionada"];
            var linguagem = linguagemSelecionada?.Value ?? LinguagemPadrao;

            return CultureInfo.CreateSpecificCulture(linguagem);
        }

        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request;

            if (request.Cookies["linguagemSelecionada"] != null)
            {
                _linguagemSelecionada = request.Cookies["linguagemSelecionada"].Value;
                return;
            }

            if (request.UserLanguages != null && LinguagensSuportadas.Contains(request.UserLanguages[0]) )
            {
                _linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie("linguagemSelecionada", _linguagemSelecionada);
            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }
    }
}