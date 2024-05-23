using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.CartItems
{
    public record CartItemReadDto(int id,int productId,int Qty);
}
