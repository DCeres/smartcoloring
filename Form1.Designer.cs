namespace test
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generatePDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propetiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textBox_info = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button_add_color = new System.Windows.Forms.Button();
			this.button_delete_color = new System.Windows.Forms.Button();
			this.butoon_generate_field = new System.Windows.Forms.Button();
			this.button_generate_num = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button_del_palette = new System.Windows.Forms.Button();
			this.button_save_palette = new System.Windows.Forms.Button();
			this.comboBox_plt = new System.Windows.Forms.ComboBox();
			this.groupBox_demo = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_activ = new System.Windows.Forms.TextBox();
			this.button_options = new System.Windows.Forms.Button();
			this.axPXV_Control1 = new AxPDFXEdit.AxPXV_Control();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox_demo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(973, 33);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem,
            this.generatePDFToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click_1);
			// 
			// saveConfigurationToolStripMenuItem
			// 
			this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
			this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
			this.saveConfigurationToolStripMenuItem.Text = "Save Template";
			this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
			// 
			// generatePDFToolStripMenuItem
			// 
			this.generatePDFToolStripMenuItem.Name = "generatePDFToolStripMenuItem";
			this.generatePDFToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
			this.generatePDFToolStripMenuItem.Text = "Generate PDF";
			this.generatePDFToolStripMenuItem.Click += new System.EventHandler(this.generatePDFToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanAllToolStripMenuItem,
            this.optionsToolStripMenuItem1});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// cleanAllToolStripMenuItem
			// 
			this.cleanAllToolStripMenuItem.Name = "cleanAllToolStripMenuItem";
			this.cleanAllToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
			this.cleanAllToolStripMenuItem.Text = "Clean";
			this.cleanAllToolStripMenuItem.Click += new System.EventHandler(this.cleanAllToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem1
			// 
			this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
			this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(160, 30);
			this.optionsToolStripMenuItem1.Text = "Options";
			this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propetiesToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// propetiesToolStripMenuItem
			// 
			this.propetiesToolStripMenuItem.Name = "propetiesToolStripMenuItem";
			this.propetiesToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
			this.propetiesToolStripMenuItem.Text = "Settings";
			this.propetiesToolStripMenuItem.Click += new System.EventHandler(this.propetiesToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(20, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 36);
			this.label1.TabIndex = 3;
			this.label1.Text = "Keys:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.dataGridView1.Location = new System.Drawing.Point(20, 52);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(231, 150);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Numbers";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 125;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.HeaderText = "Color";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// textBox_info
			// 
			this.textBox_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_info.Cursor = System.Windows.Forms.Cursors.Default;
			this.textBox_info.Enabled = false;
			this.textBox_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_info.Location = new System.Drawing.Point(20, 440);
			this.textBox_info.Multiline = true;
			this.textBox_info.Name = "textBox_info";
			this.textBox_info.ReadOnly = true;
			this.textBox_info.Size = new System.Drawing.Size(231, 90);
			this.textBox_info.TabIndex = 7;
			// 
			// button_add_color
			// 
			this.button_add_color.AutoSize = true;
			this.button_add_color.Location = new System.Drawing.Point(20, 209);
			this.button_add_color.Name = "button_add_color";
			this.button_add_color.Size = new System.Drawing.Size(99, 30);
			this.button_add_color.TabIndex = 8;
			this.button_add_color.Text = "Add Color";
			this.button_add_color.UseVisualStyleBackColor = true;
			this.button_add_color.Click += new System.EventHandler(this.button_add_color_Click);
			// 
			// button_delete_color
			// 
			this.button_delete_color.AutoSize = true;
			this.button_delete_color.Location = new System.Drawing.Point(144, 209);
			this.button_delete_color.Name = "button_delete_color";
			this.button_delete_color.Size = new System.Drawing.Size(107, 30);
			this.button_delete_color.TabIndex = 8;
			this.button_delete_color.Text = "Delete Color";
			this.button_delete_color.UseVisualStyleBackColor = true;
			this.button_delete_color.Click += new System.EventHandler(this.button_delete_color_Click);
			// 
			// butoon_generate_field
			// 
			this.butoon_generate_field.AllowDrop = true;
			this.butoon_generate_field.AutoSize = true;
			this.butoon_generate_field.Location = new System.Drawing.Point(20, 372);
			this.butoon_generate_field.Name = "butoon_generate_field";
			this.butoon_generate_field.Size = new System.Drawing.Size(231, 30);
			this.butoon_generate_field.TabIndex = 0;
			this.butoon_generate_field.Text = "Generate PDF";
			this.butoon_generate_field.UseVisualStyleBackColor = true;
			this.butoon_generate_field.Click += new System.EventHandler(this.butoon_generate_field_Click);
			this.butoon_generate_field.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butoon_generate_field_KeyDown);
			// 
			// button_generate_num
			// 
			this.button_generate_num.AutoSize = true;
			this.button_generate_num.Location = new System.Drawing.Point(20, 339);
			this.button_generate_num.Name = "button_generate_num";
			this.button_generate_num.Size = new System.Drawing.Size(231, 30);
			this.button_generate_num.TabIndex = 9;
			this.button_generate_num.Text = "Generate new keys Numbers";
			this.button_generate_num.UseVisualStyleBackColor = true;
			this.button_generate_num.Click += new System.EventHandler(this.button_generate_num_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.CausesValidation = false;
			this.vScrollBar1.Location = new System.Drawing.Point(619, 6);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(15, 609);
			this.vScrollBar1.SmallChange = 5;
			this.vScrollBar1.TabIndex = 11;
			this.vScrollBar1.Visible = false;
			this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
			this.vScrollBar1.Leave += new System.EventHandler(this.vScrollBar1_Leave);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(0, 611);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(619, 14);
			this.hScrollBar1.SmallChange = 5;
			this.hScrollBar1.TabIndex = 12;
			this.hScrollBar1.Visible = false;
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button_del_palette);
			this.groupBox1.Controls.Add(this.button_save_palette);
			this.groupBox1.Controls.Add(this.comboBox_plt);
			this.groupBox1.Location = new System.Drawing.Point(20, 239);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(231, 82);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Templates palettes";
			// 
			// button_del_palette
			// 
			this.button_del_palette.AutoSize = true;
			this.button_del_palette.Location = new System.Drawing.Point(132, 48);
			this.button_del_palette.Name = "button_del_palette";
			this.button_del_palette.Size = new System.Drawing.Size(93, 30);
			this.button_del_palette.TabIndex = 1;
			this.button_del_palette.Text = "Delete";
			this.button_del_palette.UseVisualStyleBackColor = true;
			this.button_del_palette.Click += new System.EventHandler(this.button_del_palette_Click);
			// 
			// button_save_palette
			// 
			this.button_save_palette.AutoSize = true;
			this.button_save_palette.Location = new System.Drawing.Point(7, 48);
			this.button_save_palette.Name = "button_save_palette";
			this.button_save_palette.Size = new System.Drawing.Size(108, 30);
			this.button_save_palette.TabIndex = 1;
			this.button_save_palette.Text = "Save palette";
			this.button_save_palette.UseVisualStyleBackColor = true;
			this.button_save_palette.Click += new System.EventHandler(this.button_save_palette_Click);
			// 
			// comboBox_plt
			// 
			this.comboBox_plt.FormattingEnabled = true;
			this.comboBox_plt.Location = new System.Drawing.Point(7, 20);
			this.comboBox_plt.MaxLength = 30;
			this.comboBox_plt.Name = "comboBox_plt";
			this.comboBox_plt.Size = new System.Drawing.Size(218, 28);
			this.comboBox_plt.TabIndex = 0;
			this.comboBox_plt.SelectedIndexChanged += new System.EventHandler(this.comboBox_plt_SelectedIndexChanged);
			this.comboBox_plt.TextUpdate += new System.EventHandler(this.comboBox_plt_TextUpdate);
			this.comboBox_plt.TextChanged += new System.EventHandler(this.comboBox_plt_TextChanged);
			// 
			// groupBox_demo
			// 
			this.groupBox_demo.Controls.Add(this.button1);
			this.groupBox_demo.Controls.Add(this.textBox_activ);
			this.groupBox_demo.Location = new System.Drawing.Point(20, 533);
			this.groupBox_demo.Name = "groupBox_demo";
			this.groupBox_demo.Size = new System.Drawing.Size(239, 114);
			this.groupBox_demo.TabIndex = 15;
			this.groupBox_demo.TabStop = false;
			this.groupBox_demo.Text = "Activation";
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(6, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(219, 30);
			this.button1.TabIndex = 1;
			this.button1.Text = "Activate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_activ
			// 
			this.textBox_activ.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_activ.Enabled = false;
			this.textBox_activ.ForeColor = System.Drawing.Color.Black;
			this.textBox_activ.Location = new System.Drawing.Point(6, 19);
			this.textBox_activ.Multiline = true;
			this.textBox_activ.Name = "textBox_activ";
			this.textBox_activ.ReadOnly = true;
			this.textBox_activ.Size = new System.Drawing.Size(197, 41);
			this.textBox_activ.TabIndex = 0;
			this.textBox_activ.Text = "Your program is in demo mode. In generated PDF document you will see watermarks. " +
    "";
			// 
			// button_options
			// 
			this.button_options.AllowDrop = true;
			this.button_options.AutoSize = true;
			this.button_options.Location = new System.Drawing.Point(20, 406);
			this.button_options.Name = "button_options";
			this.button_options.Size = new System.Drawing.Size(231, 30);
			this.button_options.TabIndex = 1;
			this.button_options.Text = "Options";
			this.button_options.UseVisualStyleBackColor = true;
			this.button_options.Click += new System.EventHandler(this.button_options_Click);
			this.button_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butoon_generate_field_KeyDown);
			// 
			// axPXV_Control1
			// 
			this.axPXV_Control1.Enabled = true;
			this.axPXV_Control1.Location = new System.Drawing.Point(887, 662);
			this.axPXV_Control1.Name = "axPXV_Control1";
			this.axPXV_Control1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPXV_Control1.OcxState")));
			this.axPXV_Control1.Size = new System.Drawing.Size(288, 288);
			this.axPXV_Control1.TabIndex = 16;
			this.axPXV_Control1.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Controls.Add(this.textBox_info);
			this.panel1.Controls.Add(this.button_add_color);
			this.panel1.Controls.Add(this.button_delete_color);
			this.panel1.Controls.Add(this.button_generate_num);
			this.panel1.Controls.Add(this.butoon_generate_field);
			this.panel1.Controls.Add(this.button_options);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox_demo);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(698, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(275, 675);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.hScrollBar1);
			this.panel2.Controls.Add(this.vScrollBar1);
			this.panel2.Location = new System.Drawing.Point(27, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(642, 632);
			this.panel2.TabIndex = 17;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
			this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(973, 708);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.axPXV_Control1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Smart Coloring";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox_demo.ResumeLayout(false);
			this.groupBox_demo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem cleanAllToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_add_color;
        private System.Windows.Forms.Button button_delete_color;
        private System.Windows.Forms.Button butoon_generate_field;
        private System.Windows.Forms.Button button_generate_num;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propetiesToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_plt;
        private System.Windows.Forms.Button button_del_palette;
        private System.Windows.Forms.Button button_save_palette;
        private System.Windows.Forms.GroupBox groupBox_demo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_activ;
        private System.Windows.Forms.Button button_options;
        private AxPDFXEdit.AxPXV_Control axPXV_Control1;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

