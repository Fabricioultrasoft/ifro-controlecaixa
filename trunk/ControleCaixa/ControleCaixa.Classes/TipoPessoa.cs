using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    public class TipoPessoa : CLASSEPAI
    {
        #region Construtores
        public TipoPessoa() { }
        public TipoPessoa(string id, string nome, DateTime dataCriacao)
        {
            this._ID = Convert.ToInt32(id);
            this.Nome = nome;
            this.DataCriacao = dataCriacao;
        }

        #endregion Fim dos Métodos Construtores
        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        //Atributo Identificador ID

        #endregion Fim dos Atributos

        #region Métodos

        public static void Inserir(List<TipoPessoa> lista, TipoPessoa TipPes)
        {
            TipPes._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(TipPes);
        }
        public static void Inserir(List<TipoPessoa> lista, TipoPessoa TipPes, int ID)
        {
            TipPes._ID = ID;
            lista.Add(TipPes);
        }
        public static void Salvar(List<TipoPessoa> listaTipoPessoa, string Base)
        {

            if (!File.Exists(Base))
                CriaBase(Base);

            try
            {
                StreamWriter stream = new StreamWriter(Base);

                foreach (TipoPessoa TipPes in listaTipoPessoa)
                {

                    stream.WriteLine(TipPes.ID + ";" + TipPes.Nome + ";" + Convert.ToString(TipPes.DataCriacao));

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
        public static List<TipoPessoa> Carrega(string Base)
        {
            if (!File.Exists(Base))
                CriaBase(Base);

            List<TipoPessoa> lista = new List<TipoPessoa>();

            try
            {
                StreamReader stream = new StreamReader(Base);

                string linha = null;
                while ((linha = stream.ReadLine()) != null)
                {
                    string[] atrib = linha.Split(';');
                    TipoPessoa TipPes = new TipoPessoa(atrib[0], atrib[1], Convert.ToDateTime(atrib[2]));
                    TipoPessoa.Inserir(lista, TipPes, Convert.ToInt32(atrib[0]));
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
        #endregion

        }
    }
}
