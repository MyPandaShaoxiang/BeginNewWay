using MyControls;

namespace GameBox
{
    partial class MessgeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessgeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new MyControls.OvalButton();
            this.okBtn = new MyControls.OvalButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MsgLabel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelBtn.CaptureBackColor = System.Drawing.Color.Empty;
            this.cancelBtn.CaptureForeColor = System.Drawing.Color.White;
            this.cancelBtn.CapturePenColor = System.Drawing.Color.Gold;
            this.cancelBtn.Location = new System.Drawing.Point(227, 76);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.PenColor = System.Drawing.Color.Black;
            this.cancelBtn.PenWidth = 1;
            this.cancelBtn.Size = new System.Drawing.Size(52, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.Transparent;
            this.okBtn.CaptureBackColor = System.Drawing.Color.Empty;
            this.okBtn.CaptureForeColor = System.Drawing.Color.White;
            this.okBtn.CapturePenColor = System.Drawing.Color.Gold;
            this.okBtn.Location = new System.Drawing.Point(109, 76);
            this.okBtn.Name = "okBtn";
            this.okBtn.PenColor = System.Drawing.Color.Black;
            this.okBtn.PenWidth = 1;
            this.okBtn.Size = new System.Drawing.Size(52, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "确定";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // MessgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(431, 111);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessgeForm";
            this.Text = "MessgeForm";
            this.Load += new System.EventHandler(this.MessgeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private OvalButton okBtn;
        private OvalButton cancelBtn;
    }
}