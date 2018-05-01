using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadCTFile
{
    public partial class Form2 : Form
    {
   
        public Bitmap bmpinit = null;
        //Graphics g = null;
        LImage image = new LImage();
        LImage image1 = new LImage();
        LImage image2 = new LImage();
        LImage image3 = new LImage();
        LImage image4 = new LImage();
        LImage image5 = new LImage();
        LImage image6 = new LImage();
        LImage image7 = new LImage();
        LImage image8 = new LImage();
        LImage image9 = new LImage();
        LImage image10 = new LImage();
        LImage image11 = new LImage();
        LImage image12 = new LImage();
        LImage image13 = new LImage();
        int pb1=0,pb2=1,pb3=2,pb4=3,pb5=4,pb6=5,pb7=6,pb8=7,pb9=8,pb10=9,pb11=10,pb12=11,pb13=12,pb14=13;
        string[] ImgPath = new string[16];
        //int PathCount = -1;

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image.Load(dlg.FileName);

                    ImgPath[pb1] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;
                  
                    pictureBox1.Image = Image.FromFile(image.Load(dlg.FileName));
                }
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb1];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (pictureBox2.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                  
                    image1.Load(dlg.FileName);
                    ImgPath[pb2] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox2.Image = Image.FromFile(image1.Load(dlg.FileName));
                }
            }
            else
            {
                Form1 frm1 = new Form1();
                if (Program.IsOn1)
                {

                    frm1.so = ImgPath[pb3];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh(); 
                }
            }
            //this.Refresh();
        }

 

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image2.Load(dlg.FileName);

                    ImgPath[pb3] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox3.Image = Image.FromFile(image2.Load(dlg.FileName));
                }
                //OpenFileDialog dlg = new OpenFileDialog();
                //dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                //dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                //dlg.RestoreDirectory = true;
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{



                //}
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb3];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image3.Load(dlg.FileName);

                    ImgPath[pb4] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox4.Image = Image.FromFile(image3.Load(dlg.FileName));
                }
                //OpenFileDialog dlg = new OpenFileDialog();
                //dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                //dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                //dlg.RestoreDirectory = true;
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{



                //}
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb4];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image4.Load(dlg.FileName);

                    ImgPath[pb5] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox5.Image = Image.FromFile(image4.Load(dlg.FileName));
                }
  
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb5];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image5.Load(dlg.FileName);

                    ImgPath[pb6] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox6.Image = Image.FromFile(image5.Load(dlg.FileName));
                }
                
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb6];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pictureBox7.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image6.Load(dlg.FileName);

                    ImgPath[pb7] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox7.Image = Image.FromFile(image6.Load(dlg.FileName));
                }
               
            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb7];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pictureBox8.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image7.Load(dlg.FileName);

                    ImgPath[pb8] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox8.Image = Image.FromFile(image7.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb8];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox9.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image8.Load(dlg.FileName);

                    ImgPath[pb9] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox9.Image = Image.FromFile(image8.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb9];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (pictureBox10.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image9.Load(dlg.FileName);

                    ImgPath[pb10] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox10.Image = Image.FromFile(image9.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb10];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (pictureBox11.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image10.Load(dlg.FileName);

                    ImgPath[pb11] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox11.Image = Image.FromFile(image10.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb11];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (pictureBox12.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image11.Load(dlg.FileName);

                    ImgPath[pb12] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox12.Image = Image.FromFile(image11.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb12];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (pictureBox13.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image12.Load(dlg.FileName);

                    ImgPath[pb13] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox13.Image = Image.FromFile(image12.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb13];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (pictureBox14.Image == null)
            {
                //PathCount++;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "C:\\Documents and Settings\\ttc\\桌面\\ReadCTFile111\\ReadCTFile\\bin\\Debug";
                dlg.Filter = "Raw文件(*.raw)|*.raw|所有文件(*.*)|*.*";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image13.Load(dlg.FileName);

                    ImgPath[pb14] = (string)dlg.FileName;

                    //MessageBox.Show(ImgPath[PathCount]);
                    //PathCount++;

                    pictureBox14.Image = Image.FromFile(image13.Load(dlg.FileName));
                }

            }
            else
            {
                Form1 frm1 = new Form1();
                //frm1.pictureBox1 = img;

                if (Program.IsOn1)
                {
                    frm1.so = ImgPath[pb14];
                    frm1.Show();
                    Program.IsOn1 = false;
                    //PathCount++;
                    this.Refresh();
                }

            }
        }
        
    }
}
