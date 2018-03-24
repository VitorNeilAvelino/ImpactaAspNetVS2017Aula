using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo04.Colecoes.Testes
{
    [TestClass]
    public class VetorTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];
            strings[0] = "String 1";
            //strings[10] = "String 10";

            //var veiculos = new Veiculo[1000];

            //var decimais = new decimal[] { 1.7m, 0.3m, 15};

            decimal[] decimais = { 1.7m, 0.3m, 15 };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor: {decimais.Length}");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Resize(ref decimais, 4);

            decimais[3] = 17.2m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Sort(decimais);

            Assert.IsTrue(decimais[0] == 0.3m);
        }

        [TestMethod]
        public void MediaTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Console.WriteLine(Media(decimais));

            Console.WriteLine(Media(1.6m, 2.5m, 58, 4.4m));
        }

        [TestMethod]
        public void StringsSaoVetoresTeste()
        {
            var nome = "Vítor";

            foreach (var caractere in nome)
            {
                Console.WriteLine(caractere);
            }
        }

        private decimal Media(decimal valor1, decimal valor2)
        {
            return (valor1 + valor2) / 2;
        }

        private decimal Media(params decimal[] valores)
        {
            var soma = 0m;

            foreach (var valor in valores)
            {
                soma += valor; 
            }

            return soma / valores.Length;
        }
    }
}
