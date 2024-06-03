namespace autodownloader
{
    partial class MessageBoxForAddNewRoutes
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
            this.captureText = new System.Windows.Forms.Button();
            this.finish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.captureClick = new System.Windows.Forms.Button();
            this.textBoxCaptureText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.captureWaitTime = new System.Windows.Forms.Button();
            this.textBoxCaptureWaitTime = new System.Windows.Forms.TextBox();
            this.comboBoxActualPersonalisedRoutes = new System.Windows.Forms.ComboBox();
            this.addActualPersonalisedRoutes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // captureText
            // 
            this.captureText.DialogResult = System.Windows.Forms.DialogResult.No;
            this.captureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureText.Location = new System.Drawing.Point(433, 49);
            this.captureText.Name = "captureText";
            this.captureText.Size = new System.Drawing.Size(107, 55);
            this.captureText.TabIndex = 1;
            this.captureText.Text = "Capturar texto ";
            this.captureText.UseVisualStyleBackColor = true;
            this.captureText.Click += new System.EventHandler(this.captureText_Click);
            // 
            // finish
            // 
            this.finish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish.Location = new System.Drawing.Point(24, 213);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(107, 55);
            this.finish.TabIndex = 2;
            this.finish.Text = "Terminar";
            this.finish.UseVisualStyleBackColor = true;
            this.finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elija la opcion a realizar:";
            // 
            // captureClick
            // 
            this.captureClick.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.captureClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureClick.Location = new System.Drawing.Point(24, 49);
            this.captureClick.Name = "captureClick";
            this.captureClick.Size = new System.Drawing.Size(107, 55);
            this.captureClick.TabIndex = 4;
            this.captureClick.Text = "Capturar click";
            this.captureClick.UseVisualStyleBackColor = true;
            this.captureClick.Click += new System.EventHandler(this.captureClick_Click);
            // 
            // textBoxCaptureText
            // 
            this.textBoxCaptureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCaptureText.Location = new System.Drawing.Point(546, 66);
            this.textBoxCaptureText.Name = "textBoxCaptureText";
            this.textBoxCaptureText.Size = new System.Drawing.Size(224, 22);
            this.textBoxCaptureText.TabIndex = 5;
            this.textBoxCaptureText.Text = "texto";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 67);
            this.label2.TabIndex = 6;
            this.label2.Text = "Esta opcion capturara las coordenadas del raton tras una cuenta atras de 3 segund" +
    "os.\r\nSolo coloca el raton en la posicion que desees. (No hace falta hacer click)" +
    "\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Termina y guarda.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "Se recomienda tener la pagina web deseada \r\nabierta, para utilizarla como referen" +
    "cia.";
            this.label4.Visible = false;
            // 
            // captureWaitTime
            // 
            this.captureWaitTime.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.captureWaitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureWaitTime.Location = new System.Drawing.Point(24, 132);
            this.captureWaitTime.Name = "captureWaitTime";
            this.captureWaitTime.Size = new System.Drawing.Size(107, 55);
            this.captureWaitTime.TabIndex = 9;
            this.captureWaitTime.Text = "Esperar \'x\' segundos";
            this.captureWaitTime.UseVisualStyleBackColor = true;
            this.captureWaitTime.Click += new System.EventHandler(this.captureWaitTime_Click);
            // 
            // textBoxCaptureWaitTime
            // 
            this.textBoxCaptureWaitTime.Location = new System.Drawing.Point(148, 151);
            this.textBoxCaptureWaitTime.Name = "textBoxCaptureWaitTime";
            this.textBoxCaptureWaitTime.Size = new System.Drawing.Size(125, 20);
            this.textBoxCaptureWaitTime.TabIndex = 10;
            this.textBoxCaptureWaitTime.Text = "1";
            // 
            // comboBoxActualPersonalisedRoutes
            // 
            this.comboBoxActualPersonalisedRoutes.FormattingEnabled = true;
            this.comboBoxActualPersonalisedRoutes.Location = new System.Drawing.Point(562, 195);
            this.comboBoxActualPersonalisedRoutes.Name = "comboBoxActualPersonalisedRoutes";
            this.comboBoxActualPersonalisedRoutes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxActualPersonalisedRoutes.TabIndex = 14;
            this.comboBoxActualPersonalisedRoutes.Text = "Rutas Guardadas";
            // 
            // addActualPersonalisedRoutes
            // 
            this.addActualPersonalisedRoutes.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.addActualPersonalisedRoutes.Enabled = false;
            this.addActualPersonalisedRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addActualPersonalisedRoutes.Location = new System.Drawing.Point(433, 194);
            this.addActualPersonalisedRoutes.Name = "addActualPersonalisedRoutes";
            this.addActualPersonalisedRoutes.Size = new System.Drawing.Size(107, 55);
            this.addActualPersonalisedRoutes.TabIndex = 15;
            this.addActualPersonalisedRoutes.Text = "Añadir ruta personalizada";
            this.addActualPersonalisedRoutes.UseVisualStyleBackColor = true;
            this.addActualPersonalisedRoutes.Click += new System.EventHandler(this.addActualPersonalisedRoutes_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(559, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 42);
            this.label5.TabIndex = 16;
            this.label5.Text = "Para añadir una tecla especial, hazlo asi: {Enter}";
            // 
            // MessageBoxForAddNewRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 280);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addActualPersonalisedRoutes);
            this.Controls.Add(this.comboBoxActualPersonalisedRoutes);
            this.Controls.Add(this.textBoxCaptureWaitTime);
            this.Controls.Add(this.captureWaitTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCaptureText);
            this.Controls.Add(this.captureClick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.captureText);
            this.Name = "MessageBoxForAddNewRoutes";
            this.Text = "Create a Personalise Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button captureText;
        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button captureClick;
        private System.Windows.Forms.TextBox textBoxCaptureText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button captureWaitTime;
        private System.Windows.Forms.TextBox textBoxCaptureWaitTime;
        private System.Windows.Forms.ComboBox comboBoxActualPersonalisedRoutes;
        private System.Windows.Forms.Button addActualPersonalisedRoutes;
        private System.Windows.Forms.Label label5;
    }
}