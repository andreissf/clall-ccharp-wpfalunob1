using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaManager.Utils
{
    class ManagerPessoa
    {

        private Pessoa pessoa;
        private List<Pessoa> pessoas;

        public ManagerPessoa()
        {
            pessoas = new List<Pessoa>();
        }

        public void Add(string nome, int idade, string turma)
        {
            pessoa = new Pessoa();
            pessoa.Name = nome;
            pessoa.Idade = idade;
            pessoa.Turma = turma;

            pessoas.Add(pessoa);
        }

        public void RemovePessoa(int index)
        {
            pessoas.RemoveAt(index);
        }

        public void Update(int index, string nome, int idade, string turma)
        {
            pessoa = pessoas.ElementAt(index);
            pessoa.Name = nome;
            pessoa.Idade = idade;
            pessoa.Turma = turma;
        }

        public Pessoa[] GetList()
        {
            var tmp = new Pessoa[pessoas.Count];
            pessoas.CopyTo(tmp);
            return tmp;
        }

    }
}
