using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    //Classe Filha da Classe PessoaJuridica
    public class Empresa : PessoaJuridica
    {
        #region Métodos Construtores
        public Empresa() { }
        public Empresa( string id, string nome, string razaoSocial, string CNPJ, string dataCriacao, string endereco, string telefone ) { } 
        #endregion Fim dos Construtores

        #region Atributos
       
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        #endregion Fim dos Atributos

        #region Métodos

        public static void Inserir(List<Empresa> lista, Empresa Empr)
        {
            Empr._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(Empr);
        }
        public static void Inserir(List<Empresa> lista, Empresa Empr, int ID)
        {
            Empr._ID = ID;
            lista.Add(Empr);
        }
        public static void Salvar(List<Empresa> listaEmpresa, string Base)
        {

            if (!File.Exists(Base))
                CriaBase(Base);

            try
            {
                StreamWriter stream = new StreamWriter(Base);

                foreach (Empresa Empr in listaEmpresa)
                {

                    stream.WriteLine(Empr.ID + ";" + Empr.Nome + ";" + Empr.RazaoSocial +";" + Empr.CNPJ + ";" + Convert.ToString(Empr.DataCriacao) + ";" + Convert.ToString(Empr.Endereco) + ";" + Empr.Telefone);

                }
                stream.Close();
            }
            catch
            {
                Console.Write("Arquivo da Base de Dados não Encontrado!");
            }

        }
        #endregion Fim Métodos

        #region Métodos Extras
        public static List<Empresa> Carrega(string Base)
        {
            if (!File.Exists(Base))
                CriaBase(Base);

            List<Empresa> lista = new List<Empresa>();

            try
            {
                StreamReader stream = new StreamReader(Base);

                string linha = null;
                while ((linha = stream.ReadLine()) != null)
                {
                    string[] atrib = linha.Split(';');
                    Empresa Empr = new Empresa(atrib[0], atrib[1], atrib[2], atrib[3], atrib[4], atrib[5], atrib[6]);
                    Empresa.Inserir(lista, Empr, Convert.ToInt32(atrib[0]));
                }
                stream.Close();
            }
            catch
            {
                Console.Write("Arquivo da Base de Dados não Encontrado!");
            }
            return lista;
        }
        public static void CriaBase(string Base)
        {
            try
            {
                FileStream fs = File.Create(Base);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Arquivo da Base de Dados não Criado!");
            }


        }

        #endregion Fim dos metodos

    }
}
