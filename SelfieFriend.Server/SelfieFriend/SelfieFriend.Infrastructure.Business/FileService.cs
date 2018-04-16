using System;
using System.IO;
using System.Web;
using SelfieFriend.Services.Interface;

namespace SelfieFriend.Infrastructure.Business
{
    public class FileService:IFileService
    {
        public string ImageDecodeAndSave(string base64String)
        {
            var buffer = Convert.FromBase64String(base64String);

            var filename = Guid.NewGuid() + ".jpg";
            var filePath = HttpContext.Current.Server.MapPath("~/Content/photos/" + filename);
            File.WriteAllBytes(filePath, buffer);
            return filename;
        }

        
    }
}
