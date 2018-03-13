using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public abstract class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Placa { get; set; }
        public Modelo Modelo { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cor Cor { get; set; }
        public Cambio Cambio { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }

        public abstract List<string> Validar();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}