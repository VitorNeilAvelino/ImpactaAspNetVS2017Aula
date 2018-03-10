using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.AspNet
{
    public class VeiculoAplicacao
    {
        CorRepositorio _corRepositorio = new CorRepositorio();
        ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();

        }
    }
}