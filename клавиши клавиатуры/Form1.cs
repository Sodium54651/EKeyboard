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

namespace клавиши_клавиатуры
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            if (!Directory.Exists(@"C:/Ekey")) { Directory.CreateDirectory(@"C:/Ekey"); };
        }
        




        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Esc_Click(object sender, EventArgs e)
        {
            //Button but = (Button)sender;
            //string butont = but.Tag as string;
            ////but.BackColor = Color.Aquamarine;

            //int u1 = DateTime.Now.Second;


        }


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
                //foreach (var ctrl in Controls)
                //{
                //    var btn = ctrl as Button;
                //    if (btn != null)
                //    {
                //        btn.PerformClick();
                //        richTextBox.Text = btn.Name;

                //        int t1 = DateTime.Now.Second;
                //        int t2 = DateTime.Now.Second + 20;
                //        btn.BackColor = Color.Coral;
                //        while (t1 < t2)
                //        {
                //            t1 = DateTime.Now.Second;
                //        }
                //        btn.ForeColor = Color.Black;
                //    }
                //}
            }
            catch (System.NullReferenceException)
            {
                File.AppendAllText(@"C:/Ekey/logs.log", DateTime.Now + ": " + "Программа не нашла клавишу: " + key.ToString() + "\n");
            }

        }
    }
}
