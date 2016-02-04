using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxPDFXEdit;
using PDFXEdit;
using System.Windows.Forms;
using System.Drawing;

namespace test
{
    public class OpenImageNewThred
    {
        public void OpenImage(Bitmap btm, string imgPath, IIXC_Image img_for_open, IIXC_Inst inst, IXC_PageFormat pgFmt)
        { 
            btm = null;
            img_for_open.Load(imgPath); //Load image from it path
            IIXC_Page page_ixc = img_for_open.GetPage(0);
            page_ixc.ConvertToFormat(pgFmt);
            btm = new Bitmap((int)page_ixc.Width, (int)page_ixc.Height); //Converting by pixels page to C# bitmap
            for (int i = 0; i < page_ixc.Width; i++)
            {
                for (int j = 0; j < page_ixc.Height; j++)
                {
                    int color = (int)page_ixc.GetPixel(i, j);
                    Color clr = ColorTranslator.FromWin32(color);
                    btm.SetPixel(i, j, clr);
                }
            }
        }
    //    public static void SaveImage(AxPXV_Control axPXV_Control1, Workspace workspace_ob, string imageDest, IXC_ImageFileFormatIDs format)
    //    {
    //        IXC_PageFormat nFormat = IXC_PageFormat.PageFormat_8Indexed;
    //        IIXC_Inst inst = (IIXC_Inst)axPXV_Control1.Inst.GetExtension("IXC");
    //        IIXC_Page page_ixc = inst.Page_CreateEmpty((uint)workspace_ob.field_ex.width, (uint)workspace_ob.field_ex.heigth, nFormat, 324345);
    //        page_ixc.PaletteSize = (uint)workspace_ob.keys.Count;
    //        for (int i = 0; i < workspace_ob.field_ex.width; i++)
    //        {
    //            for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
    //            {
    //                Color clr = workspace_ob.field_ex.clr_fild[i][j];
    //                uint clgr = (uint)((byte)(clr.R) | ((UInt16)((byte)(clr.G)) << 8)) | (((UInt32)(byte)(clr.B)) << 16);
    //                page_ixc.SetPixel(i, j, (uint)clgr, (uint)IXC_ColorFlags.Color_AddColor);
    //            }
    //        }
    //        page_ixc.ConvertToFormat(nFormat);
    //        IIXC_Image img = inst.CreateEmptyImage();
    //        img.InsertPage(page_ixc);
    //        page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_FILTER, 0);
    //        page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_FORMAT, (uint)format);
    //        page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_ITYPE, 16);
    //        page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_COMP_LEVEL, 2);
    //        page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_COMP_TYPE, 0);
    //        img.Save(imageDest, IXC_CreationDisposition.CreationDisposition_Overwrite);
    //    }
    }
}
