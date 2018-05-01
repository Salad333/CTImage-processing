using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ReadCTFile
{
    public class MImage
    {
        private string fileName;        //文件名
        private short[] imageData;       //原始数据
        Bitmap bmpImage;                //显示位图
        private int windowWidth = 600; //窗宽
        private int windowCenter = 400; //窗位
        private int imgWidth = 512;     //图像宽度
        private int imgHeight = 512;    //图像高度
        byte[] grayBmp;     //显示图像数据(灰度)
        public int ImgWidth
        {
            get { return imgWidth; }
        }
        public int ImgHeight
        {
            get { return imgHeight; }
        }
        public int WindowWidth
        {
            get { return windowWidth; }
            set { windowWidth = value; }
        }
        public int WindowCenter
        {
            get { return windowCenter; }
            set { windowCenter = value; }
        }
        public Bitmap BmpImage
        {
            get { return bmpImage; }
        }
        public MImage(string fileName)
        {
            this.fileName = fileName;
        }

        // 加载初始数据 
        public Bitmap LoadImage()
        {
            imageData = new short[imgWidth * imgHeight];
            bmpImage = new System.Drawing.Bitmap(imgWidth, imgHeight);

            byte[] tempData = new byte[imgWidth * imgHeight * 2];
            FileStream fs = File.Open(fileName, FileMode.Open);
            BinaryReader sr = new BinaryReader(fs);
            //没有办法直接把数据读到short数组里面，所以借助byte数组转化一下。

            sr.Read(tempData, 0, imgWidth * imgHeight * 2);
            sr.Close();
            fs.Close();

            for (int i = 0; i < imgWidth * imgHeight; i++)
            {
               
                imageData[i] = (short)(tempData[2 * i + 1] *256 + tempData[2 * i]);
                
            }

            Rendering();
            return bmpImage;
        }
        /// <summary>
        /// 生成图像
        /// </summary>
        public void Rendering()
        {
            //使用窗宽窗位，创建灰度查找表。图像存储的数据都是正值，而CT值的最小值是1024，查表时下标必须为正，

            //所以此处调整了窗宽窗位
            int offset = 1024;
            Byte[] lookUpTable = new Byte[4096];    //数组元素默认值为0
            int low = windowCenter - windowWidth / 2 + offset;
            int high = windowCenter + windowWidth / 2 + offset;
            for (int i = low; i <= high; i++)
            {
                lookUpTable[i] = (Byte)((i - (windowCenter - windowWidth / 2 + offset)) / (double)windowWidth * 255);
            }
            for (int i = high + 1; i < 4096; i++)
            {
                lookUpTable[i] = 255;
            }

            grayBmp = new byte[imgWidth * imgHeight];
            for (int i = 0; i < imgHeight; i++)
            {
                for (int j = 0; j < imgWidth; j++)
                {
                    short data = (short)(imageData[i * imgWidth + j]);
                    grayBmp[i * imgWidth + j] = lookUpTable[data];
                }
            }

            unsafe
            {
                //fixed使得使用grayAddr指针时,grayBmp的存储位置不会被垃圾收集器移动

                fixed (byte* grayAddr = grayBmp)
                {
                    IntPtr ptr = (IntPtr)(byte*)grayAddr;
                    bmpImage = new Bitmap(imgWidth, imgHeight, imgWidth, PixelFormat.Format8bppIndexed, ptr);
                    ColorPalette pal = bmpImage.Palette;    //得到的是bmpImage.Palette的副本？
                    for (int i = 0; i < 256; i++)
                    {
                        pal.Entries[i] = Color.FromArgb(i, i, i);
                    }

                    bmpImage.Palette = pal; //必须重新赋值，才可以生效
                }
            }
        }




    }
}
