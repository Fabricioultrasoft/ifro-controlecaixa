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
        const string BaseDadosLancamento = @"C:\Users\Tiago\Documents\Escola\Desnvolvimento de Sistemas\Projeto_Final_Da_Materia\BaseDadosLancamento";
        #endregion Fim dos Atributos de Lancamento
        
        
        static void Main(string[] args)
        {
            // MovimentacaoItem.tipoMovimentacao vv = MovimentacaoItem.tipoMovimentacao.Credito;
            Console.WriteLine("\nBusca dos Dados na Base de Dados TXT ");


            Console.ReadKey();


        }
    }
}
