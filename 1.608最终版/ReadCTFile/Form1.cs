using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;

namespace ReadCTFile
{
    public partial class Form1 : Form
    {
        public Bitmap bitmap = null;
        public Bitmap bitmap2 = null;
        public Bitmap bitmapbak = null;
        public Color color;
        Pen pen;
        public int w;
        Graphics g = null;
        Graphics g2 = null;
        public Bitmap bmpinit = null;
        int x_x, y_y;
        int flag = 9;
        bool mousedown = false;
        float fontSize = 8;
        Color fontColor = Color.White;
        FontFamily FontF = null;
        FontStyle fontStyle = FontStyle.Regular;
        public string so;
        public MImage mypic;
        public bool moveflag;
        private Point start;
        private Point end;
        public bool cutoff = false;
        CImage CImage;
        Bitmap Bi = null;
        int x1;     //鼠标按下时横坐标
        int y1;     //鼠标按下时纵坐标
        int width;  //所打开的图像的宽
        int heigth; //所打开的图像的高
        bool HeadImageBool = true;    // 此布尔变量用来判断pictureBox1控件是否有图片
        Point p1;   //定义鼠标按下时的坐标点
        Point p2;   //定义移动鼠标时的坐标点
        Point p3;   //定义松开鼠标时的坐标点
        double l = 0;


        public Form1()
        {
            InitializeComponent();
            trackBar1.SetRange(0, 1000);
            trackBar2.SetRange(0, 1000);


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mypic = new MImage(so);
            int h = mypic.ImgHeight;
            int w = mypic.ImgWidth;
            pictureBox1.Height = h;
            pictureBox1.Width = w;
            mypic.LoadImage();

            //mypic.Rendering();
            color = Color.Red;
            pen = new Pen(color, 2);
            pen.Width = 5;
            bitmap = new Bitmap(512, 512);
            pictureBox1.Image = mypic.BmpImage;  //将下载好的图像赋值给Picturebox1，以后可直接用
            bitmap2 = new Bitmap(200, 200);
            pictureBox2.Image = (Image)bitmap2;
            g2 = Graphics.FromImage(pictureBox2.Image);
            TimetextBox1.Text = DateTime.Now.ToString(); //显示时间

            Bitmap HighQ = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height, PixelFormat.Format32bppArgb);
            using (Graphics graph = Graphics.FromImage(HighQ))
            {
                graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graph.DrawImage(pictureBox1.Image, 0, 0);
                pictureBox1.Image = HighQ;

            }


            g = Graphics.FromImage(HighQ);
        }
//*********************************************打开文件********************************************************************//
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG文件(*.JPG)|*.Jpg|动画文件(*.Gif)|*.Gif|”+”图标文件(*.Icon)|*.Ico|Png文件(*.Png)|*.Png|Tiff文件(*.Tiff)|*.Tiff|所有文件(*.*)|*.*";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            else
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();

            pictureBox1.Image = Image.FromFile(dlg.FileName);
            bmpinit = (System.Drawing.Bitmap)Image.FromFile(dlg.FileName);
            trackBar1.Dispose();
            trackBar2.Dispose();
            ///
            g = Graphics.FromImage(pictureBox1.Image);



        }


//**************************************保存***************************************************************//

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPG文件(*.JPG)|*.Jpg|动画文件(*.Gif)|*.Gif|”+”图标文件(*.Icon)|*.Ico|Png文件(*.Png)|*.Png|Tiff文件(*.Tiff)|*.Tiff|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string[] fileName = dlg.FileName.Split('.');
            if (fileName.Length < 2)
            {
                MessageBox.Show("文件名格式不对!");
                return;
            }
            if (fileName[fileName.Length - 1] == "Jpg")
            {
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Jpeg);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Gif")
            {
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Gif);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Png")
            {
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Png);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Tiff")
            {
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Tiff);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Ico")
            {
                pictureBox1.Image.Save(dlg.FileName, ImageFormat.Icon);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("文件名格式不对!");
        }
//**************************************退出***************************************************************************************************************************************************//
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
//**************************************调窗*****************************************************************************************************************//
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar1.Value.ToString();
            mypic.WindowWidth = trackBar1.Value;
            mypic.LoadImage();
            mypic.Rendering();
            pictureBox1.Image = mypic.BmpImage;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar2.Value.ToString();
            mypic.WindowCenter = trackBar2.Value;
            mypic.LoadImage();
            mypic.Rendering();
            pictureBox1.Image = mypic.BmpImage;
        }


