using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Products
{
    public record ProductAddDto(string Name, string Desc, string Brand, int Qty,int price);

}
