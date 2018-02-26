using System.ComponentModel;

namespace Oficina.Dominio
{
    public enum Cambio
    {
        Manual = 1,

        [Description("Automático")]
        Automatico = 2
    }
}