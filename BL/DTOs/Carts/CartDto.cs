using BL.DTOs.CartItems;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.ShoppingCarts
{
    public record CartDto(int id,string userId,IEnumerable<CartItemReadDto> CartItems);
}
