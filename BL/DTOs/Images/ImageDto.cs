using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Images
{
    
    public class ImageDto
    {
        public bool IsSucceded { get; set; }   
        public string Message { get; set; }
        public string ImageURL { get; set; }
        public ImageDto(bool succeded,string msg, string URL)
        {
            IsSucceded = succeded;
            Message = msg;
            ImageURL = URL;
        }
    }
}
