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
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string path = string.Empty;
        private int findPos = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Notepad";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitPrompt()
        {
            DialogResult = MessageBox.Show("Do you want to save changes to Untitled?",
                "Notepad",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                exitPrompt();
                
                if (DialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    richTextBox1.Text = String.Empty;
                    path = String.Empty;
                }
                if (DialogResult == DialogResult.No)
                {
                    richTextBox1.Text = String.Empty;
                    path = String.Empty;
                }
            }
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Title = "Save file";
            // set dinh dang cho file
            //saveFileDialog1.FileName = 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                File.WriteAllText(path, richTextBox1.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dr = new SaveFileDialog();
            dr.Filter = "Text Document|*.txt";
            if (dr.ShowDialog()   ==  DialogResult.OK)
            {
               
                File.WriteAllText(path = dr.FileName, richTextBox1.Text,Encoding.ASCII);
                
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog temp_ofd = new OpenFileDialog();
            temp_ofd.Filter = "Text Files|*.txt";
            temp_ofd.FileName = string.Empty;
            if (temp_ofd.ShowDialog() == DialogResult.OK)
            {
                if (temp_ofd.FileName == String.Empty)
                {
                    return;
                }
                else
                {
                    string str = temp_ofd.FileName;
                    richTextBox1.LoadFile(str, RichTextBoxStreamType.PlainText);
                    this.Text = temp_ofd.FileName;
                    path = str;
                }
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pageSetupDialog.AllowMargins = true;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.AllowPaper = true;
            pageSetupDialog.AllowPrinter = true;
            pageSetupDialog.ShowHelp = true;
            pageSetupDialog.ShowNetwork = true;

            pd.DocumentName = "temp";
            pageSetupDialog.Document = pd;
            pageSetupDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                exitPrompt();
                if (DialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    Application.Exit();
                }
                if (DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = String.Empty;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        
        public void temp_findnext(string text_find)
        {
            string searchText = text_find;
            try
            {
                string s = text_find;
                richTextBox1.Focus();
                findPos = richTextBox1.Find(s, findPos, RichTextBoxFinds.None);
                richTextBox1.Select(findPos, s.Length);
                findPos += text_find.Length+1;
            }
            catch
            {
                MessageBox.Show("không có từ này trong văn bản");
                findPos = 0;
            }
        }

        public void replace_only(string a)
        {
            //Console.WriteLine(richTextBox1.SelectedText.ToString());
            Regex regReplace = new Regex(richTextBox1.SelectedText.ToString());
            richTextBox1.Text = regReplace.Replace(richTextBox1.Text.ToString(), a, 1);

        }

        public void replace_all(string a)
        {
            richTextBox1.Text = richTextBox1.Text.Replace(richTextBox1.SelectedText.ToString(), a);
        }
        
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find findd = new Find();
            
            findd.Show(this);
            findd.Location = new Point(this.ClientSize.Width / 2, this.ClientSize.Height+30);


        }


        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace findd = new Replace();

            findd.Show(this);
            findd.Location = new Point(this.ClientSize.Width / 2, this.ClientSize.Height + 30);
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/khoauit99");
            }
            catch
            { }
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: \t\t1.4.9 \nDeveloper:\tKhoa Pham", "KMHT 2017", MessageBoxButtons.OK);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.Font = richTextBox1.Font;
            fontDialog1.Color = richTextBox1.ForeColor;
            if (fontDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            
            richTextBox1.Text += localDate.ToString();
        }
    }
}
