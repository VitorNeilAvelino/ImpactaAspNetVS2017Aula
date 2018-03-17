using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - abstração ou classe.
    public abstract class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _placa;

        //ToDo: OO - encapsulamento.
        public string Placa
        {
            get
            {
                return _placa.ToUpper();
            }
            set
            {
                _placa = value.ToUpper();
            }
        }

        public int Ano { get; set; }
        public string Observacao { get; set; }

        public Cor Cor { get; set; }
        public Modelo Modelo { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        //public string Placa { get => _placa.ToUpper(); set => _placa = value.ToUpper(); }

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            //if (Placa == string.Empty)
            if(string.IsNullOrEmpty(Placa))
            {
                erros.Add("A Placa é obrigatória.");
            }

            return erros;
        }

        public abstract List<string> Validar();

        //ToDo: OO - polimorfismo por substituição.
        public override string ToString()
        {
            return $"{Modelo.Nome} - {Cor.Nome} - {Placa}";
        }
    }
}