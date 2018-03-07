using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio
    {
        private string _caminhoArquivoCor = ConfigurationManager.AppSettings["caminhoArquivoCor"];

        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(_caminhoArquivoCor))
            {
                var cor = new Cor();

                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);
                
                cores.Add(cor);                
            }

            return cores;
        }

        public Cor Selecionar(int corId)
        {
            Cor cor = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivoCor))
            {
                string linhaId = linha.Substring(0, 5);

                if (Convert.ToInt32(linhaId) == corId)
                {
                    cor = new Cor();

                    cor.Id = Convert.ToInt32(linhaId);
                    cor.Nome = linha.Substring(5);

                    break;
                }             
            }

            return cor;
        }
    }
}