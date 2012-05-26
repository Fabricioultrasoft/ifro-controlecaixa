using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{
    //Classe Filha da Classe PessoaFisica
    class Funcionario : PessoaFisica
    {
        #region Atributos
        private string _Matricula;
        public string Matricula
        {
            get { return Matricula; }
            set { _Matricula = value; }
        }
        private string _Cargo;
        public string Cargo
        {
            get { return Cargo; }
            set { _Cargo = value; }
        }
        private DateTime _DataInicio;
        public DateTime DataInicio
        {
            get { return DataInicio; }
            set { _DataInicio = value; }
        }
        private DateTime _DataFim;
        public DateTime DataFim
        {
            get { return DataFim; }
            set { _DataFim = value; }
        }
        //Empresa do Funcionario
        private Empresa _empresa;
        public Empresa empresa
        {
            get { return empresa; }
            set { _empresa = value; }
        }
        #endregion Fim dos Atributos
    }
}
