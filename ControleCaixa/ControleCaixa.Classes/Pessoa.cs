﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{   
    //Classe Abstrata Pessoa [Classe PAI]
    public class Pessoa : CLASSEPAI
    {
       // #region Construtor


//        #endregion Fim do Construtor

        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
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

        #endregion Fim dos Métodos
    }
}
