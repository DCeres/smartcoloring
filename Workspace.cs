using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace test
{
    public class Workspace
    {
        public string img_path;
        public Bitmap btm;
        public class options
        {
            public enum g_mod
            {
                BASIC_EVEN_ODD, BASIC_PRIM_COMP, BASIC_MYST, ALGEBRA_SIMP, ALGEBRA_MIDD_REGROPING, ALGEBRA_MIDD_ROUNDING, ALGEBRA_HARD_FRAC, ALGEBRA_HARD_DEC, ALGEBRA_HARD_PERC, GEOM_ANGLES, GEOM_QUADR, GEOM_SHAPES, NONE
            };
            public enum complexity
            {
                JUNIOR, BASIC, ADVANCED, ADVANCED_COMA, ADVANCED_HYPHEN, NONE
            };
            public enum fractions
            {
                DIFFERENT, EQUAL_NUM, EQUAL_DEN, NONE
            }
            public enum algebra_middle_round{
                HUNDREDS, TENS, NONE
            }
            
            public g_mod game_mod = g_mod.ALGEBRA_SIMP;
            public bool addition_act = true;
            public bool subtraction_act = true;
            public bool division_act = false;
            public bool multiplication_act = false;
            public fractions active_fractions_mode = fractions.DIFFERENT;
            public complexity active_complexity = complexity.BASIC;
            public int active_range_first = 1;
            public int active_range_second = 10;
            public algebra_middle_round active_algebra_middle_round = algebra_middle_round.NONE;
            public int orientation_of_document = 0;//if 1 then horisontal if 0 then vertical
            public int[] custom_colors = new int[]{6916092, 15195440, 16107657, 1836924,
   3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
   3102017, 7324121, 14993507, 11730944};
        }
        public int selectedValTmpl = 0;
        public string activationKey = "";
        public string[] list_of_cnf_files;
        public string[] list_of_plt_files;
        public DragEventArgs dragAndDropEnterArg;
        public options op = new options();
        public List<string> clr_name;
        public List<Color> known_color;
        public class field
        {
            public int heigth;
            public int width;
            public int mudslide_for_hskroll;
            public int mudslide_for_vskroll;
            public int size_rect;
            public List<List<Color>> clr_fild;
            public List<List<string>> str_fild;

            public field()
            {
                int max_width_heigth = 40;
                width = 20;
                heigth = 20;
                mudslide_for_hskroll = 0;
                mudslide_for_vskroll = 0;
                clr_fild = new List<List<Color>>();
                str_fild = new List<List<string>>();
                size_rect = 30;
                for (int i = 0; i <= max_width_heigth; i++)
                {
                    clr_fild.Add(new List<Color>());
                    str_fild.Add(new List<string>());
                    for (int j = 0; j <= max_width_heigth; j++)
                    {
                        clr_fild[i].Add(Color.Transparent);
                        str_fild[i].Add(" ");
                    }
                }
            }
        }
        public class key
        {
            public string str = "";
            public Color clr = Color.Transparent;
            public key(string st, Color cl)
            {
                str = st;
                clr = cl;
            }
        }
        public bool isLbuttonDown = false;
        public bool isRbuttonDown = false;
        public bool clean_colors = false;
        public Color active_rc_color = Color.Brown;
        public field field_ex = new field();
        public List<key> keys;
        public List<Color> main_colors = new List<Color>();
        public char sign = '+';
        public ToolStripMenuItem checked_item_in_tmpl_menu;
        public List<string> vadil_data;
        public bool auto_generate = true;
        public int delta_for_open_image = 110;
        public int qnt = 0;
        public Workspace()
        {
            keys = new List<key>();
            known_color = new List<Color>();
            clr_name = new List<string>();
            keys.Add(new Workspace.key("", Color.Tan));
            keys.Add(new Workspace.key("", Color.Brown));

            known_color.Add(Color.Black);
            known_color.Add(Color.Blue);
            known_color.Add(Color.Brown);
            known_color.Add(Color.Coral);
            known_color.Add(Color.Gold);
            known_color.Add(Color.Gray);
            known_color.Add(Color.Green);
            known_color.Add(Color.Lime);
            known_color.Add(Color.Olive);
            known_color.Add(Color.Orange);
            known_color.Add(Color.Pink);
            known_color.Add(Color.Purple);
            known_color.Add(Color.Red);
            known_color.Add(Color.Silver);
            known_color.Add(Color.Tan);
            known_color.Add(Color.Violet);
            known_color.Add(Color.White);
            known_color.Add(Color.Yellow);
            known_color.Add(Color.Tomato);
            known_color.Add(Color.DarkBlue);
            known_color.Add(Color.DarkGreen);
            known_color.Add(Color.DarkOrange);
            known_color.Add(Color.DarkRed);
            known_color.Add(Color.DarkViolet);
            known_color.Add(Color.DeepPink);
            known_color.Add(Color.ForestGreen);
            known_color.Add(Color.Navy);
            known_color.Add(Color.Beige);
            known_color.Add(Color.DarkCyan);
            known_color.Add(Color.Cyan);
            known_color.Add(Color.DarkOrchid);
            known_color.Add(Color.DarkSalmon);
            known_color.Add(Color.DarkSeaGreen);
            known_color.Add(Color.DarkSlateBlue);
            known_color.Add(Color.Firebrick);
            known_color.Add(Color.Fuchsia);
            known_color.Add(Color.GreenYellow);
            known_color.Add(Color.Indigo);
            known_color.Add(Color.Ivory);
            known_color.Add(Color.RoyalBlue);
            known_color.Add(Color.Turquoise);
        }
    }
    
}
