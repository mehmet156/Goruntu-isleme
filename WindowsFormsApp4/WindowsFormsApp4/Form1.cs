using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        Bitmap kaynak,islem;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int en = kaynak.Width;
            int boy = kaynak.Height;

            islem = new Bitmap(en, boy);

            for(int x=0;x<boy;x++)

            {
                for(int y=0;y<en;y++)

                {


                    Color Renk = kaynak.GetPixel(x, y);
                    int gri = (Renk.R * 30 + Renk.G * 59 + Renk.B * 11);
                    gri = gri / 100;
                    Color grirenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel (x, y, grirenk);



                }
            }
            pictureBox2.Image = islem;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
