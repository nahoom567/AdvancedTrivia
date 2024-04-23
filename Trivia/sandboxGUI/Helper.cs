using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandboxGUI
{
    class Helper
    {
        public static void resizeControl(Rectangle r, Control c, Rectangle originalFormSize, Form other)
        {
            float xRatio = (float)(other.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(other.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);


            // for the future to understand how much should the font grow
            if (c.GetType().GetProperty("Font") != null)
            {
                //float averageRatio = (xRatio + yRatio) / 2;
                //float maxFontInc = 0.1f; // Maximum font increment
                //float minFontInc = -0.1f; // Minimum font increment
                //
                //float fontInc = averageRatio - 1;
                //
                //// Adjust the font increment if it exceeds the maximum or minimum values
                //if (fontInc > maxFontInc)
                //{
                //    fontInc = maxFontInc;
                //}
                //else if (fontInc < minFontInc)
                //{
                //    fontInc = minFontInc;
                //}
                //
                //float currentFontSize = c.Font.Size;
                //float newFontSize = currentFontSize + fontInc;
                //
                //// Ensure that the new font size is not negative or zero
                //if (newFontSize > 0)
                //{
                //    c.Font = new Font(c.Font.FontFamily, newFontSize, c.Font.Style);
                //}
            }
        }
    }
}
