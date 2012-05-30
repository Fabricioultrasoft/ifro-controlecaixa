using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCaixa.Classes;
using System.IO;
using System.Collections;



namespace ControleCaixa
{
    class Program
    {
        #region Atributos Da Classe Lancamento
        static List<Lancamento> listaLamcamentos;
        const string BaseDadosLancamento = @"C:\BaseDadosLancamento.txt";
        #endregion Fim dos Atributos de Lancamento

        #region Atributos da Classe Empresa
        static List<Empresa> listaEmpresa;
        const string BaseDadosEmpresa = @"C:\BaseDadosEmpresa.txt";
        #endregion


        #region Atributos da Classe TipoEndereço
        static List<TipoEndereco> listaTipoEndereco;
        const string BaseDadosTipoEndereco = @"C:\BaseDadosTipoEndereco.txt";
        #endregion 

        #region Atributos da Classe Endereço
        static List<Endereco> listaEndereco;
        const string BaseDadosEndereco = @"C:\BaseDadosEndereco.txt";

        #endregion

        //Executa os Metodos do programa
        static void Main(string[] args)
        {
           // ManipulaLancameto();
           // ManipulaTipoEndereco();
            ManipulaEdereco();
           
        }
        /***********************************************************************************************
         *                                             LANÇAMENTOS
         **********************************************************************************************/

