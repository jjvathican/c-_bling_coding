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
using System.Diagnostics;

namespace blindcoding
{
    public partial class Form1 : Form
    {
        int i ;
        int m ;
        int t ;
        string pass;

       
        public Form1()
        {
            //i = 60;
            //m = 1;
            //t = 0;
            //textBox1.Enabled = false;
            //button2.Enabled = false;
            //textBox2.Text = (m.ToString());
            //timebox.Enabled = false;
            //button5.Enabled = false;
            InitializeComponent();
            i = 60;
            m = 1;
            t = 0;
            pass = ".c";
            textBox1.Enabled = false;
            button2.Enabled = false;
            textBox2.Text = (m.ToString());
            timebox.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = true;
            tabcontrol.Enabled = true;
            textBox3.Text = null;
            textBox1.Text = null;
            textBox3.Enabled = true;
            comboBox1.SelectedIndex = 2;

        }

        private void timebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && searchfor(textBox3.Text,pass)==false)
            {
            Timer t = new Timer();
            timer1.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Focus();
            tabcontrol.Enabled = false;
            button1.Enabled = false;
            button5.Enabled = true;
            textBox3.Enabled = false;
            m = m - 1;
            if (comboBox1.SelectedIndex == 0)
                pass = ".java";
            else
            {
                pass = ".c";
               
            }

            }

           
        }

        private void time(object sender, EventArgs e)
        {
            i = i - 1;
           
            timebox.Text = ("M:" + m + "  S:" + i);
            if (m == 0 && i == 0)
            {
                textBox1.Enabled = false;
                timebox.Enabled = false;
                timer1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                tabcontrol.Enabled = true;
                writedata(textBox3.Text,pass);
               
            }
            if (i == 0)
            {
                i = 60;
                m = m - 1;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            m = m - 1;
            textBox2.Text = (m.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m = m + 1;
            textBox2.Text = (m.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {

            writedata(textBox3.Text,pass);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            readdata(listBox1.SelectedItem.ToString());
           
        }

        private void update(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                string[] lines = System.IO.File.ReadAllLines("Hello.txt");

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                    listBox2.Items.Add(line);
                    listBox3.Items.Add(line);
                    listBox4.Items.Add(line);
                }
            }
            catch (Exception)
            {

            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            i = 60;
            m = 1;
            t = 0;
            pass = ".c";
            textBox1.Enabled = false;
            button2.Enabled = false;
            textBox2.Text = (m.ToString());
            timebox.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = true;
            tabcontrol.Enabled = true;
            textBox3.Text = null;
            textBox1.Text = null;
            textBox3.Enabled = true;
            comboBox1.SelectedIndex = 2;



	   }
        public Boolean searchfor(String a,String b)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Hello.txt");
                a = a + b;
                foreach (string line in lines)
                {
                    if (line == a)
                    {
                        return true;
                    }
                    //listBox1.Items.Add(line);
                    //listBox2.Items.Add(line);
                }
                return false;
            }
            catch(Exception)
            { return false; }
        }
        public void writedata(string a,string b)
        {
          
                TextWriter tw = new StreamWriter(textBox3.Text + b);
                // write a line of text to the file
                tw.WriteLine(textBox1.Text);
                // close the stream
                tw.Close();
                if (t == 0)
                {
                    TextWriter twc = new StreamWriter("Hello.txt", true);
                    twc.WriteLine(textBox3.Text+b);
                    twc.Close();
                }
                MessageBox.Show("DATA SAVED");
                t = t + 1;
              
         
        }
        public void readdata(String a)
        {
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = @"" + a ;
            p.StartInfo = pi;
            MessageBox.Show(pi.FileName);
            try
            {
                p.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

        
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            info.FileName = "cmd.exe";
            info.CreateNoWindow = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            p.StartInfo = info;
            p.Start();
            //p.WaitForExit();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("javac " + listBox2.SelectedItem);
                    String s= listBox2.SelectedItem.ToString();
                    s=s.Substring(0,s.IndexOf("."));
                   // MessageBox.Show(s);
                    sw.WriteLine("java " + s );
                    //sw.WriteLine("use mydb;");
                }
            }
            String line="";
            while (!p.StandardOutput.EndOfStream)
            {
                line = line + p.StandardOutput.ReadToEnd();
               
                // do something with line
            }
            MessageBox.Show(line);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            info.FileName = "cmd.exe";
            info.CreateNoWindow = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            p.StartInfo = info;
            p.Start();
            //p.WaitForExit();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    String s = listBox3.SelectedItem.ToString();
                    s = s.Substring(0, s.IndexOf("."));
                    sw.WriteLine("gcc -o " + s +" "+ s + ".c");
                    sw.WriteLine(""+s);
                    //sw.WriteLine("use mydb;");
                }
            }
            String line = "";
            while (!p.StandardOutput.EndOfStream)
            {
                line = line + p.StandardOutput.ReadToEnd();

                // do something with line
            }
            MessageBox.Show(line);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            info.FileName = "cmd.exe";
            info.CreateNoWindow = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            p.StartInfo = info;
            p.Start();
            //p.WaitForExit();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    String s = listBox4.SelectedItem.ToString();
                    s = s.Substring(0, s.IndexOf("."));
                    sw.WriteLine("g++ " + s + ".c -o " + s + ".exe");
                    sw.WriteLine("" + s);
                    //sw.WriteLine("use mydb;");
                }
            }
            String line = "";
            while (!p.StandardOutput.EndOfStream)
            {
                line = line + p.StandardOutput.ReadToEnd();

                // do something with line
            }
            MessageBox.Show(line);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
