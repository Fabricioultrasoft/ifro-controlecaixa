using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
   public class TipoEndereco : CLASSEPAI
    {

        #region Métodos Construtores
        public TipoEndereco() { }

        public TipoEndereco( string id, string enderecoTipo, string dataCriacao )
        {
            this._ID = Convert.ToInt32(id);
            this.EnderecoTipo = enderecoTipo;
            this.DataCriacao = Convert.ToDateTime(dataCriacao);
        } 
        #endregion Fim dos Construtores

        #region Atributos
        private string _EnderecoTipo;
        public string EnderecoTipo
        {
            get { return _EnderecoTipo; }
            set { _EnderecoTipo = value; }
        }


        #endregion Fim dos Atributos

        #region Métodos

        public static void Inserir(List<TipoEndereco> lista, TipoEndereco TipEnd)
        {
            TipEnd._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(TipEnd);
        }
        public static void Inserir(List<TipoEndereco> lista, TipoEndereco TipEnd, int ID)
        {
            TipEnd._ID = ID;
            lista.Add(TipEnd);
        }
        public static void Salvar(List<TipoEndereco> listaTipoEndereco, string Base)
        {

            if (!File.Exists(Base))
                CriaBase(Base);

            try
            {
                StreamWriter stream = new StreamWriter(Base);

                foreach (TipoEndereco TipEnd in listaTipoEndereco)
                {

                    stream.WriteLine(TipEnd.ID + ";" + TipEnd.EnderecoTipo + ";" + Convert.ToString(TipEnd.DataCriacao));

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
        public static List<TipoEndereco> CarregaTipoEndereco(string Base)
        {
            if (!File.Exists(Base))
                CriaBase(Base);

            List<TipoEndereco> lista = new List<TipoEndereco>();

            try
            {
                StreamReader stream = new StreamReader(Base);

                string linha = null;
                while ((linha = stream.ReadLine()) != null)
                {
                    string[] atrib = linha.Split(';');
                    TipoEndereco TipEnd = new TipoEndereco(atrib[0], atrib[1], atrib[2]);
                    TipoEndereco.Inserir(lista, TipEnd, Convert.ToInt32(atrib[0]));
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
