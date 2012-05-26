using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    public class Lancamento
    {
        #region Construtores
        public Lancamento(string nome) 
        {
            this.Nome = nome;

            //o id não é inserido aqui porque o usuario não deve modificá-lo
        }
        #endregion Fim dos Construtores

        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        //Atributos de identificação 'ID'

        #endregion Fim dos Atributos

        #region Metodos
        public static void Inserir();
        public static void Salvar();
        public static void Editar();
        public static void Excluir();
        public static void Pesquisar();
        public static void CarrgarLancameto();

        #endregion Fim dos Métodos

    }
}
