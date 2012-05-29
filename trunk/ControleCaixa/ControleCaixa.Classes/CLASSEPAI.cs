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

       private DateTime _DataCriacao = DateTime.Now;
       public DateTime DataCriacao
       {
           get { return _DataCriacao; }
           
       }
    }
}
