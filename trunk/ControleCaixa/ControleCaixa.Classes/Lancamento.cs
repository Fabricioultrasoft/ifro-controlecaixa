using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    public class Lancamento : CLASSEPAI
    {
        #region Construtores
        public Lancamento(string nome) 
        {
            this.Nome = nome;

            //o id não é inserido aqui porque o usuario não deve modificá-lo
        }
        #endregion Fim dos Construtores

        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        //Atributos de identificação 'ID'

        #endregion Fim dos Atributos

        #region Métodos
        //metodo para adicionar a identificação [ID] aos dados
        public static void Inserir(List<Lancamento> lista, Lancamento Lanc)
        {
            Lanc._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(Lanc);
        }

        public static void Inserir(List<Lancamento> lista, Lancamento Lanc, int ID)
        {
            Lanc._ID = ID;
            lista.Add(Lanc);
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

        public static void Inserir() { }

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

        public static void Editar() { }
        public static void Excluir() { }
        public static void Pesquisar() { }
        #endregion Fim dos Métodos
    }
}
