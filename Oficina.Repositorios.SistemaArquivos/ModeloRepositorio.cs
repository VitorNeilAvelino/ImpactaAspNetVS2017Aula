﻿using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml.Linq;
using System.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio
    {
        XDocument _arquivoXml = XDocument.Load(ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();

            foreach (var elemento in _arquivoXml.Descendants("modelo"))
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

        public Modelo Selecionar(int modeloId)
        {
            Modelo modelo = null;

            foreach (var elemento in _arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("id").Value == modeloId.ToString())
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = new MarcaRepositorio().Selecionar(Convert.ToInt32(elemento.Element("marcaId").Value));
                }
            }

            return modelo;
        }
    }
}