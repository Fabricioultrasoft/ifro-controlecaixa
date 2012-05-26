using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
   public class MovimentacaoItem : CLASSEPAI
    {
        #region Atributos
        private int _DocumentoNumero;
        public int DocumentoNumero
        {
            get { return DocumentoNumero; }
            set { _DocumentoNumero = value; }
        }
        private string _DescricaoComplementar;
        public string DescricaoComplementar
        {
            get { return DescricaoComplementar; }
            set { _DescricaoComplementar = value; }
        }
        //atributo tipomovimentacao [Entrada/Saida]
        //private Enum _tipoMovimentacao;
        public enum tipoMovimentacao {Credito,Debito }
 

        private Lancamento _Lancamento;
        public Lancamento Lancamento
        {
            get { return Lancamento; }
            set { _Lancamento = value; }
        }
        private Pessoa _Pessoa;
        public Pessoa Pessoa
        {
            get { return Pessoa; }
            set { _Pessoa = value; }
        }
        private ValorMovimentacao _ValorMovimentacao;
        public ValorMovimentacao ValorMovimentacao
        {
            get { return ValorMovimentacao; }
            set { _ValorMovimentacao = value; }
        }


        #endregion Fim dos atributos

        #region Métodos 

        #endregion Fim dos Metodos
    }
}
