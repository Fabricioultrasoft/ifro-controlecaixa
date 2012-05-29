using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    //Classe Filha de Pessoa e...
    // ....Classe Pai da Classe Empresa
   public abstract class PessoaJuridica : Pessoa
    {
        #region Atributos
        private string _CNPJ;
        public string CNPJ
        {
            get { return CNPJ; }
            set { _CNPJ = value; }
        }
        private string _RazaoSocial;
        public string RazaoSocial
        {
            get { return RazaoSocial; }
            set { _RazaoSocial = value; }
        }
        #endregion Fim dos Atributos
        #region Métodos
        public static void Inserir() { }
        public static void Salvar() { }
        public static void Editar() { }
        public static void Excluir() { }
        public static void Pesquisar() { }
        #endregion Fim dos Metodos
    }
}
