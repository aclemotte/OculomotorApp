using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LookAndPlayForm.progressbarMiguel
{
    public partial class barraHorizontal : UserControl
    {

        private Color barColor = Color.DodgerBlue;

        public barraHorizontal()
        {
            InitializeComponent();

            //this.ForeColor = SystemColors.Highlight;
            this.ForeColor = Color.White;
            this.BackColor = barColor;
        }

        public void changeColor(Color newColor)
        {
            barColor = newColor;
            this.BackColor = barColor;
        }

        protected float percent = 0.0f;

        public float value
        {
            get
            {
                return percent;
            }
            set
            {
                if (value < 0) value = 0;
                else if (value > 100) value = 100;
                percent = (100 - value);
                //label1.Text = value.ToString();
                this.Invalidate();
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Brush b = new SolidBrush(this.ForeColor);
        //    //LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.ForwardDiagonal);
        //    int width = (int)((percent / 100) * this.Width);
        //    e.Graphics.FillRectangle(b, 0 , 0 , width , this.Height);
        //    //e.Graphics.FillRectangle(lb, 0, 0 , width , this.Height);
        //    b.Dispose();
        //    //lb.Dispose();
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //this.BackColor = barColor;
            Brush b = new SolidBrush(Color.White);

            //LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.ForwardDiagonal);
            int width = (int)((percent / 100) * this.Width);
            e.Graphics.FillRectangle(b, 0, 0, width, this.Height);
            //e.Graphics.FillRectangle(lb, 0, 0 , width , this.Height);
            b.Dispose();
            //lb.Dispose();
        }       

    }
}
