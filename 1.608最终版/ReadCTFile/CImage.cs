using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace ReadCTFile
{
    public class CImage
    {


        public Bitmap KiCut(Bitmap b)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (X >= w || Y >= h)
            {
                return null;
            }

            if (X + Width > w)
            {
                Width = w - X;
            }

            if (Y + Height > h)
            {
                Height = h - Y;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                // Create rectangle for displaying image.
                Rectangle destRect = new Rectangle(0, 0, Width, Height);        //所画的矩形正确，它指定所绘制图像的位置和大小。 将图像进行缩放以适合该矩形。

                // Create rectangle for source image.
                Rectangle srcRect = new Rectangle(X, Y, Width, Height);      //srcRect参数指定要绘制的 image 对象的矩形部分。 将此部分进行缩放以适合 destRect 参数所指定的矩形。

                g.DrawImage(b, destRect, srcRect, GraphicsUnit.Pixel);
                //resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        public int X;
        public int Y;
        public int Width;
        public int Height;

        public CImage(int x, int y, int width, int heigth)
        {
            X = x;
            Y = y;
            Width = width;
            Height = heigth;
        }

    }
}
