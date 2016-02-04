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
    public partial class TabOptions : Form
    {
        public Workspace workspace_ob = new Workspace();
        public Workspace workspace_ob_last = new Workspace();
        List<RadioButton> radio_buttons_arr = new List<RadioButton>();
        public TabOptions()
        {
            InitializeComponent();
            List<ToolTip> t_list_tab = new List<ToolTip>(6);
            for(int i = 0; i <=100; i++){
                t_list_tab.Add(new ToolTip());
            }
            t_list_tab[0].SetToolTip(radioButton_even_odd, "Even and odd numbers randomly");
            t_list_tab[1].SetToolTip(radioButton_prime_comp, "Prime and composite numbers randomly");
            t_list_tab[2].SetToolTip(radioButton_mystery_dis, "In each rectangle are four numbers split by comma. \nEach next number is bigger than previously on number from key.");
            t_list_tab[3].SetToolTip(textBox_alg_bas_frst, "Minimum threshold from which numbers will generate.");
            t_list_tab[4].SetToolTip(textBox_alg_hard_scnd, "Maximum threshold to which numbers will generate.");
            t_list_tab[5].SetToolTip(label11, "Actions that will be used in generating tasks.");
            t_list_tab[6].SetToolTip(check_box_Addition, "Add the addition to list of uses actions.");
            t_list_tab[7].SetToolTip(check_box_Subtraction, "Add the subtraction to list of uses actions.");
            t_list_tab[8].SetToolTip(check_box_Division, "Add the division to list of uses actions.");
            t_list_tab[9].SetToolTip(check_box_Mult, "Add the multiplication to list of uses actions.");
            t_list_tab[10].SetToolTip(radioButton_Junior, "In this mode in each key will be two different numbers.");
            t_list_tab[11].SetToolTip(radioButton_Basic, "In this mode in each key will be one number.");
            t_list_tab[12].SetToolTip(radioButton_Advanced, "In this mode in each key will be range of numbers \nor couple numbers separated by comma.");
            t_list_tab[13].SetToolTip(textBox_alg_simple_frst, "Minimum threshold from which numbers will generate.");
            t_list_tab[14].SetToolTip(textBox_alg_simple_scnd, "Maximum threshold to which numbers will generate.");
            t_list_tab[15].SetToolTip(label13, "Actions that will be used in generating tasks.");
            t_list_tab[16].SetToolTip(check_box_regr_add, "Add the addition to list of uses actions.");
            t_list_tab[17].SetToolTip(check_box_regr_sub, "Add the subtraction to list of uses actions.");
            t_list_tab[18].SetToolTip(check_box_regr_mult, "Add the multiplication to list of uses actions.");
            t_list_tab[19].SetToolTip(textBox_alg_mid_regr_frst, "Minimum threshold from which numbers will generate.");
            t_list_tab[20].SetToolTip(textBox_alg_mid_regr_scnd, "Maximum threshold to which numbers will generate.");
            t_list_tab[21].SetToolTip(radioButton_rounds_ten, "Randomly numbers that must be rounds to number in key.");
            t_list_tab[22].SetToolTip(radioButton_rounds_hun, "Randomly numbers that must be rounds to number in key.");
            t_list_tab[23].SetToolTip(radioButton_fractions, "Randomly fractions in the keys to which must be found equal fraction.");
            t_list_tab[24].SetToolTip(radioButton_Percentages, "Randomly percentages in the keys to which must be found equal value.");
            t_list_tab[25].SetToolTip(radioButton_decimals, "Key value in some (ten or hundred) place.");
            t_list_tab[26].SetToolTip(textBox_alg_hard_frst, "Minimum threshold from which numbers will generate.");
            t_list_tab[27].SetToolTip(textBox_alg_hard_scnd, "Maximum threshold to which numbers will generate.");
            t_list_tab[28].SetToolTip(radioButton_angles, "Found what type of randomly chosen angle.");
            t_list_tab[29].SetToolTip(radioButton_qua, "Found in which quadrant exist randomly chosen point.");
            t_list_tab[30].SetToolTip(radioButton_shapes, "Answer how much angle has randomly chosen shape.");
            t_list_tab[31].SetToolTip(group_box_regro, "For each color generate random range of number.");
        }

        private void radioButton_Junior_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Junior.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.JUNIOR;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_mystery_dis_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_mystery_dis.Checked == true)
            {
                label6.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                textBox_alfg_bas_scnd.Visible = true;
                textBox_alg_bas_frst.Visible = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_MYST;
            }
            else
            {
                label6.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                textBox_alfg_bas_scnd.Visible = false;
                textBox_alg_bas_frst.Visible = false;
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
            }
        }

        private void radioButton_alg_hard_frac_equal_num_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage_basic_Click(object sender, EventArgs e)
        {

        }

        private void TabOptions_Shown(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            #region last_configuration
            if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD) radioButton_even_odd.Checked = true;
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_PRIM_COMP) radioButton_prime_comp.Checked = true;
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST) { 
                radioButton_mystery_dis.Checked = true;
                textBox_alg_bas_frst.Visible = true;
                textBox_alfg_bas_scnd.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_SIMP)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 0;
                if (workspace_ob.op.addition_act == true) check_box_Addition.Checked = true;
                if (workspace_ob.op.division_act == true) check_box_Division.Checked = true;
                if (workspace_ob.op.multiplication_act == true) check_box_Mult.Checked = true;
                if (workspace_ob.op.subtraction_act == true) check_box_Subtraction.Checked = true;
                if (workspace_ob.op.active_complexity == Workspace.options.complexity.BASIC) radioButton_Basic.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.JUNIOR) radioButton_Junior.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED) radioButton_Advanced.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_COMA)
                {
                    radioButton_Advanced.Checked = true;
                    comboBox_alg_simpl_adv.SelectedIndex = 0;
                }
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_HYPHEN)
                {
                    radioButton_Advanced.Checked = true;
                    comboBox_alg_simpl_adv.SelectedIndex = 1;
                }

            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 1;
                if (workspace_ob.op.addition_act == true) check_box_regr_add.Checked = true;
                if (workspace_ob.op.multiplication_act == true) check_box_regr_mult.Checked = true;
                if (workspace_ob.op.subtraction_act == true) check_box_regr_sub.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 1;
                if (workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.HUNDREDS) radioButton_rounds_hun.Checked = true;
                else if (workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.TENS) radioButton_rounds_ten.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_DEC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_decimals.Checked = true;

            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_FRAC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_fractions.Checked = true;
                if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM) { comboBox1.SelectedIndex = 0; }
                else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_DEN) { comboBox1.SelectedIndex = 1; }
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_PERC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_Percentages.Checked = true;
                if (workspace_ob.op.active_complexity == Workspace.options.complexity.BASIC)
                    comboBox_percent.SelectedIndex = 0;
                else if(workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED)
                    comboBox_percent.SelectedIndex = 1;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_ANGLES)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_angles.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_QUADR)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_qua.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_SHAPES)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_shapes.Checked = true;
            }
            #endregion    
            update_tmpl_list();
            try
            {
                comboBox_tmpl.SelectedIndex = workspace_ob.selectedValTmpl;
            }
            catch
            {
                comboBox_tmpl.SelectedIndex = 0;
            }
            
        }

        private void check_box_regr_add_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_add.Checked == true){
                workspace_ob.op.division_act = false;
                if (check_box_regr_mult.Checked == false) workspace_ob.op.multiplication_act = false;
                else workspace_ob.op.multiplication_act = true;
                if (check_box_regr_sub.Checked == false) workspace_ob.op.subtraction_act = false;
                else workspace_ob.op.subtraction_act = true;
                workspace_ob.op.addition_act = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
            }
            else
                workspace_ob.op.addition_act = false;
        }

        private void check_box_regr_sub_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_sub.Checked == true)
            {
                workspace_ob.op.division_act = false;
                if (check_box_regr_mult.Checked == false) workspace_ob.op.multiplication_act = false;
                else workspace_ob.op.multiplication_act = true;
                if (check_box_regr_add.Checked == false) workspace_ob.op.addition_act = false;
                else workspace_ob.op.addition_act = true;
                workspace_ob.op.subtraction_act = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
                workspace_ob.op.division_act = false;
            }
            else
                workspace_ob.op.subtraction_act = false;
        }

        private void check_box_regr_mult_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_mult.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                workspace_ob.op.division_act = false;
                workspace_ob.op.multiplication_act = true;
                if (check_box_regr_add.Checked == false) workspace_ob.op.addition_act = false;
                else workspace_ob.op.addition_act = true;
                if (check_box_regr_sub.Checked == false) workspace_ob.op.subtraction_act = false;
                else workspace_ob.op.subtraction_act = true;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
                workspace_ob.op.division_act = false;
            }
            else
                workspace_ob.op.multiplication_act = false;
        }

        private void check_box_Addition_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Addition.Checked == true)
                workspace_ob.op.addition_act = true;
            else
                workspace_ob.op.addition_act = false;
        }

        private void check_box_Subtraction_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Subtraction.Checked == true)
                workspace_ob.op.subtraction_act = true;
            else
                workspace_ob.op.subtraction_act = false;
        }

        private void check_box_Mult_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Mult.Checked == true)
                workspace_ob.op.multiplication_act = true;
            else
                workspace_ob.op.multiplication_act = false;
        }

        private void Division_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Division.Checked == true)
                workspace_ob.op.division_act = true;
            else
                workspace_ob.op.division_act = false;
        }

        private void radioButton_Basic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Basic.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_Advanced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Advanced.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
                comboBox_alg_simpl_adv.SelectedIndex = 0;
                comboBox_alg_simpl_adv.Enabled = true;
            }
            else
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
                comboBox_alg_simpl_adv.Enabled = false;
            }
        
        }

        private void radioButton_fractions_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fractions.Checked == true)
            {
                if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM) { 
                    comboBox1.SelectedIndex = 0; 
                }
                else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_DEN) { 
                    comboBox1.SelectedIndex = 1; 
                }
                else comboBox1.SelectedIndex = 0;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_FRAC;
                comboBox1.Enabled = true;
                textBox_alg_hard_frst.Enabled = false;
                textBox_alg_hard_scnd.Enabled = false;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                comboBox1.Enabled = false;
            }
        }

        private void radioButton_decimals_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_decimals.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_DEC;
                textBox_alg_hard_frst.Enabled = true;
                textBox_alg_hard_scnd.Enabled = true;
                textBox_alg_hard_frst.MaxLength = 1;
                textBox_alg_hard_scnd.MaxLength = 1;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                textBox_alg_hard_frst.MaxLength = 3;
                textBox_alg_hard_scnd.MaxLength = 3;
            }
        }

        private void radioButton_Percentages_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Percentages.Checked == true)
            { 
                comboBox_percent.Enabled = true;
                comboBox_percent.SelectedIndex = 0;
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_PERC;
                textBox_alg_hard_frst.Enabled = true;
                textBox_alg_hard_scnd.Enabled = true;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                comboBox_percent.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_NUM;
            else if (comboBox1.SelectedIndex == 1)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_DEN;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            #region save_Mystery_data
            if (algebraTab.SelectedTab == tabPage_basic)
            {
                if (radioButton_even_odd.Checked != true && radioButton_mystery_dis.Checked != true && radioButton_prime_comp.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
                if(workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
                {
                    try
                    {
                        int.Parse(textBox_alg_bas_frst.Text);
                        int.Parse(textBox_alfg_bas_scnd.Text);
                    }
                    catch
                    {
                        if(textBox_alg_bas_frst.Text == "" || textBox_alfg_bas_scnd.Text == "")
                            textBox_info_error.Text = "Ranges of numbers is empty.";
                        else
                            textBox_info_error.Text = "Numbers are incorrect.";
                        return;
                    }
                    if (int.Parse(textBox_alg_bas_frst.Text) >= int.Parse(textBox_alfg_bas_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_bas_frst.Text) < 0 || int.Parse(textBox_alfg_bas_scnd.Text) < 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    }
                    workspace_ob.op.active_range_first = int.Parse(textBox_alg_bas_frst.Text);
                    workspace_ob.op.active_range_second = int.Parse(textBox_alfg_bas_scnd.Text);
                }
            }
            #endregion
            #region save_Algebra_simple_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_simple && algebraTab.SelectedTab == tabPage_alg)
            {
                if((radioButton_Advanced.Checked != true && radioButton_Junior.Checked != true && radioButton_Basic.Checked != true) 
                || (check_box_Addition.Checked != true && check_box_Mult.Checked != true && check_box_Subtraction.Checked != true && check_box_Division.Checked != true))
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_simple_frst.Text);
                    int.Parse(textBox_alg_simple_scnd.Text);
                }
                catch
                {
                    if (textBox_alg_simple_frst.Text == "" || textBox_alg_simple_scnd.Text == "")
                        textBox_info_error.Text = "Ranges of numbers is empty.";
                    else
                        textBox_info_error.Text = "Numbers are incorrect.";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) >= int.Parse(textBox_alg_simple_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }

                if (int.Parse(textBox_alg_simple_frst.Text) == 0 || int.Parse(textBox_alg_simple_scnd.Text) == 0)
                {
                    textBox_info_error.Text = "You can`t enter zero.";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) < 0 || int.Parse(textBox_alg_simple_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                }
                if ((int.Parse(textBox_alg_simple_scnd.Text) - int.Parse(textBox_alg_simple_frst.Text)) < workspace_ob.keys.Count)
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                    return;
                }
                if (radioButton_Advanced.Checked == true && comboBox_alg_simpl_adv.SelectedIndex == 1 && ((int.Parse(textBox_alg_simple_scnd.Text) - int.Parse(textBox_alg_simple_frst.Text)) < workspace_ob.keys.Count * 2))
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys multiplicated by 2.";
                    return;
                }
                if (radioButton_Junior.Checked)
                {
                    if (int.Parse(textBox_alg_simple_scnd.Text) - int.Parse(textBox_alg_simple_frst.Text) < workspace_ob.keys.Count*2)
                    {
                        DialogResult result1 = MessageBox.Show("With this numbers some keys will stay without value. Continue?",
    "Empty keys",
    MessageBoxButtons.YesNo);
                        if (result1 == System.Windows.Forms.DialogResult.No)
                        {
                            textBox_info_error.Text = "Enter some other numbers.";
                            return;
                        }
                    }
                }
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_simple_frst.Text);
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_simple_scnd.Text);
            }
            #endregion
            #region save_Algebra_Middle_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_middle && algebraTab.SelectedTab == tabPage_alg)
            {
                if ((check_box_regr_add.Checked != true && check_box_regr_mult.Checked != true && check_box_regr_sub.Checked != true)
                && (radioButton_rounds_ten.Checked != true && radioButton_rounds_hun.Checked != true))
                {
                    textBox_info_error.Text = "Select some actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_mid_regr_frst.Text);
                    int.Parse(textBox_alg_mid_regr_scnd.Text);
                }
                catch
                {
                    if (textBox_alg_mid_regr_frst.Text == "" || textBox_alg_mid_regr_scnd.Text == "")
                        textBox_info_error.Text = "Ranges of numbers is empty.";
                    else
                        textBox_info_error.Text = "Numbers are incorrect.";
                    return;
                }
                if (radioButton_rounds_ten.Checked == true && (int.Parse(textBox_alg_mid_regr_frst.Text) < 10 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 10))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 10.";
                    return;
                } 
                
                else if((radioButton_rounds_hun.Checked == true && (int.Parse(textBox_alg_mid_regr_frst.Text) < 100 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 100)))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 100.";
                    return;
                }

                if (int.Parse(textBox_alg_mid_regr_frst.Text) >= int.Parse(textBox_alg_mid_regr_scnd.Text)) 
                { 
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_mid_regr_frst.Text) < 0 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                }
                if (radioButton_rounds_ten.Checked == true && ((int.Parse(textBox_alg_mid_regr_scnd.Text) - int.Parse(textBox_alg_mid_regr_frst.Text)) < 10))
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than 10.";
                    return;
                }
                if (radioButton_rounds_hun.Checked == true && ((int.Parse(textBox_alg_mid_regr_scnd.Text) - int.Parse(textBox_alg_mid_regr_frst.Text)) < 100))
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than 100.";
                    return;
                }
                if ((int.Parse(textBox_alg_mid_regr_scnd.Text) - int.Parse(textBox_alg_mid_regr_frst.Text)) < workspace_ob.keys.Count)
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                    return;
                }
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_mid_regr_frst.Text); 
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_mid_regr_scnd.Text);
            }
            #endregion
            #region save_Algebra_Hard_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_hard && algebraTab.SelectedTab == tabPage_alg)
            {
                if (radioButton_fractions.Checked != true && radioButton_decimals.Checked != true && radioButton_Percentages.Checked != true)
                {
                    textBox_info_error.Text = "Select some value.";
                    return;
                }
                if (radioButton_fractions.Checked != true)
                {
                    try
                    {
                        int.Parse(textBox_alg_hard_frst.Text);
                        int.Parse(textBox_alg_hard_scnd.Text);
                    }
                    catch
                    {
                        if (textBox_alg_hard_frst.Text == "" || textBox_alg_hard_scnd.Text == "")
                            textBox_info_error.Text = "Ranges of numbers is empty.";
                        else
                            textBox_info_error.Text = "Numbers are incorrect.";
                        return;
                    }
                    if (int.Parse(textBox_alg_hard_frst.Text) >= int.Parse(textBox_alg_hard_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_hard_frst.Text) <= 0 || int.Parse(textBox_alg_hard_scnd.Text) <= 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    }
                    if ((int.Parse(textBox_alg_hard_scnd.Text) - int.Parse(textBox_alg_hard_frst.Text)) < workspace_ob.keys.Count)
                    {
                        textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                        return;
                    }
                    workspace_ob.op.active_range_first = int.Parse(textBox_alg_hard_frst.Text);
                    workspace_ob.op.active_range_second = int.Parse(textBox_alg_hard_scnd.Text);
                }
            }
            #endregion
            #region save_Geom_data
            else if (algebraTab.SelectedTab == tabPage_geom)
            {
                if (radioButton_angles.Checked != true && radioButton_qua.Checked != true && radioButton_shapes.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
            }
            #endregion
            #region generate_new_keys
            if (workspace_ob.keys.Count != 0)
            {
                if (workspace_ob.keys.Count < 2)
                {
                    return;
                }
                else
                {
                    foreach (Workspace.key a in workspace_ob.keys)
                    {
                        a.str = "";
                    }
                    GenereteNumbers.workspace = workspace_ob;
                    GenereteNumbers.Generate_Number();
                }
            }
            #endregion
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton_prime_comp_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_PRIM_COMP;
        }

        private void radioButton_even_odd_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_EVEN_ODD;
        }

        private void radioButton_angles_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_ANGLES;
        }

        private void radioButton_qua_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_QUADR;
        }

        private void radioButton_shapes_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_SHAPES;
        }

        private void tabPage_basic_CursorChanged(object sender, EventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_basic_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage4_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_alg_middle_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_alg_hard_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }
        
        private void radioButton_rounds_ten_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rounds_ten.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.TENS;
                check_box_regr_add.Checked = false;
                check_box_regr_mult.Checked = false;
                check_box_regr_sub.Checked = false;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.TENS;
            }
        }

        private void radioButton_rounds_hun_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rounds_hun.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.HUNDREDS;
                check_box_regr_add.Checked = false;
                check_box_regr_mult.Checked = false;
                check_box_regr_sub.Checked = false;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.HUNDREDS;
            }
        }

        private void comboBox_alg_simpl_adv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_alg_simpl_adv.SelectedIndex == 0) { workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED_COMA; }
            else if (comboBox_alg_simpl_adv.SelectedIndex == 1) { workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED_HYPHEN; }
        }

       
        private void comboBox_percent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_percent.SelectedIndex == 0)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
            }
            else if (comboBox_percent.SelectedIndex == 1)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_tmpl.Text == "Custom")
            {
                textBox_info_error.Text = "You can`t save file with that name.";
                return;
            }
            Workspace workspace = workspace_ob;
            #region save_Mystery_data
            if (algebraTab.SelectedTab == tabPage_basic)
            {
                if (radioButton_even_odd.Checked != true && radioButton_mystery_dis.Checked != true && radioButton_prime_comp.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
                if(workspace.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
                {
                    try
                    {
                        int.Parse(textBox_alg_bas_frst.Text);
                        int.Parse(textBox_alfg_bas_scnd.Text);
                    }
                    catch
                    {
                        textBox_info_error.Text = "Please, enter the numbers.";
                        return;
                    }
                    if (int.Parse(textBox_alg_bas_frst.Text) >= int.Parse(textBox_alfg_bas_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_bas_frst.Text) < 0 || int.Parse(textBox_alfg_bas_scnd.Text) < 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    }
                    if ((int.Parse(textBox_alfg_bas_scnd.Text) - int.Parse(textBox_alg_bas_frst.Text)) < workspace_ob.keys.Count)
                    {
                        textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                        return;
                    }
                    workspace.op.active_range_first = int.Parse(textBox_alg_bas_frst.Text);
                    workspace.op.active_range_second = int.Parse(textBox_alfg_bas_scnd.Text);
                }
            }
            #endregion
            #region save_Algebra_simple_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_simple && algebraTab.SelectedTab == tabPage_alg)
            {
                if((radioButton_Advanced.Checked != true && radioButton_Junior.Checked != true && radioButton_Basic.Checked != true) 
                || (check_box_Addition.Checked != true && check_box_Mult.Checked != true && check_box_Subtraction.Checked != true && check_box_Division.Checked != true))
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_simple_frst.Text);
                    int.Parse(textBox_alg_simple_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) >= int.Parse(textBox_alg_simple_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) >= int.Parse(textBox_alg_simple_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) < 0 || int.Parse(textBox_alg_simple_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                }
                if ((int.Parse(textBox_alg_simple_scnd.Text) - int.Parse(textBox_alg_simple_frst.Text)) < workspace_ob.keys.Count)
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                    return;
                }
                workspace.op.active_range_first = int.Parse(textBox_alg_simple_frst.Text);
                workspace.op.active_range_second = int.Parse(textBox_alg_simple_scnd.Text);
            }
            #endregion
            #region save_Algebra_Middle_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_middle && algebraTab.SelectedTab == tabPage_alg)
            {
                if ((check_box_regr_add.Checked != true && check_box_regr_mult.Checked != true && check_box_regr_sub.Checked != true)
                && (radioButton_rounds_ten.Checked != true && radioButton_rounds_hun.Checked != true))
                {
                    textBox_info_error.Text = "Select some actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_mid_regr_frst.Text);
                    int.Parse(textBox_alg_mid_regr_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                if (radioButton_rounds_ten.Checked == true && (int.Parse(textBox_alg_mid_regr_scnd.Text) < 10 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 10))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 10.";
                    return;
                }
                else if ((radioButton_rounds_hun.Checked == true && (int.Parse(textBox_alg_mid_regr_scnd.Text) < 100 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 100)))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 100.";
                    return;
                }

                if (int.Parse(textBox_alg_mid_regr_frst.Text) >= int.Parse(textBox_alg_mid_regr_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_mid_regr_frst.Text) < 0 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                }
                if ((int.Parse(textBox_alg_mid_regr_scnd.Text) - int.Parse(textBox_alg_mid_regr_frst.Text)) < workspace_ob.keys.Count)
                {
                    textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                    return;
                }
                workspace.op.active_range_first = int.Parse(textBox_alg_mid_regr_frst.Text);
                workspace.op.active_range_second = int.Parse(textBox_alg_mid_regr_scnd.Text);
            }
            #endregion
            #region save_Algebra_Hard_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_hard && algebraTab.SelectedTab == tabPage_alg)
            {
                if (radioButton_fractions.Checked != true && radioButton_decimals.Checked != true && radioButton_Percentages.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
                if (radioButton_fractions.Checked != true)
                {
                    try
                    {
                        int.Parse(textBox_alg_hard_frst.Text);
                        int.Parse(textBox_alg_hard_scnd.Text);
                    }
                    catch
                    {
                        textBox_info_error.Text = "Please, enter the numbers.";
                        return;
                    }
                    if (int.Parse(textBox_alg_hard_frst.Text) >= int.Parse(textBox_alg_hard_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_hard_frst.Text) < 0 || int.Parse(textBox_alg_hard_scnd.Text) < 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    }
                    if ((int.Parse(textBox_alg_hard_scnd.Text) - int.Parse(textBox_alg_hard_frst.Text)) < workspace_ob.keys.Count)
                    {
                        textBox_info_error.Text = "In this mode difference between numbers must be bigger than count of keys.";
                        return;
                    }
                    workspace.op.active_range_first = int.Parse(textBox_alg_hard_frst.Text);
                    workspace.op.active_range_second = int.Parse(textBox_alg_hard_scnd.Text);
                }
            }
            #endregion
            #region save_Geom_data
            else if (algebraTab.SelectedTab == tabPage_geom)
            {
                if (radioButton_angles.Checked != true && radioButton_qua.Checked != true && radioButton_shapes.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
            }
            #endregion
            if (comboBox_tmpl.Text == "")
            {
                textBox_info_error.Text = "Enter the name of new template.";
                return;
            }
            object ob = comboBox_tmpl.Text;
            if (comboBox_tmpl.Items.Contains(ob))
            {
                DialogResult result1 = MessageBox.Show("Do you want replace \"" + comboBox_tmpl.Text + ".cnf\"?",
    "Save new template",
    MessageBoxButtons.YesNo);
                if (result1 == System.Windows.Forms.DialogResult.No)
                {
                    textBox_info_error.Text = "Enter some other name of new template.";
                    return;
                }
            }
            string dest = ".\\configtmpl" + "\\" + comboBox_tmpl.Text + ".cnf";
            string for_save = OpenSave.saves_string_for_save_conf(workspace);
            System.IO.File.WriteAllText(@dest, for_save);
            
            update_tmpl_list();

            
        }
        private void update_tmpl_list()
        {

            workspace_ob.list_of_cnf_files = System.IO.Directory.GetFiles(@".\configtmpl", "*.cnf");
            for (int i = 0; i < workspace_ob.list_of_cnf_files.Count(); i++)
            {
                string[] tmp_str = workspace_ob.list_of_cnf_files[i].Split('\\');
                tmp_str = tmp_str[tmp_str.Count() - 1].Split('.');
                workspace_ob.list_of_cnf_files[i] = tmp_str[tmp_str.Count() - 2];
            }
            comboBox_tmpl.Items.Clear();
            comboBox_tmpl.Items.Add("Custom");
            foreach (string str in workspace_ob.list_of_cnf_files)
            {
                comboBox_tmpl.Items.Add(str);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int slctd_in = comboBox_tmpl.SelectedIndex;
            if (slctd_in == -1)
            {
                if (comboBox_tmpl.Items.Count != 0)
                    textBox_info_error.Text = "Select some template.";
                else
                    textBox_info_error.Text = "List of templates is empty.";
                return;
            }
            else if (slctd_in == 0)
            {
                textBox_info_error.Text = "You can delete custom template.";
                return;
            }
            System.IO.File.Delete(".\\configtmpl" + "\\" + workspace_ob.list_of_cnf_files[slctd_in - 1] + ".cnf");
            comboBox_tmpl.Text = "";
            update_tmpl_list();
            comboBox_tmpl.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int slctd_in = comboBox_tmpl.SelectedIndex;
            if (comboBox_tmpl.Text != "Custom" || comboBox_tmpl.Text != "")
            {
                comboBox_tmpl.SelectedItem = (object)comboBox_tmpl.Text;
                slctd_in = comboBox_tmpl.SelectedIndex;
            }
                
            if (slctd_in == -1) 
            {
                if(comboBox_tmpl.Items.Count != 0)
                    textBox_info_error.Text = "Select some template.";
                else
                    textBox_info_error.Text = "List of templates is empty.";
                return; 
            }
            else if (slctd_in == 0)
            {
                textBox_info_error.Text = "Select some other template.";
                return;
            }
            string input = ".\\configtmpl" + "\\" + workspace_ob.list_of_cnf_files[slctd_in - 1] + ".cnf";
            string for_open;
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(@input, Encoding.UTF8))
            {
                for_open = streamReader.ReadToEnd();
            }
            try
            {
                OpenSave.opens_string_for_save_conf(for_open, workspace_ob);
            }
            catch (System.FormatException)
            {
                textBox_info_error.Text = "File is incorrect. Please, delete it.";
            }
            workspace_ob.selectedValTmpl = slctd_in;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void comboBox_tmpl_TextChanged(object sender, EventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void comboBox_tmpl_TextUpdate(object sender, EventArgs e)
        {
            String str = "";
            for (int i = 0; i < comboBox_tmpl.Text.Count(); i++)
            {
                bool q = false;
                if (!Char.IsLetterOrDigit(comboBox_tmpl.Text[i]))
                {
                    q = true;
                }
                if (q == false)
                {
                    str += comboBox_tmpl.Text[i];
                }

            }
            comboBox_tmpl.Text = str;
        }

        private void comboBox_tmpl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_alg_simple_frst_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
