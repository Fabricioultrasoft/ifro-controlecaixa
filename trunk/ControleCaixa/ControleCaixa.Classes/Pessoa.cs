using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControleCaixa.Classes
{   
    //Classe Abstrata Pessoa [Classe PAI]
    public class Pessoa : CLASSEPAI
    {
       #region Construtor
        public Pessoa() { }
        public Pessoa(string id, string nome, string telefone, DateTime dataCriacao)
        {
            this._ID = Convert.ToInt32(id);
            this.Nome = nome;
            this.Telefone = telefone;
            this.DataCriacao = dataCriacao;
        }

    #endregion Fim do Construtor

        #region Atributos
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }
        
        //Atributo do tipo lista de TipoPessoa
        private IList<TipoPessoa> _TipoPessoa;
        public IList<TipoPessoa> TipoPessoa
        {
            get {return _TipoPessoa; }
            set { _TipoPessoa = value; }
        }
        //Atributo do tipo lista de Endereços [Endereco]
        private IList<Endereco> _Endereco;
        public IList<Endereco> Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }
        #endregion Fim dos Atributos

        #region Métodos

        public static void Inserir(List<Pessoa> lista, Pessoa Pess)
        {
            Pess._ID = lista.Count == 0 ? 1 : lista.Max(p => p.ID) + 1;
            lista.Add(Pess);
        }
        public static void Inserir(List<Pessoa> lista, Pessoa Pess, int ID)
        {
            Pess._ID = ID;
            lista.Add(Pess);
        }
        public static void Salvar(List<Pessoa> listaPessoa, string Base, string BasePessoa_Endereco, string BasePessoa_TipoPessoa)
        {

            if (!File.Exists(Base))
                CriaBase(Base);

            try
            {
                StreamWriter stream = new StreamWriter(Base);
                StreamWriter stream2 = new StreamWriter(BasePessoa_Endereco);
                StreamWriter stream3 = new StreamWriter(BasePessoa_TipoPessoa);
                foreach (Pessoa Pess in listaPessoa)
                {
                    //grava os dados da pessoa
                    stream.WriteLine(Pess.ID + ";" + Pess.Nome +";" + Pess.Telefone + ";" + Convert.ToString(Pess.DataCriacao));

                    foreach (Endereco End in Pess.Endereco)
                    {
                        //grava os dados do endereço da pessoa
                        stream2.WriteLine(End.ID + ";" + End.Logradouro + ";" + End.Numero + ";" + End.Bairro + ";" + End.Cidade +  ";" + Pess.ID);
                    }

                    foreach (TipoPessoa TipPess in Pess.TipoPessoa)
                    {
                        //grava os dados TipoPessoa da Pessoa
                        stream3.WriteLine(TipPess.ID + ";" + TipPess.Nome + ";" + Pess.ID);
                    }

                }
                stream.Close();
                stream2.Close();
                stream3.Close();
            }
            catch
            {
                Console.Write("Arquivo da Base de Dados não Encontrado!");
            }

        }
       

        
        public static List<Pessoa> Carrega(string Base, string BasePessoa_TipoPessoa, string BasePessoa_Endereco, List<Endereco> listaEndereco, List<TipoPessoa> listaTipoPessoa)
        {
            if (!File.Exists(Base))
                CriaBase(Base);
            /*
            if (!File.Exists(BasePessoa_TipoPessoa))
                CriaBase(BasePessoa_TipoPessoa);

            if (!File.Exists(BasePessoa_Endereco))
                CriaBase(BasePessoa_Endereco);
            */
            List<Pessoa> lista = new List<Pessoa>();

            try
            {
                StreamReader stream = new StreamReader(Base);
                StreamReader stream2 = new StreamReader(BasePessoa_TipoPessoa);
                StreamReader stream3 = new StreamReader(BasePessoa_Endereco);
                //Carega os dados da Pessoa
                string linhaPessoa = null;
                while ((linhaPessoa = stream.ReadLine()) != null)
                {
                    string[] atribPessoa = linhaPessoa.Split(';');
                    Pessoa Pess = new Pessoa(atribPessoa[0], atribPessoa[1], atribPessoa[2], Convert.ToDateTime(atribPessoa[3]));

                    //Carega os dados do Endereço da Pessoa
                    string linhaEndereco = null;
                    while ((linhaEndereco = stream3.ReadLine()) != null)
                    {
                        string[] atribEndereco = linhaEndereco.Split(';');
                        if (atribEndereco[5] == Pess.ID.ToString())
                        {
                            if (Pess.Endereco == null)
                                Pess.Endereco = new List<Endereco>();
                            Pess.Endereco.Add(listaEndereco.SingleOrDefault(p => p.ID.ToString() == atribEndereco[0]));
                        }
                        
                        
                        
                        //Carega os dados de TipoPessoa da Pessoa
                        string linhaTipoPessoa = null;
                        while ((linhaTipoPessoa = stream2.ReadLine()) != null)
                        {
                            string[] atribTipEssoa = linhaTipoPessoa.Split(';');
                            if (atribTipEssoa[2] == Pess.ID.ToString())
                            {
                                if (Pess.TipoPessoa == null)
                                    Pess.TipoPessoa = new List<TipoPessoa>();
                                Pess.TipoPessoa.Add(listaTipoPessoa.SingleOrDefault(p => p.ID.ToString() == atribTipEssoa[0]));
                            }
                           
                        }
                        stream2.Close();
                        stream3.Close();           
                        Pessoa.Inserir(lista, Pess, Convert.ToInt32(atribPessoa[0]));
                        stream.Close();
                       
                    }
                  
                }
                
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

        #endregion Fim Métodos

    }
}
