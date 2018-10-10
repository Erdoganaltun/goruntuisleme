using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageProc
{
    public partial class Form3 : Form
    {
        Bitmap kaynak, islem;
        public Form3()
        {
            InitializeComponent();
        }

        private void ortalamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);

            for (int y=0;y<yuk;y++)
            {
                for (int x=0;x<gen;x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int gri = (renkliRenk.R + renkliRenk.G + renkliRenk.B) / 3;
                    Color griRenk = Color.FromArgb(gri, gri, gri);
                    islem.SetPixel(x, y, griRenk);
                }
            }

            islemBox.Image = islem;

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG|*.png";
            DialogResult sonuc = saveFileDialog1.ShowDialog();
            ImageFormat format = ImageFormat.Png;
            if (sonuc==DialogResult.OK)
            {
                islem.Save(saveFileDialog1.FileName, format);
            }
        }

        private void bt109AlgoritmasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    double gri = (renkliRenk.R*0.2125 + renkliRenk.G*0.7154 + renkliRenk.B*0.072) ;
                    int a = (int)gri;
                    Color griRenk =Color.FromArgb(a, a, a);
                    islem.SetPixel(x, y, griRenk);
                }
            }

            islemBox.Image = islem;
        }

        private void lumaYontemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    double gri = (renkliRenk.R * 0.3 + renkliRenk.G * 0.59 + renkliRenk.B * 0.11);
                    int a = (int)gri;
                    Color griRenk = Color.FromArgb(a, a, a);
                    islem.SetPixel(x, y, griRenk);
                }
            }

            islemBox.Image = islem;
        }

        private void açıklıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    int R = renkliRenk.R;
                    int G = renkliRenk.G;
                    int B = renkliRenk.B ;
                    if (R > G)
                    {
                        if (R > B)
                        {
                            if (G > B)
                            {
                                int a = (R + B) / 2;
                                Color griRenk = Color.FromArgb(a, a, a);
                                islem.SetPixel(x, y, griRenk);
                            }
                            else
                            {
                                int a = (R + G) / 2;
                                Color griRenk = Color.FromArgb(a, a, a);
                                islem.SetPixel(x, y, griRenk);
                            }

                        }
                        else
                        {
                            int a = (B + G) / 2;
                            Color griRenk = Color.FromArgb(a, a, a);
                            islem.SetPixel(x, y, griRenk);
                        }
                    }
                    else
                    {
                        if(G>B)
                        {
                            if(B>R)
                            {
                                int a = (G+R) / 2;
                                Color griRenk = Color.FromArgb(a, a, a);
                                islem.SetPixel(x, y, griRenk);
                            }
                            else
                            {
                                int a = (G + B) / 2;
                                Color griRenk = Color.FromArgb(a, a, a);
                                islem.SetPixel(x, y, griRenk);
                            }
                        }
                        else
                        {
                            int a = (B + R) / 2;
                            Color griRenk = Color.FromArgb(a, a, a);
                            islem.SetPixel(x, y, griRenk);
                        }
                    }       
                }
            }

            islemBox.Image = islem;
        }

        private void kanalÇıkarımıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;

            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renkliRenk = kaynak.GetPixel(x, y);
                    double gri = (renkliRenk.R);
                    int a = (int)gri;
                    Color griRenk = Color.FromArgb(a, a, a);
                    islem.SetPixel(x, y, griRenk);
                }
            }

            islemBox.Image = islem;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                kaynak = new Bitmap(openFileDialog1.FileName);
                kaynakBox.Image = kaynak;
            }
        }
    }
}
