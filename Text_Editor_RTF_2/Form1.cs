using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Text_Editor_RTF_2
{
    public partial class Form1 : Form
    {
        List<Paths> filenames = new List<Paths>(10);
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
           
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "RTF files(*.rtf)|*.rtf|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            richTextBoxMain.LoadFile(filename);
            MessageBox.Show($"File open:\n{filename}\n", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }   
        private void saveToXml(string path = "filenames.xml")
        {
            Paths.Serealize_it(filenames, path);
        }        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "RTF files(*.rtf)|*.rtf|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            var paths = new Paths(filename);
            // сохраняем текст в файл
            richTextBoxMain.SaveFile(filename);
            filenames.Add(paths);
            saveToXml();
            MessageBox.Show($"The result is saved to a file:\n{filename}\n", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // расширенное окно для выбора цвета
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // установка цвета формы
           // richTextBoxMain.BackColor = colorDialog1.Color;
            this.BackColor = colorDialog1.Color;
        }
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string imagePath = openFileDialog1.FileName;
            Image image = Image.FromFile(imagePath);
            this.BackgroundImage = image;
        }       

        private void insertingAnImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            Bitmap myBitmap = new Bitmap(filename);
            Clipboard.SetDataObject(myBitmap);
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            if (richTextBoxMain.CanPaste(myFormat))
            {
                richTextBoxMain.Paste(myFormat);
                return;
            }
            else
            {
                MessageBox.Show("The data format that you attempted to paste is not supported by this control.");
                return;
            }
        }
        private void fondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // добавляем возможность выбора цвета шрифта
            fontDialog1.ShowColor = true;
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // установка шрифта
            richTextBoxMain.SelectionFont = fontDialog1.Font;
            // установка цвета шрифта
            richTextBoxMain.SelectionColor = fontDialog1.Color;
        }
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // расширенное окно для выбора цвета
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // установка цвета формы
            richTextBoxMain.BackColor = colorDialog1.Color;
        }
        private void textHighlightColorToolStripMenuItem_Click(object sender, EventArgs e)
        {                    
            colorDialog1.Color = richTextBoxMain.SelectionColor;           
            if (colorDialog1.ShowDialog() == DialogResult.OK &&
               colorDialog1.Color != richTextBoxMain.SelectionColor)
            {   
                richTextBoxMain.SelectionBackColor = colorDialog1.Color; // маркер
            }
        }
        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBoxMain.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK &&
               colorDialog1.Color != richTextBoxMain.SelectionColor)
            {
                richTextBoxMain.SelectionColor = colorDialog1.Color; //меняет цвет выделенного текста                   
            }
        }
        private void allTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBoxMain.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK &&
               colorDialog1.Color != richTextBoxMain.SelectionColor)
            {                
                richTextBoxMain.ForeColor = colorDialog1.Color; // меняет цвет всего текста    
            }
        }        
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            listBoxHistory.Items.Clear();
            Paths.Deserealize_it("filenames.xml", out filenames);            
            foreach (var item in filenames)
            {
                listBoxHistory.Items.Add(item.Path);               
                listBoxHistory.Sorted = true;               
            }
        }      
        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            bool isDay = currentTime.Hour >= 6 & currentTime.Hour <= 18;
            if (isDay)
            {
                BackColor = Color.White;
                ForeColor = Color.Black;
            }
            else
            {
                BackColor = Color.Black;
                ForeColor = Color.DarkGoldenrod;
            }
        }
        private void clipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.richTextBoxMain = richTextBoxMain;
            form2.Show();
        }
    }
}
