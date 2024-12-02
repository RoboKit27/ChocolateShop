using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.Core.Dots
{
    public class ChocolateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string ProductDate { get; set; }
        public int BestBefore { get; set; }
        public int Weight { get; set; }
        public CompanyDto Company {  get; set; }
        public TypeDto Type { get; set; }
        public List<AdditiveDto> Additives { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}\nName: {this.Name}\nCost: {this.Cost}\nProductDate: {this.ProductDate}\nBestBefore: {this.BestBefore}\nWeight: {this.Weight}";
        }

    }
}
