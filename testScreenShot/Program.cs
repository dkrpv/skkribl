using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;

namespace testScreenShot
{
    class Program
    {
        public static class VirtualMouse
        {
            [DllImport("user32.dll")]
            static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
            private const int MOUSEEVENTF_MOVE = 0x0001;
            private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            private const int MOUSEEVENTF_LEFTUP = 0x0004;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            private const int MOUSEEVENTF_RIGHTUP = 0x0010;
            private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
            private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
            public static void Move(int xDelta, int yDelta)
            {
                mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
            }
            public static void MoveTo(int x, int y)
            {
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
            }
            public static void LeftClick()
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void LeftDown()
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void LeftUp()
            {
                mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightClick()
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightDown()
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightUp()
            {
                mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }
        }
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
            int[] pxlColors = new int[100];

            for (int i = 0; i < nbmp.Width; i++)
            {
                for (int j = 0; j < nbmp.Height; j++)
                {
                    Color pixel = nbmp.GetPixel(i, j);
                    pxlColors[j] = pixel.ToArgb();
                }
            }
            for (int v = 0; v < 100; v++)
            {
                if (pxlColors[v] / 2 != 0)
                {
                    int x = 10000 + v;
                    int y = 10000 + v;
                    VirtualMouse.MoveTo(x, y);
                    VirtualMouse.LeftClick();
                }
                else
                {

                }
            }
        }
        static void Main(string[] args)
        {
            getPixelsetPixel();
        }
    }
}
