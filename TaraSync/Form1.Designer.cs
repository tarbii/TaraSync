namespace TaraSync
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
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxFilesA = new System.Windows.Forms.ListBox();
            this.textBoxPathA = new System.Windows.Forms.TextBox();
            this.listBoxFilesB = new System.Windows.Forms.ListBox();
            this.textBoxPathB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1098, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Ready.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxFilesA);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPathA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxFilesB);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPathB);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 483);
            this.splitContainer1.SplitterDistance = 549;
            this.splitContainer1.TabIndex = 6;
            // 
            // listBoxFilesA
            // 
            this.listBoxFilesA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilesA.FormattingEnabled = true;
            this.listBoxFilesA.Location = new System.Drawing.Point(0, 20);
            this.listBoxFilesA.Name = "listBoxFilesA";
            this.listBoxFilesA.Size = new System.Drawing.Size(549, 463);
            this.listBoxFilesA.TabIndex = 6;
            // 
            // textBoxPathA
            // 
            this.textBoxPathA.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPathA.Location = new System.Drawing.Point(0, 0);
            this.textBoxPathA.Name = "textBoxPathA";
            this.textBoxPathA.Size = new System.Drawing.Size(549, 20);
            this.textBoxPathA.TabIndex = 5;
            this.textBoxPathA.Text = "c:\\TestCases\\Case1\\A\\";
            this.textBoxPathA.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBoxFilesB
            // 
            this.listBoxFilesB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilesB.FormattingEnabled = true;
            this.listBoxFilesB.Location = new System.Drawing.Point(0, 20);
            this.listBoxFilesB.Name = "listBoxFilesB";
            this.listBoxFilesB.Size = new System.Drawing.Size(545, 463);
            this.listBoxFilesB.TabIndex = 7;
            // 
            // textBoxPathB
            // 
            this.textBoxPathB.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPathB.Location = new System.Drawing.Point(0, 0);
            this.textBoxPathB.Name = "textBoxPathB";
            this.textBoxPathB.Size = new System.Drawing.Size(545, 20);
            this.textBoxPathB.TabIndex = 6;
            this.textBoxPathB.Text = "c:\\TestCases\\Case1\\B\\";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 33);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxFilesA;
        private System.Windows.Forms.TextBox textBoxPathA;
        private System.Windows.Forms.TextBox textBoxPathB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxFilesB;
    }
}

