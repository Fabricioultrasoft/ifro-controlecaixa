using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleCaixa.Classes;
using System.IO;



namespace ControleCaixa
{
    class Program
    {
        #region Atributos Da Classe Lancamento
        static List<Lancamento> listaLamcamentos;
        const string BaseDadosLancamento = @"C:\Users\Tiago\Documents\Escola\Desnvolvimento de Sistemas\Projeto_Final_Da_Materia\BaseDadosLancamento.txt";
        #endregion Fim dos Atributos de Lancamento

        #region Atributos da Classe Empresa
        static List<Empresa> listaEmpresa;
        const string BaseDadosEmpresa = @"C:\Users\Tiago\Documents\Escola\Desnvolvimento de Sistemas\Projeto_Final_Da_Materia\BaseDadosEmpresa.txt";
        #endregion

        #region Atributos da Classe TipoEndereço
        static List<TipoEndereco> listaTipoEndereco;
        const string BaseDadosTipoEndereco = @"C:\Users\Tiago\Documents\Escola\Desnvolvimento de Sistemas\Projeto_Final_Da_Materia\BaseDadosTipoEndereco.txt";
        #endregion 

        //Executa os Metodos do programa
        static void Main(string[] args)
        {
           // ManipulaLancameto();
            ManipulaTipoEndereco();
           
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

        /***********************************************************************************************************
         *                                          TIPO ENDEREÇO
         * ********************************************************************************************************/
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



    }


}