//**************************************放大***************************************************************************************************************//
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Height = (int)(pictureBox1.Height * 1.2);
            pictureBox1.Width = (int)(pictureBox1.Width * 1.2);
            Point pp1 = new Point(this.panel1.Width / 2, this.panel1.Height / 2);
            Point pp2 = new Point();
            pp2.X = pp1.X - pictureBox1.Width / 2;
            pp2.Y = pp1.Y - pictureBox1.Height / 2;
            this.pictureBox1.Location = pp2;
        }

//***********************************缩小*************************************************//
        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Height = (int)(pictureBox1.Height * 0.85);
            pictureBox1.Width = (int)(pictureBox1.Width * 0.85);
            Point pp1 = new Point(this.panel1.Width / 2, this.panel1.Height / 2);
            Point pp2 = new Point();
            pp2.X = pp1.X - pictureBox1.Width / 2;
            pp2.Y = pp1.Y - pictureBox1.Height / 2;
            this.pictureBox1.Location = pp2;
        }



//*********************************顺时针******************************************************//
        private void button8_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();
            //可能需要先赋值给位图，再把位图取到picturebox里
        }

//*********************************逆时针*************************************************//
        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Refresh();
        }



//*********************************垂直***********************************************************//
        private void fVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Refresh();
        }

//*********************************水平*********************************************************//
        private void fHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Refresh();
        }
//*********************************移动*************************************************************************************************************//

        private void button10_Click_1(object sender, EventArgs e)
        {
            moveflag = true;
        }
        
        
//***********************************鼠标落**********************************************************************************************************//
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cutoff)
            {

                if (e.Button == MouseButtons.Right)
                {

                    if (textBox1.Text.Length != 0 && pictureBox1.Image != null)
                    {
                        Bitmap bt = new Bitmap(pictureBox1.Image);
                        string myfont = textBox1.Text.Trim();
                        Graphics gg = Graphics.FromImage(bt);
                        FontF = fontDialog1.Font.FontFamily;
                        gg.DrawString(textBox1.Text.Trim(), new Font(FontF, fontSize, fontStyle), new SolidBrush(fontColor), new PointF(e.X, e.Y));
                        pictureBox1.Image = bt;
                    }


                }
                else
                {

                    if (moveflag == true)
                    {
                        start = new Point(e.X, e.Y);
                        end = start;
                    }
                    int x, y;
                    x = e.X * bitmap.Width / pictureBox1.Width;
                    y = e.Y * bitmap.Height / pictureBox1.Height;
                    Color c = bitmap.GetPixel(x, y);
                    x_x = x;
                    y_y = y;
                    mousedown = true;
                    if (flag == 0)
                    {
                        Rectangle dest2 = new Rectangle(1, 1, pictureBox2.Width, pictureBox2.Height);
                        System.Drawing.Imaging.ImageAttributes imageattr = new System.Drawing.Imaging.ImageAttributes();
                        imageattr.SetGamma(1.0F);
                        g2.DrawImage(pictureBox1.Image, dest2, x, y, pictureBox2.Width, pictureBox2.Height, GraphicsUnit.Pixel);
                        pictureBox2.BackColor = Color.Transparent;
                        Invalidate(true);
                    }

                }
            }
            else
            {
                this.Cursor = Cursors.Cross;
                this.p1 = new Point(e.X, e.Y);
                x1 = e.X;
                y1 = e.Y;
                if (this.pictureBox1.Image != null)
                {
                    HeadImageBool = true;
                }
                else
                {
                    HeadImageBool = false;
                }
            }
        }

       
//*********************************鼠标移动********************************************************************************************************//
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!cutoff)
            {

                int x, y;

                x = e.X * bitmap.Width / pictureBox1.Width;
                y = e.Y * bitmap.Height / pictureBox1.Height;
                if (flag == 2 && mousedown)
                {
                    g.DrawLine(pen, new Point(x_x, y_y), new Point(x, y));
                    l = l + System.Math.Sqrt((x - x_x) * (x - x_x) + (y - y_y) * (y - y_y));
                    textBox2.Text = "线长：" + ((int)l).ToString();
                    x_x = x;
                    y_y = y;
                }
            }
            else
            {
                if (this.Cursor == Cursors.Cross)
                {
                    this.p2 = new Point(e.X, e.Y);
                    if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)     //当鼠标从左上角向开始移动时P3坐标
                    {
                        this.p3 = new Point(p1.X, p1.Y);
                    }
                    if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)     //当鼠标从右上角向左下方向开始移动时P3坐标
                    {
                        this.p3 = new Point(p2.X, p1.Y);
                    }
                    if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)     //当鼠标从左下角向上开始移动时P3坐标
                    {
                        this.p3 = new Point(p1.X, p2.Y);
                    }
                    if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)     //当鼠标从右下角向左方向上开始移动时P3坐标
                    {
                        this.p3 = new Point(p2.X, p2.Y);
                    }
                    this.pictureBox1.Invalidate();  //使控件的整个图面无效，并导致重绘控件

                }
            }
        }

        
