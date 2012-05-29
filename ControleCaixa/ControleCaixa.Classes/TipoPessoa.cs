using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    public class TipoPessoa : CLASSEPAI
    {
        #region Construtores

        #endregion Fim dos Métodos Construtores
        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return Nome; }
            set { _Nome = value; }
        }
        //Atributo Identificador ID

        #endregion Fim dos Atributos

        #region Métodos
        public static void Inserir() { }
        public static void Salvar() { }
        public static void Editar() { }
        public static void Excluir() { }
        public static void Pesquisar() { }
        #endregion Fim dos Métodos
    }
}
