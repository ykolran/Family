using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowerWheelOfFortune
{
    public partial class Form1 : Form
    {
        int deg = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = RotateImage(global::ShowerWheelOfFortune.Properties.Resources.Down, deg);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private Image RotateImage(Image img, float angle)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(img.Width / 2.0f, img.Height / 2.0f);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-img.Width / 2.0f, -img.Height / 2.0f);
                // Draw the image on the bitmap
                g.DrawImage(img, new Point(0, 0));
            }

            return img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            Random r = new Random();
            int numOfChanges = r.Next() % 4 + 20;
            for (int i = 0; i < numOfChanges * 9; i++)
            {
                deg = (deg + 10) % 360;
                pictureBox1.Image = RotateImage(global::ShowerWheelOfFortune.Properties.Resources.Down, deg);
                 Application.DoEvents();
                Thread.Sleep(10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
