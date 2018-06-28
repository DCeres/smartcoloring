using PDFXEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using test;
using System.Reflection;

namespace test
{
    public partial class Form1 : Form
    {
        IIXC_Inst inst;
        public Workspace workspace_ob = new Workspace();

        public delegate void CloseDelagate();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty  | BindingFlags.Instance | BindingFlags.NonPublic, null,  panel2, new object[] { true });

            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                }
            }
            inst = (IIXC_Inst)axPXV_Control1.Inst.GetExtension("IXC");
            GenereteNumbers.workspace = workspace_ob;
            GenereteNumbers.Generate_Number();
            UpdateDataGridView1();
            Directory.CreateDirectory("configtmpl");
            Directory.CreateDirectory("palettes");
            //Register_Dlls("AxInterop.PDFXCviewAxLib.dll");
            //Register_Dlls("AxInterop.PDFXEdit.dll");
            //Register_Dlls("Interop.PDFXCviewAxLib.dll");
            //Register_Dlls("Interop.PDFXEdit.dll");
        }


        void UpdateDataGridView1()
        {
            dataGridView1.Rows.Clear();
            workspace_ob.clr_name.Clear();
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                dataGridView1.Rows.Add(workspace_ob.keys[i].str, GetColorName(workspace_ob.keys[i].clr));
                if (GetColorName(workspace_ob.keys[i].clr) == "Black"
                    || GetColorName(workspace_ob.keys[i].clr) == "Brown"
                    || GetColorName(workspace_ob.keys[i].clr) == "Navy"
                    || GetColorName(workspace_ob.keys[i].clr) == "DarkGreen"
                    || GetColorName(workspace_ob.keys[i].clr) == "Indigo")
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.WhiteSmoke;
                workspace_ob.clr_name.Add(GetColorName(workspace_ob.keys[i].clr));
                dataGridView1.Rows[i].Cells[1].Style.BackColor = workspace_ob.keys[i].clr;
            }
            dataGridView1.PerformLayout();
        }
        void clean_keys()
        {
            dataGridView1.Rows.Clear();
            workspace_ob.keys.Clear();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int current_width = 20;
            int current_heigth = 20;
            if (workspace_ob.field_ex.width > 20)
            {
                current_width = 20;
                if (workspace_ob.field_ex.heigth > 20)
                {
                    current_heigth = 20;
                }
                else
                    current_heigth = workspace_ob.field_ex.heigth;
            }
            else
            {
                current_heigth = workspace_ob.field_ex.heigth;
                current_width = workspace_ob.field_ex.width;
            }
            if (workspace_ob.field_ex.width <= 20 && current_heigth > current_width)
            {
                current_width = workspace_ob.field_ex.width;
                current_heigth = current_width;
            }
            for (int i = 0; i < current_width; i++)
            {
                for (int j = 0; j < current_heigth; j++)
                {
                    int i_curr = i + workspace_ob.field_ex.mudslide_for_hskroll;
                    int j_curr = j + workspace_ob.field_ex.mudslide_for_vskroll;
                    int x = i * workspace_ob.field_ex.size_rect + 15;
                    int y = j * workspace_ob.field_ex.size_rect + 27;
                    Pen myPen = new Pen(Color.Black, 1);
                    e.Graphics.DrawRectangle(myPen, x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                    //if clean color is not active filling rect
                    if (workspace_ob.clean_colors == false) e.Graphics.FillRectangle(new SolidBrush(workspace_ob.field_ex.clr_fild[i_curr][j_curr]), x + 1, y + 1, workspace_ob.field_ex.size_rect - 1, workspace_ob.field_ex.size_rect - 1);

                    SolidBrush br = new SolidBrush(Color.Black);
                    RectangleF temp_rc = new RectangleF(x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                    //StringFormat sf = new StringFormat();
                    //Font fn = this.Font;
                    //float Size = fn.Size;
                    //Size = 7F;
                    //fn = new Font(fn.Name, Size, fn.Style, fn.Unit);
                    //if (workspace_ob.field_ex.str_fild[i_curr][j_curr].Length > 5)
                    //{
                    //    float currentSize = fn.Size;
                    //    currentSize -= 1.5F;
                    //    fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                    //}
                    //else if (workspace_ob.field_ex.str_fild[i_curr][j_curr].Length > 6)
                    //{
                    //    float currentSize = fn.Size;
                    //    currentSize -= 2.0F;

                    //    fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                    //}
                    //sf.Alignment = StringAlignment.Center;
                    //sf.LineAlignment = StringAlignment.Center;
                    ////if chosen "Regroping" aligment by right side
                    //if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
                    //{
                    //    sf.Alignment = StringAlignment.Far;
                    //    fn = new Font(fn.Name, fn.Size, FontStyle.Underline, fn.Unit);
                    //}
                    //int n = 0;
                    //for(int m = 0; m < workspace_ob.keys.Count; m++){
                    //    if (workspace_ob.keys[m].clr == workspace_ob.field_ex.clr_fild[i_curr][j_curr])
                    //    {
                    //        n = m;
                    //        break;
                    //    }
                    //}
                    //try
                    //{
                    //    if (workspace_ob.keys[n].str == "")
                    //        workspace_ob.field_ex.str_fild[i_curr][j_curr] = "";
                    //}
                    //catch { }

                    //e.Graphics.DrawString(workspace_ob.field_ex.str_fild[i_curr][j_curr], fn, br, temp_rc, sf);
                }
            }
            if (workspace_ob.qnt > 10) textBox_info.Text = "";
            workspace_ob.clean_colors = false;
            workspace_ob.qnt++;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            butoon_generate_field.Select();
            if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
            {
                return;
            }
            if (workspace_ob.isLbuttonDown == true)
            {
                if (workspace_ob.keys.Count == 0)
                {
                    textBox_info.Text = "Please, add some keys.";
                    return;

                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = workspace_ob.active_rc_color;
                Refresh();
            }
            else if (workspace_ob.isRbuttonDown == true)
            {
                if (workspace_ob.keys.Count == 0)
                {
                    textBox_info.Text = "Please, add some keys.";
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = Color.Transparent;
                workspace_ob.field_ex.str_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = "";
                Refresh();
            }
        }

        private void cleanColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.clean_colors = true;
            Refresh();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (workspace_ob.keys.Count != 0) workspace_ob.active_rc_color = workspace_ob.keys[dataGridView1.CurrentRow.Index].clr;
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (workspace_ob.keys.Count == 0)
            {
                textBox_info.Text = "Please, add some keys.";
                return;
            }
            if(workspace_ob.isLbuttonDown == true)
            {
                if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
                {
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = workspace_ob.active_rc_color;
                Refresh();
            }
            else if (workspace_ob.isRbuttonDown == true)
            {
                if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
                {
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = Color.Transparent;
                workspace_ob.field_ex.str_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = "";
                Refresh();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { workspace_ob.isLbuttonDown = true; }
            else if (e.Button == MouseButtons.Right) { workspace_ob.isRbuttonDown = true; }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { workspace_ob.isLbuttonDown = false; }
            else if(e.Button == MouseButtons.Right) { workspace_ob.isRbuttonDown = false; }
        }

        void GenerateStrings_of_Numbers()
        {
            string input = "";
            List<char> list_of_active_signs = new List<char>();
            if (workspace_ob.op.addition_act == true) list_of_active_signs.Add('+');
            if (workspace_ob.op.subtraction_act == true) list_of_active_signs.Add('-');
            if (workspace_ob.op.division_act == true) list_of_active_signs.Add('/');
            if (workspace_ob.op.multiplication_act == true) list_of_active_signs.Add('*');
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    if (workspace_ob.field_ex.clr_fild[i][j] == Color.Transparent) { continue; }
                    for (int z = 0; z < workspace_ob.keys.Count; z++)
                    {
                        if (workspace_ob.keys[z].clr == workspace_ob.field_ex.clr_fild[i][j])
                        {
                            input = workspace_ob.keys[z].str;
                            continue;
                        }
                    }
                    if (input == "") { continue; }

                    if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD)
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Even_Odd(input);
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_PRIM_COMP)
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_PrimeOrComposite(input);
                    else if(workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_NumbPatterns(input);
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_SIMP)
                    {
                        workspace_ob.sign = list_of_active_signs[MathTemplate.GenerateRandomNumber(list_of_active_signs.Count)];
                        if(workspace_ob.op.active_complexity == Workspace.options.complexity.BASIC)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Basic(input, workspace_ob.sign);
                        if (workspace_ob.op.active_complexity == Workspace.options.complexity.JUNIOR)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Jr(input, workspace_ob.sign);
                        if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_COMA || workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_HYPHEN)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Advanced(input, workspace_ob.sign);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
                    {
                        workspace_ob.sign = list_of_active_signs[MathTemplate.GenerateRandomNumber(list_of_active_signs.Count)];
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_Regrouping(input, workspace_ob.sign);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING)
                    {
                        if(workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.TENS)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.PlaceValue_Rounding(input, true);
                        else if (workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.HUNDREDS)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.PlaceValue_Rounding(input, false);

                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_ANGLES)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_GeomAndMeasur(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_QUADR)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Quadrants(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_SHAPES)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Shapes_Names(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_FRAC)
                    {
                        if(workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Fractions_Numerators(input);
                        else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_DEN)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Fractions_Denominators(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_PERC)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Percent_Equivalence(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_DEC)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Decimal_Place_Value(input);
                    }
                }
            }
        }
        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workspace_ob.field_ex.clr_fild.Count; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.clr_fild.Count; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                    workspace_ob.field_ex.str_fild[i][j] = "";
                }
            }
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_add_color_Click(object sender, EventArgs e)
        {

            if (workspace_ob.keys.Count >= 10)
            {
                textBox_info.Text = "You can`t add more than 10 keys.";
                return;
            }
            colorDialog1.SolidColorOnly = true;
            colorDialog1.CustomColors = workspace_ob.op.custom_colors;
            bool q = false;
            do
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < workspace_ob.keys.Count; i++)
                    {
                        if (colorDialog1.Color == workspace_ob.keys[i].clr)
                        {
                            MessageBox.Show("Current color is in list of the keys. Chose other color.");
                            q = true;
                            break;
                        }
                        else
                        {
                            q = false;
                        }
                    }
                    if (q == true)
                        continue;
                    workspace_ob.keys.Add(new Workspace.key("", colorDialog1.Color));
                    workspace_ob.op.custom_colors = colorDialog1.CustomColors;
                }
                else
                    return;

            } while (q);
            if (workspace_ob.keys.Count >= 2)
            {
                GenereteNumbers.Generate_Number();
                optionsToolStripMenuItem1.Enabled = true;
                button_options.Enabled = true;
            }

            UpdateDataGridView1();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
            if (workspace_ob.keys.Count != 0) workspace_ob.active_rc_color = workspace_ob.keys[dataGridView1.CurrentRow.Index].clr;
        }

        private void button_delete_color_Click(object sender, EventArgs e)
        {
            workspace_ob.clr_name.Clear();

            if (workspace_ob.keys.Count > 0)
            {
                for (int i = 0; i < workspace_ob.field_ex.width; i++)
                {
                    for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                    {
                        if (workspace_ob.field_ex.clr_fild[i][j] == workspace_ob.keys[dataGridView1.CurrentRow.Index].clr)
                        {
                            workspace_ob.field_ex.str_fild[i][j] = "";
                            workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                        }
                    }
                }
                workspace_ob.keys.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            if (workspace_ob.keys.Count < 2)
            {
                textBox_info.Text = "Please, add more keys.";
            }
            UpdateDataGridView1();
            Refresh();
            if (workspace_ob.keys.Count < 2)
            {
                optionsToolStripMenuItem1.Enabled = false;
                button_options.Enabled = false;
            }

        }

        private void button_generate_num_Click(object sender, EventArgs e)
        {
            GenerateNumbers();
        }
        private void GenerateNumbers()
        {
            textBox_info.Text = "";

            if (workspace_ob.keys.Count != 0)
            {
                if (workspace_ob.keys.Count < 2)
                {
                    textBox_info.Text = "Please, add more keys.";
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
                    UpdateDataGridView1();
                }
            }
        }

        private void butoon_generate_field_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < workspace_ob.field_ex.width; i++)
                {
                    for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = "";
                    }
                }
                GenerateStrings_of_Numbers();
                this.AllowDrop = false;
                Pdf pdf = new Pdf();
                Pdf.workspace_ob = workspace_ob;
                pdf.ShowDialog();
                Refresh();
                this.AllowDrop = true;
            }
            catch
            {
                MessageBox.Show("Generate PDF one more time.");
            }
        }

        private void cleanNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j <= workspace_ob.field_ex.width; j++)
                    workspace_ob.field_ex.str_fild[i][j] = "";
            }
            Refresh();
        }

        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            string for_save = OpenSave.get_string_for_save(workspace_ob);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                File.WriteAllText(saveFileDialog1.FileName, for_save);
            }

        }



        public Image ResizeOrigImg(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }
        public Color Minimize_Image_Colors(Color clr)
        {
            double delta = 0;
            double min_delta = 1000;
            Color min_delta_clr = Color.Transparent;
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                delta = Math.Sqrt((clr.R - workspace_ob.keys[i].clr.R) * (clr.R - workspace_ob.keys[i].clr.R)
                    + (clr.G - workspace_ob.keys[i].clr.G) * (clr.G - workspace_ob.keys[i].clr.G)
                    + (clr.B - workspace_ob.keys[i].clr.B) * (clr.B - workspace_ob.keys[i].clr.B));

                if (delta < min_delta)
                {
                    min_delta = delta;
                    min_delta_clr = workspace_ob.keys[i].clr;
                }
            }
            return min_delta_clr;
        }
        public void Minimize_All_Image_Colors()
        {
            double delta = 0;
            Color clr_one;
            Color clr_two;
            Color min_delta_clr = Color.Transparent;
            List<Color> new_main_colors = new List<Color>();
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                clr_one = workspace_ob.keys[i].clr;
                for (int j = 0; j < workspace_ob.keys.Count; j++)
                {
                    clr_two = workspace_ob.keys[j].clr;

                    delta = Math.Sqrt((clr_one.R - clr_two.R) * (clr_one.R - clr_two.R)
                    + (clr_one.G - clr_two.G) * (clr_one.G - clr_two.G)
                    + (clr_one.B - clr_two.B) * (clr_one.B - clr_two.B));

                    if (delta < workspace_ob.delta_for_open_image)
                    {
                        int r,g,b;
                        if(clr_one.R > clr_two.R)r = (clr_one.R - clr_two.R)/2 + clr_two.R;
                        else r = (clr_two.R - clr_one.R)/2 + clr_one.R;
                        if(clr_one.G > clr_two.G)g = (clr_one.G - clr_two.G)/2 + clr_two.G;
                        else g = (clr_two.G - clr_one.G)/2 + clr_one.G;
                        if(clr_one.B > clr_two.B)b = (clr_one.B - clr_two.B)/2 + clr_two.B;
                        else b = (clr_two.B - clr_one.B)/2 + clr_one.B;

                        Color myRgbColor = new Color();
                        myRgbColor = Color.FromArgb(r,g,b);
                        workspace_ob.keys[i].clr = myRgbColor;
                        workspace_ob.keys[j].clr = myRgbColor;

                    }
                }
            }
            List<Workspace.key> keys_temp = new List<Workspace.key>();
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                bool ifExist = false;
                for (int j = 0; j < keys_temp.Count; j++)
                {
                    if (workspace_ob.keys[i].clr.Name == keys_temp[j].clr.Name)
                    {
                        ifExist = true;
                    }
                }
                if (ifExist == false) keys_temp.Add(new Workspace.key("", workspace_ob.keys[i].clr));
            }
            workspace_ob.keys = keys_temp;
        }

        private void propetiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProperties vp = new ViewProperties(axPXV_Control1);
            vp.workspace_ob = workspace_ob;
            vp.ShowDialog();
            workspace_ob = vp.workspace_ob;

            if (workspace_ob.field_ex.width > 20)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Minimum = 1;
                hScrollBar1.Maximum = (workspace_ob.field_ex.width - 18) * 5;
            }
            else
                hScrollBar1.Visible = false;

            if (workspace_ob.field_ex.heigth > 20)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - 18) * 5;
            }
            else
                vScrollBar1.Visible = false;

            if (workspace_ob.field_ex.width <= 20 && workspace_ob.field_ex.heigth > workspace_ob.field_ex.width)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - workspace_ob.field_ex.width + 2) * 5;
            }
            Refresh();
        }

        private void generatePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateStrings_of_Numbers();
            this.AllowDrop = false;
            Pdf pdf = new Pdf();
            Pdf.workspace_ob = workspace_ob;
            pdf.ShowDialog();
            Refresh();
            this.AllowDrop = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            textBox_info.Text = "For choose other actions, complexity or mode press \"Options\"";
            UpdatePalettesList();
            if (workspace_ob.field_ex.heigth > 20) { }
            if (workspace_ob.field_ex.width > 20) { }
            ToolTip tl_tp = new ToolTip();
            tl_tp.SetToolTip(button_options, "Select actions, complexity and mode.");
            tl_tp.SetToolTip(butoon_generate_field, "Generate PDF document which you can save or print.");
            tl_tp.SetToolTip(button_generate_num, "Generate other random key for each color.");
            tl_tp.SetToolTip(button1, "Enter key for activating program.");
            tl_tp.SetToolTip(button_save_palette, "Save color palette which you can open next time opens program.");
            tl_tp.SetToolTip(button_del_palette, "Delete current palette.");
            tl_tp.SetToolTip(button_add_color, "Add new color.");
            tl_tp.SetToolTip(button_delete_color, "Delete current color.");
            UpdateDataGridView1();
            comboBox_plt.SelectedIndex = 0;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            workspace_ob.field_ex.mudslide_for_hskroll = hScrollBar1.Value / 5;
            Refresh();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            workspace_ob.field_ex.mudslide_for_vskroll = vScrollBar1.Value / 5;
            Refresh();
        }

        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFile(false);
            }
            catch
            {
                this.Enabled = true;
            }

        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            DragEventArgs arg = workspace_ob.dragAndDropEnterArg;
            string[] objects = (string[])arg.Data.GetData(DataFormats.FileDrop);
            if (objects.Count() > 1) { return; }
            string[] file_name = objects[0].Split('.');
            try
            {
                if (file_name[file_name.Count() - 1].ToLower() == "tif" || file_name[file_name.Count() - 1].ToLower() == "wmf" || file_name[file_name.Count() - 1].ToLower() == "dcx" || file_name[file_name.Count() - 1].ToLower() == "pbm" || file_name[file_name.Count() - 1].ToLower() == "tiff" || file_name[file_name.Count() - 1].ToLower() == "ppm" || file_name[file_name.Count() - 1].ToLower() == "pcx" || file_name[file_name.Count() - 1].ToLower() == "png" || file_name[file_name.Count() - 1].ToLower() == "jpeg" || file_name[file_name.Count() - 1].ToLower() == "gif" || file_name[file_name.Count() - 1].ToLower() == "bmp" || file_name[file_name.Count() - 1].ToLower() == "ico" || file_name[file_name.Count() - 1].ToLower() == "jpg")
                {
                    openFile(true, 1, objects[0]);
                }
                else if (file_name[file_name.Count() - 1].ToLower() == "cnf")
                {
                    try
                    {
                        openFile(true, 3, objects[0]);
                    }
                    catch
                    {
                        MessageBox.Show("File is incorrect.");
                        return;
                    }
                    GenerateNumbers();
                }
                else
                {
                    textBox_info.Text = "File is incorrect.";
                    return;
                }
            }
            catch
            {
                textBox_info.Text = "File is incorrect.";
                return;
            }
            Refresh();
        }


        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            workspace_ob.dragAndDropEnterArg = e;
            e.Data.ToString();
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
            e.Effect = DragDropEffects.Move;

            string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (objects.Count() > 1) { return; }
            string[] file_name = objects[0].Split('.');
            if (!(file_name[file_name.Count() - 1].ToLower() == "tif" || file_name[file_name.Count() - 1].ToLower() == "wmf" || file_name[file_name.Count() - 1].ToLower() == "dcx" || file_name[file_name.Count() - 1].ToLower() == "pbm" || file_name[file_name.Count() - 1].ToLower() == "tiff" || file_name[file_name.Count() - 1].ToLower() == "ppm" || file_name[file_name.Count() - 1].ToLower() == "pcx" || file_name[file_name.Count() - 1].ToLower() == "cnf" || file_name[file_name.Count() - 1].ToLower() == "png" || file_name[file_name.Count() - 1].ToLower() == "jpeg" || file_name[file_name.Count() - 1].ToLower() == "gif" || file_name[file_name.Count() - 1].ToLower() == "bmp" || file_name[file_name.Count() - 1].ToLower() == "ico" || file_name[file_name.Count() - 1].ToLower() == "jpg"))
            {
                textBox_info.Text = "File is incorrect.";
                return;
            }
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabOptions op = new TabOptions();
            if (workspace_ob.keys.Count < 2)
            {
                textBox_info.Text = "Please, add more keys.";
                return;
            }
            op.workspace_ob = this.workspace_ob;
            op.workspace_ob_last = this.workspace_ob;
            if (op.ShowDialog() == DialogResult.OK)
            {
                this.workspace_ob = op.workspace_ob;
                GenerateNumbers();
            }
            else return;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveFile();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                openFile(false);
            }
        }



        private void butoon_generate_field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                SaveFile();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                openFile(false);
            }
        }
        private void openFile(bool dragAndDrop, int slIndex = 0, string path_in = "")
        {

            this.Enabled = false;
            ProgressBar1 prgBar = new ProgressBar1();
            string path = path_in;
            int selected = slIndex;
            if (dragAndDrop == false)
            {
                openFileDialog1.Filter = "Image Files(*.png; *.jpeg; *.gif; *bmp; *.jpg; *.ico; *.pcx; *.ppm; *.tiff; *.tif; *pbm; *.dcx; *.wmf)| *.png; *.jpeg; *.gif; *bmp; *.jpg; *.ico; *.pcx; *.ppm; *.tiff; *.tif; *pbm; *.dcx; *.wmf|Configuration Files(*.cnf)| *.cnf|All Files| *.*";
                openFileDialog1.DefaultExt = "";

                if(Directory.Exists(Application.StartupPath.ToString() + "\\samples\\")){
                    openFileDialog1.InitialDirectory = Application.StartupPath.ToString() + "\\samples\\";
                }
                openFileDialog1.FileName = "";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selected = openFileDialog1.FilterIndex;
                    path = openFileDialog1.FileName;
                }
                else
                {
                    this.Enabled = true;
                    return;
                }
            }

            #region open_image
            if (selected == 1)
            {
                Bitmap temp = null;
                try
                {
                    prgBar.Show();
                    prgBar.Refresh();

                    OpenSaveImage.OpenImage(axPXV_Control1, out temp, path);
                    if(temp == null)
                    {
                        MessageBox.Show("File is incorrect.");
                        this.Enabled = true;
                        prgBar.Hide();
                        prgBar.Refresh();
                        return;
                    }
                    Image img = (Image)temp;
                    Graphics g = Graphics.FromImage(temp);
                    clean_keys();
                    img = ResizeOrigImg(img, workspace_ob.field_ex.width, workspace_ob.field_ex.heigth);


                    Bitmap bmp = new Bitmap(img);
                    for (int i = 0; i < workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                        {
                            bool ifColorExist = false;
                            for (int z = 0; z < workspace_ob.keys.Count; z++)
                            {
                                if (workspace_ob.keys[z].clr == bmp.GetPixel(i, j)) ifColorExist = true;
                            }
                            if (ifColorExist == false) workspace_ob.keys.Add(new Workspace.key("", bmp.GetPixel(i, j)));
                        }
                    }

                    Minimize_All_Image_Colors();
                    for (int i = 0; i < workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                        {
                            workspace_ob.field_ex.clr_fild[i][j] = Minimize_Image_Colors(bmp.GetPixel(i, j));
                            bool ifColorExist = false;
                            for (int z = 0; z < workspace_ob.keys.Count; z++)
                            {
                                if (workspace_ob.keys[z].clr == workspace_ob.field_ex.clr_fild[i][j])
                                    ifColorExist = true;
                            }
                            if (ifColorExist == false)
                                workspace_ob.keys.Add(new Workspace.key("", workspace_ob.field_ex.clr_fild[i][j]));
                        }
                    }
                    for (int i = 0; i <= workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j <= workspace_ob.field_ex.width; j++)
                            workspace_ob.field_ex.str_fild[i][j] = "";
                    }

                    GenerateNumbers();

                    UpdateDataGridView1();
                    if (workspace_ob.keys.Count >= 2)
                    {
                        optionsToolStripMenuItem1.Enabled = true;
                        button_options.Enabled = true;
                    }
                    else
                    {
                        optionsToolStripMenuItem1.Enabled = false;
                        button_options.Enabled = false;
                        MessageBox.Show("Please, add more keys.");
                    }
                    prgBar.Hide();
                    prgBar.Refresh();
                }
                catch(FormatException)
                {
                    textBox_info.Text = "File is incorrect.";
                    this.Enabled = true;
                    prgBar.Hide();
                    prgBar.Refresh();
                    return;
                }
                prgBar.Hide();
                prgBar.Refresh();
            }
            #endregion
            #region open template
            else if (selected == 2)
            {
                string input = path;
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
                    textBox_info.Text = "File is incorrect. Please, delete it.";
                    MessageBox.Show("File is incorrect.");
                }
                GenerateNumbers();
            }

            #endregion
            Refresh();
            this.Enabled = true;
            this.Activate();
        }

        private void SaveFile()
        {
            saveFileDialog1.Filter = "PNG Image Files(*.png)| *.png|BMP Image Files(*.bmp)| *.bmp|GIF Image Files(*.gif)| *.gif|PPM Image Files(*.ppm)| *.ppm|PCX Image Files(*.pcx)| *.pcx";
            saveFileDialog1.DefaultExt = "";
            saveFileDialog1.FileName = "SmartColoring";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int selected = saveFileDialog1.FilterIndex;
                if (selected == 1)
                {
                    OpenSaveImage.SaveImage(axPXV_Control1, workspace_ob, saveFileDialog1.FileName, IXC_ImageFileFormatIDs.FMT_PNG_ID);
                }
                else if (selected == 2)
                {
                    OpenSaveImage.SaveImage(axPXV_Control1, workspace_ob, saveFileDialog1.FileName, IXC_ImageFileFormatIDs.FMT_BMP_ID);
                }
                else if (selected == 3)
                {
                    OpenSaveImage.SaveImage(axPXV_Control1, workspace_ob, saveFileDialog1.FileName, IXC_ImageFileFormatIDs.FMT_GIF_ID);
                }
                else if (selected == 4)
                {
                    OpenSaveImage.SaveImage(axPXV_Control1, workspace_ob, saveFileDialog1.FileName, IXC_ImageFileFormatIDs.FMT_PPM_ID);
                }
                else if (selected == 5)
                {
                    OpenSaveImage.SaveImage(axPXV_Control1, workspace_ob, saveFileDialog1.FileName, IXC_ImageFileFormatIDs.FMT_PCX_ID);
                }
                else if (selected == 6)
                {
                    string for_save = OpenSave.saves_string_for_save_conf(workspace_ob);
                    File.WriteAllText(saveFileDialog1.FileName, for_save);
                }
            }
        }
        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            int range = e.NewValue - e.OldValue;
            vScrollBar1.Value += range;
            workspace_ob.field_ex.mudslide_for_vskroll = vScrollBar1.Value / 5;
        }
        private void UpdatePalettesList()
        {
            workspace_ob.list_of_plt_files = System.IO.Directory.GetFiles(@".\palettes", "*.plt");
            for (int i = 0; i < workspace_ob.list_of_plt_files.Count(); i++)
            {
                string[] tmp_str = workspace_ob.list_of_plt_files[i].Split('\\');
                tmp_str = tmp_str[tmp_str.Count() - 1].Split('.');
                workspace_ob.list_of_plt_files[i] = tmp_str[tmp_str.Count() - 2];
            }
            comboBox_plt.Items.Clear();
            comboBox_plt.Items.Add("Custom");
            foreach (string str in workspace_ob.list_of_plt_files)
            {
                comboBox_plt.Items.Add(str);
            }
        }

        private void comboBox_plt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slctd_in = comboBox_plt.SelectedIndex;
            if (slctd_in == -1)
            {
                if (comboBox_plt.Items.Count != 0)
                    textBox_info.Text = "Select some template.";
                else
                    textBox_info.Text = "List of templates is empty.";
                return;
            }
            else if (slctd_in == 0)
            {
                return;
            }
            string input = ".\\palettes" + "\\" + workspace_ob.list_of_plt_files[slctd_in - 1] + ".plt";
            string for_open;
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(@input, Encoding.UTF8))
            {
                for_open = streamReader.ReadToEnd();
            }
            try
            {
                clean_keys();
                OpenSave.opens_string_for_save_plt(for_open, workspace_ob);
            }
            catch (System.FormatException)
            {
                textBox_info.Text = "File is incorrect. Please, delete it.";
                return;
            }
            if (workspace_ob.keys.Count > 2)
            {
                optionsToolStripMenuItem1.Enabled = true;
                button_options.Enabled = true;
            }
            UpdateDataGridView1();
            GenerateNumbers();
        }

        private void button_save_palette_Click(object sender, EventArgs e)
        {
            Workspace workspace = workspace_ob;
            if(comboBox_plt.Text == "")
            {
                textBox_info.Text = "Enter the name of new palette template.";
                return;
            }
            object ob = comboBox_plt.Text;
            if(comboBox_plt.Text == "Custom")
            {
                textBox_info.Text = "You can`t save file with that name.";
                return;
            }
            if (comboBox_plt.Items.Contains(ob))
            {
                DialogResult result1 = MessageBox.Show("Do you want replace \"" + comboBox_plt.Text + ".plt\"?",
    "Save new palette template",
    MessageBoxButtons.YesNo);
                if (result1 == System.Windows.Forms.DialogResult.No)
                {
                    textBox_info.Text = "Enter some other name of new palette template.";
                    return;
                }
            }
            string dest = ".\\palettes" + "\\" + comboBox_plt.Text + ".plt";
            string for_save = OpenSave.saves_string_for_save_plt(workspace);
            System.IO.File.WriteAllText(@dest, for_save);
            UpdatePalettesList();
        }

        private void button_del_palette_Click(object sender, EventArgs e)
        {
            int slctd_in = comboBox_plt.SelectedIndex;
            if (slctd_in == -1)
            {
                if (comboBox_plt.Items.Count != 0)
                    textBox_info.Text = "Select some palette template.";
                else
                    textBox_info.Text = "List of palette templates is empty.";
                return;
            }
            else if (slctd_in == 0)
            {
                textBox_info.Text = "You can delete custom template.";
                return;
            }
            System.IO.File.Delete(".\\palettes" + "\\" + workspace_ob.list_of_plt_files[slctd_in - 1] + ".plt");
            comboBox_plt.Text = "";
            UpdatePalettesList();
            comboBox_plt.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ViewProperties vp = new ViewProperties(axPXV_Control1, true);
            vp.workspace_ob = workspace_ob;

            vp.ShowDialog();
            workspace_ob = vp.workspace_ob;

            if (workspace_ob.field_ex.width > 20)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Minimum = 1;
                hScrollBar1.Maximum = (workspace_ob.field_ex.width - 18) * 5;
            }
            else
                hScrollBar1.Visible = false;

            if (workspace_ob.field_ex.heigth > 20)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - 18) * 5;
            }
            else
                vScrollBar1.Visible = false;

            if (workspace_ob.field_ex.width <= 20 && workspace_ob.field_ex.heigth > workspace_ob.field_ex.width)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - workspace_ob.field_ex.width + 2) * 5;
            }
            if (workspace_ob.activationKey != "")
                groupBox_demo.Visible = false;
            Refresh();
        }
        public static void Register_Dlls(string filePath)
        {
            try
            {
                //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
                string arg_fileinfo = "/s" + " " + "\"" + filePath + "\"";
                System.Diagnostics.Process reg = new System.Diagnostics.Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = arg_fileinfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetColorName(Color clr)
        {
            string clr_name = "";
            double delta = 0;
            double min_delta = 1000;
            Color min_delta_clr = Color.Transparent;
            for (int i = 0; i < workspace_ob.known_color.Count; i++)
            {
                delta = Math.Sqrt((clr.R - workspace_ob.known_color[i].R) * (clr.R - workspace_ob.known_color[i].R)
                    + (clr.G - workspace_ob.known_color[i].G) * (clr.G - workspace_ob.known_color[i].G)
                    + (clr.B - workspace_ob.known_color[i].B) * (clr.B - workspace_ob.known_color[i].B));

                if (delta < min_delta)
                {
                    min_delta = delta;
                    min_delta_clr = workspace_ob.known_color[i];
                    clr_name = min_delta_clr.Name;
                }
            }
            return clr_name;
        }

        private void button_options_Click(object sender, EventArgs e)
        {
            TabOptions op = new TabOptions();
            if (workspace_ob.keys.Count < 2)
            {
                textBox_info.Text = "Please, add more keys.";
                return;
            }
            op.workspace_ob = this.workspace_ob;
            op.workspace_ob_last = this.workspace_ob;
            if (op.ShowDialog() == DialogResult.OK)
            {
                this.workspace_ob = op.workspace_ob;
                GenerateNumbers();
            }
            else return;
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Configuration Files(*.cnf)| *.cnf";
            saveFileDialog1.DefaultExt = "";
            if (Directory.Exists(Application.StartupPath.ToString() + "\\configtmpl\\"))
            {
                saveFileDialog1.InitialDirectory = Application.StartupPath.ToString() + "\\configtmpl\\";
            }
            saveFileDialog1.FileName = "SmartColoring";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                #region save_configure
                {
                    string for_save = OpenSave.saves_string_for_save_conf(workspace_ob);
                    File.WriteAllText(saveFileDialog1.FileName, for_save);
                    Refresh();
                }
                #endregion
            }
        }

        //private void OpenProgressDialog()
        //{
        //    prgBar.ShowDialog();

        //}

        private void vScrollBar1_Leave(object sender, EventArgs e)
        {

            vScrollBar1.Value = workspace_ob.field_ex.mudslide_for_vskroll * 5;
        }

        private void comboBox_plt_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_plt_TextUpdate(object sender, EventArgs e)
        {
            String str = "";
            for (int i = 0; i < comboBox_plt.Text.Count(); i++)
            {
                bool q = false;
                if (!Char.IsLetterOrDigit(comboBox_plt.Text[i]))
                {
                    q = true;
                }
                if (q == false)
                {
                    str += comboBox_plt.Text[i];
                }

            }
            comboBox_plt.Text = str;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            IIXC_Image img_for_open = inst.CreateEmptyImage(); //Crete new empty image for open file
            img_for_open.Load(workspace_ob.img_path); //Load image from it path

            IIXC_Page page_ixc = img_for_open.GetPage(0); //Create new page from image
            page_ixc.ConvertToFormat(IXC_PageFormat.PageFormat_8Indexed);
            workspace_ob.btm = new Bitmap((int)page_ixc.Width, (int)page_ixc.Height); //Converting by pixels page to C# bitmap
            for (int i = 0; i < page_ixc.Width; i++)
            {
                for (int j = 0; j < page_ixc.Height; j++)
                {
                    int color = (int)page_ixc.GetPixel(i, j);
                    Color clr = ColorTranslator.FromWin32(color);
                    workspace_ob.btm.SetPixel(i, j, clr);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bool q = false;
            colorDialog1.SolidColorOnly = true;
            colorDialog1.CustomColors = workspace_ob.op.custom_colors;
            do
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < workspace_ob.keys.Count; i++)
                    {
                        if (colorDialog1.Color == workspace_ob.keys[i].clr)
                        {
                            MessageBox.Show("Current color is in list of the keys. Chose other color.");
                            q = true;
                            break;
                        }
                        else
                        {
                            q = false;
                        }
                    }
                    if (q == true)
                        continue;
                    workspace_ob.op.custom_colors = colorDialog1.CustomColors;

                    int slRw = dataGridView1.CurrentRow.Index;
                    Color lastClr = workspace_ob.keys[slRw].clr;
                    workspace_ob.keys[slRw].clr = colorDialog1.Color;
                    workspace_ob.op.custom_colors = colorDialog1.CustomColors;
                    for (int i = 0; i < workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                        {
                            if (workspace_ob.field_ex.clr_fild[i][j] == lastClr)
                            {
                                workspace_ob.field_ex.str_fild[i][j] = "";
                                workspace_ob.field_ex.clr_fild[i][j] = colorDialog1.Color;
                            }
                        }
                    }
                    Refresh();
                }
                else
                    return;

            } while (q);
            UpdateDataGridView1();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help1 hlp = new Help1();
            hlp.StartPosition = FormStartPosition.CenterParent;
            hlp.ShowDialog();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            OpenImageNewThred open = new OpenImageNewThred();
            IIXC_Inst inst = (IIXC_Inst)axPXV_Control1.Inst.GetExtension("IXC"); //Create new instance
            IIXC_Image img_for_open = inst.CreateEmptyImage(); //Crete new empty image for open file
            IXC_PageFormat iFrmt = IXC_PageFormat.PageFormat_8Indexed;
            Bitmap btm = null;
            Thread workerThread = new Thread(delegate() { open.OpenImage(btm, openFileDialog1.FileName, img_for_open, inst, iFrmt); });

            workerThread.Start();
            workerThread.Join();
        }
    }

}
