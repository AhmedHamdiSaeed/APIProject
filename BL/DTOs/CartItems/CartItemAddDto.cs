﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Carts
{
    public class CartItemAddDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
