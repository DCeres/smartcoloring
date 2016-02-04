using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AxPDFXEdit;
using PDFXEdit;

namespace test
{

    public partial class Pdf : Form
    {
        public static PXC_Rect rc = new PXC_Rect();// Create new PXC_Rect instance
        public static PXC_Rect rc_out = new PXC_Rect();// Create new PXC_Rect instance
        static IPXC_Inst inst_pxc;// Create new IPXC_Inst instance

        public static int page_Width;
        public static int page_Height;
        public static Workspace workspace_ob = new Workspace();
        public static int Rect_size = (page_Width) / (workspace_ob.field_ex.size_rect - 8);
        public static int height = workspace_ob.field_ex.heigth;
        public static int width = workspace_ob.field_ex.width;
        public static int keys_count = workspace_ob.keys.Count;
        public static int y_field_bottom = 0;
        public static int x_field_bottom = 0;
        AxPXV_Control apx_ctrl = new AxPXV_Control();
        private bool isColor = false;

        public static double x = 0;
        public static double y = 0;

        public Pdf()
        {
            InitializeComponent();
            inst_pxc = (IPXC_Inst)axPXV_Control1.Inst.GetExtension("PXC"); // Create new IPXC instance
        }

        public enum Colomn_number
        {
            FIRST, SECOND
        }

        private static bool isDarkColor(string color_name)
        {
            switch (color_name)
            {
                case "Brown": return true;
                case "Black": return true;
                case "Navy": return true;
                case "DarkGreen": return true;
                case "Indigo": return true;
                default: return false;
            }
        }

