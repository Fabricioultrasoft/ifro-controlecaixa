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
        const string BaseEndereco_Tipo = @"C:\BaseDadosEndereco_Tipo.txt";
        
        #endregion


        #region Atributos da Classe TipoPessoa
        static List<TipoPessoa> listaTipoPessoa;
        const string BaseDadosTipoPessoa = @"C:\BaseDadosTipoPessoa.txt";
        #endregion fim dos atributos do metodo TipoEndereco

        #region Atributos da Classe Pessoa
        static List<Pessoa> listaPessoa;
        const string BaseDadosPessoa = @"C:\BaseDadosPessoa.txt";
        const string BasePessoa_Endereco = @"C:\BasePessoa_Endereco.txt";
        const string BasePessoa_TipoPessoa = @"C:\BasePessoa_TipoPessoa.txt";
        #endregion Fim dos Atributos da Classe Pessoa

        //Executa os Metodos do programa
        static void Main(string[] args)
        {
          // ManipulaLancameto(); // funcionando
         //  ManipulaTipoEndereco(); // funcionando
         //  ManipulaEdereco(); //Funcionando
         //  ManipulaTipoPessoa(); //Funcionando


            ManipulaPessoa(); // Esta escrevendo nos arquivos de pessoa e os de relacionametos, porém, esta apresentado erros na hora de ler

        }


        /*************************************************************************************************
            *                                      TIPOPESSOA
        * **********************************************************************************************/

        #region Método de Manitupalção de TipoPessoa
        public static void ManipulaTipoPessoa()
        {
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de TipoPessoa na base de Dados
            listaTipoPessoa = TipoPessoa.Carrega(BaseDadosTipoPessoa);
            #endregion Fim de Buscas de dados nos TipoPessoa

            #region Mostra os Dados dos Lançamentos

            foreach (TipoPessoa TipPes in listaTipoPessoa)
            {
                Console.WriteLine("\n\n TipoPessoa " + TipPes.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1} ",
                   TipPes.Nome, TipPes.DataCriacao);
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");


            #region Criando os Objetos
            TipoPessoa TipoPes = new TipoPessoa();
            Console.WriteLine("Digite o nome da Pessoa: ");
            TipoPes.Nome = Console.ReadLine();
            TipoPessoa.Inserir(listaTipoPessoa, TipoPes);
            #endregion

            #region Mostra os objetos da Lista
            foreach (TipoPessoa TipPes in listaTipoPessoa)
            {
                Console.WriteLine("\n\n TipoPessoa " + TipPes.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1}",
                   TipPes.Nome, TipPes.DataCriacao);
            }
            #endregion
            #region Método para salva no arquivo
            TipoPessoa.Salvar(listaTipoPessoa, BaseDadosTipoPessoa);
            Console.WriteLine("Tipo de Pessoa Cadastrada Com Sucesso");
            #endregion
            Console.ReadKey();
        }

        #endregion Fim dos metodos do TipoPessoa

        /***********************************************************************************************
         *                                             LANÇAMENTOS
         **********************************************************************************************/
        #region Método de Manipulação de Lançamentos
        public static void ManipulaLancameto()
        {
            // MovimentacaoItem.tipoMovimentacao vv = MovimentacaoItem.tipoMovimentacao.Credito;
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Lançamentos na base de Dados
            listaLamcamentos = Lancamento.Carrega(BaseDadosLancamento);
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
            listaEmpresa = Empresa.Carrega(BaseDadosEmpresa);
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
            listaTipoEndereco = TipoEndereco.Carrega(BaseDadosTipoEndereco);
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
            //adciono a lista os valores do arquivo [BaseDadosTipoEndereco] que contem cadastrado todos os Tipos de Endereços Disponiveis
            listaTipoEndereco = TipoEndereco.Carrega(BaseDadosTipoEndereco);
            //-------------------------------
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Endereços na base de Dados
            //Adiociona a variavel listaEndereco os valores da base de dados de endereço e base de tipoendereço
            listaEndereco = Endereco.Carrega(BaseDadosEndereco,BaseEndereco_Tipo, listaTipoEndereco);
            #endregion Fim de Buscas de dados nas Empresas

            #region Mostra os Dados dos Endereços
            //Escreve na tela os valores da lista "listaEndereço";
            foreach (Endereco End in listaEndereco)
            {   
                //mostra os valores do arquivo BaseDadosEndereco
                Console.WriteLine("\n\n Edereco " + End.ID);
                Console.WriteLine("\n Logradouro : {0} " + "\nNumero : {1} " + "\nBairro : {2} " + "\nCidade : {3} " + "\nEstado : {4}" + "\nCEP : {5} " + "\nData de Criacao : {6} ",
                   End.Logradouro, End.Numero, End.Bairro, End.Cidade, End.Estado, End.CEP, End.DataCriacao, End.TipoEndereco);
                //Mostra os dados do arquivo BaseEndereco_Tipo [Este arquivo armazena os realcionamentos entre Endereço e TipoEndereco (muitos para muitos)]
                foreach (TipoEndereco x in End.TipoEndereco)
                {
                    Console.WriteLine(x.ID + " , " + x.EnderecoTipo + " , " + x.DataCriacao);
                }
                               
            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");
            //interage com o usuario para inserir um novo endereço

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
           
            Console.WriteLine("Adicionar um Tipo de Endereço para o Endereço");

            //crio uma variavel string vazia
            string opcao = "";
            //crio uma lista [lista] do tipo [TipoEndereco]
            List<TipoEndereco> lista = new List<TipoEndereco>();
            foreach (TipoEndereco TipEnd in listaTipoEndereco)
            {
                //mostra item por item para o usuario escolher
                Console.WriteLine("\n\n Tipo de Endereco " + TipEnd.ID);
                Console.WriteLine("\n Nome : {0} " + "\nDataCriacao : {1} ",
                   TipEnd.EnderecoTipo, TipEnd.DataCriacao);
                //interege com o usuario. se opção for igual a [S] adiciona valor ao endereço, senão continua...
                Console.WriteLine("Digite [S] para adicionar este Tipo [N] para nao : ");
                opcao = Console.ReadLine();
                if (opcao == "s")
                {                    
                    //Adiciona os items na lista [lista]
                    lista.Add(TipEnd);
                    //seto o [Ende.TipoEndereco] com toos os itens da lista [lista]
                    Ende.TipoEndereco = lista;
                }
                else
                {
                    opcao = "";
                }
              
            }
            //Ensiro os Valores
            Endereco.Inserir(listaEndereco, Ende);
            #endregion

            #region Mostra os objetos da Lista
            foreach (Endereco End in listaEndereco)
            {
                //mostra os itens do Endereço
                Console.WriteLine("\n\n Endereco " + End.ID);
                Console.WriteLine("\n Logradouro : {0} " + "\nNumero : {1} " + "\nBairro : {2} " + "\nCidade : {3} " + "\nEstado : {4}" + "\nCEP : {5} " + "\nData de Criacao : {6} " ,
                   End.Logradouro, End.Numero, End.Bairro, End.Cidade, End.Estado, End.CEP, End.DataCriacao);
                //mostra os itens do TipoEndereco
                foreach (TipoEndereco TipEnd in End.TipoEndereco)
                {
                    Console.WriteLine(TipEnd.ID + ";" + TipEnd.EnderecoTipo + ";" + Convert.ToString(TipEnd.DataCriacao) + ";" + End.ID);
                }
            }
            #endregion
            #region Método para salva no arquivo
            //Salva os Dados nos Arquivos [BaseDadosEndereco] e [BaseEndereco_Tipo]
            Endereco.Salvar(listaEndereco, BaseDadosEndereco, BaseEndereco_Tipo);
            Console.WriteLine("Endereco Cadastrado Com Sucesso");
            #endregion
            Console.ReadKey();
        }
        #endregion Fim do Manipula Endereco

        /*************************************************************************************************
         *                                          PESSOA
         * **********************************************************************************************/
        #region Metodo de Manipulação de Pessoa


         public static void ManipulaPessoa()
        {
            
            //adciono a lista os valores do arquivo [BaseDadosTipoPessoa] que contem cadastrado todos os  Tipo de Pessoas Disponiveis
            listaTipoPessoa = TipoPessoa.Carrega(BaseDadosTipoPessoa);
            listaTipoEndereco = TipoEndereco.Carrega(BaseDadosTipoEndereco);
            //adciono a lista os valores do arquivo [BaseDadosEndereco] que contem cadastrado todos os  Endereços Disponiveis
            listaEndereco = Endereco.Carrega(BaseDadosEndereco, BaseEndereco_Tipo, listaTipoEndereco);

            //-------------------------------
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");
            #region Busca de Dados de Pessoa na base de Dados
           
            listaPessoa = Pessoa.Carrega(BaseDadosPessoa, BasePessoa_TipoPessoa, BasePessoa_Endereco, listaEndereco ,listaTipoPessoa);
            #endregion Fim de Buscas de dados nas Empresas

            #region Mostra os Dados dos Endereços
            //Escreve na tela os valores da lista "listaEndereço";
            foreach (Pessoa Pess in listaPessoa)
            {   
                //mostra os valores do arquivo BaseDadosEndereco
                Console.WriteLine("\n\n Pessoa " + Pess.ID);
                Console.WriteLine("\n Nome : {0} " + "\nTelefone : {1} " + "\nData de Criacao : {2} " ,
                   Pess.Nome, Pess.Telefone, Pess.DataCriacao);
                //Mostra os dados do arquivo BasePessoa_Endereco [Este arquivo armazena os realcionamentos entre Pessoa e Endereço (muitos para muitos)]
                foreach (Endereco x in Pess.Endereco)
                {
                    Console.WriteLine(x.ID + " , " + x.Logradouro + " , " + x.Numero + " , " + " , " + x.Bairro + " , " + x.Cidade + " , " + x.DataCriacao);
                }
                //Mostra os dados do arquivo BasePessoa_TipoPessoa [Este arquivo armazena os realcionamentos entre Pessoa e Tipos de Pessoa (muitos para muitos)]
                foreach (TipoPessoa x in Pess.TipoPessoa)
                {
                    Console.WriteLine(x.ID + " , " + x.Nome);
                }

            }

            #endregion
            Console.WriteLine("---------------------------------------------------------");
            //interage com o usuario para inserir um novo endereço

            #region Criando os Objetos
            Pessoa Pesso = new Pessoa();
            Console.WriteLine("Digite o Nome: ");
            Pesso.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Telefone: ");
            Pesso.Telefone = Console.ReadLine();
           

            Console.WriteLine("Adicionar um  Endereço para o a Pessoa");
             /*
              * Adicionando o Endereço a Pessoa
              */
            //crio uma variavel string vazia
            string opcao = "";
            //crio uma lista [lista] do tipo [Endereco]
            List<Endereco> lista = new List<Endereco>();
            foreach (Endereco End in listaEndereco)
            {
                //mostra item por item para o usuario escolher
                Console.WriteLine("\n\n Endereco " + End.ID);
                Console.WriteLine("\n Logradouro : {0} " + "\nN : {1} " + "\nBairro : {2} " + "\nCidade : {3} " + "\nDataCriacao : {4} ",
                   End.Logradouro, End.Numero, End.Bairro, End.Cidade ,  End.DataCriacao);
                //interege com o usuario. se opção for igual a [S] adiciona valor ao endereço, senão continua...
                Console.WriteLine("Digite [S] para adicionar este Endereco [N] para nao : ");
                opcao = Console.ReadLine();
                if (opcao == "s")
                {                    
                    //Adiciona os items na lista [lista]
                    lista.Add(End);
                    //seto o [Ende.TipoEndereco] com toos os itens da lista [lista]
                    Pesso.Endereco = lista;
                }
                else
                {
                    opcao = "";
                }

                /*
                 * Adicionando o Tipo de Pessoa a Pessoa
                 */
                //Limpo a Variavel opcao
                opcao = "";
                //crio uma lista [lista] do tipo [Endereco]
                List<TipoPessoa> listTpess = new List<TipoPessoa>();
                foreach (TipoPessoa Tipess in listaTipoPessoa)
                {
                    //mostra os valores do arquivo BaseDadosEndereco
                    Console.WriteLine("\n\n Pessoa " + Tipess.ID);
                    Console.WriteLine("\n Nome : {0} " ,
                       Tipess.Nome);

                    Console.WriteLine("Digite [S] para adicionar este TipoPessoa [N] para nao : ");
                    opcao = Console.ReadLine();
                    if (opcao == "s")
                    {
                        //Adiciona os items na lista [lista]
                        listTpess.Add(Tipess);
                        //seto o [Ende.TipoEndereco] com toos os itens da lista [lista]
                        Pesso.TipoPessoa = listTpess;
                      
                    }
                    else
                    {
                        opcao = "";
                    }

                }

            }
            //Ensiro os Valores

            Pessoa.Inserir(listaPessoa, Pesso);
            #endregion

            #region Mostra os objetos da Lista
            foreach (Pessoa Pes in listaPessoa)
            {
                //mostra os itens da Pessoa
                Console.WriteLine("\n\n Pessoa " + Pes.ID);
                Console.WriteLine("\n Nome : {0} " + "\nTelefone : {1} " + "\nDataCriacao : {2} " ,
                   Pes.Nome, Pes.Telefone, Pes.DataCriacao);
                //mostra os itens do Endereco
                foreach (Endereco End in Pes.Endereco)
                {
                    Console.WriteLine(End.ID + ";" + End.Logradouro + ";" + End.Numero + ";" + End.Bairro + ";" + End.Cidade+ ";" + Convert.ToString(End.DataCriacao) + ";" + Pes.ID);
                }
                //Mostra os itens de TipoPessoa
                foreach (TipoPessoa TipPes in Pes.TipoPessoa)
                {
                    Console.WriteLine(TipPes.ID + ";" + TipPes.Nome + ";" + Pes.ID);
                }

            }
            #endregion
            #region Método para salva no arquivo
            //Salva os Dados nos Arquivos [BaseDadosPessoa] , [BasePessoa_TipoPessoa] e [BasePessoa_Endereco]
            Pessoa.Salvar(listaPessoa, BaseDadosPessoa, BasePessoa_Endereco, BasePessoa_TipoPessoa);
            Console.WriteLine("Pessoa Cadastrada Com Sucesso");
            #endregion
            Console.ReadKey();
        }

        #endregion Fim de Manipulação de Pessoa

    }


}

