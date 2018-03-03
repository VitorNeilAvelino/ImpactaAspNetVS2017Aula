public class ModeloRepositorio
{

    public List<Modelo> SelecionarPorMarca(int marcaId)
    {
        var modelos = new List<Modelo>();
        var arquivoXml = XDocument.Load(ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

        foreach (var elemento in arquivoXml.Descendants("modelo"))
        {
            if (marcaId.ToString() == elemento.Element("marcaId").Value)
            {
                var modelo = new Modelo();
                modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                modelo.Nome = elemento.Element("nome").Value;
                modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);

                modelos.Add(modelo);
            }
        }

        return modelos;
    }

}