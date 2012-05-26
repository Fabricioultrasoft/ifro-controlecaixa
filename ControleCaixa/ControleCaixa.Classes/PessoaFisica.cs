using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    //Classe Filha da Classe Pessoa e...
    //...Classe Pai da da Classe Funcionario
    public abstract class PessoaFisica : Pessoa
    {
        #region Atributos
        private string _CPF;
        public string CPF 
        {
            get { return CPF; }
            set { _CPF = value; }
        }
        private DateTime _DataNascimento;
        public DateTime DataNascimento
        {
            get { return DataNascimento; }
            set { _DataNascimento = value; }
        }

        #endregion Fim dos Atributos

        #region Métodos
        public static void Inserir();
        public static void Salvar();
        public static void Editar();
        public static void Excluir();
        public static void Pesquisar();
        #endregion Fim dos Métodos

    }
}
