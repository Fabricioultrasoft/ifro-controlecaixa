using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{
    public class Endereco : CLASSEPAI
    {
        #region Metodos Construtores
        public Endereco() { }
        public Endereco(string id, string logradouro, string numero, string bairro,
                         string cidade, string estado, string cep, string dataCriacao)
        {
            this._ID = Convert.ToInt32(id);
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.CEP = cep;
            this.DataCriacao = Convert.ToDateTime(dataCriacao);

        }
        //  public Endereco (List<TipoEndereco> TpEndereco)
        // {
        //     this.TipoEndereco = TpEndereco;
        //   }


        #endregion Fim dos Métodos Construtores


        #region Atributos
        private string _Logradouro;
        public string Logradouro
        {
            get { return _Logradouro; }
            set { _Logradouro = value; }
        }
        private string _Numero;
        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }
        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }
        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _CEP;
        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        //Atributo do tipo Lista de Tipos de endereços [Ex. entrega, casa de campo]
        private IList<TipoEndereco> _TipoEndereco;
        public IList<TipoEndereco> TipoEndereco
        {
            get { return _TipoEndereco; }
            set { _TipoEndereco = value; }
        }

        #endregion Fim dos Atributos

        #region Métodos

        public static void Inserir(List<Endereco> lista, Endereco Ender)
        {
            Ender._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(Ender);
        }
        public static void Inserir(List<Endereco> lista, Endereco End, int ID)
        {
            End._ID = ID;
            lista.Add(End);
        }
        public static void Salvar(List<Endereco> listaEndereco, string Base, string baseTipo)
        {

            if (!File.Exists(Base))
                CriaBase(Base);

            try
            {
                StreamWriter stream = new StreamWriter(Base);
                StreamWriter stream2 = new StreamWriter(baseTipo);
                foreach (Endereco End in listaEndereco)
                {

                    stream.WriteLine(End.ID + ";" + End.Logradouro + ";" + End.Numero + ";" + End.Bairro + ";" + End.Cidade + ";" + End.Estado + ";" + End.CEP + ";" + Convert.ToString(End.DataCriacao));

                    foreach (TipoEndereco TipEnd in End.TipoEndereco)
                    {

                        stream2.WriteLine(TipEnd.ID + ";" + TipEnd.EnderecoTipo + ";" + Convert.ToString(TipEnd.DataCriacao) + ";" + End.ID);
                    }
                }
                stream.Close();
                stream2.Close();
            }
            catch
            {
                Console.Write("Arquivo da Base de Dados não Encontrado!");
            }

        }
        #endregion Fim Métodos

        #region Métodos Extras
        public static List<Endereco> CarregaEndereco(string Base, string baseTipo, List<TipoEndereco> listaTipoEndereco)
        {
            if (!File.Exists(Base))
                CriaBase(Base);

            List<Endereco> lista = new List<Endereco>();

            try
            {
                StreamReader stream = new StreamReader(Base);

                //lê o arquivo do endereço
                string linha = null;
                while ((linha = stream.ReadLine()) != null)
                {
                    string[] atrib = linha.Split(';');
                    Endereco Ender = new Endereco(atrib[0], atrib[1], atrib[2], atrib[3], atrib[4], atrib[5], atrib[6], atrib[7]);

                    //lê o arquivo que armazena o codigo do Endereço e o Valores do tipo endereço [arquivo de relacionamento entre as classes Endereco e TipoEndereco]
                    StreamReader stream2 = new StreamReader(baseTipo);

                    string linhatipoEnder = null;
                    while ((linhatipoEnder = stream2.ReadLine()) != null)
                    {
                        string[] atribt = linhatipoEnder.Split(';');
                        if (atribt[3] == Ender.ID.ToString())
                        {
                            if (Ender.TipoEndereco == null)
                                Ender.TipoEndereco = new List<TipoEndereco>();
                            Ender.TipoEndereco.Add(listaTipoEndereco.SingleOrDefault(p => p.ID.ToString() == atribt[0]));
                        }
                    }
                    stream2.Close();
                    Endereco.Inserir(lista, Ender, Convert.ToInt32(atrib[0]));
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
