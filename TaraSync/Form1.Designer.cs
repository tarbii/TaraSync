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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxFilesA = new System.Windows.Forms.ListBox();
            this.textBoxPathA = new System.Windows.Forms.TextBox();
            this.listBoxFilesB = new System.Windows.Forms.ListBox();
            this.textBoxPathB = new System.Windows.Forms.TextBox();
            this.buttonDeleteB = new System.Windows.Forms.Button();
            this.buttonOpenB = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOpenA = new System.Windows.Forms.Button();
            this.buttonDeleteA = new System.Windows.Forms.Button();
            this.buttonCreateA = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSync = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCreateA = new System.Windows.Forms.TextBox();
            this.buttonCreateB = new System.Windows.Forms.Button();
            this.textBoxCreateB = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPathA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxFilesB);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPathB);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 487);
            this.splitContainer1.SplitterDistance = 549;
            this.splitContainer1.TabIndex = 6;
            // 
            // listBoxFilesA
            // 
            this.listBoxFilesA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilesA.FormattingEnabled = true;
            this.listBoxFilesA.Location = new System.Drawing.Point(0, 20);
            this.listBoxFilesA.Name = "listBoxFilesA";
            this.listBoxFilesA.Size = new System.Drawing.Size(549, 438);
            this.listBoxFilesA.TabIndex = 6;
            // 
            // textBoxPathA
            // 
            this.textBoxPathA.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPathA.Location = new System.Drawing.Point(0, 0);
            this.textBoxPathA.Name = "textBoxPathA";
            this.textBoxPathA.Size = new System.Drawing.Size(549, 20);
            this.textBoxPathA.TabIndex = 5;
            this.textBoxPathA.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // listBoxFilesB
            // 
            this.listBoxFilesB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilesB.FormattingEnabled = true;
            this.listBoxFilesB.Location = new System.Drawing.Point(0, 20);
            this.listBoxFilesB.Name = "listBoxFilesB";
            this.listBoxFilesB.Size = new System.Drawing.Size(545, 438);
            this.listBoxFilesB.TabIndex = 7;
            // 
            // textBoxPathB
            // 
            this.textBoxPathB.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPathB.Location = new System.Drawing.Point(0, 0);
            this.textBoxPathB.Name = "textBoxPathB";
            this.textBoxPathB.Size = new System.Drawing.Size(545, 20);
            this.textBoxPathB.TabIndex = 6;
            this.textBoxPathB.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // buttonDeleteB
            // 
            this.buttonDeleteB.Location = new System.Drawing.Point(82, 3);
            this.buttonDeleteB.Name = "buttonDeleteB";
            this.buttonDeleteB.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteB.TabIndex = 5;
            this.buttonDeleteB.Text = "Delete";
            this.buttonDeleteB.UseVisualStyleBackColor = true;
            this.buttonDeleteB.Click += new System.EventHandler(this.buttonDeleteB_Click);
            // 
            // buttonOpenB
            // 
            this.buttonOpenB.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenB.Name = "buttonOpenB";
            this.buttonOpenB.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenB.TabIndex = 4;
            this.buttonOpenB.Text = "Open";
            this.buttonOpenB.UseVisualStyleBackColor = true;
            this.buttonOpenB.Click += new System.EventHandler(this.buttonOpenB_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.textBoxCreateA);
            this.panel2.Controls.Add(this.buttonCreateA);
            this.panel2.Controls.Add(this.buttonOpenA);
            this.panel2.Controls.Add(this.buttonDeleteA);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 29);
            this.panel2.TabIndex = 7;
            // 
            // buttonOpenA
            // 
            this.buttonOpenA.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenA.Name = "buttonOpenA";
            this.buttonOpenA.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenA.TabIndex = 3;
            this.buttonOpenA.Text = "Open";
            this.buttonOpenA.UseVisualStyleBackColor = true;
            this.buttonOpenA.Click += new System.EventHandler(this.buttonOpenA_Click);
            // 
            // buttonDeleteA
            // 
            this.buttonDeleteA.Location = new System.Drawing.Point(82, 3);
            this.buttonDeleteA.Name = "buttonDeleteA";
            this.buttonDeleteA.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteA.TabIndex = 5;
            this.buttonDeleteA.Text = "Delete";
            this.buttonDeleteA.UseVisualStyleBackColor = true;
            this.buttonDeleteA.Click += new System.EventHandler(this.buttonDeleteA_Click);
            // 
            // buttonCreateA
            // 
            this.buttonCreateA.Location = new System.Drawing.Point(161, 3);
            this.buttonCreateA.Name = "buttonCreateA";
            this.buttonCreateA.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateA.TabIndex = 6;
            this.buttonCreateA.Text = "Create";
            this.buttonCreateA.UseVisualStyleBackColor = true;
            this.buttonCreateA.Click += new System.EventHandler(this.buttonCreateA_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.textBoxCreateB);
            this.panel3.Controls.Add(this.buttonCreateB);
            this.panel3.Controls.Add(this.buttonDeleteB);
            this.panel3.Controls.Add(this.buttonOpenB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 458);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(545, 29);
            this.panel3.TabIndex = 8;
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(3, 3);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(88, 23);
            this.buttonSync.TabIndex = 2;
            this.buttonSync.Text = "Synchronize";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonSync);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 29);
            this.panel1.TabIndex = 7;
            // 
            // textBoxCreateA
            // 
            this.textBoxCreateA.Location = new System.Drawing.Point(242, 5);
            this.textBoxCreateA.Name = "textBoxCreateA";
            this.textBoxCreateA.Size = new System.Drawing.Size(303, 20);
            this.textBoxCreateA.TabIndex = 7;
            // 
            // buttonCreateB
            // 
            this.buttonCreateB.Location = new System.Drawing.Point(163, 3);
            this.buttonCreateB.Name = "buttonCreateB";
            this.buttonCreateB.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateB.TabIndex = 6;
            this.buttonCreateB.Text = "Create";
            this.buttonCreateB.UseVisualStyleBackColor = true;
            this.buttonCreateB.Click += new System.EventHandler(this.buttonCreateB_Click);
            // 
            // textBoxCreateB
            // 
            this.textBoxCreateB.Location = new System.Drawing.Point(244, 5);
            this.textBoxCreateB.Name = "textBoxCreateB";
            this.textBoxCreateB.Size = new System.Drawing.Size(289, 20);
            this.textBoxCreateB.TabIndex = 7;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxFilesA;
        private System.Windows.Forms.TextBox textBoxPathA;
        private System.Windows.Forms.TextBox textBoxPathB;
        private System.Windows.Forms.ListBox listBoxFilesB;
        private System.Windows.Forms.Button buttonOpenB;
        private System.Windows.Forms.Button buttonDeleteB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCreateA;
        private System.Windows.Forms.Button buttonOpenA;
        private System.Windows.Forms.Button buttonDeleteA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCreateA;
        private System.Windows.Forms.TextBox textBoxCreateB;
        private System.Windows.Forms.Button buttonCreateB;
    }
}

