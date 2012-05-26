using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
   public class TipoEndereco : CLASSEPAI
    {

        #region Atributos
        private string _EnderecoTipo;
        public string EnderecoTipo
        {
            get { return EnderecoTipo; }
            set { _EnderecoTipo = value; }
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
