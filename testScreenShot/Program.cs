using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace testScreenShot
{
    class Program
    {
        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private static void getPixelsetPixel()
        {
            Image jpg = Image.FromFile("C:/Users/danila/skkribl/testScreenShot/image.jpg");
            Bitmap img = new Bitmap(jpg);
            Bitmap nbmp = ResizeBitmap(img, 100, 100);

            for (int i = 0; i < nbmp.Width; i++)
            {
                for (int j = 0; j < nbmp.Height; j++)
                {
                    Color pixel = nbmp.GetPixel(i, j);
                    Console.WriteLine(pixel);
                }
            }

        }
        static void Main(string[] args)
        {
            getPixelsetPixel();
        }
    }
}
