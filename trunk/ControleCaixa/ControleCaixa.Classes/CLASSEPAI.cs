using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCaixa.Classes
{

    //esta classe servirá de base para todas as outras classes do projeto
    //ela definirá o atributo de identificação ID, Data de criação etc
   public abstract class CLASSEPAI
    {
        public int _ID;
        public int ID
        {
            get { return _ID; }
        }

        private DateTime _DataCriacao;
       public DateTime DataCriacao
       {
           get { return _DataCriacao; }
           set { _DataCriacao = value; }
           
       }
       public CLASSEPAI() { DataCriacao = DateTime.Now; }
    }

}
