using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo04.Colecoes.Testes
{
    [TestClass]
    public class ListTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new List<int>() { 0, 9, 4, 1 };
            inteiros.Add(14);
            inteiros.Add(3);

            //var inteiro = inteiros[0];

            var maisInteiros = new List<int> { 1, 8, 3, 0};

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(0, 52);

            inteiros.Remove(3);

            inteiros.RemoveAt(4);

            inteiros.Sort();

            var primeiro = inteiros[0];
            var ultimo = inteiros[inteiros.Count - 1];

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();
            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(Convert.ToDateTime("01/01/2018"), "Ano novo");
            feriados.Add(Convert.ToDateTime("25/01/2018"), "Aniversário de São Paulo");

            var nomeFeriado = feriados[new DateTime(2018, 12, 25)];

            foreach (var feriado in feriados)
            {
                Console.WriteLine($"{feriado.Key.ToString("dd/MM/yyyy")}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("25/01/2018")));
            Console.WriteLine(feriados.ContainsValue("Sexta-feira Santa"));

            //var veiculos = new Dictionary<string, Veiculo>();
        }
    }
}
