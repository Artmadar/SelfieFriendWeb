using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieFriend.Services.Interface
{
    public interface IFileService
    {
        string ImageDecodeAndSave(string base64String);
        
        void test();

    }
}
