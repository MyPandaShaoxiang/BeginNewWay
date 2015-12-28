using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBox
{
    public partial class JigsawForm : Form
    {
        public JigsawForm(Form1 f)
        {
            InitializeComponent();
            this.Owner = f;

            boxArray = new PictureBox[9];
            boxArray[0] = pictureBox1;
            boxArray[1] = pictureBox2;
            boxArray[2] = pictureBox3;
            boxArray[3] = pictureBox4;
            boxArray[4] = pictureBox5;
            boxArray[5] = pictureBox6;
            boxArray[6] = pictureBox7;
            boxArray[7] = pictureBox8;
            boxArray[8] = pictureBox9;

            curOrder = 6;

            //picArray = new ImageList();
            
        }
        #region
        private Form1 Owner;
        //private ImageList picArray;
        private PictureBox[] boxArray;
        int curOrder;
        #endregion
        private void JigsawForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SeaGreen;

            this.CallBackBtn.BackColor = Color.Transparent;
           this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
           this.CallBackBtn.MouseMove += new MouseEventHandler(CallBackBtn_MouseMove);
            this.CallBackBtn.MouseLeave+=new EventHandler(CallBackBtn_MouseLeave);

            this.picPanel.BackgroundImage = Image.FromFile("..//..//res//frame1.gif");

            int i=0;
            int k = 0;
            while(i<9)
            {
                if (i != 6)
                {
                    boxArray[i].BackgroundImage = Image.FromFile("..//..//res//背景_0" + (k++).ToString() + ".gif");
                    
                }
                boxArray[i].BackColor = Color.Transparent;
                boxArray[i].MouseClick += new MouseEventHandler(PicBox_MouseClick);
                i++;
            }

            this.label.ForeColor = Color.Red;
            this.label.MouseLeave+=new EventHandler(label_MouseLeave);
            this.label.MouseMove+=new MouseEventHandler(label_MouseMove);


        
            
        }
       


        private void CallBackBtn_Click(object sender, EventArgs e)
        {
            this.Owner.panel_Run(1, this);
        }

        private void CallBackBtn_MouseMove(object sender, EventArgs e)
        {
            this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou2.gif");
        }
        private void CallBackBtn_MouseLeave(object sender, EventArgs e)
        {
            this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
        }
        private void label_MouseMove(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Blue;
        }
        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Red;
        }

        private void PicBox_MouseClick(object sender, EventArgs e)
        {
            PictureBox curBox = (PictureBox)sender;

            int t = Array.IndexOf(boxArray, curBox);

            if (isValide(t,curOrder))
            {
                boxArray[curOrder].BackgroundImage = boxArray[t].BackgroundImage;
                boxArray[t].BackgroundImage = null;
                curOrder = t;
            }

        }
        

        private void label_Click(object sender, EventArgs e)
        {
            MessgeForm f = new MessgeForm("你确定要打乱图像吗？",this.Owner);
            

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                Random rd = new Random();
                
                List<int> flag = new List<int>();
                for (int i = 0; i < 8; i++)
                {
                    flag.Add(i);
                }
                int k = 0;
                for (int i = 7; i >= 0; i--)
                    {
                        int t =rd.Next(0, i);
                        int key = flag[t];
                        if (k != 6)
                        {
                            boxArray[k].BackgroundImage = Image.FromFile("..//..//res//背景_0" + key.ToString() + ".gif");
                            flag.RemoveAt(t);
                        }
                        else
                        {
                            i = i+1;
                        }
                    
                        k++;

                       
                    }
                curOrder = 6;
                this.boxArray[curOrder].BackgroundImage = null;
            }
        }//labelclick

        private bool isValide(int t,int curOrder)
        {
            if (Math.Abs(t - curOrder) == 3)
                return true;
            else {
                if (t - curOrder == -1 && t % 3 != 2)
                    return true;
                if (t - curOrder == 1 && t % 3 != 0)
                    return true;
                }
            return false;
        }

       
    }
}
