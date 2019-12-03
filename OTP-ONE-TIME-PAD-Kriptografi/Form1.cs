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
        //Global variables
        String randomSifre, text, sifre;
        List<Char> ASCII = new List<Char>();
        Random rnd = new Random();

        int random;

        public Form1()
        {
            InitializeComponent();
        }

        //Reset Password texts near the textbox
        public void textBoxLengthTemizle()
        {
            textBox1Length.Text = "";
            textBox2Length.Text = "";
            textBox4Length.Text = "";
            textBox5Length.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            textBoxLengthTemizle();

            //Creating ASCII array with characters
            for (int i = 0; i < 256; i++)
            {
                ASCII.Add((char)i);
            }
        }
        String SifreliMetin;

        private void button1_Click(object sender, EventArgs e)
        {
            //We can't global this two, because we want it to work everytime we press the button
            text = textBox1.Text.ToString();
            sifre = textBox2.Text.ToString();

            if (textBox1.Text.Length == textBox2.Text.Length)
            {
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
                textBox3.Text = "Lütfen Şifrelenmiş Metin ve Şifreyi aynı uzunlukta giriniz. (" + textBox1.Text.Length + ")";
            }

            textBox1Length.Text = "(" + textBox1.Text.Length + ")";
            textBox2Length.Text = "(" + textBox2.Text.Length + ")";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text = textBox1.Text.ToString();
            //Creating random password between 33. and 122. (including 33 and 122) values of ASCII table
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                random = rnd.Next(33, 122);
                randomSifre += ASCII[random].ToString();
            }
            sifre = randomSifre;
            textBox2.Text = randomSifre;

            //Converting strings below to Char array, because we need each char seperately to multiply them in binary form
            Char[] Atext = text.ToCharArray();
            Char[] Asifre = sifre.ToCharArray();
            Char[] AsifreliMetin = new char[Atext.Length];

            //This is the logic behind;
            //This algorihm getting each char of text and password and converting them to decimal values in ASCII table
            //After that it multiplying this two variable's binary value in XOR gate(using ^ for this in C#) 
            //and finally converting this final value to char and equals this value to encyrptedText's i. value
            //For example; text is A and password is a
            //F's Decimal value in ASCII table is 70, 70 means 1000110 in binary
            //b's Decimal value in ASCII table is 98, 98 means 1100010 in binary
            //If we multiply this two value in XOR(if two of them same, write 0, if two of them diffrent write 1 for each digit)
            //We get 100100‬ in binary, which means 36 in Decimal and it equals $ in ASCII table
            //it equals this char to encyrptedText's i. value and that's it.
            for (int i = 0; i < Atext.Length; i++)
            {
                AsifreliMetin[i] = Convert.ToChar(Convert.ToInt32(Atext[i]) ^ Convert.ToInt32(Asifre[i]));
            }

            //Putting values to appropriate locations
            SifreliMetin = new String(AsifreliMetin);
            textBox3.Text = Convert.ToString(SifreliMetin);
            textBox1Length.Text = "(" + textBox1.Text.Length + ")";
            textBox2Length.Text = "(" + textBox2.Text.Length + ")";
            //We are using this because we need to reset this value after use it again, or else it will add new password end to it. 
            randomSifre = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == textBox5.Text.Length)
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
            textBox4Length.Text = "(" + textBox4.Text.Length + ")";
            textBox5Length.Text = "(" + textBox5.Text.Length + ")";

        }

        //Make black all textBoxLabel's in same time
        public void labelColorClear()
        {
            textBox1Label.ForeColor = Color.Black;
            textBox2Label.ForeColor = Color.Black;
            textBox3Label.ForeColor = Color.Black;
            textBox4Label.ForeColor = Color.Black;
            textBox5Label.ForeColor = Color.Black;
            textBox6Label.ForeColor = Color.Black;
        }

        //This 6 methods below requied to copy textboxes values to clipboard to make process easy
        private void textBox1Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text != null)
            {
                Clipboard.SetText(textBox1.Text);
                labelColorClear();
                textBox1Label.ForeColor = Color.Blue;
            }
        }

        private void textBox2Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text != null)
            {
                Clipboard.SetText(textBox2.Text);
                labelColorClear();
                textBox2Label.ForeColor = Color.Blue;
            }
        }

        private void textBox3Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text != null)
            {
                Clipboard.SetText(textBox3.Text);
                labelColorClear();
                textBox3Label.ForeColor = Color.Blue;
            }
        }

        private void textBox4Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text != null)
            {
                Clipboard.SetText(textBox4.Text);
                labelColorClear();
                textBox4Label.ForeColor = Color.Blue;
            }
        }

        private void textBox5Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text != null)
            {
                Clipboard.SetText(textBox5.Text);
                labelColorClear();
                textBox5Label.ForeColor = Color.Blue;
            }
        }

        private void textBox6Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text != null)
            {
                Clipboard.SetText(textBox6.Text);
                labelColorClear();
                textBox6Label.ForeColor = Color.Blue;
            }
        }
    }
}
