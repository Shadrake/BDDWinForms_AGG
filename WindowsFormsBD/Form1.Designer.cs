namespace BDDWinForms_AGG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInsert1 = new System.Windows.Forms.Button();
            this.btnInsert2 = new System.Windows.Forms.Button();
            this.grboxJob2 = new System.Windows.Forms.GroupBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInsert3 = new System.Windows.Forms.Button();
            this.btnInsert4 = new System.Windows.Forms.Button();
            this.grboxJob2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 71);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(95, 41);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Conectar";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // labMessage
            // 
            this.labMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labMessage.Location = new System.Drawing.Point(12, 9);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(237, 34);
            this.labMessage.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(154, 71);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Desconectar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInsert1
            // 
            this.btnInsert1.Location = new System.Drawing.Point(12, 142);
            this.btnInsert1.Name = "btnInsert1";
            this.btnInsert1.Size = new System.Drawing.Size(237, 28);
            this.btnInsert1.TabIndex = 3;
            this.btnInsert1.Text = "Insertar valores concretos (Job1)";
            this.btnInsert1.UseVisualStyleBackColor = true;
            this.btnInsert1.Click += new System.EventHandler(this.btnInsert1_Click);
            // 
            // btnInsert2
            // 
            this.btnInsert2.Location = new System.Drawing.Point(12, 176);
            this.btnInsert2.Name = "btnInsert2";
            this.btnInsert2.Size = new System.Drawing.Size(237, 28);
            this.btnInsert2.TabIndex = 3;
            this.btnInsert2.Text = "Insertar valores de usuario (Job2)";
            this.btnInsert2.UseVisualStyleBackColor = true;
            this.btnInsert2.Click += new System.EventHandler(this.btnInsert2_Click);
            // 
            // grboxJob2
            // 
            this.grboxJob2.Controls.Add(this.txtMax);
            this.grboxJob2.Controls.Add(this.lblMax);
            this.grboxJob2.Controls.Add(this.txtMin);
            this.grboxJob2.Controls.Add(this.lblMin);
            this.grboxJob2.Controls.Add(this.txtTitle);
            this.grboxJob2.Controls.Add(this.lblTitle);
            this.grboxJob2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grboxJob2.Location = new System.Drawing.Point(286, 77);
            this.grboxJob2.Name = "grboxJob2";
            this.grboxJob2.Size = new System.Drawing.Size(353, 126);
            this.grboxJob2.TabIndex = 4;
            this.grboxJob2.TabStop = false;
            this.grboxJob2.Text = "Job 2+";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(88, 86);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(145, 22);
            this.txtMax.TabIndex = 3;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(22, 90);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(35, 16);
            this.lblMax.TabIndex = 0;
            this.lblMax.Text = "Max:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(88, 61);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(145, 22);
            this.txtMin.TabIndex = 2;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(22, 65);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(31, 16);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(88, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(235, 22);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(22, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(36, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // btnInsert3
            // 
            this.btnInsert3.Location = new System.Drawing.Point(12, 210);
            this.btnInsert3.Name = "btnInsert3";
            this.btnInsert3.Size = new System.Drawing.Size(237, 28);
            this.btnInsert3.TabIndex = 3;
            this.btnInsert3.Text = "Insertar objeto Job (Job3)";
            this.btnInsert3.UseVisualStyleBackColor = true;
            this.btnInsert3.Click += new System.EventHandler(this.btnInsert3_Click);
            // 
            // btnInsert4
            // 
            this.btnInsert4.Location = new System.Drawing.Point(12, 244);
            this.btnInsert4.Name = "btnInsert4";
            this.btnInsert4.Size = new System.Drawing.Size(237, 28);
            this.btnInsert4.TabIndex = 3;
            this.btnInsert4.Text = "Insertar Job con parámetros (Job4)";
            this.btnInsert4.UseVisualStyleBackColor = true;
            this.btnInsert4.Click += new System.EventHandler(this.btnInsert4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 285);
            this.Controls.Add(this.grboxJob2);
            this.Controls.Add(this.btnInsert4);
            this.Controls.Add(this.btnInsert3);
            this.Controls.Add(this.btnInsert2);
            this.Controls.Add(this.btnInsert1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grboxJob2.ResumeLayout(false);
            this.grboxJob2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInsert1;
        private System.Windows.Forms.Button btnInsert2;
        private System.Windows.Forms.GroupBox grboxJob2;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnInsert3;
        private System.Windows.Forms.Button btnInsert4;
    }
}

