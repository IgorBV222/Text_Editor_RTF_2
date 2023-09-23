using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Text_Editor_RTF_2
{
    public partial class Form2 : Form
    {
        internal RichTextBox richTextBoxMain;

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //хотел сделать одну функцию
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (System.Windows.Forms.Button)sender;
            string btnTag = btn.Tag.ToString();
            RichTextBox rtb = new RichTextBox();
            rtb.Name = ("textBox" + btnTag);
            richTextBox1.Text = rtb.Text;           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox2.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox3.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox4.Text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox5.Text;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox6.Text;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox7.Text;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox8.Text;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox9.Text;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox10.Text;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox11.Text;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox12.Text;
        }
        private void addToText_Click(object sender, EventArgs e)
        {
           richTextBoxMain.Text += richTextBox1.Text;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {            
            this.Close();
            this.Hide();
        }
    }
}
