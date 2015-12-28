using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyControls
{
   
        class OvalButton : Label
        {
            public OvalButton()
                : base()
            {


                this.captureForeColor = Color.White;
                this.capturePenColor = Color.Gold;




            }
            protected override void OnCreateControl()
            {
                base.OnCreateControl();

            }
            #region
            private Color penColor = Color.Black;
            private int penWidth = 1;
            private Color captureForeColor;
            private Color captureBackColor;
            private Color capturePenColor;
            private Color tempBackColor;
            private Color tempForeColor;
            private Color tempPenColor;
            private bool Flag = true;
            private bool Flag2 = true;
            private Color BtnBackColor;



            public Color PenColor
            {
                set
                {
                    penColor = value;
                }
                get
                {
                    return penColor;
                }
            }
            public int PenWidth
            {
                set
                {
                    penWidth = value;
                }
                get
                {
                    return penWidth;
                }
            }
            public Color CaptureForeColor
            {
                set
                {
                    penColor = value;
                }
                get
                {
                    return captureForeColor;
                }
            }
            public Color CapturePenColor
            {
                set
                {
                    penColor = value;
                }
                get
                {
                    return capturePenColor;
                }
            }
            public Color CaptureBackColor
            {
                set
                {
                    penColor = value;
                }
                get
                {
                    return captureBackColor;
                }
            }

            #endregion

            protected override void OnPaint(PaintEventArgs pevent)
            {
                //base.OnPaint(pevent);

                Graphics btnGraphic = pevent.Graphics;

                if (Flag2)
                {
                    BtnBackColor = this.BackColor;
                    Flag2 = false;
                }

                this.BackColor = Color.Transparent;


                btnGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = pevent.ClipRectangle;
                Pen btnPen = new Pen(new SolidBrush(penColor), penWidth);

                Rectangle rect2 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
                btnGraphic.DrawEllipse(btnPen, rect2);
                btnGraphic.FillEllipse(new SolidBrush(this.BtnBackColor), rect2);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                btnGraphic.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect2, sf);

            }
            protected override void OnMouseMove(MouseEventArgs mevent)
            {
                //base.OnMouseMove(mevent);
                if (Flag)
                {
                    this.tempBackColor = this.BtnBackColor;
                    this.tempForeColor = this.ForeColor;
                    this.tempPenColor = this.PenColor;

                    this.captureBackColor = this.BtnBackColor;

                    Flag = false;
                }

                this.ForeColor = this.captureForeColor;
                this.BtnBackColor = this.captureBackColor;
                this.penColor = this.capturePenColor;

            }
            protected override void OnMouseLeave(EventArgs e)
            {
                //base.OnMouseLeave(e);
                this.ForeColor = this.tempForeColor;
                this.BtnBackColor = this.tempBackColor;
                this.PenColor = this.tempPenColor;
            }

        }
    
}
