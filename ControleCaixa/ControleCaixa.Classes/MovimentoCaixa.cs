using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
   public class MovimentoCaixa
    {
        #region Atributos
        private DateTime _Data;
        public DateTime Data
        {
            get { return Data; }
            set { _Data = value; }
        }
        private double _SaldoAtual;
        public double SaldoAtual
        {
            get { return SaldoAtual; }
            set { _SaldoAtual = value; }
        }
        private double _SaldoAnterior;
        public double SaldoAnterior
        {
            get { return SaldoAnterior; }
            set { _SaldoAnterior = value; }
        }
        private Caixa _Caixa;
        public Caixa Caixa
        {
            get { return Caixa; }
            set { _Caixa = value; }
        }
        private IList<MovimentacaoItem> _MovimetacaoItem;
        public IList<MovimentacaoItem> MovimentacaoItem
        {
            get { return MovimentacaoItem; }
            set { _MovimetacaoItem = value; }
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
