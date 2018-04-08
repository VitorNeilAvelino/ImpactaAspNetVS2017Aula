using System;
using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Produto> Itens { get; set; }
    }
}