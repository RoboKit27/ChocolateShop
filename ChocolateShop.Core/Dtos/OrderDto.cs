using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.Core.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public ClientDto Client { get; set; }
        public int ChocolateAmount { get; set; }
        public decimal Cost { get; set; }
        public List<ChocolateDto> Chocolates { get; set; }
    }
}
