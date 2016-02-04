namespace test
{
    partial class Pdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pdf));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axPXV_Control1 = new AxPDFXEdit.AxPXV_Control();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_with_color = new System.Windows.Forms.CheckBox();
            this.button_Print = new System.Windows.Forms.Button();
            this.button_zoomin = new System.Windows.Forms.Button();
            this.button_zoom_out = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // axPXV_Control1
            // 
            this.axPXV_Control1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axPXV_Control1.Enabled = true;
            this.axPXV_Control1.Location = new System.Drawing.Point(0, 0);
            this.axPXV_Control1.Name = "axPXV_Control1";
            this.axPXV_Control1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPXV_Control1.OcxState")));
            this.axPXV_Control1.Size = new System.Drawing.Size(587, 601);
            this.axPXV_Control1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 628);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_with_color
            // 
            this.checkBox_with_color.AutoSize = true;
            this.checkBox_with_color.Location = new System.Drawing.Point(11, 606);
            this.checkBox_with_color.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_with_color.Name = "checkBox_with_color";
            this.checkBox_with_color.Size = new System.Drawing.Size(74, 17);
            this.checkBox_with_color.TabIndex = 2;
            this.checkBox_with_color.Text = "With color";
            this.checkBox_with_color.UseVisualStyleBackColor = true;
            this.checkBox_with_color.CheckedChanged += new System.EventHandler(this.checkBox_with_color_CheckedChanged);
            // 
            // button_Print
            // 
            this.button_Print.Location = new System.Drawing.Point(111, 628);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(75, 23);
            this.button_Print.TabIndex = 1;
            this.button_Print.Text = "Print";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // button_zoomin
            // 
            this.button_zoomin.Location = new System.Drawing.Point(219, 628);
            this.button_zoomin.Name = "button_zoomin";
            this.button_zoomin.Size = new System.Drawing.Size(87, 23);
            this.button_zoomin.TabIndex = 3;
            this.button_zoomin.Text = "Zoom In";
            this.button_zoomin.UseVisualStyleBackColor = true;
            this.button_zoomin.Click += new System.EventHandler(this.button_zoomin_Click);
            // 
            // button_zoom_out
            // 
            this.button_zoom_out.Location = new System.Drawing.Point(312, 628);
            this.button_zoom_out.Name = "button_zoom_out";
            this.button_zoom_out.Size = new System.Drawing.Size(87, 23);
            this.button_zoom_out.TabIndex = 4;
            this.button_zoom_out.Text = "Zoom Out";
            this.button_zoom_out.UseVisualStyleBackColor = true;
            this.button_zoom_out.Click += new System.EventHandler(this.button_zoom_out_Click);
            // 
            // Pdf
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(587, 659);
            this.Controls.Add(this.button_zoom_out);
            this.Controls.Add(this.button_zoomin);
            this.Controls.Add(this.checkBox_with_color);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axPXV_Control1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF";
            this.Shown += new System.EventHandler(this.Pdf_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxPDFXEdit.AxPXV_Control axPXV_Control1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_with_color;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Button button_zoomin;
        private System.Windows.Forms.Button button_zoom_out;
    }
}