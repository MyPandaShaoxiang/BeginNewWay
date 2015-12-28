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
    enum carMoveDirect { left,right};
    enum areaStatus{empty,full};
    enum gameStatus { run,stop};
    enum carStatus{dead,live};
    public partial class carForm : Form
    {
        public carForm(Form1 f)
        {
            InitializeComponent();
            this.Owner = f;
            carMoveSpeed = new Timer();
            carMoveSpeed.Interval = 50;
            carMoveSpeed.Tick+=new EventHandler(carMoveSpeed_Tick);

            carSpeed = new Timer();
            carSpeed.Interval = 100;
            carSpeed.Tick+=new EventHandler(carSpeed_Tick);

            toMainArea=new areaStatus[3]{areaStatus.empty,areaStatus.empty,areaStatus.empty};
            Area1=new areaStatus[3]{areaStatus.full,areaStatus.empty,areaStatus.empty};
            Area2=new areaStatus[3]{areaStatus.empty,areaStatus.empty,areaStatus.full};
            areaMainTo = new areaStatus[3] { areaStatus.empty, areaStatus.full, areaStatus.empty };

            initTop1 = this.viseCarBox1.Top;
            initTop2 = this.viseCarBox2.Top;

            appStatus=gameStatus.stop;
            mainCarStatus = carStatus.live;
        }
        #region 
        private Form1 Owner;
        private Timer carMoveSpeed;
        private carMoveDirect moveDirect;
        private Timer   carSpeed;

        private areaStatus[] toMainArea;
        private areaStatus[] Area1;
        private areaStatus[] Area2;
        private areaStatus[] areaMainTo;

        private int initTop1;
        private int initTop2;

        private gameStatus appStatus;
        private carStatus mainCarStatus;
        #endregion

        private void CallBackBtn_Click(object sender, EventArgs e)
        {
            this.Owner.panel_Run(1, this);
            //this.Close();
        }

        private void carForm_Load(object sender, EventArgs e)
        {
            this.CallBackBtn.BackColor = Color.Transparent;
            this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
            this.CallBackBtn.MouseMove += new MouseEventHandler(CallBackBtn_MouseMove);
            this.CallBackBtn.MouseLeave += new EventHandler(CallBackBtn_MouseLeave);

            this.mainCarlBox.BackColor = Color.Transparent;
            this.mainCarlBox.BackgroundImage = Image.FromFile("..//..//res//cars//Car.gif");

            this.leftBox.BackColor = Color.Transparent;
            this.leftBox.BackgroundImage = Image.FromFile("..//..//res//cars//left.gif");
            this.leftBox.MouseMove+=new MouseEventHandler(leftBox_MouseMove);
            this.leftBox.MouseLeave+=new EventHandler(leftBox_MouseLeave);
            //this.leftBox.Click+=new EventHandler(leftBox_Click);
            this.rightBox.BackColor = Color.Transparent;
            this.rightBox.BackgroundImage = Image.FromFile("..//..//res//cars//right.gif");
            this.rightBox.MouseMove += new MouseEventHandler(rightBox_MouseMove);
            this.rightBox.MouseLeave += new EventHandler(rightBox_MouseLeave);
           // this.rightBox.Click+=new EventHandler(rightBox_Click);


                 this.viseCarBox1.BackColor = Color.Transparent;
                 this.viseCarBox2.BackColor = Color.Transparent;
                this.viseCarBox1.BackgroundImage = Image.FromFile("..//..//res//cars//car1.gif");
                this.viseCarBox2.BackgroundImage = Image.FromFile("..//..//res//cars//car2.gif");

                //carSpeed.Enabled = true;

                this.beginBtn.BackColor = Color.Transparent;
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
                this.beginBtn.MouseMove+=new MouseEventHandler(beginBtn_MouseMove);
                this.beginBtn.MouseLeave+=new EventHandler(beginBtn_MouseLeave);
                this.beginBtn.Click += new EventHandler(beginToolStripMenuItem_Click);

                this.informLabel.BackColor = Color.Transparent;
                this.informLabel.ForeColor = Color.Red;
                this.informLabel.Text = "";

                this.slowToolStripMenuItem.Checked = true;
                this.stopToolStripMenuItem.Enabled = false;

                this.helpLabel.BackColor = Color.Transparent;
                this.helpLabel.ForeColor = Color.Red;
                this.helpLabel.Text = "";

                this.BackColor = Color.SeaGreen;
                
        }//form_load
        private void CallBackBtn_MouseMove(object sender, EventArgs e)
        {
            this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou2.gif");
        }
        private void CallBackBtn_MouseLeave(object sender, EventArgs e)
        {
            this.CallBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
        }
        private void rightBox_MouseMove(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = Color.Orange;

            carMoveSpeed.Enabled = true;
            moveDirect = carMoveDirect.right;
        }
        private void rightBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = Color.Transparent;

            carMoveSpeed.Enabled = false;
            
        }

        private void leftBox_MouseMove(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = Color.Orange;

            carMoveSpeed.Enabled = true;
            moveDirect = carMoveDirect.left;
        }
        private void leftBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = Color.Transparent;

            carMoveSpeed.Enabled = false;
        }
        private void beginBtn_MouseMove(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (appStatus == gameStatus.stop)
            {
                pic.BackgroundImage = Image.FromFile("..//..//res//cars//begin2.jpg");
            }
            else
            {
                pic.BackgroundImage = Image.FromFile("..//..//res//cars//stop2.gif");
            }
        }
        private void beginBtn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            if (appStatus == gameStatus.stop)
            {
                pic.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
            }
            else
            {
                pic.BackgroundImage = Image.FromFile("..//..//res//cars//stop1.jpg");
            }
        }
       


        private void carMoveSpeed_Tick(object sender, EventArgs e)
        {
            if (this.appStatus == gameStatus.run&&this.mainCarStatus==carStatus.live)
            {
                if (moveDirect == carMoveDirect.left)
                {
                    if (this.mainCarlBox.Left > -15 && isContinue(carMoveDirect.left))
                    {
                        this.mainCarlBox.Left -= 2;
                    }


                }

                if (moveDirect == carMoveDirect.right)
                {
                    if (this.mainCarlBox.Left < this.roadPanel.Width - 40 && isContinue(carMoveDirect.right))
                    {
                        this.mainCarlBox.Left += 2;
                    }

                }

                ModifyStatus();
            }

        }//carMoveSpeed_Tick
        int p=0;
        private void carSpeed_Tick(object sender, EventArgs e)
        {
            
                this.viseCarBox1.Top += 2;
                this.viseCarBox2.Top += 2;
            

           if (this.viseCarBox1.Top +this.viseCarBox1.Height > this.mainCarlBox.Top+6)
            { 
                for(int i=0;i<3;i++)
                {
                    if(Area1[i]==areaStatus.full&&areaMainTo[i]==areaStatus.full)
                    {
                        this.carSpeed.Enabled=false;
                        this.mainCarStatus = carStatus.dead;
                        this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
                        this.appStatus=gameStatus.stop;
                        declear_Dead();
                        break;
                    }
                   
                    if(Area1[i]==areaStatus.full)
                        {
                            toMainArea[i]=areaStatus.full;
                        }


                }//for
            }//if

           if (this.viseCarBox2.Top + this.viseCarBox2.Height > this.mainCarlBox.Top+6)
           {
               for (int i = 0; i < 3; i++)
               {
                   if (Area2[i] == areaStatus.full && areaMainTo[i] == areaStatus.full)
                   {
                       this.carSpeed.Enabled = false;
                       this.mainCarStatus = carStatus.dead;
                       this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
                       this.appStatus = gameStatus.stop;
                       declear_Dead();
                       break;
                   }
                   
                   if (Area2[i] == areaStatus.full)
                   {
                       toMainArea[i] = areaStatus.full;
                   }


               }//for
           }//if

           if (this.viseCarBox1.Top >= this.roadPanel.Height)
           {
               for (int i = 0; i < 3; i++)
               {
                   if (Area1[i] == areaStatus.full)
                   {
                       toMainArea[i] = areaStatus.empty;
                       Area1[i] = areaStatus.empty;
                   }
               }

               Random rd = new Random();
               int k = rd.Next(0, 2);

               Area1[k] = areaStatus.full;

               int carOrder = rd.Next(1, 3);
               this.viseCarBox1.BackgroundImage = Image.FromFile("..//..//res//cars//car" + carOrder.ToString() + ".gif");

               this.viseCarBox1.Left = k * this.roadPanel.Width / 3;
               if(k==1)
                   this.viseCarBox1.Left = k * this.roadPanel.Width / 3+7;
               this.viseCarBox1.Top=0-this.viseCarBox1.Height;

           }
           if (this.viseCarBox2.Top >= this.roadPanel.Height)
           {
               for (int i = 0; i < 3; i++)
               {
                   if (Area2[i] == areaStatus.full)
                   {
                       toMainArea[i] = areaStatus.empty;
                       Area2[i] = areaStatus.empty;
                   }
               }

               Random rd = new Random();
               int k = rd.Next(0, 3);

               Area2[k] = areaStatus.full;

               int carOrder = rd.Next(1, 3);
               this.viseCarBox2.BackgroundImage = Image.FromFile("..//..//res//cars//car" + carOrder.ToString() + ".gif");

               this.viseCarBox2.Left = k * this.roadPanel.Width / 3;
               if(k==1)
                   this.viseCarBox2.Left = k * this.roadPanel.Width / 3+7;
               this.viseCarBox2.Top = 0 - this.viseCarBox2.Height; ;
           }

            
            //this.label1.Text = p++.ToString();
        }//Tick

        private void ModifyStatus()
        {
            if (mainCarlBox.Left + 15 >= this.roadPanel.Width / 3 * 2)
            {
                this.areaMainTo[2] = areaStatus.full;
                this.areaMainTo[1] = areaStatus.empty;
                this.areaMainTo[0] = areaStatus.empty;

            }

            if (mainCarlBox.Left + 35 > this.roadPanel.Width / 3 * 2&&mainCarlBox.Left+15<this.roadPanel.Width/3*2)
            {
                this.areaMainTo[2] = areaStatus.full;
                this.areaMainTo[1] = areaStatus.full;
                this.areaMainTo[0] = areaStatus.empty;

            }

            if (mainCarlBox.Left + 15 >= this.roadPanel.Width / 3 && mainCarlBox.Left + 35 <= this.roadPanel.Width / 3 * 2)
            {
                this.areaMainTo[1] = areaStatus.full;
                this.areaMainTo[0] = areaStatus.empty;
                this.areaMainTo[2] = areaStatus.empty;

            }
            if (mainCarlBox.Left + 15 < this.roadPanel.Width / 3 && mainCarlBox.Left + 35 > this.roadPanel.Width / 3)
            {
                this.areaMainTo[0] = areaStatus.full;
                this.areaMainTo[1] = areaStatus.full;
                this.areaMainTo[2] = areaStatus.empty;

            }
            if (mainCarlBox.Left+35 <= this.roadPanel.Width / 3)
            {
                this.areaMainTo[0] = areaStatus.full;
                this.areaMainTo[1] = areaStatus.empty;
                this.areaMainTo[2] = areaStatus.empty;

            }
        }//ModifyStatus

        private bool isContinue(carMoveDirect d)
        {
            if (d == carMoveDirect.left)
            {
                if ((this.mainCarlBox.Left + 35 >= this.roadPanel.Width / 3 * 2 && this.mainCarlBox.Left + 13 <= this.roadPanel.Width / 3 * 2) && this.toMainArea[1] == areaStatus.full)
                    return false;
                if (this.mainCarlBox.Left + 13 <= this.roadPanel.Width / 3 && this.mainCarlBox.Left + 35 > this.roadPanel.Width / 3 && this.toMainArea[0] == areaStatus.full)
                    return false;
                return true;
            }
            if (d == carMoveDirect.right)
            {
                if ((this.mainCarlBox.Left + 37 >= this.roadPanel.Width / 3 * 2 && this.mainCarlBox.Left + 15 <= this.roadPanel.Width / 3 * 2) && this.toMainArea[2] == areaStatus.full)
                    return false;
                if ((this.mainCarlBox.Left + 37 >= this.roadPanel.Width / 3 && this.mainCarlBox.Left + 15 <= this.roadPanel.Width / 3) && this.toMainArea[1] == areaStatus.full)
                    return false;
                return true;
            }
            return false;
        }//iscontinue

        private void InitApp()
        {
            toMainArea = new areaStatus[3] { areaStatus.empty, areaStatus.empty, areaStatus.empty };
            Area1 = new areaStatus[3] { areaStatus.full, areaStatus.empty, areaStatus.empty };
            Area2 = new areaStatus[3] { areaStatus.empty, areaStatus.empty, areaStatus.full };
            areaMainTo = new areaStatus[3] { areaStatus.empty, areaStatus.full, areaStatus.empty };

            this.viseCarBox1.Left = 2;
            this.viseCarBox1.Top = this.initTop1;
            this.viseCarBox2.Top = this.initTop2;
            this.viseCarBox2.Left = this.roadPanel.Width / 3 * 2 + 3;
            this.mainCarlBox.Left = this.roadPanel.Width / 3 + 3;

            //this.carSpeed.Enabled = true;
            appStatus=gameStatus.stop;
            mainCarStatus = carStatus.live;

            this.informLabel.Text = "";



        }

        private void declear_Dead()
        {
            this.informLabel.Text = "你挂掉了！！";
            this.beginToolStripMenuItem.Enabled= true;
            this.stopToolStripMenuItem.Enabled= false;
        }

        private void beginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainCarStatus == carStatus.live)
            {
                if (this.appStatus == gameStatus.stop)
                {
                    this.appStatus = gameStatus.run;
                    this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//stop1.jpg");
                    this.carSpeed.Enabled = true;
                    this.beginToolStripMenuItem.Enabled = false;
                    this.stopToolStripMenuItem.Enabled = true;
                }
                else
                {
                    this.appStatus = gameStatus.stop;
                    this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
                    this.carSpeed.Enabled = false;
                    this.stopToolStripMenuItem.Enabled = false;
                    this.beginToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                MessgeForm f = new MessgeForm("你已死亡，确定要重新开始游戏吗?", this.Owner);

                DialogResult result = f.ShowDialog();

                if (result == DialogResult.OK)
                {
                    InitApp();
                }
            }
        }//click

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.appStatus = gameStatus.stop;
            this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
            this.carSpeed.Enabled = false;
            this.stopToolStripMenuItem.Enabled = false;
            this.beginToolStripMenuItem.Enabled = true;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carMoveSpeed.Interval = 50;
            carSpeed.Interval = 100;
            slowToolStripMenuItem.Checked = true;
            normalToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = false;

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carMoveSpeed.Interval = 30;
            carSpeed.Interval = 60;
            slowToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = true;
            fastToolStripMenuItem.Checked = false;
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carMoveSpeed.Interval = 10;
            carSpeed.Interval = 20;
            slowToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            fastToolStripMenuItem.Checked = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.helpToolStripMenuItem.Checked == false)
            {
                this.helpToolStripMenuItem.Checked = true;
                string helpStr = "操作说明:\n\n将鼠标移动到\n\n游戏框右边的\n\n左右箭头上以\n\n使赛车移动\n\n"+
                    "点击方向箭头\n\n下方图标或选\n\n择菜单栏开始\n\n或暂停游戏";
                this.helpLabel.Text = helpStr;
            }
            else 
            {
                this.helpToolStripMenuItem.Checked = false;
                this.helpLabel.Text = "";
            }
        }

        

    }
}
