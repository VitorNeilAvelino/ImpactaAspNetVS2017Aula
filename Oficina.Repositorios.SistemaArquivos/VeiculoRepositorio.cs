public class VeiculoRepositorio
{
    private string _caminhoArquivoVeiculo = ConfigurationManager.AppSettings["caminhoArquivoVeiculo"];

    public void Inserir(Veiculo veiculo)
    {
        var veiculos = XDocument.Load(_caminhoArquivoVeiculo);

        var registro = new StringWriter();
        new XmlSerializer(typeof(Veiculo))
            .Serialize(registro, veiculo);

        veiculos.Root.Add(XElement.Parse(registro.ToString()));

        veiculos.Save(_caminhoArquivoVeiculo);
    }
}