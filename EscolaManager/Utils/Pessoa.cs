using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Utils
{
    class Pessoa
    {
        private string name;
        public string Name{ get { return name; } set { name = value; }}

        private int idade;
        public int Idade { get { return idade; } set { idade = value; } }

        private string turma;
        public string Turma { get { return turma; } set { turma = value; } }

        public Pessoa()
        {

        }
    }
}
