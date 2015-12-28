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
    public partial class MessgeForm : Form
    {
        public MessgeForm(string str,Form f)
        {
            InitializeComponent();
            this.msg = str;
            this.Text = "GameBox_通知";
            this.owner = f;
        }
        #region
        private string msg;
        private Form owner;

        #endregion

        private void MessgeForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("..//..//res//bk3.jpg");

            this.label1.Text=msg;
            this.label1.BackColor = Color.Transparent;

            this.StartPosition = FormStartPosition.Manual;
            int x = this.owner.Left + 60;
            int y = this.owner.Top + 80;
            this.Location = new Point(x, y);

            this.okBtn.PenColor = Color.Black;
            this.okBtn.ForeColor = Color.Black;
            this.okBtn.BackColor = Color.Plum;
            this.cancelBtn.PenColor = Color.Black;
            this.cancelBtn.ForeColor = Color.Black;
            this.cancelBtn.BackColor = Color.Plum;
           
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            this.Close();
        }
    }
}
