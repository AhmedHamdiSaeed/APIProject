using BL.DTOs.Images;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        //[HttpPost]
        //public ActionResult<ImagesDto> Upload(IFormFile []Images)
        //{
        //    string[] allowExtenstion = [".jpg",".jpeg",".png"];
        //    ICollection<string> ImagesURL = [];
        //    if (Images.Length>4)
        //    {
        //        return BadRequest();
        //    }
        //    foreach (var image in Images)
        //    { 

        //        if (!allowExtenstion.Contains(Path.GetExtension(image.FileName), StringComparer.InvariantCultureIgnoreCase))
        //        { return BadRequest(new ImagesDto(false, "not support this extension", [])); }
        //        else if (image.Length > 2_000_000)
        //        {
        //            return BadRequest(new ImagesDto(false,"must less or equal 2MB", []));
        //        }
        //    }

        //        foreach(var image in Images)
        //    {
        //        var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
        //        var fullFilePath = Path.Combine(Environment.CurrentDirectory, "Images",$"{newFileName}");
        //       using var stream = new FileStream(fullFilePath,FileMode.Create);
        //        image.CopyTo(stream);
        //        ImagesURL.Add($"{Request.Scheme}://{Request.Host}/Images/{newFileName}");
        //    }

        //    return new ImagesDto(true,"success",ImagesURL);
        //}
        [HttpPost]
        public ActionResult<ImageDto> Upload(IFormFile Image)
        {
            string[] allowExtenstion = [".jpg", ".jpeg", ".png"];

                if (!allowExtenstion.Contains(Path.GetExtension(Image.FileName), StringComparer.InvariantCultureIgnoreCase))
                { return BadRequest(new ImageDto(false, "not support this extension",string.Empty)); }
                if (Image.Length > 2_000_000)
                {
                    return BadRequest(new ImageDto(false, "must less or equal 2MB", string.Empty));
                }
         
                var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(Image.FileName)}";
                var fullFilePath = Path.Combine(Environment.CurrentDirectory, "Images", $"{newFileName}");
                using var stream = new FileStream(fullFilePath, FileMode.Create);
                Image.CopyTo(stream);
                
            

            return new ImageDto(true, "success", $"{Request.Scheme}://{Request.Host}/Images/{newFileName}");
        }
    }
}
