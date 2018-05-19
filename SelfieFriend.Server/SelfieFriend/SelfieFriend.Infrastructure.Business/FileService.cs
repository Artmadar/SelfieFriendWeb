using System;
using System.Drawing;
using System.Drawing.Imaging;
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




        public void test()
        {
            var filePath = HttpContext.Current.Server.MapPath("~/Content/photos/moby.jpg");
            var image = new Bitmap(filePath);
            var watermarkPath = HttpContext.Current.Server.MapPath("~/Content/photos/co.png");
            var watermark = new Bitmap(watermarkPath);

            DrawWatermark(image, watermark, WatermarkPosition.Middle, Color.Cyan, 0.4f);



        }


        public void DrawWatermark(Image original, Bitmap watermark,
    WatermarkPosition position, Color transparentColor, float opacity)
        {
            if (original == null)
                throw new ArgumentNullException("original");
            if (watermark == null)
                throw new ArgumentNullException("watermark");
            if (opacity < 0 || opacity > 1)
                throw new ArgumentOutOfRangeException("Watermark opacity value is out of range");

            Rectangle dest = new Rectangle(
                GetDestination(original.Size, watermark.Size, position), watermark.Size);

            using (Graphics g = Graphics.FromImage(original))
            {
                ImageAttributes attr = new ImageAttributes();
                ColorMatrix matrix = new ColorMatrix(new float[][] {
            new float[] { opacity, 0f, 0f, 0f, 0f },
            new float[] { 0f, opacity, 0f, 0f, 0f },
            new float[] { 0f, 0f, opacity, 0f, 0f },
            new float[] { 0f, 0f, 0f, opacity, 0f },
            new float[] { 0f, 0f, 0f, 0f, opacity } });
                attr.SetColorMatrix(matrix);
                watermark.MakeTransparent(transparentColor);

                g.DrawImage(watermark, dest, 0, 0, watermark.Width, watermark.Height,
                    GraphicsUnit.Pixel, attr, null, IntPtr.Zero);
                g.Save();

                var bytes = ImageToByte2(original);

                var filePath = HttpContext.Current.Server.MapPath("~/Content/photos/ppp.jpg");
                File.WriteAllBytes(filePath, bytes);

            }
        }



        private static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private static Point GetDestination(Size originalSize, Size watermarkSize, WatermarkPosition position)
        {
            Point destination = new Point(0, 0);
            switch (position)
            {
                case WatermarkPosition.TopRight:
                    destination.X = originalSize.Width - watermarkSize.Width;
                    break;
                case WatermarkPosition.BottomLeft:
                    destination.Y = originalSize.Height - watermarkSize.Height;
                    break;
                case WatermarkPosition.BottomRight:
                    destination.X = originalSize.Width - watermarkSize.Width;
                    destination.Y = originalSize.Height - watermarkSize.Height;
                    break;
                case WatermarkPosition.Middle:
                    destination.X = (originalSize.Width - watermarkSize.Width) / 2;
                    destination.Y = (originalSize.Height - watermarkSize.Height) / 2;
                    break;
            }
            return destination;
        }

    }


    public enum WatermarkPosition
    {
        TopLeft = 0,
        TopRight,
        BottomLeft,
        BottomRight,
        Middle
    }


}
