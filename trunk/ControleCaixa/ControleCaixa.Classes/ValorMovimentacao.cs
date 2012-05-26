using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
   public class ValorMovimentacao : CLASSEPAI
    {
        #region Atributos
        private double _Valor;
        public double Valor 
        {
            get { return Valor; }
            set { _Valor = value; }
        }
        private IList<FormaPagamento> _FormaPagamento;
        public IList<FormaPagamento> FormaPagamento
        {
            get { return FormaPagamento; }
            set { _FormaPagamento = value; }
        }
        #endregion Fim dos Atributos


        #region Métodos
        public static void Inserir();
        public static void Salvar();
        public static void Editar();
        public static void Excluir();
        public static void Pesquisar();
        #endregion Fim dos Metodos
    }
}
