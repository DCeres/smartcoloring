using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxPDFXEdit;
using PDFXEdit;
using System.Threading;

namespace test
{
    public partial class ViewProperties : Form
    {
        private int h_temp;
        private int w_temp;
        private AxPXV_Control axPXV_Control1;
        public Workspace workspace_ob = new Workspace();
        private ViewProperties()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            workspace_ob = new Workspace();
            
        }
        public ViewProperties(AxPXV_Control axPXV_Control1)
        {
            InitializeComponent();
            checkBox1.Checked = true;
            workspace_ob = new Workspace();
            this.axPXV_Control1 = axPXV_Control1;
        }
        public ViewProperties(AxPXV_Control axPXV_Control1, bool q)
        {
            InitializeComponent();
            checkBox1.Checked = true;
            workspace_ob = new Workspace();
            this.axPXV_Control1 = axPXV_Control1;
            tabControl1.SelectedIndex = 1;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown_width.Value != w_temp || (int)numericUpDown_height.Value != w_temp)
                if (MessageBox.Show("If you change size, current field will be cleaned. Are you sure?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            workspace_ob.field_ex.width = (int)numericUpDown_width.Value;
            workspace_ob.field_ex.heigth = (int)numericUpDown_height.Value;
            try
            {
                workspace_ob.field_ex.width = (int)numericUpDown_width.Value;
                workspace_ob.field_ex.heigth = (int)numericUpDown_height.Value;
                if (workspace_ob.field_ex.width <= 20) workspace_ob.field_ex.size_rect = 600 / (int)numericUpDown_width.Value;
                else workspace_ob.field_ex.size_rect = 30;  
                
            }
            catch { return; }
            
            for (int i = 0; i <= 40; i++)
            {
                for (int j = 0; j <= 40; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                    workspace_ob.field_ex.str_fild[i][j] = "";
                }
            }
            if (workspace_ob.field_ex.width < workspace_ob.field_ex.heigth)
                workspace_ob.op.orientation_of_document = 1;
            else
                workspace_ob.op.orientation_of_document = 0;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void Options_Shown(object sender, EventArgs e)
        {
            if (workspace_ob.auto_generate == true)
            {
                checkBox1.Checked = true;
                numericUpDown_height.Visible = false;
                label2.Visible = false;
            }
            else
            {
                checkBox1.Checked = false;
                numericUpDown_height.Visible = true;
                label2.Visible = true;
            }
            h_temp = workspace_ob.field_ex.heigth;
            w_temp = workspace_ob.field_ex.width;
            if (workspace_ob.op.orientation_of_document == 0) radioButton_ver.Checked = true;
            else radioButton_hor.Checked = true;
            numericUpDown_width.Value = workspace_ob.field_ex.width;
            numericUpDown_height.Value = workspace_ob.field_ex.heigth;
            
            if (workspace_ob.activationKey != "")
            {
                textBox_key.Visible = false;
                button_activate.Visible = false;
                label_ent_key.Text = "Program is activated.";
            }
            else
            {
                textBox_info.Text = "If you activate your program, watermarks in PDF documents will disappear.";
            }
            //trackBar_delta_for_colors_open_image.Value = workspace_ob.delta_for_open_image / 26;
        }


        private void trackBar_qauntity_of_square_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown_height.Visible = false;
                label2.Visible = false;
                workspace_ob.auto_generate = true;
                try
                {
                    numericUpDown_height.Value = numericUpDown_width.Value;
                }
                catch
                {
                    return;
                }
            }
            else
            {
                workspace_ob.auto_generate = false;
                label2.Visible = true;
                numericUpDown_height.Visible = true;
                numericUpDown_height.Enabled = true;
            }
        }


        private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                try
                {
                    numericUpDown_height.Value = numericUpDown_width.Value;
                }
                catch
                {
                    return;
                }
            }
            else
            {
                numericUpDown_height.Enabled = true;
            }
        }

        private void radioButton_ver_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton_ver.Checked == true)
            //{
            //    workspace_ob.op.orientation_of_document = 0;
            //    numericUpDown_width.Maximum = 20;
            //    numericUpDown_height.Maximum = 25;
            //}
            //else
            //{
            //    workspace_ob.op.orientation_of_document = 1;
            //    numericUpDown_width.Maximum = 25;
            //    numericUpDown_height.Maximum = 20;
            //}
        }

        private void radioButton_hor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_width.Value >= numericUpDown_height.Value)
            {
                workspace_ob.op.orientation_of_document = 0;
                radioButton_ver.Checked = true;
            }
            else
            {
                workspace_ob.op.orientation_of_document = 1;
                radioButton_hor.Checked = true;
            }
        }

        private void ViewProperties_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }
        //Activating the program
        private void button_activate_Click(object sender, EventArgs e)
        {

            if (axPXV_Control1.SetLicKey(textBox_key.Text) == true)
            {
                workspace_ob.activationKey = textBox_key.Text;
                textBox_key.Visible = false;
                button_activate.Visible = false;
                label_ent_key.Text = "Program is activated.";
                textBox_info.Text = "";
            }
            else
            {
                textBox_info.Text = "Key is not valid! Enter another key.";
            }

            
        }
    }
}
