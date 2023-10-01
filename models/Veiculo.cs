using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcess.models
{
    public class Veiculo
    {
        public int id { get; set; }
        public int idLavagem { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public DateTime dataLavagem { get; set; }
    }
}