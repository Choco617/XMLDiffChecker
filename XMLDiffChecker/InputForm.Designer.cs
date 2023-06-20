namespace XMLDiffChecker
{
    partial class InputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FileAPath = new System.Windows.Forms.TextBox();
            this.FileBPath = new System.Windows.Forms.TextBox();
            this.BrowseButtonA = new System.Windows.Forms.Button();
            this.BrowseButtonB = new System.Windows.Forms.Button();
            this.CompareButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File B";
            // 
            // FileAPath
            // 
            this.FileAPath.Location = new System.Drawing.Point(12, 29);
            this.FileAPath.Name = "FileAPath";
            this.FileAPath.Size = new System.Drawing.Size(478, 20);
            this.FileAPath.TabIndex = 2;
            // 
            // FileBPath
            // 
            this.FileBPath.Location = new System.Drawing.Point(12, 78);
            this.FileBPath.Name = "FileBPath";
            this.FileBPath.Size = new System.Drawing.Size(478, 20);
            this.FileBPath.TabIndex = 3;
            // 
            // BrowseButtonA
            // 
            this.BrowseButtonA.Location = new System.Drawing.Point(496, 29);
            this.BrowseButtonA.Name = "BrowseButtonA";
            this.BrowseButtonA.Size = new System.Drawing.Size(75, 23);
            this.BrowseButtonA.TabIndex = 4;
            this.BrowseButtonA.Text = "Browse";
            this.BrowseButtonA.UseVisualStyleBackColor = true;
            this.BrowseButtonA.Click += new System.EventHandler(this.BrowseButtonA_Click);
            // 
            // BrowseButtonB
            // 
            this.BrowseButtonB.Location = new System.Drawing.Point(496, 75);
            this.BrowseButtonB.Name = "BrowseButtonB";
            this.BrowseButtonB.Size = new System.Drawing.Size(75, 23);
            this.BrowseButtonB.TabIndex = 5;
            this.BrowseButtonB.Text = "Browse";
            this.BrowseButtonB.UseVisualStyleBackColor = true;
            this.BrowseButtonB.Click += new System.EventHandler(this.BrowseButtonB_Click);
            // 
            // CompareButton
            // 
            this.CompareButton.Location = new System.Drawing.Point(254, 116);
            this.CompareButton.Name = "CompareButton";
            this.CompareButton.Size = new System.Drawing.Size(75, 23);
            this.CompareButton.TabIndex = 6;
            this.CompareButton.Text = "Compare";
            this.CompareButton.UseVisualStyleBackColor = true;
            this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 151);
            this.Controls.Add(this.CompareButton);
            this.Controls.Add(this.BrowseButtonB);
            this.Controls.Add(this.BrowseButtonA);
            this.Controls.Add(this.FileBPath);
            this.Controls.Add(this.FileAPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InputForm";
            this.Text = "XMLDiffChecker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileAPath;
        private System.Windows.Forms.TextBox FileBPath;
        private System.Windows.Forms.Button BrowseButtonA;
        private System.Windows.Forms.Button BrowseButtonB;
        private System.Windows.Forms.Button CompareButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

