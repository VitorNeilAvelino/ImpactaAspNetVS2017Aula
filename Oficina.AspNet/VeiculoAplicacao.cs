using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.AspNet
{
    public class VeiculoAplicacao
    {
        MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        CorRepositorio _corRepositorio = new CorRepositorio();
        VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();

        public VeiculoAplicacao()
        {
            //if (HttpContext.Current.Request.HttpMethod != "POST")
            //{
            PopularControles();
            //}
        }

        public List<Marca> Marcas { get; private set; }
        public string MarcaSelecionada { get; private set; }
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios { get; private set; }

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();
            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            ObterVeiculos();

            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        private List<VeiculoPasseio> ObterVeiculos()
        {
            var veiculos = new List<VeiculoPasseio>();

            for (int i = 0; i < 2000000; i++)
            {
                veiculos.Add(new VeiculoPasseio());
            }

            return veiculos;
        }

        public void Inserir()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = _modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];
                veiculo.Carroceria = TipoCarroceria.Hatch;

                _veiculoRepositorio.Inserir(veiculo);
            }
            catch (FileNotFoundException ex) when (!ex.FileName.Contains("Senha"))
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Arquivo {ex.FileName} não encontrado.");
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Arquivo sem permissão de gravação.");
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Caminho não encontrado.");
                throw;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Ooops! Ocorreu um erro.");
                //logar o erro contido no objeto exception.
                throw;
            }
            finally
            {
                // Opcional - se presente, é executado sempre, independente de sucesso, erro ou qualquer return.
            }
        }
    }
}