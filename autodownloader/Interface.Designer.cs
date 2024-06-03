namespace autodownloader
{
    partial class Interface
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNewPersonalisedRouteName = new System.Windows.Forms.TextBox();
            this.button_addPersonalisedRoute = new System.Windows.Forms.Button();
            this.button_showAllRoutes = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_saveDB = new System.Windows.Forms.Button();
            this.textBoxDBModifyValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_loadDB = new System.Windows.Forms.Button();
            this.button_deleteDB = new System.Windows.Forms.Button();
            this.button_updateDB = new System.Windows.Forms.Button();
            this.xmlTreeView = new System.Windows.Forms.TreeView();
            this.textBox_displayData = new System.Windows.Forms.TextBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_startPersonalised = new System.Windows.Forms.Button();
            this.comboBoxPersonalisedRoutes = new System.Windows.Forms.ComboBox();
            this.button_startDownloadRoute = new System.Windows.Forms.Button();
            this.button_setScheludedTimeToRoute = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 172);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_setScheludedTimeToRoute);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxNewPersonalisedRouteName);
            this.tabPage1.Controls.Add(this.button_addPersonalisedRoute);
            this.tabPage1.Controls.Add(this.button_showAllRoutes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Introduzca un Nombre";
            // 
            // textBoxNewPersonalisedRouteName
            // 
            this.textBoxNewPersonalisedRouteName.Location = new System.Drawing.Point(21, 73);
            this.textBoxNewPersonalisedRouteName.Name = "textBoxNewPersonalisedRouteName";
            this.textBoxNewPersonalisedRouteName.Size = new System.Drawing.Size(124, 20);
            this.textBoxNewPersonalisedRouteName.TabIndex = 31;
            this.textBoxNewPersonalisedRouteName.Text = "Sin nombre";
            this.textBoxNewPersonalisedRouteName.TextChanged += new System.EventHandler(this.textBoxNewPersonalisedRouteName_TextChanged);
            // 
            // button_addPersonalisedRoute
            // 
            this.button_addPersonalisedRoute.Location = new System.Drawing.Point(12, 18);
            this.button_addPersonalisedRoute.Name = "button_addPersonalisedRoute";
            this.button_addPersonalisedRoute.Size = new System.Drawing.Size(165, 31);
            this.button_addPersonalisedRoute.TabIndex = 30;
            this.button_addPersonalisedRoute.Text = "Definir ruta personalizada";
            this.button_addPersonalisedRoute.UseVisualStyleBackColor = true;
            this.button_addPersonalisedRoute.Click += new System.EventHandler(this.button_addPersonalisedRoute_Click_1);
            // 
            // button_showAllRoutes
            // 
            this.button_showAllRoutes.Location = new System.Drawing.Point(183, 18);
            this.button_showAllRoutes.Name = "button_showAllRoutes";
            this.button_showAllRoutes.Size = new System.Drawing.Size(165, 31);
            this.button_showAllRoutes.TabIndex = 29;
            this.button_showAllRoutes.Text = "Mostrar todas las Rutas";
            this.button_showAllRoutes.UseVisualStyleBackColor = true;
            this.button_showAllRoutes.Click += new System.EventHandler(this.button_showAllRoutes_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_saveDB);
            this.tabPage2.Controls.Add(this.textBoxDBModifyValue);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button_loadDB);
            this.tabPage2.Controls.Add(this.button_deleteDB);
            this.tabPage2.Controls.Add(this.button_updateDB);
            this.tabPage2.Controls.Add(this.xmlTreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 146);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_saveDB
            // 
            this.button_saveDB.Location = new System.Drawing.Point(29, 97);
            this.button_saveDB.Name = "button_saveDB";
            this.button_saveDB.Size = new System.Drawing.Size(87, 31);
            this.button_saveDB.TabIndex = 49;
            this.button_saveDB.Text = "Guardar DB";
            this.button_saveDB.UseVisualStyleBackColor = true;
            this.button_saveDB.Click += new System.EventHandler(this.button_saveDB_Click);
            // 
            // textBoxDBModifyValue
            // 
            this.textBoxDBModifyValue.Location = new System.Drawing.Point(579, 60);
            this.textBoxDBModifyValue.Multiline = true;
            this.textBoxDBModifyValue.Name = "textBoxDBModifyValue";
            this.textBoxDBModifyValue.Size = new System.Drawing.Size(189, 44);
            this.textBoxDBModifyValue.TabIndex = 48;
            this.textBoxDBModifyValue.Text = "New value";
            this.textBoxDBModifyValue.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Actual DataBase";
            // 
            // button_loadDB
            // 
            this.button_loadDB.Location = new System.Drawing.Point(29, 23);
            this.button_loadDB.Name = "button_loadDB";
            this.button_loadDB.Size = new System.Drawing.Size(87, 31);
            this.button_loadDB.TabIndex = 46;
            this.button_loadDB.Text = "Leer DB";
            this.button_loadDB.UseVisualStyleBackColor = true;
            this.button_loadDB.Click += new System.EventHandler(this.button_loadDB_Click_2);
            // 
            // button_deleteDB
            // 
            this.button_deleteDB.Enabled = false;
            this.button_deleteDB.Location = new System.Drawing.Point(29, 60);
            this.button_deleteDB.Name = "button_deleteDB";
            this.button_deleteDB.Size = new System.Drawing.Size(87, 31);
            this.button_deleteDB.TabIndex = 45;
            this.button_deleteDB.Text = "Eliminar DB";
            this.button_deleteDB.UseVisualStyleBackColor = true;
            this.button_deleteDB.Click += new System.EventHandler(this.button_deleteDB_Click_1);
            // 
            // button_updateDB
            // 
            this.button_updateDB.Enabled = false;
            this.button_updateDB.Location = new System.Drawing.Point(579, 23);
            this.button_updateDB.Name = "button_updateDB";
            this.button_updateDB.Size = new System.Drawing.Size(87, 31);
            this.button_updateDB.TabIndex = 44;
            this.button_updateDB.Text = "Modificar DB";
            this.button_updateDB.UseVisualStyleBackColor = true;
            this.button_updateDB.Click += new System.EventHandler(this.button_updateDB_Click_2);
            // 
            // xmlTreeView
            // 
            this.xmlTreeView.Location = new System.Drawing.Point(138, 23);
            this.xmlTreeView.Name = "xmlTreeView";
            this.xmlTreeView.Size = new System.Drawing.Size(435, 116);
            this.xmlTreeView.TabIndex = 42;
            this.xmlTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.xmlTreeView_AfterSelect);
            // 
            // textBox_displayData
            // 
            this.textBox_displayData.AcceptsTab = true;
            this.textBox_displayData.Location = new System.Drawing.Point(12, 190);
            this.textBox_displayData.Multiline = true;
            this.textBox_displayData.Name = "textBox_displayData";
            this.textBox_displayData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_displayData.Size = new System.Drawing.Size(655, 155);
            this.textBox_displayData.TabIndex = 8;
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(689, 307);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(105, 38);
            this.button_stop.TabIndex = 10;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_startPersonalised
            // 
            this.button_startPersonalised.Location = new System.Drawing.Point(689, 219);
            this.button_startPersonalised.Name = "button_startPersonalised";
            this.button_startPersonalised.Size = new System.Drawing.Size(105, 38);
            this.button_startPersonalised.TabIndex = 17;
            this.button_startPersonalised.Text = "Start Personalised Route";
            this.button_startPersonalised.UseVisualStyleBackColor = true;
            this.button_startPersonalised.Click += new System.EventHandler(this.button_startPersonalised_Click);
            // 
            // comboBoxPersonalisedRoutes
            // 
            this.comboBoxPersonalisedRoutes.FormattingEnabled = true;
            this.comboBoxPersonalisedRoutes.Location = new System.Drawing.Point(689, 192);
            this.comboBoxPersonalisedRoutes.Name = "comboBoxPersonalisedRoutes";
            this.comboBoxPersonalisedRoutes.Size = new System.Drawing.Size(105, 21);
            this.comboBoxPersonalisedRoutes.TabIndex = 18;
            this.comboBoxPersonalisedRoutes.Text = "Elija una Ruta";
            // 
            // button_startDownloadRoute
            // 
            this.button_startDownloadRoute.Location = new System.Drawing.Point(689, 263);
            this.button_startDownloadRoute.Name = "button_startDownloadRoute";
            this.button_startDownloadRoute.Size = new System.Drawing.Size(105, 38);
            this.button_startDownloadRoute.TabIndex = 20;
            this.button_startDownloadRoute.Text = "Start Route with Links";
            this.button_startDownloadRoute.UseVisualStyleBackColor = true;
            this.button_startDownloadRoute.Click += new System.EventHandler(this.button_startDownloadRoute_Click);
            // 
            // button_setScheludedTimeToRoute
            // 
            this.button_setScheludedTimeToRoute.Location = new System.Drawing.Point(443, 18);
            this.button_setScheludedTimeToRoute.Name = "button_setScheludedTimeToRoute";
            this.button_setScheludedTimeToRoute.Size = new System.Drawing.Size(129, 44);
            this.button_setScheludedTimeToRoute.TabIndex = 33;
            this.button_setScheludedTimeToRoute.Text = "Asignar una hora de ejecucion a una ruta";
            this.button_setScheludedTimeToRoute.UseVisualStyleBackColor = true;
            this.button_setScheludedTimeToRoute.Click += new System.EventHandler(this.button_setScheludedTimeToRoute_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 357);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_startDownloadRoute);
            this.Controls.Add(this.comboBoxPersonalisedRoutes);
            this.Controls.Add(this.button_startPersonalised);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.textBox_displayData);
            this.Name = "Interface";
            this.Text = "Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Interface_FormClosing);
            this.Load += new System.EventHandler(this.Interface_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNewPersonalisedRouteName;
        private System.Windows.Forms.Button button_addPersonalisedRoute;
        private System.Windows.Forms.Button button_showAllRoutes;
        public System.Windows.Forms.TextBox textBox_displayData;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_startPersonalised;
        private System.Windows.Forms.ComboBox comboBoxPersonalisedRoutes;
        private System.Windows.Forms.Button button_startDownloadRoute;
        private System.Windows.Forms.TreeView xmlTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_loadDB;
        private System.Windows.Forms.Button button_deleteDB;
        private System.Windows.Forms.Button button_updateDB;
        private System.Windows.Forms.TextBox textBoxDBModifyValue;
        private System.Windows.Forms.Button button_saveDB;
        private System.Windows.Forms.Button button_setScheludedTimeToRoute;
    }
}