using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{   
    //Classe Abstrata Pessoa [Classe PAI]
    public abstract class Pessoa : CLASSEPAI
    {
        #region Construtor
        public Pessoa(string nome, string telefone, IList<TipoPessoa> tipoPessoa ,IList<Endereco> endereco)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.TipoPessoa = tipoPessoa;
            this.Endereco = endereco;
        }

        #endregion Fim do Construtor

        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return Nome; }
            set { _Nome = value; }
        }

        private string _Telfone;
        public string Telefone
        {
            get { return Telefone; }
            set { _Telfone = value; }
        }
        


        //Atributo do tipo lista de TipoPessoa
        private IList<TipoPessoa> _TipoPessoa;
        public IList<TipoPessoa> TipoPessoa
        {
            get {return TipoPessoa; }
            set { _TipoPessoa = value; }
        }
        //Atributo do tipo lista de Endereços [Endereco]
        private IList<Endereco> _Endereco;
        public IList<Endereco> Endereco
        {
            get { return Endereco; }
            set { _Endereco = value; }
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
