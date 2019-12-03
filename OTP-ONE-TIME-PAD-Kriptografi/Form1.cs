using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTP_ONE_TIME_PAD_Kriptografi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
        String SifreliMetin;

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == textBox2.Text.Length)
            {
                String text = textBox1.Text.ToString();
                String sifre = textBox2.Text.ToString();

                Char[] Atext = text.ToCharArray();
                Char[] Asifre = sifre.ToCharArray();

                Char[] AsifreliMetin = new char[Atext.Length];

                for (int i = 0; i < Atext.Length; i++)
                {
                    AsifreliMetin[i] = Convert.ToChar(Convert.ToInt32(Atext[i]) ^ Convert.ToInt32(Asifre[i]));
                }

                SifreliMetin = new String(AsifreliMetin);
                textBox3.Text = Convert.ToString(SifreliMetin);
            }
            else
            {
                textBox3.Text = "Lütfen Şifrelenecek Metin ve Şifreyi aynı uzunlukta giriniz. (" + textBox1.Text.Length +")" ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Length == textBox5.Text.Length)
            {
                String text = textBox4.Text.ToString();
                String sifre = textBox5.Text.ToString();

                Char[] Atext = text.ToCharArray();
                Char[] Asifre = sifre.ToCharArray();

                Char[] AsifreliMetin = new char[Atext.Length];

                for (int i = 0; i < Atext.Length; i++)
                {
                    AsifreliMetin[i] = Convert.ToChar(Convert.ToInt32(Atext[i]) ^ Convert.ToInt32(Asifre[i]));
                }

                SifreliMetin = new String(AsifreliMetin);
                textBox6.Text = Convert.ToString(SifreliMetin);
            }
            else
            {
                textBox6.Text = "Lütfen Şifrelenmiş Metin ve Şifreyi aynı uzunlukta giriniz. (" + textBox4.Text.Length + ")";
            }
            
        }
    }
}