//*********************************鼠标起*************************************************************************************************************//
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!cutoff)
            {
                if (moveflag == true)
                {
                    end = new Point(e.X, e.Y);
                    int piox = this.pictureBox1.Location.X;
                    int pioy = this.pictureBox1.Location.Y;
                    piox += end.X - start.X;
                    pioy += end.Y - start.Y;
                    this.pictureBox1.Location = new Point(piox, pioy);
                }

                pen.Color = color;
                pen.Width = w;
                int x, y;
                x = e.X * bitmap.Width / pictureBox1.Width;
                y = e.Y * bitmap.Height / pictureBox1.Height;
                if (flag == 1 && mousedown)
                {
                    g.DrawLine(pen, new Point(x_x, y_y), new Point(x, y));
                    textBox2.Text = "线长：" + ((int)(System.Math.Sqrt((x - x_x) * (x - x_x) + (y - y_y) * (y - y_y)))).ToString();

                }

                if (flag == 4 && mousedown)
                {
                    g.DrawRectangle(pen, x_x, y_y, (x - x_x), (y - y_y));
                    textBox2.Text = "面积：" + System.Math.Abs((x - x_x) * (y - y_y)).ToString();
                }
                if (flag == 3 && mousedown)
                {
                    g.DrawEllipse(pen, x_x, y_y, (x - x_x), (y - y_y));
                    textBox2.Text = "面积：" + System.Math.Abs(0.5 * 3.14 * (x - x_x) * (y - y_y)).ToString();
                }

                mousedown = false;
                pictureBox1.Refresh();
            }
            else
            {
                if (HeadImageBool)
                {
                    width = this.pictureBox1.Image.Width;
                    heigth = this.pictureBox1.Image.Height;
                    if ((e.X - x1) > 0 && (e.Y - y1) > 0)   //当鼠标从左上角向右下方向开始移动时发生
                    {
                        CImage = new CImage(x1, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));    //实例化CImage类
                    }
                    if ((e.X - x1) < 0 && (e.Y - y1) > 0)   //当鼠标从右上角向左下方向开始移动时发生
                    {
                        CImage = new CImage(e.X, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化CImage类
                    }
                    if ((e.X - x1) > 0 && (e.Y - y1) < 0)   //当鼠标从左下角向右上方向开始移动时发生
                    {
                        CImage = new CImage(x1, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化CImage类
                    }
                    if ((e.X - x1) < 0 && (e.Y - y1) < 0)   //当鼠标从右下角向左上方向开始移动时发生
                    {
                        CImage = new CImage(e.X, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));      //实例化CImage类
                    }
                    this.pictureBox4.Width = (CImage.KiCut((Bitmap)(this.pictureBox1.Image))).Width;
                    this.pictureBox4.Height = (CImage.KiCut((Bitmap)(this.pictureBox1.Image))).Height;
                    this.pictureBox4.Image = CImage.KiCut((Bitmap)(this.pictureBox1.Image));
                    this.Cursor = Cursors.Default;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }

        }

   

//*********************************字体选择***********************************************************************************************//
        private void button11_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowHelp = false;
            fontDialog1.ShowApply = false;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                FontF = fontDialog1.Font.FontFamily;
                fontColor = fontDialog1.Color;
                fontSize = fontDialog1.Font.Size;
                fontStyle = fontDialog1.Font.Style;

            }
        }

//*********************************输入文字************************************************************************************************//
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && pictureBox1.Image != null)
            {
                Bitmap bt = new Bitmap(pictureBox1.Image);
                string myfont = textBox1.Text.Trim();
                Graphics gg = Graphics.FromImage(bt);
                gg.DrawString(textBox1.Text.Trim(), new Font(FontF, fontSize, fontStyle), new SolidBrush(fontColor), new PointF(10, 10));
                pictureBox1.Image = bt;
            }
        }
//*********************************可选局部作图******************************************************************************************//   
        private void cancleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;

        } 
//*********************************直线*****************************************************************************************************// 
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            moveflag = false;
        }