        #region Método de Manipulação de Lançamentos
        public static void ManipulaLancameto()
        {
            // MovimentacaoItem.tipoMovimentacao vv = MovimentacaoItem.tipoMovimentacao.Credito;
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Lançamentos na base de Dados
            listaLamcamentos = Lancamento.CarregaLancamento(BaseDadosLancamento);
            #endregion Fim de Buscas de dados nos Lançamentos

            #region Mostra os Dados dos Lançamentos

            foreach (Lancamento lanc in listaLamcamentos)
            {
                Console.WriteLine("\n\n Lancamento " + lanc.ID);
                Console.WriteLine("\n Nome do Lancamento : " + lanc.Nome);
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");


            #region Criando os Objetos
            Lancamento Lanc = new Lancamento();
            Console.WriteLine("Digite o nome do Lancamento: ");
            Lanc.Nome = Console.ReadLine();
            Lancamento.Inserir(listaLamcamentos, Lanc);
            #endregion

            #region Mostra os objetos da Lista
            foreach (Lancamento lanc in listaLamcamentos)
            {
                Console.WriteLine("\n\n Lancamento " + lanc.ID);
                Console.WriteLine(" \n Nome {0}: ", lanc.Nome);
            }
            #endregion

            #region Método para salva no arquivo
            Lancamento.Salvar(listaLamcamentos, BaseDadosLancamento);
            Console.WriteLine("Lancamento Gravado Com Sucesso");
            #endregion
            Console.ReadKey();
        }
        #endregion
        /*************************************************************************************************
         *                                              EMPRESA
         * **********************************************************************************************/
        #region Método de Manipulação de Empresa

        public static void ManipulaEmpresa()
        {
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Empresas na base de Dados
            listaEmpresa = Empresa.CarregaEmpresa(BaseDadosEmpresa);
            #endregion Fim de Buscas de dados nas Empresas

            #region Mostra os Dados dos Lançamentos

            foreach (Empresa Empr in listaEmpresa)
            {
                Console.WriteLine("\n\n Empresa " + Empr.ID);
                Console.WriteLine("\n Nome : {0} " + "\nRazao Social : {1} " + "\nCNPJ : {2} " + "\nDataCriacao : {3} " + "\nEndereco : {4}" + "\nTelefone : {6} ",
                   Empr.Nome, Empr.RazaoSocial, Empr.CNPJ, Empr.DataCriacao, Empr.Endereco, Empr.Telefone);
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");


            #region Criando os Objetos
            Empresa Empres = new Empresa();
            Console.WriteLine("Digite o nome do Empresa: ");
            Empres.Nome = Console.ReadLine();
            Empresa.Inserir(listaEmpresa, Empres);
            #endregion

            #region Mostra os objetos da Lista
            foreach (Empresa empr in listaEmpresa)
            {
                Console.WriteLine("\n\n Empresa " + empr.ID);
                Console.WriteLine("\n Nome : {0} " + "\nRazao Social : {1} " + "\nCNPJ : {2} " + "\nDataCriacao : {3} " + "\nEndereco : {4}" + "\nTelefone : {6} ",
                   empr.Nome, empr.RazaoSocial, empr.CNPJ, empr.DataCriacao, empr.Endereco, empr.Telefone);
            }
            #endregion
            #region Método para salva no arquivo
            Empresa.Salvar(listaEmpresa, BaseDadosEmpresa);
            Console.WriteLine("Empresa Cadastrada Com Sucesso");
            #endregion
            Console.ReadKey();
        }
        #endregion

        /*************************************************************************************************
         *                                          TIPO ENDEREÇO
         * **********************************************************************************************/
        #region Método de Manipulaçãdo dos Tipos De Endereços

        public static void ManipulaTipoEndereco()
        {

            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Tipos de Endereços na base de Dados
            listaTipoEndereco = TipoEndereco.CarregaTipoEndereco(BaseDadosTipoEndereco);
            #endregion Fim de Buscas de dados nos Tipos de Endereços

            #region Mostra os Dados dos Lançamentos

            foreach (TipoEndereco TipEnd in listaTipoEndereco)
            {
                Console.WriteLine("\n\n Tipo de Endereco " + TipEnd.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1} ",
                   TipEnd.EnderecoTipo, TipEnd.DataCriacao);
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");


            #region Criando os Objetos
            TipoEndereco TipEnder = new TipoEndereco();
            Console.WriteLine("Digite o Tipo de Endereco: ");
            TipEnder.EnderecoTipo = Console.ReadLine();
            TipoEndereco.Inserir(listaTipoEndereco, TipEnder);
            #endregion

            #region Mostra os objetos da Lista
            foreach (TipoEndereco TipEnd in listaTipoEndereco)
            {
                Console.WriteLine("\n\n Tipo de Endereco " + TipEnd.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1} ",
                   TipEnd.EnderecoTipo,TipEnd.DataCriacao );
            }
            #endregion
            #region Método para salva no arquivo
            TipoEndereco.Salvar(listaTipoEndereco, BaseDadosTipoEndereco);
            Console.WriteLine("Tipo de Endereço Cadastrado Com Sucesso");
            #endregion
            Console.ReadKey();
        }
        #endregion Tipos de Endereços

        /*************************************************************************************************
         *                                          ENDEREÇO
         * **********************************************************************************************/
        #region Método de Manipulação de Endereços

        public static void ManipulaEdereco()
        {
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Endereços na base de Dados
            listaEndereco = Endereco.CarregaEndereco(BaseDadosEndereco);
            #endregion Fim de Buscas de dados nas Empresas

            #region Mostra os Dados dos Endereços

            foreach (Endereco End in listaEndereco)
            {
                Console.WriteLine("\n\n Edereco " + End.ID);
                Console.WriteLine("\n Logradouro : {0} " + "\nNumero : {1} " + "\nBairro : {2} " + "\nCidade : {3} " + "\nEstado : {4}" + "\nCEP : {6} " + "\nData de Criacao : {7} " + "\nTipo de Endereco : {8} ",
                   End.Logradouro, End.Numero, End.Bairro, End.Cidade, End.Estado, End.CEP, End.DataCriacao, End.TipoEndereco);
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");


            #region Criando os Objetos
            Endereco Ende = new Endereco();
            Console.WriteLine("Digite o Logradouro: ");
            Ende.Logradouro = Console.ReadLine();
            Console.WriteLine("Digite o Numero: ");
            Ende.Numero = Console.ReadLine();
            Console.WriteLine("Digite o Bairro: ");
            Ende.Bairro = Console.ReadLine();
            Console.WriteLine("Digite a UF: ");
            Ende.Estado = Console.ReadLine();
            Console.WriteLine("Dite o Nome da Cidade: ");
            Ende.Cidade = Console.ReadLine();
            Console.WriteLine("Digite o CEP: ");
            Ende.CEP = Console.ReadLine();
            Console.WriteLine("Carregando a Lista de Tipos de Endereços \n Digite o Código do tipo de Endereco que quer salvar:");
 

            listaTipoEndereco = TipoEndereco.CarregaTipoEndereco(BaseDadosTipoEndereco);

            string opcao = "";
            foreach (TipoEndereco TipEnd in listaTipoEndereco)
            {
                Console.WriteLine("\n\n Tipo de Endereco " + TipEnd.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1} ",
                   TipEnd.EnderecoTipo, TipEnd.DataCriacao);
                Console.WriteLine("Digite [S] para adicionar este Tipo [N] para nao : ");
                opcao = Console.ReadLine();
                if (opcao == "s")
                {
                    List<TipoEndereco> lista = new List<TipoEndereco>();
                    lista.Add(TipEnd);
                    Ende.TipoEndereco = lista;
                }
                else
                {
                    opcao = "";
                }
              
            }

            Endereco.Inserir(listaEndereco, Ende);
            #endregion

            #region Mostra os objetos da Lista
            foreach (Endereco End in listaEndereco)
            {
                Console.WriteLine("\n\n Endereco " + End.ID);
                Console.WriteLine("\n Logradouro : {0} " + "\nNumero : {1} " + "\nBairro : {2} " + "\nCidade : {3} " + "\nEstado : {4}" + "\nCEP : {6} " + "\nData de Criacao : {7} " + "\nTipo de Endereco : {6} ",
                   End.Logradouro, End.Numero, End.Bairro, End.Cidade, End.Estado, End.CEP, End.DataCriacao, End.TipoEndereco);
            }
            #endregion
            #region Método para salva no arquivo
            Endereco.Salvar(listaEndereco, BaseDadosEndereco);
            Console.WriteLine("Endereco Cadastrado Com Sucesso");
            #endregion
            Console.ReadKey();
        }
        #endregion


    }


}

