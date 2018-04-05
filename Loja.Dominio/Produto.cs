﻿namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }

        public Categoria Categoria{ get; set; }
    }
}