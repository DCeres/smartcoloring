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

namespace test
{

    
    public partial class SaveAsImage : Form
    {
        public Workspace workspace_ob = new Workspace();
        public SaveAsImage()
        {
            InitializeComponent();
        }

        private void SaveAsImage_Shown(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            axPXV_Control1.CreateNewBlankDoc(500, 500, 1);
            
            var page = axPXV_Control1.Doc.CoreDoc.Pages[0];
            var CC = axPXV_Control1.Doc.CoreDoc.CreateContentCreator();
            //page.Document.AddImageFromFile(openFileDialog1.FileName);
            //axPXV_Control1.Doc.CoreDoc.WriteToFile(openFileDialog1.FileName);
            IXC_ImageFileFormatIDs img = IXC_ImageFileFormatIDs.FMT_PBM_ID;
            page.Document.WriteToFile(openFileDialog1.FileName);
            IXC_PageFormat nFormat = IXC_PageFormat.PageFormat_8Indexed;
            //ConvertFormatToIndx(page, nFormat);
            IXC_Channel sd = IXC_Channel.Channel_R;
           IIXC_Page d;
            axPXV_Control1.CreateNewBlankDoc(600, 600, 1);
            PXC_BoxType bx = new PXC_BoxType();
            PXC_Matrix mtr = page.GetMatrix(bx);
            page.GetMatrix(bx);
            tagRECT tgRct = new tagRECT();
            IIXC_Inst inst = (IIXC_Inst)axPXV_Control1.Inst.GetExtension("IXC");
            

        }
        private void ConvertFormatToIndx(PDFXEdit.IIXC_Page pPage, PDFXEdit.IXC_PageFormat pFormat)
        {
            if (pPage == null)
                return;
            pPage.ConvertToFormat(pFormat);



            //PDFXEdit.IOperation pOp = pInst.CreateOp(nID);
            //PDFXEdit.ICabNode input = pOp.Params.Root["Input"];
            //input.v = pDoc;
            //PDFXEdit.ICabNode options = pOp.Params.Root["Options"];
            //options["PaperType"].v = 1; //Standard values table
            //options["StdPaperIndex"].v = 2; //A2
            //pOp.Do();
        }
        private void CreateEmptyPage(PDFXEdit.IIXC_Inst inst, ref PDFXEdit.IIXC_Page pg)
        {
            pg = inst.Page_CreateEmpty(600, 600, 0, 234);



            //PDFXEdit.IOperation pOp = pInst.CreateOp(nID);
            //PDFXEdit.ICabNode input = pOp.Params.Root["Input"];
            //input.v = pDoc;
            //PDFXEdit.ICabNode options = pOp.Params.Root["Options"];
            //options["PaperType"].v = 1; //Standard values table
            //options["StdPaperIndex"].v = 2; //A2
            //pOp.Do();
        }
    
    }
    
    
}
