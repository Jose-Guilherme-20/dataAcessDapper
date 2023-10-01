using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcess.models
{
    public class Cliente
    {
        public int id { get; set; }
        public int idVeiculo { get; set; }
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}