using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class CustomButton : System.Windows.Forms.Button
    {
        public CustomButton()
        {
            this.BackColor = Color.FromArgb(173, 216, 230, 255);
            this.ForeColor = Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Arial", 12f);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderRadius = 10;
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(0, 0, this.Width, this.Height));
            this.Region = new Region(path);
        }


    }
}
