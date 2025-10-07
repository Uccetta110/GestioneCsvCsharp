using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCsv
{
    internal class CV
    {
        protected string Cognome { set; get;  }
        protected string Nome { set; get; }
        protected string Classe { set; get; }
        protected string Indirizzo { set; get; }
        protected string Paese { set; get;  }
        protected string Residenza { set; get; }
        protected string Email { set; get; }
        protected string Esperienze { set; get; }

        protected int Cell { set; get; }

        public CV(string cognome, string nome, string classe, string indirizzo, string paese, string residenza, string email, int cell, string esperienze)
        {
            Cognome = cognome;
            Nome = nome;
            Classe = classe;
            Indirizzo = indirizzo;
            Paese = paese;
            Residenza = residenza;
            Email = email;
            Cell = cell;
            Esperienze = esperienze;
        }
        
    }
}