        //Method for drawing Keys in verrtical mode
        private static void Draw_Keys_Vartical(ref IPXC_ContentCreator CC, ref IPXC_Page page)
        {
            // Create new PXC_Rect instances
            PXC_Rect rc = new PXC_Rect();
            PXC_Rect rc_out = new PXC_Rect();

            int Rect_size_for_20 = page_Width / 22;
            height = workspace_ob.field_ex.heigth;
            width = workspace_ob.field_ex.width;
            keys_count = workspace_ob.keys.Count;
            Colomn_number key_colomn_number = Colomn_number.FIRST;

            CC.SetLineWidth(0.5);//Set line  width

            string str_keys = "Keys:\n";

            // Define the coordinates for rect
            rc.top = y_field_bottom - Rect_size_for_20 + Rect_size_for_20;
            rc.bottom = y_field_bottom - Rect_size_for_20 * 6;
            rc.left = Rect_size_for_20;
            rc.right = Rect_size_for_20 * 3;

            //Create IPXC_CharFormat to modify font size 
            IPXC_CharFormat char_format = inst_pxc.CreateCharFormat();
            char_format.FontSize = 20;
            char_format.ModifyMask((uint)PXC_CharFormatMask.CFM_FontSize, 0);

            //Creation text block for keys text
            CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

            //Draw text block with current text in rc coordinates
            CC.ShowTextBlock(str_keys, ref rc, ref rc,
                (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter | (uint)PXC_DrawTextFlags.DTF_Justify,
                (int)-1, char_format, null, null, out rc_out);


            // Define the coordinates for Template text block
            rc.top = page_Height - Rect_size_for_20 * 2 + 50;
            rc.bottom = page_Height - Rect_size_for_20 - 30;
            rc.left = Rect_size_for_20;
            rc.right = page_Width - Rect_size_for_20;

            //Showing text block with Template name            
            string template_info = Get_Template_String();
            CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

            //Draw text block with current text in rc coordinates
            CC.ShowTextBlock(template_info, ref rc, ref rc,
                (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter
                | (uint)PXC_DrawTextFlags.DTF_Justify, (int)-1, char_format, null, null, out rc_out);

            for (int i = 1, key_counter = 0; i <= keys_count && key_counter < keys_count; i++, key_counter++)
            {
                int key_rect_top = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20 + Rect_size_for_20);
                int key_rect_bottom = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20);
                int key_rect_right = page_Width - Rect_size_for_20;
                int key_rect_left = Rect_size_for_20;
                Color current_key_color = workspace_ob.keys[key_counter].clr;
                string string_in_key_field = workspace_ob.clr_name[key_counter];

                string current_key_text = workspace_ob.keys[key_counter].str;

                // Define the coordinates for rect
                rc.top = key_rect_top;
                rc.bottom = key_rect_bottom;
                rc.left = key_rect_left;
                rc.right = key_rect_right / 4;

                if (key_colomn_number == Colomn_number.FIRST && rc.top >= Rect_size)
                {
                    DrawColoringRect(ref CC, ref rc, Color.White);

                    // Define the coordinates for rect
                    rc.top = key_rect_top + 30;
                    rc.bottom = key_rect_bottom - 30;

                    CC.SetFillColorRGB(Get_UINT_Color(Color.Black)); //Set color of filling

                    //Draw text block with current text in rc coordinates
                    CC.ShowTextBlock(current_key_text, ref rc, ref rc,
                        (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                    rc.top = key_rect_top;
                    rc.bottom = key_rect_bottom;
                    rc.left = key_rect_right / 4;
                    rc.right = key_rect_right / 2 - 2;

                    CC.Rect(rc.left, rc.bottom, rc.right, rc.top);//Draw rectangle by current coordinates
                    CC.SetFillColorRGB(Get_UINT_Color(current_key_color));//Set color of filling
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);//Filling current element

                    rc.top = key_rect_top + 50;
                    rc.bottom = key_rect_bottom - 50;
                    rc.left = key_rect_right / 4;
                    rc.right = key_rect_right / 2 - 2;

                    if (!isDarkColor(string_in_key_field))
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling 
                    else
                        CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling 

                    CC.ShowTextBlock(string_in_key_field, ref rc, ref rc,
                        (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                }

                else
                {
                    if (key_colomn_number == Colomn_number.FIRST)
                    {
                        key_colomn_number = Colomn_number.SECOND;
                        i = 1;
                    }

                    key_rect_top = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20 + Rect_size_for_20);
                    key_rect_bottom = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20);
                    key_rect_right = page_Width - Rect_size_for_20 - 6;
                    key_rect_left = key_rect_right / 2;

                    // Define the coordinates for rect
                    rc.top = key_rect_top;
                    rc.bottom = key_rect_bottom;
                    rc.left = key_rect_left + 10;
                    rc.right = key_rect_left + (key_rect_right - key_rect_left) / 2;

                    CC.Rect(rc.left, rc.bottom, rc.right, rc.top);//Draw rectangle by current coordinates
                    CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);//Filling current element

                    // Define the coordinates for rect
                    rc.top = key_rect_top + 30;
                    rc.bottom = key_rect_bottom - 30;

                    CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

                    //Draw text block with current text in rc coordinates
                    CC.ShowTextBlock(current_key_text, ref rc, ref rc,
                        (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                    rc.top = key_rect_top;
                    rc.bottom = key_rect_bottom;
                    rc.left = rc.right;
                    rc.right = key_rect_left + (key_rect_right - key_rect_left);

                    CC.Rect(rc.left, rc.bottom, rc.right, rc.top);//Draw rectangle by current coordinates
                    CC.SetFillColorRGB(Get_UINT_Color(current_key_color));//Set color of filling
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);//Filling current element

                    rc.top = key_rect_top + 30;
                    rc.bottom = key_rect_bottom - 30;

                    rc.right = key_rect_right;

                    if (!isDarkColor(string_in_key_field))
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling 
                    else
                        CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling 

                    CC.ShowTextBlock(string_in_key_field, ref rc, ref rc,
                        (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                }
                page.PlaceContent(CC.Detach());//Appends drawn content to current page
                CC.SetLineWidth(0.5);//Set line  width
                CC.StrokePath(true);//Set end of drawing current element
            }

        }

        private static void DrawColoringRect(ref IPXC_ContentCreator CC, ref PXC_Rect rc, Color current_key_color)
        {
            CC.Rect(rc.left, rc.bottom, rc.right, rc.top);//Draw rectangle by current coordinates
            CC.SetFillColorRGB(Get_UINT_Color(current_key_color));//Set color of filling
            CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);//Filling current element
        }

        private static void Draw_Keys_Horisontal(ref IPXC_ContentCreator CC, ref IPXC_Page page)
        {
            int Rect_size_for_20 = (page_Width) / (20 + 2);
            height = workspace_ob.field_ex.heigth;
            width = workspace_ob.field_ex.width;
            keys_count = workspace_ob.keys.Count;
            PXC_Rect rc = new PXC_Rect();
            PXC_Rect rc_out = new PXC_Rect();
            CC.SetLineWidth(0.5);//Set line  width

            string str_keys = "Keys:\n";

            // Define the coordinates for rect
            rc.top = page_Height - (2 * Rect_size) - Rect_size_for_20 + 60;
            rc.bottom = page_Height - (2 * Rect_size) - 60;
            rc.left = x_field_bottom + Rect_size_for_20;
            rc.right = x_field_bottom + Rect_size_for_20 * 6;

            IPXC_CharFormat char_format = inst_pxc.CreateCharFormat();
            char_format.FontSize = 20;
            char_format.ModifyMask((uint)PXC_CharFormatMask.CFM_FontSize, 0);

            CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

            //Draw text block with current text in rc coordinates
            CC.ShowTextBlock(str_keys, ref rc, ref rc,
                (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter | (uint)PXC_DrawTextFlags.DTF_Justify,
                (int)-1, char_format, null, null, out rc_out);

            // Define the coordinates for rect
            rc.top = page_Height - Rect_size_for_20 * 2 + 90;
            rc.bottom = page_Height - Rect_size_for_20;
            rc.left = Rect_size_for_20;
            rc.right = page_Width - Rect_size_for_20;

            string template_info = Get_Template_String();
            CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

            //Draw text block with current text in rc coordinates
            CC.ShowTextBlock(template_info, ref rc, ref rc,
                (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter
                | (uint)PXC_DrawTextFlags.DTF_Justify, (int)-1, char_format, null, null, out rc_out);

            for (int i = 1, key_counter = 0; i <= keys_count && key_counter < keys_count; i++, key_counter++)
            {
                int key_rect_top = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20 + Rect_size_for_20);
                int key_rect_bottom = y_field_bottom - 2 * Rect_size_for_20 - (i * Rect_size_for_20);
                int key_rect_right = page_Width - Rect_size_for_20;
                int key_rect_left = Rect_size_for_20;
                Color current_key_color = workspace_ob.keys[key_counter].clr;
                string string_in_key_field = workspace_ob.clr_name[key_counter];
                string current_key_text = workspace_ob.keys[key_counter].str;

                // Define the coordinates for rect
                rc.top = page_Height - (3 * Rect_size) - ((Rect_size_for_20 / 2) * (i + 1)) + Rect_size_for_20 / 2;
                rc.bottom = page_Height - (3 * Rect_size) - ((Rect_size_for_20 / 2) * i) + Rect_size_for_20 / 2;
                rc.left = x_field_bottom + Rect_size_for_20;
                rc.right = x_field_bottom + Rect_size_for_20 * 4;

                DrawColoringRect(ref CC, ref rc, Color.White);

                // Define the coordinates for rect
                rc.top = rc.top + 30;
                rc.bottom = rc.bottom - 30;

                CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

                //Draw text block with current text in rc coordinates
                CC.ShowTextBlock(current_key_text, ref rc, ref rc,
                    (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                double old_left = rc.left;

                // Define the coordinates for rect
                rc.top = page_Height - (3 * Rect_size) - ((Rect_size_for_20 / 2) * (i + 1)) + Rect_size_for_20 / 2;
                rc.bottom = page_Height - (3 * Rect_size) - ((Rect_size_for_20 / 2) * i) + Rect_size_for_20 / 2;
                rc.left = rc.right + 10;
                rc.right = rc.right + (rc.right - old_left) + 10;

                DrawColoringRect(ref CC, ref rc, current_key_color);

                rc.top = rc.top + 30;
                rc.bottom = rc.bottom - 30;

                if (!isDarkColor(string_in_key_field))
                    CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling 
                else
                    CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling 

                CC.ShowTextBlock(string_in_key_field, ref rc, ref rc,
                    (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                page.PlaceContent(CC.Detach());//Appends drawn content to current page
                CC.SetLineWidth(0.5);//Set line  width
                CC.StrokePath(true);//Set end of drawing current element
            }
        }


        private void Pdf_Shown(object sender, EventArgs ep)
        {
            if (workspace_ob.op.orientation_of_document == 0)
            {
                page_Width = 800;
                page_Height = 1200;
                this.Width = 586;
                this.Height = 713;
                axPXV_Control1.Width = 570;
                axPXV_Control1.Height = 608;
                button1.Location = new Point(10, 635);
                checkBox_with_color.Location = new Point(11, 613);
                button_Print.Location = new Point(99, 635);
                button_zoomin.Location = new Point(190, 635);
                button_zoom_out.Location = new Point(288, 635);
            }
            else if (workspace_ob.op.orientation_of_document == 1)
            {
                page_Width = 1200;
                page_Height = 800;
                this.Width = 835;
                this.Height = 647;
                axPXV_Control1.Width = 809;
                axPXV_Control1.Height = 543;
                button1.Location = new Point(10, 570);
                checkBox_with_color.Location = new Point(11, 548);
                button_Print.Location = new Point(99, 570);
                button_zoomin.Location = new Point(190, 570);
                button_zoom_out.Location = new Point(288, 570);
            }
            axPXV_Control1.Inst.Settings["Operations.PrintPages.ScaleType"].v = 1; //Set Scale Type in Print dialog to "Fit to printer margins"
            axPXV_Control1.Inst.Settings["Operations.PrintPages.ScaleSimple.AutoCentre"].v = true; //Set Scale Simple in Print dialog to "AutoCentre"
            axPXV_Control1.CreateNewBlankDoc(page_Width, page_Height, 0); // Create new Page in Doc
            int z;
            if (workspace_ob.op.orientation_of_document == 0)
            {
                z = 2;

            }
            else
            {
                z = 3;
            }
            for (int i = 0; i <= z; i++)
            {
                axPXV_Control1.ZoomOut(); //Zoom out current document
            }
            Redraw_PDF();
        }

        private void Redraw_field_vertical(int width, int height, PDFXEdit.IPXC_ContentCreator CC, PDFXEdit.IPXC_Page page)
        {
            for (int i = 1; i <= width + 1; i++)
            {
                CC.SetLineWidth(1);//Set line  width
                CC.MoveTo(i * Rect_size, page_Height - (2 * Rect_size));//Draw line
                CC.LineTo(i * Rect_size, page_Height - (2 * Rect_size + (height * Rect_size)));//Draw line
                CC.StrokePath(true);//Set end of drawing current element
            }

            for (int i = 2; i <= height + 2; i++)
            {
                CC.SetLineWidth(1);//Set line  width
                CC.MoveTo(Rect_size, page_Height - (i * Rect_size));//Draw line
                CC.LineTo(Rect_size + (width * Rect_size), page_Height - (i * Rect_size));//Draw line
                CC.StrokePath(true);//Set end of drawing current element

                if (i == height + 2)
                    y_field_bottom = page_Height - (i * Rect_size);
            }

            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    x = i * Rect_size + Rect_size;
                    y = page_Height - (j * Rect_size + Rect_size);
                    Color current_field_color = workspace_ob.field_ex.clr_fild[i - 1][j - 1];

                    // Define the coordinates for rect
                    rc.bottom = y - Rect_size;
                    rc.top = y;
                    rc.left = x - (Rect_size);
                    rc.right = x;

                    if (isColor)
                    {
                        CC.Rect(rc.left, rc.bottom, rc.right, rc.top);//Draw rectangle by current coordinates
                        CC.SetFillColorRGB(Get_UINT_Color(current_field_color));//Set color of filling
                        CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);//Filling current element
                        CC.StrokePath(true);//Set end of drawing current element
                        page.PlaceContent(CC.Detach());//Appends drawn content to current page

                        string current_text = workspace_ob.field_ex.str_fild[i - 1][j - 1];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

                        for (int k = 0; k < workspace_ob.keys.Count; k++)
                        {
                            if (workspace_ob.keys[k].clr == current_field_color)
                            {
                                if (isDarkColor(workspace_ob.clr_name[k]))
                                    CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling
                            }
                        }

                        //Draw text block with current text in rc coordinates
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                    }
                    else
                    {
                        string current_text = workspace_ob.field_ex.str_fild[i - 1][j - 1];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

                        //Draw text block with current text in rc coordinates
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                    }
                    CC.StrokePath(true);//Set end of drawing current element
                    page.PlaceContent(CC.Detach());//Appends drawn content to current page
                }
            }
        }

        private void Redraw_field_horisontal(int width, int height, PDFXEdit.IPXC_ContentCreator CC, PDFXEdit.IPXC_Page page)
        {
            for (int i = 1; i <= width + 1; i++)
            {
                CC.SetLineWidth(1);//Set line  width
                CC.MoveTo(i * Rect_size, page_Height - (2 * Rect_size)); //Draw line
                CC.LineTo(i * Rect_size, page_Height - (2 * Rect_size + (height * Rect_size)));//Draw line
                CC.StrokePath(true);//Set end of drawing current element

                if (i == width + 1)
                    x_field_bottom = i * Rect_size;
            }

            for (int i = 2; i <= height + 2; i++)
            {
                CC.SetLineWidth(1);//Set line  width
                CC.MoveTo(Rect_size, page_Height - (i * Rect_size));//Draw line
                CC.LineTo(Rect_size + (width * Rect_size), page_Height - (i * Rect_size));//Draw line
                CC.StrokePath(true);//Set end of drawing current element
            }

            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    x = i * Rect_size + Rect_size;
                    y = page_Height - (j * Rect_size + Rect_size);
                    Color current_field_color = workspace_ob.field_ex.clr_fild[i - 1][j - 1];

                    // Define the coordinates for rect
                    rc.bottom = y - Rect_size;
                    rc.top = y;
                    rc.left = x - (Rect_size);
                    rc.right = x;

                    if (isColor)
                    {
                        CC.Rect(rc.left, rc.bottom, rc.right, rc.top); //Draw rectangle by current coordinates
                        CC.SetFillColorRGB(Get_UINT_Color(current_field_color)); //Set color of filling
                        CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd); //Filling current element
                        CC.StrokePath(true);//Set end of drawing current element
                        page.PlaceContent(CC.Detach());//Appends drawn content to current page
                        string current_text = workspace_ob.field_ex.str_fild[i - 1][j - 1];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));//Set color of filling

                        for (int k = 0; k < workspace_ob.keys.Count; k++)
                        {
                            if (workspace_ob.keys[k].clr == current_field_color)
                            {
                                if (isDarkColor(workspace_ob.clr_name[k]))
                                    CC.SetFillColorRGB(Get_UINT_Color(Color.White));//Set color of filling
                            }
                        }

                        //Draw text block with current text in rc coordinates
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter,
                            (int)-1, null, null, null, out rc_out);
                    }
                    else
                    {
                        string current_text = workspace_ob.field_ex.str_fild[i - 1][j - 1];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black)); //Set color of filling

