using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Options : Form
    {
        public Workspace workspace_ob = new Workspace();
        public Options()
        {
            InitializeComponent();
            workspace_ob = new Workspace();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && int.Parse(textBox1.Text) <= 20)
            {
                workspace_ob.field_ex.width = int.Parse(textBox1.Text);
                workspace_ob.field_ex.heigth = int.Parse(textBox1.Text);
                workspace_ob.field_ex.size_rect = 600 / int.Parse(textBox1.Text);
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void Options_Shown(object sender, EventArgs e)
        {
            textBox1.Text = workspace_ob.field_ex.width.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = ""; 
            try { 
                int i = int.Parse(textBox1.Text);
                if (int.Parse(textBox1.Text) > 20) { textBox2.Text = "If value width of square greater than 20, it`s not comfortable to colored picture! Enter valid value."; }
            }
            catch { textBox2.Text = "Enter a number."; }
            
        }

    }
}
