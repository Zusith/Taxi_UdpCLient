
namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.buttonPortSend = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxOrder = new System.Windows.Forms.TextBox();
            this.labelOrder = new System.Windows.Forms.Label();
            this.buttonCompleteOrder = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Location = new System.Drawing.Point(354, 489);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(278, 51);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(354, 447);
            this.textBoxSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(278, 32);
            this.textBoxSend.TabIndex = 4;
            this.textBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSend_KeyDown);
            // 
            // textBoxChat
            // 
            this.textBoxChat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxChat.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxChat.Location = new System.Drawing.Point(0, 0);
            this.textBoxChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxChat.Size = new System.Drawing.Size(344, 553);
            this.textBoxChat.TabIndex = 3;
            // 
            // buttonPortSend
            // 
            this.buttonPortSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPortSend.Location = new System.Drawing.Point(504, 407);
            this.buttonPortSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonPortSend.Name = "buttonPortSend";
            this.buttonPortSend.Size = new System.Drawing.Size(128, 32);
            this.buttonPortSend.TabIndex = 8;
            this.buttonPortSend.Text = "Войти";
            this.buttonPortSend.UseVisualStyleBackColor = true;
            this.buttonPortSend.Click += new System.EventHandler(this.buttonPortSend_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(354, 407);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 32);
            this.textBoxName.TabIndex = 9;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(350, 379);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(72, 24);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Логин:";
            // 
            // textBoxOrder
            // 
            this.textBoxOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOrder.Location = new System.Drawing.Point(354, 31);
            this.textBoxOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxOrder.Multiline = true;
            this.textBoxOrder.Name = "textBoxOrder";
            this.textBoxOrder.ReadOnly = true;
            this.textBoxOrder.Size = new System.Drawing.Size(278, 183);
            this.textBoxOrder.TabIndex = 11;
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOrder.Location = new System.Drawing.Point(350, 3);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(69, 24);
            this.labelOrder.TabIndex = 12;
            this.labelOrder.Text = "Заказ:";
            // 
            // buttonCompleteOrder
            // 
            this.buttonCompleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompleteOrder.Location = new System.Drawing.Point(354, 221);
            this.buttonCompleteOrder.Name = "buttonCompleteOrder";
            this.buttonCompleteOrder.Size = new System.Drawing.Size(278, 43);
            this.buttonCompleteOrder.TabIndex = 13;
            this.buttonCompleteOrder.Text = "Заказ выполнен";
            this.buttonCompleteOrder.UseVisualStyleBackColor = true;
            this.buttonCompleteOrder.Click += new System.EventHandler(this.buttonCompleteOrder_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(350, 271);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(145, 24);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "Статус заказа:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStatus.Location = new System.Drawing.Point(354, 299);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(141, 25);
            this.textBoxStatus.TabIndex = 15;
            this.textBoxStatus.Text = "не заказано";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(529, 274);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(647, 553);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonCompleteOrder);
            this.Controls.Add(this.labelOrder);
            this.Controls.Add(this.textBoxOrder);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonPortSend);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.textBoxChat);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Client Taxi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button buttonPortSend;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxOrder;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.Button buttonCompleteOrder;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

