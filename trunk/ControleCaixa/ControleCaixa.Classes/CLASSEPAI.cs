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
       private int _ID;
       public int ID
       {
           get { return ID; }
           set { _ID = value; }
       }
       private DateTime _DataCriacao;
       public DateTime DataCriacao
       {
           get { return DataCriacao; }
           set { _DataCriacao = value; }
       }
    }
}
