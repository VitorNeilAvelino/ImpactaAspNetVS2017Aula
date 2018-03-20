using System;

namespace Oficina.Dominio
{
    public class FaturamentoException : Exception
    {
        public FaturamentoException(string mensagem) : base(mensagem)
        {
            //base.Message = mensagem;
        }
    }
}