using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    class Caixa
    {
        #region Atributos
        private string _Numero;
        public string Numero
        {
            get { return Numero; }
            set { _Numero = value.Replace(";", ""); }
        }
        private Empresa _Empresa;
        public Empresa Empresa
        {
            get { return Empresa; }
            set { _Empresa = value; }
        }

        #endregion Fim dos Atributos

        #region Métodos
        //Este método Cria o Arquivo de Base de Dados do Caixa
        private static void CriaBase(string BaseCaixa)
        {
            try
            {
                FileStream arquivo = File.Create(BaseCaixa);
                arquivo.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("O Arquivo da base de dados do Caixa nao Foi Criado!");
            }

        }
        
        public static void Inserir();

        //Este Metodo escreve os dados no aruivo de dados BaseCaixa.txt
        public static void Salvar(IList<Caixa> listaCaixa, string BaseCaixa)
        {
            if (!File.Exists(BaseCaixa))
                CriaBase(BaseCaixa);

            try
            {
                StreamWriter stream = new StreamWriter(BaseCaixa);

                foreach (Caixa cx in listaCaixa)
                {
                    stream.WriteLine
                        (
                        cx.Numero, cx.Empresa
                        );
                }
            }
            catch
            { Console.WriteLine("Base de Dados nao Encontrada"); }
        }

        public static void Editar();
        public static void Excluir();
        public static void Pesquisar();
        #endregion Fim dos Métodos

    }
}
