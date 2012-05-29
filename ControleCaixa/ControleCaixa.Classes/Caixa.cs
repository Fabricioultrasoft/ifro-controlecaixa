using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    public class Caixa : CLASSEPAI
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
        //metodo para adicionar a identificação [ID] aos dados
        public static void Inserir(List<Caixa> lista, Caixa Caix)
        {
            Caix._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(Caix);
        }

        public static void Inserir(List<Caixa> lista, Caixa Caix, int ID)
        {
            Caix._ID = ID;
            lista.Add(Caix);
        }

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
