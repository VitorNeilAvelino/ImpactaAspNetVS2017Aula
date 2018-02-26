using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio
    {
        private string _caminhoArquivoMarca = ConfigurationManager.AppSettings["caminhoArquivoMarca"];

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(_caminhoArquivoMarca))
            {
                var vetorPropriedades = linha.Split(';');
                
                var marca = new Marca();

                marca.Id = Convert.ToInt32(vetorPropriedades[0]);
                marca.Nome = vetorPropriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int marcaId)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivoMarca))
            {
                var vetorPropriedades = linha.Split(';');

                if (vetorPropriedades[0] == marcaId.ToString())
                {
                    marca = new Marca();
                    marca.Id = Convert.ToInt32(vetorPropriedades[0]);
                    marca.Nome = vetorPropriedades[1];

                    break;
                }
            }

            return marca;
        }
    }
}