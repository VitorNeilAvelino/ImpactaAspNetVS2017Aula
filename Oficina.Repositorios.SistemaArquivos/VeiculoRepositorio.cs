using Oficina.Dominio;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio 
    {
        public void Inserir(VeiculoPasseio veiculo)
        {
            var caminhoArquivoVeiculo = ConfigurationManager.AppSettings["caminhoArquivoVeiculo"];
            
            var veiculos = XDocument.Load(caminhoArquivoVeiculo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(VeiculoPasseio)).Serialize(registro, veiculo);

            veiculos.Root.Add(XElement.Parse(registro.ToString()));

            veiculos.Save(caminhoArquivoVeiculo);            
        }
    }
}