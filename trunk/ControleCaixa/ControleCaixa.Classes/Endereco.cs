using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    public class Endereco : CLASSEPAI
    {
        #region Metodos Construtores

        #endregion Fim dos Métodos Construtores


        #region Atributos
        private string _Logradouro;
        public string Logradouro
        {
            get { return Logradouro; }
            set { _Logradouro = value; }
        }
        private string _Numero;
        public string Numero
        {
            get { return Numero; }
            set { _Numero = value; }
        }
        private string _Bairro;
        public string Bairro
        {
            get { return Bairro; }
            set { _Bairro = value; }
        }
        private string _Cidade;
        public string Cidade
        {
            get { return Cidade; }
            set { _Cidade = value; }
        }
        private string _Estado;
        public string Estado
        {
            get { return Estado; }
            set { _Estado = value; }
        }
        private string _CEP;
        public string CEP
        {
            get { return CEP; }
            set { _CEP = value; }
        }
        //Atributo Identificador ID
        private int _ID;
        public int ID
        {
            get { return _ID; }
        }
        //Atributo do tipo Lista de Tipos de endereços [Ex. entrega, casa de campo]
        private IList<TipoEndereco> _TipoEndereco;
        public IList<TipoEndereco> TipoEndereco
        {
            get { return TipoEndereco; }
            set { _TipoEndereco = value; }
        }

        #endregion Fim dos Atributos

        #region Métodos

        #endregion Fim dos Métodos
    }
}
