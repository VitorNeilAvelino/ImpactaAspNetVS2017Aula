using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Dominio
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Prioridade Prioridade{ get; set; }
        public bool Concluida { get; set; }
        public string Obervacao { get; set; }
    }
}