                        //Draw text block with current text in rc coordinates
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter,
                            (int)-1, null, null, null, out rc_out);
                    }
                    CC.StrokePath(true);//Set end of drawing current element
                    page.PlaceContent(CC.Detach()); //Appends drawn content to current page
                }
            }
        }

        private void Redraw_PDF()
        {
            ProgressBar1 prBar = new ProgressBar1();
            try
            {
                prBar.Show();
                prBar.Refresh();
                int Rect_size_for_20 = page_Width / 22;
                if (workspace_ob.op.orientation_of_document == 0)
                    Rect_size = (page_Width) / (workspace_ob.field_ex.width + 2);
                else
                    Rect_size = (page_Height) / (workspace_ob.field_ex.heigth + 2);
                height = workspace_ob.field_ex.heigth;
                width = workspace_ob.field_ex.width;
                keys_count = workspace_ob.keys.Count;

                int nID = axPXV_Control1.Inst.Str2ID("op.document.insertEmptyPages", false); //Create new "InsertEmptyPages" operation iD
                PDFXEdit.IOperation pOp = axPXV_Control1.Inst.CreateOp(nID); //Create new operation
                PDFXEdit.ICabNode input = pOp.Params.Root["Input"]; //Create "Input" id to current operation
                IPXC_Document pDoc = axPXV_Control1.Doc.CoreDoc;

                input.v = pDoc; //Specify that working with current document
                PDFXEdit.ICabNode options = pOp.Params.Root["Options"]; //Create "Option" id to current operation
                options["PaperType"].v = 2; //Apply custom paper type

                if (workspace_ob.op.orientation_of_document == 0)
                {
                    options["Width"].v = 800;
                    options["Height"].v = 1200;
                }
                else
                {
                    options["Width"].v = 1200;
                    options["Height"].v = 800;
                }
                pOp.Do(); //Applying creation new pages
                nID = axPXV_Control1.Inst.Str2ID("op.document.deletePages", false); //Create new "deletePages" operation id
                pOp = axPXV_Control1.Inst.CreateOp(nID); //Create new operation
                input = pOp.Params.Root["Input"];  //Create "Input" id to current operation
                input.v = pDoc; //Specify that working with current document
                options = pOp.Params.Root["Options"]; //Create "Option" id to current operation
                options["PagesRange.Custom"].v = 0; //Specify range of deleting pages. In this case it is just one zeroth page
                pOp.Do();//Applying deletion range of pages

                var page = axPXV_Control1.Doc.CoreDoc.Pages[0]; //Create handler to first page
                var CC = axPXV_Control1.Doc.CoreDoc.CreateContentCreator(); //Create "Content Creator" for drawing on page.

                if (workspace_ob.op.orientation_of_document == 0)
                {
                    Redraw_field_vertical(width, height, CC, page);
                    Draw_Keys_Vartical(ref CC, ref page);
                }
                else if (workspace_ob.op.orientation_of_document == 1)
                {
                    Redraw_field_horisontal(width, height, CC, page);
                    Draw_Keys_Horisontal(ref CC, ref page);
                }
                CC.SetLineWidth(0.5); //Set line  width
                CC.StrokePath(true); //Set end of drawing current element

                nID = axPXV_Control1.Inst.Str2ID("op.document.resizePages", false);
                pOp = axPXV_Control1.Inst.CreateOp(nID);
                input = pOp.Params.Root["Input"];
                input.v = pDoc;
                options = pOp.Params.Root["Options"];
                options["PaperType"].v = 2; //Document values table
                options["StdPaperIndex"].v = 4; //A2
                options["ScalePage"].v = true;
                options["ConstraintProportions"].v = true;
                options["PagesRange.Filter"].v = 1;
                if (workspace_ob.op.orientation_of_document == 1)
                {
                    options["Width"].v = 841.89;
                    options["Height"].v = 595.276;
                }
                pOp.Do();
                prBar.Hide();
                prBar.Refresh();
            }
            catch 
            {
                MessageBox.Show("Generate PDF again.");
                prBar.Hide();
                prBar.Refresh();
                return;
            }
            prBar.Hide();
            prBar.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF Files| *.pdf";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = "SmartColoring.pdf";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string path = saveFileDialog1.FileName;
                    axPXV_Control1.Doc.CoreDoc.WriteToFile(path); //Write created document to PDF new file
                }
                catch
                {
                    MessageBox.Show(this, "File with that name is open in other program. Close it for save.");
                }
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                axPXV_Control1.PrintWithDlg(); //Create and show print dialog
            }
            catch
            {
                return;
            }
        }
        private void checkBox_with_color_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_with_color.Checked == true)
                isColor = true;
            else
                isColor = false;

            Redraw_PDF();
        }

        private static uint Get_UINT_Color(Color current_field_color)
        {
            uint clgr = 0;
            return clgr = (uint)((byte)(current_field_color.R) | ((UInt16)((byte)(current_field_color.G)) << 8)) |
                (((UInt32)(byte)(current_field_color.B)) << 16);
        }

        public static string Get_Template_String()
        {
            string output = "GAME MODE : ";
            switch (workspace_ob.op.game_mod)
            {
                case Workspace.options.g_mod.BASIC_EVEN_ODD:
                    output += "Basic - Even/Odd";
                    break;
                case Workspace.options.g_mod.BASIC_PRIM_COMP:
                    output += "Basic - Prime/Composite";
                    break;
                case Workspace.options.g_mod.BASIC_MYST:
                    output += "Basic - Mystery mode";
                    break;
                case Workspace.options.g_mod.ALGEBRA_SIMP:
                    {
                        output += "Algebra - Simple";
                        output += GetComplexity();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING:
                    output += "Algebra - Middle(Regrouping)";
                    break;
                case Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING:
                    output += "Algebra - Middle(Rounding)";
                    break;
                case Workspace.options.g_mod.ALGEBRA_HARD_DEC:
                    output += "Algebra - Hard(Decimals)";
                    break;
                case Workspace.options.g_mod.ALGEBRA_HARD_FRAC:
                    output += "Algebra - Hard(Fractions)";
                    break;
                case Workspace.options.g_mod.ALGEBRA_HARD_PERC:
                    output += "Algebra - Hard(Percentages)";
                    break;
                case Workspace.options.g_mod.GEOM_ANGLES:
                    output += "Geometry - Angles";
                    break;
                case Workspace.options.g_mod.GEOM_QUADR:
                    output += "Geometry - Quadrants";
                    break;
                case Workspace.options.g_mod.GEOM_SHAPES:
                    output += "Geometry - Shapes";
                    break;
            }
            return output;
        }

        private static string GetComplexity()
        {
            string output = "";
            switch (workspace_ob.op.active_complexity)
            {
                case Workspace.options.complexity.JUNIOR:
                    output += " : Junior";
                    break;
                case Workspace.options.complexity.BASIC:
                    output += " : Basic";
                    break;
                case Workspace.options.complexity.ADVANCED_COMA:
                    output += " : Advanced(Separated by coma)";
                    break;
                case Workspace.options.complexity.ADVANCED_HYPHEN:
                    output += " : Advanced(Numbers by range)";
                    break;
            }
            return output;
        }

        private void button_zoomin_Click(object sender, EventArgs e)
        {
            axPXV_Control1.ZoomIn();
        }

        private void button_zoom_out_Click(object sender, EventArgs e)
        {
            axPXV_Control1.ZoomOut();
        }
    }
}