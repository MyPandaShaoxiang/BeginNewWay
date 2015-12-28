using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Timers;

namespace GameBox
{
    enum panelAction { inside, outside };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "GameBox";

            panelSpeed = 0;

           
        }
        #region

        private Timer panelTimer;
        private int panelSpeed;
        panelAction pa;
        Form occurForm;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.picBox1.BackgroundImage = Image.FromFile("..//..//res//背景.jpg");
            this.label1.ForeColor = Color.Blue;

            this.picBox2.BackgroundImage = Image.FromFile("..//..//res//game2.jpg");
            this.label2.ForeColor = Color.Blue;

            this.picBox3.BackgroundImage = Image.FromFile("..//..//res//game3.jpg");
            this.label3.ForeColor = Color.Blue;

            this.label1.MouseMove+=new MouseEventHandler(Label_MouseMove);
            this.label1.MouseLeave+=new EventHandler(Label_MouseLeave);
            this.label2.MouseMove+=new MouseEventHandler(Label_MouseMove);
            this.label2.MouseLeave+=new EventHandler(Label_MouseLeave);
            this.label3.MouseMove += new MouseEventHandler(Label_MouseMove);
            this.label3.MouseLeave += new EventHandler(Label_MouseLeave);

            this.label1.MouseClick+=new MouseEventHandler(picBox1_Click);
            this.picBox1.Click+=new EventHandler(picBox1_Click);
            this.label2.MouseClick+=new MouseEventHandler(picBox2_Click);
            this.label3.MouseClick += new MouseEventHandler(picBox3_Click);
            this.picBox3.Click+=new EventHandler(picBox3_Click);

            this.picBox1.MouseMove += new MouseEventHandler(Pic_MouseMove);
            this.picBox1.MouseLeave += new EventHandler(Pic_MouseLeave);
            this.picBox2.MouseMove += new MouseEventHandler(Pic_MouseMove);
            this.picBox2.MouseLeave += new EventHandler(Pic_MouseLeave);
            this.picBox3.MouseMove += new MouseEventHandler(Pic_MouseMove);
            this.picBox3.MouseLeave += new EventHandler(Pic_MouseLeave);

            this.linkLabel1.BackColor = Color.Transparent;

            panelTimer = new Timer();
            panelTimer.Tick+=new EventHandler(t1_Tick);
            panelTimer.Interval = 1;

            this.BackgroundImage = Image.FromFile("..//..//res//bk1.jpg");
            this.MainPanel.Hide();

            



        }
        
        private void t1_Tick(object sender, EventArgs e)
        {
            panelSpeed += 10;

            if (pa == panelAction.inside)
            {
                
                this.MainPanel.Left = this.Width - this.panelSpeed;

                if (this.MainPanel.Left <= 0)
                {
                    panelTimer.Enabled = false;
                }
            }
            else
            {
               
                this.MainPanel.Left =this.panelSpeed;

                if (this.MainPanel.Left >=this.Width)
                {
                    panelTimer.Enabled = false;
                    this.occurForm.Dispose();
                    this.occurForm = null;
                }
            }
        }

        private void picBox1_Click(object sender, EventArgs e)
        {
           

            JigsawForm f1 = new JigsawForm(this) { TopLevel = false, FormBorderStyle =FormBorderStyle.None};
            panel_Run(0, f1);
            this.occurForm = f1;
            
        }

        public void panel_Run(int flag, Form f)
        {
            if (flag == 0)
            {
                pa = panelAction.inside;
                
            }
            else
            {
                pa = panelAction.outside;

            }
            this.panelSpeed = 0;
            this.MainPanel.Controls.Clear();
            f.Size = this.MainPanel.Size;
            this.MainPanel.Controls.Add(f);
            f.Show();
            this.occurForm = f;
            this.MainPanel.Show();
            this.panelTimer.Enabled = true;
        }

        private void Label_MouseMove(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Red;
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Blue;
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            carForm f1 = new carForm(this) { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panel_Run(0, f1);
            this.occurForm = f1;
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            game3Form f1 = new game3Form(this) { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            panel_Run(0, f1);
            this.occurForm = f1;
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;

            //Graphics gra = picBox.Parent.CreateGraphics();
            Graphics gra = this.CreateGraphics();
            int x1 = picBox.Left - 1;
            int y1 = picBox.Top - 1;
            int x2 = picBox.Width + 1;
            int y2 = picBox.Height + 1;
            Pen PicPen = new Pen(Color.Chocolate);

            gra.DrawRectangle(PicPen, x1, y1, x2, y2);
            //MessageBox.Show(x1.ToString() + " " + y1.ToString()+" "+x2.ToString()+" "+y2.ToString());

        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;

            Graphics gra = picBox.Parent.CreateGraphics();

            int x1 = picBox.Left - 1;
            int y1 = picBox.Top - 1;
            int x2 = picBox.Width + 1;
            int y2 = picBox.Height + 1;
            Pen PicPen = new Pen(Color.White);

            gra.DrawRectangle(PicPen, x1, y1, x2, y2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string str = "班级：11021101\n\n制作人：2011302725 田晓刚 2011302721 刘明\n\n      2011302716 龚信 2011302719 李婷";
            MessgeForm f = new MessgeForm(str, this);
            f.Show();
        }


    }
}
