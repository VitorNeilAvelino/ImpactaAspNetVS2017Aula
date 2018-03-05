using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio
    {
        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();
            var arquivoXml = XDocument.Load(ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("marcaId").Value != marcaId.ToString())
                {
                    continue;
                }

                var modelo = new Modelo();

                modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                modelo.Nome = elemento.Element("nome").Value;
                modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);

                modelos.Add(modelo);
            }
            
            return modelos;
        }
    }
}