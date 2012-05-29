using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
   public class FormaPagamento : CLASSEPAI
    {
        #region Atributos
        private string _Descricao;
        public string Descricao
        {
            get { return Descricao; }
            set { _Descricao = value; }
        }
        #endregion Fim dos Atributos
        public static void Inserir() { }
        public static void Salvar() { }
        public static void Editar() { }
        public static void Excluir() { }
        public static void Pesquisar() { }
        #region Métodos


        #endregion Fim dos Métodos
    }
}
