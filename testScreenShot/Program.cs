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
        static void Main(string[] args)
        {
            Image jpg = Image.FromFile("C:/Users/danil/source/repos/testScreenShot/testScreenShot/image.jpg");
            Bitmap img = new Bitmap(jpg);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    Console.WriteLine(pixel);
                }
            }
        }
    }
}
