using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace клавиши_клавиатуры
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow(); // Получает текущее активное окно

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd); // Делает окно активным (отдаёт ему фо
        IntPtr lastWindow;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            if (!Directory.Exists(@"C:/Ekey")) Directory.CreateDirectory(@"C:/Ekey");
            //this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;

        }

        public string ru = "ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю.";
        public string ruS = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,";
        public string en = "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./";
        public string enS = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?";
        public bool lang = true;
        public bool shift = false;

        //клавиши на клавиатуре
        private void Esc_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            string[] buton = but.Text.Split();
            switch (buton[0])
            {
                case "<=":
                    if (richTextBox1.Text == null)
                        richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                    break;
                case "___":
                    //Clipboard.SetText("Твой текст");
                    //SendKeys.SendWait("^v");
                    richTextBox1.Text += " ";
                    //IntPtr currentWindow = GetForegroundWindow();
                    //Clipboard.SetText("Вставлено магией!");
                    //SetForegroundWindow(currentWindow);
                    //SendKeys.SendWait("^v");



                    //lastWindow = GetForegroundWindow();
                    //Clipboard.SetText("Вставлено магией!");
                    //SetForegroundWindow(lastWindow); // вернули фокус в предыдущее окно
                    //SendKeys.SendWait("^v");
                    break;
            }
            try
            {
            //ru
            if (lang && !shift) richTextBox1.Text += ru[enS.IndexOf(buton[0])];
            //en
            else if (!lang && !shift) richTextBox1.Text += en[enS.IndexOf(buton[0])];
            //ru + Shift
            else if (lang && shift) richTextBox1.Text += ruS[enS.IndexOf(buton[0])];
            //en + Shift
            else if (!lang && shift) richTextBox1.Text += enS[enS.IndexOf(buton[0])];
            }
            catch (System.IndexOutOfRangeException)
            {
                //MessageBox.Show("да не назначена клавиша: " + but.Text);
                File.AppendAllText(@"C:/Ekey/logs.log", DateTime.Now + ": да не назначена клавиша: " + but.Name + "\n");
            }


        }



// ==> сделать когда - нибудь ввод с клавиатуры что бы было, но врятли
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            string keyy = key.ToString().ToLower();
            //MessageBox.Show(keyy);

            try 
            {
                //Controls[keyy].PerformClick();
                Button but = Controls[keyy] as Button;
                File.AppendAllText(@"C/:Ekey/tap.tap", but.Name);
            }
            catch (System.NullReferenceException)
            {
                File.AppendAllText(@"C:/Ekey/logs.log", DateTime.Now + ": " + "Программа не нашла клавишу: " + key.ToString() + "\n");
            }

        }


//ru => en переключаетль языка 
        private void rh_Click(object sender, EventArgs e)
        {
            if (lang)
            {
                rh.Text = "en";
                lang = false;
            }
            else
            {
                rh.Text = "ru";
                lang = true;
            }  
        }



//Shift
        private void shift_left_Click(object sender, EventArgs e)
        {
            if (shift)
            {
                RightShift.BackColor = SystemColors.ControlText; 
                shift_left.BackColor = SystemColors.ControlText;
                shift = false;
            }
            else
            { 
                RightShift.BackColor = SystemColors.Highlight;
                shift_left.BackColor = SystemColors.Highlight;
                shift = true;
            }
        }
    }
}