//*********************************曲线*******************************************************************************************************//
        private void curveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 2;
            moveflag = false;
        }

//*********************************椭圆******************************************************************************************************//
        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 3;
            moveflag = false;
        }

//*********************************矩形***************************************************************//
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 4;
            moveflag = false;
        }
//*********************************变色******************************************************************//
        private void btnMoreColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                pictureBox5.BackColor = color;
            }
        }
        private void Cyan_Click(object sender, EventArgs e)
        {
            color = Color.DodgerBlue;
            pictureBox5.BackColor = color;
        }

        private void Red_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            pictureBox5.BackColor = color;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            color = Color.Black;
            pictureBox5.BackColor = color;
        }

        private void Magente_Click(object sender, EventArgs e)
        {
            color = Color.DeepSkyBlue;
            pictureBox5.BackColor = color;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            color = Color.HotPink;
            pictureBox5.BackColor = color;
        }

        private void White_Click(object sender, EventArgs e)
        {
            color = Color.White;
            pictureBox5.BackColor = color;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            color = Color.Aqua;
            pictureBox5.BackColor = color;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            color = Color.Violet;
            pictureBox5.BackColor = color;
        }
//*******************************局部裁剪中的矩形（看不懂、、）***************************************************//
        public Image GetSelectImage1(int Width, int Height)
        {
            Image initImage = this.pictureBox1.Image;
            //Image initImage = Bi;
            //原图宽高均小于模版，不作处理，直接保存 
            if (initImage.Width <= Width && initImage.Height <= Height)
            {

                return initImage;
            }
            else
            {
                //原始图片的宽、高 
                int initWidth = initImage.Width;
                int initHeight = initImage.Height;

                //非正方型先裁剪为正方型 
                if (initWidth != initHeight)
                {
                    //截图对象 
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //宽大于高的横图 
                    if (initWidth > initHeight)
                    {
                        //对象实例化 
                        pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量 
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位 
                        Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                        Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                        //画图 
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置宽 
                        initWidth = initHeight;
                    }
                    //高大于宽的竖图 
                    else
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量 
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位 
                        Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                        Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                        //画图 
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置高 
                        initHeight = initWidth;
                    }

                    initImage = (System.Drawing.Image)pickedImage.Clone();
                    //                //释放截图资源 
                    pickedG.Dispose();
                    pickedImage.Dispose();
                }

                return initImage;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (HeadImageBool)
            {
                Pen p = new Pen(Color.DodgerBlue, 1);//画笔
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; //虚线框
                Bitmap bitmap = Bi; //重新构图
                Rectangle rect = new Rectangle(p3, new Size(System.Math.Abs(p2.X - p1.X), System.Math.Abs(p2.Y - p1.Y)));
                e.Graphics.DrawRectangle(p, rect);
            }
            else
            {

            }
        }
//*********************************选中********************************************************************************************************************************//
        private void button3_Click(object sender, EventArgs e)
        {
            cutoff = true;
        }
//*********************************保存**********************************************************************************************************************************//
        private void button4_Click(object sender, EventArgs e)
        {
            cutoff = false;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPG文件(*.JPG)|*.Jpg|动画文件(*.Gif)|*.Gif|”+”图标文件(*.Icon)|*.Ico|Png文件(*.Png)|*.Png|Tiff文件(*.Tiff)|*.Tiff|所有文件(*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string[] fileName = dlg.FileName.Split('.');
            if (fileName.Length < 2)
            {
                MessageBox.Show("文件名格式不对!");
                return;
            }
            if (fileName[fileName.Length - 1] == "Jpg")
            {
                pictureBox4.Image.Save(dlg.FileName, ImageFormat.Jpeg);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Gif")
            {
                pictureBox4.Image.Save(dlg.FileName, ImageFormat.Gif);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Png")
            {
                pictureBox4.Image.Save(dlg.FileName, ImageFormat.Png);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Tiff")
            {
                pictureBox4.Image.Save(dlg.FileName, ImageFormat.Tiff);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (fileName[fileName.Length - 1] == "Ico")
            {
                pictureBox4.Image.Save(dlg.FileName, ImageFormat.Icon);
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("文件名格式不对!");
        }

//*********************************清除*************************************************//
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mypic.LoadImage();
            mypic.Rendering();
            pictureBox1.Image = mypic.BmpImage;
           
        }
        
//*********************************防止可以重复点开*************************************************//
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.IsOn1 = true;
        }
//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//

//*********************************变色*************************************************//
         

     

        




        }

    }


