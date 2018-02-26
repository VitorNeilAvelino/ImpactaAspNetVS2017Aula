using System.ComponentModel;

namespace Oficina.Dominio
{
    public enum Combustivel
    {
        Gasolina = 1,

        [Description("Álcool")]
        Alcool = 2,

        Flex = 3,

        [Description("Híbrido")]
        Hibrido = 4
    }
}