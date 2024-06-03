namespace autodownloader
{
    partial class LauncherLinksOpctions
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
            this.textBox_linksFile = new System.Windows.Forms.TextBox();
            this.button_linksFile = new System.Windows.Forms.Button();
            this.comboBoxSetRouteForEachLink = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDownWaitTime = new System.Windows.Forms.NumericUpDown();
            this.start = new System.Windows.Forms.Button();
            this.openFileDialog_linksFile = new System.Windows.Forms.OpenFileDialog();
            this.textBox_topLevelFolder = new System.Windows.Forms.TextBox();
            this.button_topLevelFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog_topLevelFolder = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownWaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_linksFile
            // 
            this.textBox_linksFile.Location = new System.Drawing.Point(153, 12);
            this.textBox_linksFile.Multiline = true;
            this.textBox_linksFile.Name = "textBox_linksFile";
            this.textBox_linksFile.Size = new System.Drawing.Size(201, 50);
            this.textBox_linksFile.TabIndex = 5;
            // 
            // button_linksFile
            // 
            this.button_linksFile.Location = new System.Drawing.Point(12, 12);
            this.button_linksFile.Name = "button_linksFile";
            this.button_linksFile.Size = new System.Drawing.Size(124, 50);
            this.button_linksFile.TabIndex = 6;
            this.button_linksFile.Text = "Cambiar la ruta del Archivo con los links";
            this.button_linksFile.UseVisualStyleBackColor = true;
            this.button_linksFile.Click += new System.EventHandler(this.button_linksFile_Click);
            // 
            // comboBoxSetRouteForEachLink
            // 
            this.comboBoxSetRouteForEachLink.FormattingEnabled = true;
            this.comboBoxSetRouteForEachLink.Location = new System.Drawing.Point(191, 149);
            this.comboBoxSetRouteForEachLink.Name = "comboBoxSetRouteForEachLink";
            this.comboBoxSetRouteForEachLink.Size = new System.Drawing.Size(139, 21);
            this.comboBoxSetRouteForEachLink.TabIndex = 26;
            this.comboBoxSetRouteForEachLink.Text = "Elige la ruta a ejecutar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "0 = NO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Realizar iteraciones entre links?";
            // 
            // UpDownWaitTime
            // 
            this.UpDownWaitTime.Location = new System.Drawing.Point(64, 155);
            this.UpDownWaitTime.Name = "UpDownWaitTime";
            this.UpDownWaitTime.Size = new System.Drawing.Size(34, 20);
            this.UpDownWaitTime.TabIndex = 23;
            this.UpDownWaitTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // start
            // 
            this.start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.start.Location = new System.Drawing.Point(107, 196);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(105, 36);
            this.start.TabIndex = 20;
            this.start.Text = "Start Route with Links";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // openFileDialog_linksFile
            // 
            this.openFileDialog_linksFile.FileName = "openFileDialog1";
            // 
            // textBox_topLevelFolder
            // 
            this.textBox_topLevelFolder.Location = new System.Drawing.Point(153, 68);
            this.textBox_topLevelFolder.Multiline = true;
            this.textBox_topLevelFolder.Name = "textBox_topLevelFolder";
            this.textBox_topLevelFolder.Size = new System.Drawing.Size(201, 50);
            this.textBox_topLevelFolder.TabIndex = 28;
            // 
            // button_topLevelFolder
            // 
            this.button_topLevelFolder.Location = new System.Drawing.Point(12, 68);
            this.button_topLevelFolder.Name = "button_topLevelFolder";
            this.button_topLevelFolder.Size = new System.Drawing.Size(124, 50);
            this.button_topLevelFolder.TabIndex = 27;
            this.button_topLevelFolder.Text = "Cambiar la ruta del Directorio de Descargas";
            this.button_topLevelFolder.UseVisualStyleBackColor = true;
            this.button_topLevelFolder.Click += new System.EventHandler(this.button_topLevelFolder_Click);
            // 
            // LauncherLinksOpctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 244);
            this.Controls.Add(this.textBox_topLevelFolder);
            this.Controls.Add(this.button_topLevelFolder);
            this.Controls.Add(this.comboBoxSetRouteForEachLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpDownWaitTime);
            this.Controls.Add(this.start);
            this.Controls.Add(this.button_linksFile);
            this.Controls.Add(this.textBox_linksFile);
            this.Name = "LauncherLinksOpctions";
            this.Text = "LauncherLinksOpctions";
            ((System.ComponentModel.ISupportInitialize)(this.UpDownWaitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_linksFile;
        private System.Windows.Forms.Button button_linksFile;
        private System.Windows.Forms.ComboBox comboBoxSetRouteForEachLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDownWaitTime;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.OpenFileDialog openFileDialog_linksFile;
        private System.Windows.Forms.TextBox textBox_topLevelFolder;
        private System.Windows.Forms.Button button_topLevelFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_topLevelFolder;
    }
}