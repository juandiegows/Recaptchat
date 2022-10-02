using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recaptchat
{
    public partial class Form1 : Form
    {
        String textCaptchat = "";
        public Form1()
        {
            InitializeComponent();
        }
        private String GetTextRandom()
        {
            MD5CryptoServiceProvider mD5Crypto = new MD5CryptoServiceProvider();
            long numRandom = new Random().Next(0, 999999999);
            var byteA = mD5Crypto.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(numRandom.ToString()));
            String text = "";
            foreach (var item in byteA)
            {
                text += item.ToString("x2");
            }
            return text.Substring(6, 6);
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(p1.Width, p1.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Font font = new System.Drawing.Font("NSimSun", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            String text = GetTextRandom();
            if(int.TryParse(text, out int numRandom))
            {
                text = GetTextRandom();
            }
            textCaptchat = text;
            graphics.DrawString(text, font, Brushes.Red, new Point(0, 0));
            //graphics.DrawLine(new Pen(Brushes.Blue,2), 0, (int)(p1.Height / 2), p1.Width,(int) (p1.Height / 2));
            Random random = new Random();
            
            graphics.DrawRectangle(new Pen(Brushes.Blue, 2), random.Next(0,p1.Width-20), random.Next(0, p1.Height - 20), 20,20);
            graphics.DrawRectangle(new Pen(Brushes.Yellow, 2), random.Next(0,p1.Width-20), random.Next(0, p1.Height - 20), 20,20);
            graphics.DrawRectangle(new Pen(Brushes.OrangeRed, 2), random.Next(0,p1.Width-20), random.Next(0, p1.Height - 20), 20,20);
            graphics.DrawRectangle(new Pen(Brushes.Green, 2), random.Next(0,p1.Width-20), random.Next(0, p1.Height - 20), 20,20);
            graphics.ResetTransform();
            p1.Image = bitmap;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(textCaptchat == textBox1.Text)
            {
                MessageBox.Show("Captchat correct");
            }else
            {
                MessageBox.Show("Captchat incorrect");
            }
        }
    }
}
