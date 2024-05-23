using BL.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public record ProductReadDto(string Name,string? Desc,int sold,string Brand,int Qty,int RattingQty,int RattingAve,CategoryReadDto Category,int Price);
}
