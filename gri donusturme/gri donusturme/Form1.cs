﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gri_donusturme
{
    public partial class Form1 : Form
    {
        Bitmap kaynak, islem;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kaynak = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = kaynak;



            int en = kaynak.Width;
            int boy = kaynak.Height;

            islem = new Bitmap(en, boy);

            for (int y = 0; y < boy; y++)

            {
                for (int x = 0; x < en; x++)

                {


                    Color Renk = kaynak.GetPixel(x, y);
                    int gri = (Renk.R * 30 + Renk.G * 59 + Renk.B * 11);
                    gri = gri / 100;
                    Color grirenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, grirenk);



                }
            }
            pictureBox2.Image = islem;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kaynak = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = kaynak;



            int en = kaynak.Width;
            int boy = kaynak.Height;

            islem = new Bitmap(en, boy);

            for (int y = 0; y < boy; y++)

            {
                for (int x = 0; x < en; x++)

                {


                    Color Renk = kaynak.GetPixel(x, y);
                    int gri = (Renk.R * 21250 + Renk.G * 71540 + Renk.B * 72);
                    gri = gri / 100000;
                    Color grirenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, grirenk);



                }
            }
            pictureBox2.Image = islem;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kaynak = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = kaynak;



            int en = kaynak.Width;
            int boy = kaynak.Height;

            islem = new Bitmap(en, boy);

            for (int y = 0; y < boy; y++)

            {
                for (int x = 0; x < en; x++)

                {


                    Color Renk = kaynak.GetPixel(x, y);
                    int gri = (Renk.R * 0 + Renk.G + Renk.B);
                    gri = gri / 2;
                    Color grirenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, grirenk);



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
