using System;

namespace SelfieFriend.Services.Interface
{
    public interface IFileService
    {
        string ImageDecodeAndSave(string base64String);

        Tuple<string, string> ImageDecodeAndSaveWithWaterMark(string base64string);

    }
}
