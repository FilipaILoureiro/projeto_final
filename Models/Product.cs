using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoPadariaApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public int Iva { get; set; }

        public override string ToString()
        {
            return $"{Nome} ({Quantidade} unidades)";
        }
    }
}
