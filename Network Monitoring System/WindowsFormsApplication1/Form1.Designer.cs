namespace WindowsFormsApplication1
{
    partial class FormSystem
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetStructureButton = new System.Windows.Forms.Button();
            this.GetStatisticButton = new System.Windows.Forms.Button();
            this.NetworkParametresButton = new System.Windows.Forms.Button();
            this.SendPackageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetStructureButton
            // 
            this.GetStructureButton.Location = new System.Drawing.Point(12, 73);
            this.GetStructureButton.Name = "GetStructureButton";
            this.GetStructureButton.Size = new System.Drawing.Size(168, 33);
            this.GetStructureButton.TabIndex = 0;
            this.GetStructureButton.Text = "Получить структуру сети";
            this.GetStructureButton.UseVisualStyleBackColor = true;
            this.GetStructureButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetStatisticButton
            // 
            this.GetStatisticButton.Location = new System.Drawing.Point(12, 12);
            this.GetStatisticButton.Name = "GetStatisticButton";
            this.GetStatisticButton.Size = new System.Drawing.Size(168, 41);
            this.GetStatisticButton.TabIndex = 1;
            this.GetStatisticButton.Text = "Получить статистику сети";
            this.GetStatisticButton.UseVisualStyleBackColor = true;
            this.GetStatisticButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // NetworkParametresButton
            // 
            this.NetworkParametresButton.Location = new System.Drawing.Point(239, 12);
            this.NetworkParametresButton.Name = "NetworkParametresButton";
            this.NetworkParametresButton.Size = new System.Drawing.Size(168, 41);
            this.NetworkParametresButton.TabIndex = 2;
            this.NetworkParametresButton.Text = "Узнать свои сетевые параметры";
            this.NetworkParametresButton.UseVisualStyleBackColor = true;
            this.NetworkParametresButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // SendPackageButton
            // 
            this.SendPackageButton.Location = new System.Drawing.Point(239, 73);
            this.SendPackageButton.Name = "SendPackageButton";
            this.SendPackageButton.Size = new System.Drawing.Size(168, 33);
            this.SendPackageButton.TabIndex = 3;
            this.SendPackageButton.Text = "Отправка сообщения узлу";
            this.SendPackageButton.UseVisualStyleBackColor = true;
            this.SendPackageButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 118);
            this.Controls.Add(this.SendPackageButton);
            this.Controls.Add(this.NetworkParametresButton);
            this.Controls.Add(this.GetStatisticButton);
            this.Controls.Add(this.GetStructureButton);
            this.Name = "FormSystem";
            this.Text = "Система мониторинга сети";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetStructureButton;
        private System.Windows.Forms.Button GetStatisticButton;
        private System.Windows.Forms.Button NetworkParametresButton;
        private System.Windows.Forms.Button SendPackageButton;
    }
}

