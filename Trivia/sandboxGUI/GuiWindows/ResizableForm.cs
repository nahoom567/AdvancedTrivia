using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandboxGUI
{
    public partial class ResizableForm : Form
    {
        private Rectangle[] controlOriginalRectangles;
        private Rectangle originalFormSize;

        public ResizableForm()
        {
            InitializeComponent();
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
        }

        private void ResizableForm_Load(object sender, EventArgs e)
        {
            SetLocation();
            controlOriginalRectangles = new Rectangle[this.Controls.Count];
            int count = 0;
            foreach (Control control in this.Controls)
            {
                controlOriginalRectangles[count] = new Rectangle(control.Location.X, control.Location.Y, control.Width, control.Height);
                count++;
            }
        }
        private void ResizableForm_Resize(object sender, EventArgs e)
        {
            int count = 0;

            int i = this.Controls.Count;
            foreach (Control control in this.Controls)
            {
                Helper.resizeControl(controlOriginalRectangles[count], control, originalFormSize, this);
                count++;
            }
        }

        protected virtual void SetLocation()
        {

        }
    }
}
