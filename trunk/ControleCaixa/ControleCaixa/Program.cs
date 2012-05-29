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
        
        
        static void Main(string[] args)
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


    }
}
