using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public class VeiculoPasseio : Veiculo
    {
        public TipoCarroceria Carroceria { get; set; }

        public override List<string> Validar()
        {
            var erros = new List<string>();



            return erros;
        }
    }
}
