﻿using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio
    {
        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(@"Dados\Cor.txt"))
            {
                //00001Preto

                var cor = new Cor();
                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }
    }
}