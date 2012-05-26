using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    //Classe Filha da Classe PessoaJuridica
    class Empresa : PessoaJuridica
    {
        #region Atributos
        private IList<Caixa> _Caixa;
        public IList<Caixa> Caixa
        {
            get { return Caixa; }
            set { _Caixa = value; }
        }
        private string _Nome;
        public string Nome
        {
            get { return Nome; }
            set { _Nome = value.Replace(";", ""); }
        }
        #endregion Fim dos Atributos
    }
}
