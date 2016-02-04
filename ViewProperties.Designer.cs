namespace test
{
    partial class ViewProperties
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProperties));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.numericUpDown_width = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_height = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton_ver = new System.Windows.Forms.RadioButton();
            this.radioButton_hor = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_view = new System.Windows.Forms.TabPage();
            this.tabPage_activ = new System.Windows.Forms.TabPage();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.button_activate = new System.Windows.Forms.Button();
            this.label_ent_key = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_view.SuspendLayout();
            this.tabPage_activ.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // numericUpDown_width
            // 
            this.numericUpDown_width.Location = new System.Drawing.Point(5, 22);
            this.numericUpDown_width.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown_width.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_width.Name = "numericUpDown_width";
            this.numericUpDown_width.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown_width.TabIndex = 10;
            this.numericUpDown_width.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_width.ValueChanged += new System.EventHandler(this.numericUpDown_width_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Height";
            // 
            // numericUpDown_height
            // 
            this.numericUpDown_height.Location = new System.Drawing.Point(5, 65);
            this.numericUpDown_height.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown_height.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_height.Name = "numericUpDown_height";
            this.numericUpDown_height.Size = new System.Drawing.Size(101, 20);
            this.numericUpDown_height.TabIndex = 10;
            this.numericUpDown_height.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_height.ValueChanged += new System.EventHandler(this.numericUpDown_height_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(110, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "The same height";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton_ver
            // 
            this.radioButton_ver.AutoSize = true;
            this.radioButton_ver.Location = new System.Drawing.Point(120, 56);
            this.radioButton_ver.Name = "radioButton_ver";
            this.radioButton_ver.Size = new System.Drawing.Size(60, 17);
            this.radioButton_ver.TabIndex = 12;
            this.radioButton_ver.TabStop = true;
            this.radioButton_ver.Text = "Vertical";
            this.radioButton_ver.UseVisualStyleBackColor = true;
            this.radioButton_ver.Visible = false;
            this.radioButton_ver.CheckedChanged += new System.EventHandler(this.radioButton_ver_CheckedChanged);
            // 
            // radioButton_hor
            // 
            this.radioButton_hor.AutoSize = true;
            this.radioButton_hor.Location = new System.Drawing.Point(120, 80);
            this.radioButton_hor.Name = "radioButton_hor";
            this.radioButton_hor.Size = new System.Drawing.Size(72, 17);
            this.radioButton_hor.TabIndex = 13;
            this.radioButton_hor.TabStop = true;
            this.radioButton_hor.Text = "Horisontal";
            this.radioButton_hor.UseVisualStyleBackColor = true;
            this.radioButton_hor.Visible = false;
            this.radioButton_hor.CheckedChanged += new System.EventHandler(this.radioButton_hor_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Orientation of a document";
            this.label4.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_view);
            this.tabControl1.Controls.Add(this.tabPage_activ);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(228, 126);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage_view
            // 
            this.tabPage_view.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_view.Controls.Add(this.numericUpDown_width);
            this.tabPage_view.Controls.Add(this.label4);
            this.tabPage_view.Controls.Add(this.radioButton_hor);
            this.tabPage_view.Controls.Add(this.label3);
            this.tabPage_view.Controls.Add(this.radioButton_ver);
            this.tabPage_view.Controls.Add(this.label2);
            this.tabPage_view.Controls.Add(this.checkBox1);
            this.tabPage_view.Controls.Add(this.numericUpDown_height);
            this.tabPage_view.Location = new System.Drawing.Point(4, 22);
            this.tabPage_view.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_view.Name = "tabPage_view";
            this.tabPage_view.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_view.Size = new System.Drawing.Size(220, 100);
            this.tabPage_view.TabIndex = 0;
            this.tabPage_view.Text = "View";
            // 
            // tabPage_activ
            // 
            this.tabPage_activ.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_activ.Controls.Add(this.textBox_info);
            this.tabPage_activ.Controls.Add(this.button_activate);
            this.tabPage_activ.Controls.Add(this.label_ent_key);
            this.tabPage_activ.Controls.Add(this.textBox_key);
            this.tabPage_activ.Location = new System.Drawing.Point(4, 22);
            this.tabPage_activ.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_activ.Name = "tabPage_activ";
            this.tabPage_activ.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_activ.Size = new System.Drawing.Size(207, 100);
            this.tabPage_activ.TabIndex = 1;
            this.tabPage_activ.Text = "Activation";
            // 
            // textBox_info
            // 
            this.textBox_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_info.Enabled = false;
            this.textBox_info.Location = new System.Drawing.Point(2, 65);
            this.textBox_info.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(202, 35);
            this.textBox_info.TabIndex = 3;
            // 
            // button_activate
            // 
            this.button_activate.Location = new System.Drawing.Point(148, 41);
            this.button_activate.Margin = new System.Windows.Forms.Padding(2);
            this.button_activate.Name = "button_activate";
            this.button_activate.Size = new System.Drawing.Size(56, 19);
            this.button_activate.TabIndex = 2;
            this.button_activate.Text = "Activate";
            this.button_activate.UseVisualStyleBackColor = true;
            this.button_activate.Click += new System.EventHandler(this.button_activate_Click);
            // 
            // label_ent_key
            // 
            this.label_ent_key.AutoSize = true;
            this.label_ent_key.Location = new System.Drawing.Point(2, 2);
            this.label_ent_key.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ent_key.Name = "label_ent_key";
            this.label_ent_key.Size = new System.Drawing.Size(55, 13);
            this.label_ent_key.TabIndex = 1;
            this.label_ent_key.Text = "Enter key:";
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(4, 19);
            this.textBox_key.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(201, 20);
            this.textBox_key.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(160, 133);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(66, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(86, 133);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(68, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ViewProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 163);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.ViewProperties_Load);
            this.Shown += new System.EventHandler(this.Options_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_view.ResumeLayout(false);
            this.tabPage_view.PerformLayout();
            this.tabPage_activ.ResumeLayout(false);
            this.tabPage_activ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NumericUpDown numericUpDown_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_height;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton_ver;
        private System.Windows.Forms.RadioButton radioButton_hor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_view;
        private System.Windows.Forms.TabPage tabPage_activ;
        private System.Windows.Forms.Button button_activate;
        private System.Windows.Forms.Label label_ent_key;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox textBox_info;
    }
}