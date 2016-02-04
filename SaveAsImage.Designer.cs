namespace test
{
    partial class SaveAsImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAsImage));
            this.axPXV_Control1 = new AxPDFXEdit.AxPXV_Control();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axCoPDFXCview1 = new AxPDFXCviewAxLib.AxCoPDFXCview();
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axCoPDFXCview1)).BeginInit();
            this.SuspendLayout();
            // 
            // axPXV_Control1
            // 
            this.axPXV_Control1.Enabled = true;
            this.axPXV_Control1.Location = new System.Drawing.Point(243, 12);
            this.axPXV_Control1.Name = "axPXV_Control1";
            this.axPXV_Control1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPXV_Control1.OcxState")));
            this.axPXV_Control1.Size = new System.Drawing.Size(550, 423);
            this.axPXV_Control1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // axCoPDFXCview1
            // 
            this.axCoPDFXCview1.Enabled = true;
            this.axCoPDFXCview1.Location = new System.Drawing.Point(12, 12);
            this.axCoPDFXCview1.Name = "axCoPDFXCview1";
            this.axCoPDFXCview1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCoPDFXCview1.OcxState")));
            this.axCoPDFXCview1.Size = new System.Drawing.Size(225, 423);
            this.axCoPDFXCview1.TabIndex = 1;
            // 
            // SaveAsImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 447);
            this.Controls.Add(this.axCoPDFXCview1);
            this.Controls.Add(this.axPXV_Control1);
            this.Name = "SaveAsImage";
            this.Text = "SaveAsImage";
            this.Shown += new System.EventHandler(this.SaveAsImage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axCoPDFXCview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxPDFXEdit.AxPXV_Control axPXV_Control1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        //private AxPDFXCviewAxLib.AxCoPDFXCview axCoPDFXCview1;
    }
}