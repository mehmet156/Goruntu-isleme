using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.IO.Ports;

namespace goruntuodev1
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection cihazlar;
        private VideoCaptureDevice kamera;
        Bitmap kaynak;
        int i;
        int bir;
        
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (kamera.IsRunning)
            {
                kamera.Stop();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
            else
            {
                kamera = new VideoCaptureDevice(cihazlar[comboBox1.SelectedIndex].MonikerString);
                kamera.NewFrame += kamera_NewFrame;
                kamera.Start();
            }
        }
        private void kamera_NewFrame(object sender, NewFrameEventArgs eventArgs)

        {
            kaynak = (Bitmap)eventArgs.Frame.Clone();
            kaynak = new GrayscaleBT709().Apply(kaynak);
            kaynak = new Threshold(30).Apply(kaynak);
            //kaynak = new OtsuThreshold().Apply(kaynak);
            kaynak = new Invert().Apply(kaynak);
            Mirror filter = new Mirror(false, true);
            filter.ApplyInPlace(kaynak);

            
            
            BlobCounter bc = new BlobCounter();
            bc.FilterBlobs = false;
            bc.MinHeight = 10;
            bc.MinWidth = 10;
            bc.ProcessImage(kaynak);
            Rectangle[] rects = bc.GetObjectsRectangles();

            
           

            Bitmap cizim = new Bitmap(kaynak.Width, kaynak.Height);
             Graphics g = Graphics.FromImage(cizim);
             g.DrawImage(kaynak, 0, 0);
             Pen cerceve = new Pen(Color.Red, 2);
             foreach (Rectangle rect in rects)
             {
                Rectangle objectRect = rects[i];
                Graphics m = pictureBox1.CreateGraphics();

                int objectX = objectRect.X + (objectRect.Width / 2);
                int objectY = objectRect.Y + (objectRect.Height / 2);

                  g.DrawString(objectX.ToString() + "X" + objectY.ToString(), new Font("Arial", 12), Brushes.Red, new System.Drawing.Point(250, 1));
                m.DrawRectangle(cerceve, rect);





                if (objectX <= 150)

                {

                    if(objectY <= 150 && objectY>0)
                    {
                      serialPort1.Write("1");
                    }
                    

                    else if(objectY<=300 && objectY>150)
                    {
                        serialPort1.Write("2");
                    }

                    else
                    {
                        serialPort1.Write("0");
                    }


                }

                
                 else
                {
                    serialPort1.Write("0");
                }


                


            }


            g.Dispose();
            pictureBox1.Image = cizim;


            
            





        }


        


        private void Form1_Load(object sender, EventArgs e)
        {
            cihazlar = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo cihaz in cihazlar)
            {
                comboBox1.Items.Add(cihaz.Name);
            }

            kamera = new VideoCaptureDevice();



            comboBox2.DataSource = SerialPort.GetPortNames();
         
            
            button2.Enabled = true;
            

            int portSayisi = 0;
            portSayisi = comboBox2.Items.Count;
            


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kamera.IsRunning)
                kamera.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            serialPort1.BaudRate = 9600;
            serialPort1.PortName = comboBox2.SelectedItem.ToString();
            serialPort1.Open();
            if (serialPort1.IsOpen == true)
            {
                
               
                button2.Enabled = true;
                
                

            }
            else
            {
                
            }

        }

        
    }
}
