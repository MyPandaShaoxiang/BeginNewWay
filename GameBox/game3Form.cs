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
    //enum category {box=0, worm,pet,sectary,jew,equip};
    enum cateName { 宝箱=0,虫子,宠物,秘籍,首饰,装备,房子};
    enum Status{dead,live,cont};
    struct findObj
    {
        public cateName  Name;
        public int       Num;
    };
    public partial class game3Form : Form
    {
        public game3Form(Form1 f)
        {
            InitializeComponent();

            this.Owner = f;

            picBoxs = new PictureBox[24];
            picCate = new cateName[24];

            objArray = new findObj[3];
            cateNum = new int[7]{0,0,0,0,0,0,0};
            curOrder = 0;
            curTime = 12;

            curStatus = Status.live;

            gameSpeed = new Timer();
            gameSpeed.Interval = 600;

            timeStatus = gameStatus.run;
        }
        #region
        private Form1 Owner;
        private PictureBox[] picBoxs;
        private cateName[] picCate;
        private findObj[]  objArray;
        private int[] cateNum;
        private int curNum;
        private int curOrder;
        private int curTime;
        private Status curStatus;
        private Timer gameSpeed;
        private gameStatus timeStatus;
        #endregion

        private void game3Form_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.SeaGreen;

            this.callBackBtn.BackColor = Color.Transparent;
            this.callBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
            this.callBackBtn.MouseMove += new MouseEventHandler(callBackBtn_MouseMove);
            this.callBackBtn.MouseLeave += new EventHandler(callBackBtn_MouseLeave);

            this.picPanel.BackgroundImage = Image.FromFile("..//..//res//pictures//bk.png");
            //this.picPanel.HorizontalScroll.Visible = true; 

            this.objNameLabel.BackColor = Color.Transparent;
            this.objNameLabel.ForeColor = Color.Red;
            this.objNumLabel.BackColor = Color.Transparent;
            this.objNumLabel.ForeColor = Color.Orange;

            this.informLabel.BackColor = Color.Transparent;
            this.ForeColor = Color.Red;
            this.informLabel.Text = null;

            this.timeLabel.BackColor = Color.Transparent;
            this.timeLabel.ForeColor = Color.Red;
            this.timeLabel.Text = null;

            this.gameSpeed.Tick+=new EventHandler(gameSpeed_Tick);
            
           this.timeLabel.Text = "00:" + curTime.ToString();

            this.beginBtn.BackColor = Color.Transparent;
            this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
            this.beginBtn.MouseMove+=new MouseEventHandler(beginBtn_MouseMove);
            this.beginBtn.MouseLeave+=new EventHandler(beginBtn_MouseLeave);


            for (int i = 0; i < 24; i++)
            {
                this.picBoxs[i] =(PictureBox)this.picPanel.Controls[23-i];
                //MessageBox.Show(picBoxs[i].Name);
                this.picBoxs[i].BackColor = Color.Transparent;
                this.picBoxs[i].Click+=new EventHandler(picBox_Click);
                
            }

            

            initApp();
            generObj();

            this.gameSpeed.Enabled = false;
            this.timeStatus = gameStatus.stop;
            this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");

            this.objNameLabel.Text = this.objArray[0].Name + " ×";
            this.objNumLabel.Text = this.objArray[0].Num.ToString();

            this.curNum = this.objArray[curOrder].Num;
           
            

            

        }
        private void callBackBtn_MouseMove(object sender, EventArgs e)
        {
            this.callBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou2.gif");
        }
        private void callBackBtn_MouseLeave(object sender, EventArgs e)
        {
            this.callBackBtn.BackgroundImage = Image.FromFile("..//..//res//jiantou1.gif");
        }

        private void callBackBtn_Click(object sender, EventArgs e)
        {
            this.Owner.panel_Run(1, this);
        }

        private void beginBtn_MouseMove(object sender, EventArgs e)
        {
            if (this.timeStatus == gameStatus.run)
            {
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//stop2.gif");
            }
            else
            {
                
                    this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin2.jpg");
                
            }
        }
        private void beginBtn_MouseLeave(object sender, EventArgs e)
        {
            if (this.timeStatus == gameStatus.run)
            {
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//stop1.jpg");
            }
            else
            {
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
            }
        }


        private void gameSpeed_Tick(object sender, EventArgs e)
        {
            curTime--;

            showTime(curTime);

            if (curTime <= 0)
            {
                this.informLabel.Text = "你输了!!";
                this.objNameLabel.Text = "";
                this.objNumLabel.Text = "";
                this.gameSpeed.Enabled = false;
                this.timeLabel.Text = "";
                this.curStatus = Status.dead;
                this.timeStatus = gameStatus.stop;
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");
               
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (this.curStatus == Status.live&&this.timeStatus==gameStatus.run)
            {
                PictureBox pic = (PictureBox)sender;
                int order = Array.IndexOf(picBoxs, pic);

                cateName name = objArray[curOrder].Name;

                if (picCate[order] == name)
                {
                    this.curTime += 1;
                    showTime(curTime);
                    pic.BackgroundImage = null;
                    curNum--;
                    if (curNum == 0)
                    {
                        if (curOrder + 1 != 3)
                        {
                            curOrder++;
                            curNum = this.objArray[curOrder].Num;
                            this.objNameLabel.Text = this.objArray[curOrder].Name + " ×";
                            this.objNumLabel.Text = curNum.ToString();

                        }
                        else
                        {
                            this.informLabel.Text = "你赢啦！！";
                            this.objNameLabel.Text = "";
                            this.objNumLabel.Text = "";
                            this.gameSpeed.Enabled = false;
                            this.timeLabel.Text = "";
                            this.curStatus = Status.cont;
                            this.timeStatus = gameStatus.stop;
                            this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");


                        }
                    }
                    else
                    {
                        this.objNumLabel.Text = curNum.ToString();
                    }
                }//if_name
                else 
                {
                    this.curTime -= 2;
                    showTime(curTime);

                }
            }//if_status
        }

        private void initApp()
        {
            Random rd = new Random();
            int num = 0;
            string fix = "";
            for (int i = 0; i < 7; i++)
                cateNum[i] = 0;

                for (int i = 0; i < 24; i++)
                {
                    int f = rd.Next(0, 4);

                    if (f == 0)
                    {
                        this.picBoxs[i].BackgroundImage = null;
                    }
                    else
                    {
                        int k = rd.Next(0, 7);
                        switch (k)
                        {
                            case 0:
                                num = 5;
                                fix = ".png";
                                break;
                            case 1:
                                num = 4;
                                fix = ".ico";
                                break;
                            case 2:
                                num = 10;
                                fix = ".ico";
                                break;
                            case 3:
                                num = 5;
                                fix = ".png";
                                break;
                            case 4:
                                num = 4;
                                fix = ".gif";
                                break;
                            case 5:
                                num = 10;
                                fix = ".png";
                                break;
                            case 6:
                                num = 5;
                                fix = ".ico";
                                break;
                            default:
                                break;
                        }

                        int key = rd.Next(0, num);

                        this.picBoxs[i].BackgroundImage = Image.FromFile("..//..//res//pictures//0" + k.ToString() +
                            "//0" + key.ToString() + fix);
                        this.picCate[i] = (cateName)k;
                        cateNum[k]++;

                    }//else
                }//for

            //initial some flags
                curStatus = Status.live;
                curOrder = 0;
                curTime = 10;
                this.gameSpeed.Enabled = true;
                this.timeStatus = gameStatus.run;
                this.informLabel.Text = "";
                this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//stop1.jpg");
            

        }//init

        private void generObj()
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < 7; i++)
                temp.Add(i);
            Random rd = new Random();

            int f=7;
            int m = 0;
            while(m<3)
            {
                int k = rd.Next(0, f);
                int key=temp[k];

                int num =0;
                if (cateNum[key] != 0)
                {
                    num = rd.Next(1, cateNum[key]);
                    this.objArray[m].Name = (cateName)key;
                    this.objArray[m].Num = num;
                    m++;
                }
                
                temp.RemoveAt(k);

                f--;

            }

        }//gener

        private void beginBtn_Click(object sender, EventArgs e)
        {
            if (this.curStatus == Status.live)
            {
                if (this.timeStatus == gameStatus.run)
                {
                    this.gameSpeed.Enabled = false;
                    this.timeStatus = gameStatus.stop;
                    this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//begin1.jpg");

                }
                else
                {
                    this.gameSpeed.Enabled = true;
                    this.timeStatus = gameStatus.run;
                    this.beginBtn.BackgroundImage = Image.FromFile("..//..//res//cars//stop1.jpg");
                }
            }
                
            else 
            {
                if(this.curStatus == Status.dead)
                {
                    MessgeForm f = new MessgeForm("你输掉了，确定要重新开始游戏吗?", this.Owner);

                    DialogResult result = f.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        initApp();
                        generObj();
                        this.objNameLabel.Text = this.objArray[0].Name + " ×";
                        this.objNumLabel.Text = this.objArray[0].Num.ToString();

                        this.curNum = this.objArray[curOrder].Num;
           
                    }
                }
                else 
                {
                    initApp();
                    generObj();
                    this.objNameLabel.Text = this.objArray[0].Name + " ×";
                    this.objNumLabel.Text = this.objArray[0].Num.ToString();

                    this.curNum = this.objArray[curOrder].Num;
                    this.timeLabel.Text = "00:" + curTime.ToString();

           
                }
            }
        }//click

        private void showTime(int curTime)
        {
            if (curTime < 10)
            {
                this.timeLabel.Text = "00:0" + curTime.ToString();
            }
            if (curTime >= 10)
            {
                this.timeLabel.Text = "00:" + curTime.ToString();
            }
        }
    }
}
