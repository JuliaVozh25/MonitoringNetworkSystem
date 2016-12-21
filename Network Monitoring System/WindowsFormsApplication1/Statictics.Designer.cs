namespace WindowsFormsApplication1
{
    partial class StatisticForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SourseAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StatisticFilterButton = new System.Windows.Forms.Button();
            this.ipTextBox2 = new WindowsFormsApplication1.IPTextBox();
            this.ipTextBox1 = new WindowsFormsApplication1.IPTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourseAddr,
            this.DestAddr,
            this.Time,
            this.Protocol,
            this.Message});
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(688, 241);
            this.dataGridView1.TabIndex = 9;
            // 
            // SourseAddr
            // 
            this.SourseAddr.HeaderText = "Адрес отправителя";
            this.SourseAddr.Name = "SourseAddr";
            this.SourseAddr.ReadOnly = true;
            this.SourseAddr.Width = 110;
            // 
            // DestAddr
            // 
            this.DestAddr.HeaderText = "Адрес назначения";
            this.DestAddr.Name = "DestAddr";
            this.DestAddr.ReadOnly = true;
            this.DestAddr.Width = 110;
            // 
            // Time
            // 
            this.Time.HeaderText = "Время отправки";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Protocol
            // 
            this.Protocol.HeaderText = "Протокол";
            this.Protocol.Name = "Protocol";
            this.Protocol.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.HeaderText = "Сообщение";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Адрес назначения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Адрес отправителя";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(369, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 20);
            this.textBox3.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Протокол";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Фильтр:";
            // 
            // StatisticFilterButton
            // 
            this.StatisticFilterButton.Location = new System.Drawing.Point(583, 36);
            this.StatisticFilterButton.Name = "StatisticFilterButton";
            this.StatisticFilterButton.Size = new System.Drawing.Size(117, 37);
            this.StatisticFilterButton.TabIndex = 13;
            this.StatisticFilterButton.Text = "Отфильтровать записи";
            this.StatisticFilterButton.UseVisualStyleBackColor = true;
            this.StatisticFilterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipTextBox2
            // 
            this.ipTextBox2.BackColor = System.Drawing.Color.Salmon;
            this.ipTextBox2.Location = new System.Drawing.Point(121, 66);
            this.ipTextBox2.Name = "ipTextBox2";
            this.ipTextBox2.Size = new System.Drawing.Size(174, 20);
            this.ipTextBox2.TabIndex = 17;
            // 
            // ipTextBox1
            // 
            this.ipTextBox1.BackColor = System.Drawing.Color.Salmon;
            this.ipTextBox1.Location = new System.Drawing.Point(121, 33);
            this.ipTextBox1.Name = "ipTextBox1";
            this.ipTextBox1.Size = new System.Drawing.Size(174, 20);
            this.ipTextBox1.TabIndex = 16;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 345);
            this.Controls.Add(this.ipTextBox2);
            this.Controls.Add(this.ipTextBox1);
            this.Controls.Add(this.StatisticFilterButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StatisticForm";
            this.Text = "Статистика сети";
            this.Load += new System.EventHandler(this.Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourseAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StatisticFilterButton;
        private IPTextBox ipTextBox1;
        private IPTextBox ipTextBox2;
    }
}