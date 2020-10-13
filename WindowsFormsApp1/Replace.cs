using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Replace : Form
    {
        public Replace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp;
            temp = textBox1.Text.ToString();
            
            Form1 fm3 = (Form1)this.Owner;
            

            fm3.temp_findnext(temp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm3 = (Form1)this.Owner;
            string temp2 = string.Empty;
            temp2 = textBox2.Text.ToString();
            fm3.replace_only(temp2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
