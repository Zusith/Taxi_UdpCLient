
namespace Dispatcher
{
    partial class DispatcherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DispatcherForm));
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.labelClients = new System.Windows.Forms.Label();
            this.comboBoxTaxi = new System.Windows.Forms.ComboBox();
            this.labelTaxiType = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.process1 = new System.Diagnostics.Process();
            this.labelMinPrice = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.comboBoxCar = new System.Windows.Forms.ComboBox();
            this.labelTaxiCar = new System.Windows.Forms.Label();
            this.labelListOrder = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.labelTravelTime = new System.Windows.Forms.Label();
            this.textBoxTravelTime = new System.Windows.Forms.TextBox();
            this.labelCalculatePrice = new System.Windows.Forms.Label();
            this.textBoxCalculatePrice = new System.Windows.Forms.TextBox();
            this.buttonSendOrder = new System.Windows.Forms.Button();
            this.buttonConfirmOrder = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.listBoxOrderedTaxi = new System.Windows.Forms.ListBox();
            this.buttonSendPrice = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.textBoxChat.Size = new System.Drawing.Size(302, 611);
            this.textBoxChat.TabIndex = 0;
            // 
            // textBoxSend
            // 
            this.textBoxSend.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSend.Location = new System.Drawing.Point(311, 520);
            this.textBoxSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxSend.Size = new System.Drawing.Size(254, 32);
            this.textBoxSend.TabIndex = 1;
            this.textBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSend_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSend.Location = new System.Drawing.Point(311, 560);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(254, 45);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClients.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(311, 482);
            this.comboBoxClients.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxClients.Size = new System.Drawing.Size(254, 32);
            this.comboBoxClients.TabIndex = 3;
            this.comboBoxClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxClients_SelectedIndexChanged);
            // 
            // labelClients
            // 
            this.labelClients.AutoSize = true;
            this.labelClients.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClients.Location = new System.Drawing.Point(308, 454);
            this.labelClients.Name = "labelClients";
            this.labelClients.Size = new System.Drawing.Size(155, 24);
            this.labelClients.TabIndex = 4;
            this.labelClients.Text = "Выбор клиента:";
            // 
            // comboBoxTaxi
            // 
            this.comboBoxTaxi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comboBoxTaxi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaxi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTaxi.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTaxi.FormattingEnabled = true;
            this.comboBoxTaxi.Items.AddRange(new object[] {
            "Эконом",
            "Комфорт",
            "Бизнес"});
            this.comboBoxTaxi.Location = new System.Drawing.Point(583, 38);
            this.comboBoxTaxi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxTaxi.Name = "comboBoxTaxi";
            this.comboBoxTaxi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxTaxi.Size = new System.Drawing.Size(187, 32);
            this.comboBoxTaxi.TabIndex = 5;
            this.comboBoxTaxi.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaxi_SelectedIndexChanged);
            // 
            // labelTaxiType
            // 
            this.labelTaxiType.AutoSize = true;
            this.labelTaxiType.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTaxiType.Location = new System.Drawing.Point(579, 10);
            this.labelTaxiType.Name = "labelTaxiType";
            this.labelTaxiType.Size = new System.Drawing.Size(132, 24);
            this.labelTaxiType.TabIndex = 6;
            this.labelTaxiType.Text = "Выбор типа такси:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(307, 9);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(162, 24);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Цена такси за 1 км:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(311, 37);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPrice.Size = new System.Drawing.Size(128, 32);
            this.textBoxPrice.TabIndex = 8;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinPrice.Location = new System.Drawing.Point(308, 72);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(131, 24);
            this.labelMinPrice.TabIndex = 9;
            this.labelMinPrice.Text = "Мин стоимость:";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(312, 102);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.ReadOnly = true;
            this.textBoxMinPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxMinPrice.Size = new System.Drawing.Size(127, 32);
            this.textBoxMinPrice.TabIndex = 10;
            // 
            // comboBoxCar
            // 
            this.comboBoxCar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comboBoxCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCar.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCar.FormattingEnabled = true;
            this.comboBoxCar.Items.AddRange(new object[] {
            "Эконом",
            "Комфорт",
            "Бизнес"});
            this.comboBoxCar.Location = new System.Drawing.Point(312, 166);
            this.comboBoxCar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCar.Name = "comboBoxCar";
            this.comboBoxCar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxCar.Size = new System.Drawing.Size(253, 32);
            this.comboBoxCar.TabIndex = 11;
            // 
            // labelTaxiCar
            // 
            this.labelTaxiCar.AutoSize = true;
            this.labelTaxiCar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTaxiCar.Location = new System.Drawing.Point(308, 138);
            this.labelTaxiCar.Name = "labelTaxiCar";
            this.labelTaxiCar.Size = new System.Drawing.Size(132, 24);
            this.labelTaxiCar.TabIndex = 12;
            this.labelTaxiCar.Text = "Выбор такси:";
            // 
            // labelListOrder
            // 
            this.labelListOrder.AutoSize = true;
            this.labelListOrder.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelListOrder.Location = new System.Drawing.Point(582, 74);
            this.labelListOrder.Name = "labelListOrder";
            this.labelListOrder.Size = new System.Drawing.Size(188, 24);
            this.labelListOrder.TabIndex = 14;
            this.labelListOrder.Text = "Список заказанных такси:";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDistance.Location = new System.Drawing.Point(308, 202);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(164, 24);
            this.labelDistance.TabIndex = 15;
            this.labelDistance.Text = "Расстояние (км):";
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(312, 230);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(84, 32);
            this.textBoxDistance.TabIndex = 16;
            this.textBoxDistance.Text = "0";
            this.textBoxDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDistance_KeyPress);
            // 
            // labelTravelTime
            // 
            this.labelTravelTime.AutoSize = true;
            this.labelTravelTime.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTravelTime.Location = new System.Drawing.Point(308, 265);
            this.labelTravelTime.Name = "labelTravelTime";
            this.labelTravelTime.Size = new System.Drawing.Size(193, 24);
            this.labelTravelTime.TabIndex = 17;
            this.labelTravelTime.Text = "Время в пути (мин):";
            // 
            // textBoxTravelTime
            // 
            this.textBoxTravelTime.Location = new System.Drawing.Point(312, 293);
            this.textBoxTravelTime.Name = "textBoxTravelTime";
            this.textBoxTravelTime.ReadOnly = true;
            this.textBoxTravelTime.Size = new System.Drawing.Size(253, 32);
            this.textBoxTravelTime.TabIndex = 18;
            // 
            // labelCalculatePrice
            // 
            this.labelCalculatePrice.AutoSize = true;
            this.labelCalculatePrice.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCalculatePrice.Location = new System.Drawing.Point(308, 328);
            this.labelCalculatePrice.Name = "labelCalculatePrice";
            this.labelCalculatePrice.Size = new System.Drawing.Size(168, 24);
            this.labelCalculatePrice.TabIndex = 19;
            this.labelCalculatePrice.Text = "Стоимость (руб.):";
            // 
            // textBoxCalculatePrice
            // 
            this.textBoxCalculatePrice.Location = new System.Drawing.Point(312, 355);
            this.textBoxCalculatePrice.Name = "textBoxCalculatePrice";
            this.textBoxCalculatePrice.ReadOnly = true;
            this.textBoxCalculatePrice.Size = new System.Drawing.Size(253, 32);
            this.textBoxCalculatePrice.TabIndex = 20;
            // 
            // buttonSendOrder
            // 
            this.buttonSendOrder.Enabled = false;
            this.buttonSendOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendOrder.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendOrder.Location = new System.Drawing.Point(312, 394);
            this.buttonSendOrder.Name = "buttonSendOrder";
            this.buttonSendOrder.Size = new System.Drawing.Size(127, 45);
            this.buttonSendOrder.TabIndex = 21;
            this.buttonSendOrder.Text = "Отправить";
            this.buttonSendOrder.UseVisualStyleBackColor = true;
            this.buttonSendOrder.Click += new System.EventHandler(this.buttonSendOrder_Click);
            // 
            // buttonConfirmOrder
            // 
            this.buttonConfirmOrder.Enabled = false;
            this.buttonConfirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmOrder.Location = new System.Drawing.Point(448, 394);
            this.buttonConfirmOrder.Name = "buttonConfirmOrder";
            this.buttonConfirmOrder.Size = new System.Drawing.Size(117, 45);
            this.buttonConfirmOrder.TabIndex = 22;
            this.buttonConfirmOrder.Text = "Подтвердить";
            this.buttonConfirmOrder.UseVisualStyleBackColor = true;
            this.buttonConfirmOrder.Click += new System.EventHandler(this.buttonConfirmOrder_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStatus.Location = new System.Drawing.Point(575, 510);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(141, 25);
            this.textBoxStatus.TabIndex = 24;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(571, 482);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(145, 24);
            this.labelStatus.TabIndex = 23;
            this.labelStatus.Text = "Статус заказа:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Location = new System.Drawing.Point(402, 229);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(163, 33);
            this.buttonConfirm.TabIndex = 25;
            this.buttonConfirm.Text = "Подтвердить";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // listBoxOrderedTaxi
            // 
            this.listBoxOrderedTaxi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listBoxOrderedTaxi.Enabled = false;
            this.listBoxOrderedTaxi.FormattingEnabled = true;
            this.listBoxOrderedTaxi.ItemHeight = 24;
            this.listBoxOrderedTaxi.Location = new System.Drawing.Point(583, 101);
            this.listBoxOrderedTaxi.Name = "listBoxOrderedTaxi";
            this.listBoxOrderedTaxi.Size = new System.Drawing.Size(187, 172);
            this.listBoxOrderedTaxi.TabIndex = 26;
            // 
            // buttonSendPrice
            // 
            this.buttonSendPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendPrice.Location = new System.Drawing.Point(448, 36);
            this.buttonSendPrice.Name = "buttonSendPrice";
            this.buttonSendPrice.Size = new System.Drawing.Size(117, 96);
            this.buttonSendPrice.TabIndex = 27;
            this.buttonSendPrice.Text = "Отправить";
            this.buttonSendPrice.UseVisualStyleBackColor = true;
            this.buttonSendPrice.Click += new System.EventHandler(this.buttonSendPrice_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(627, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // DispatcherForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(782, 611);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSendPrice);
            this.Controls.Add(this.listBoxOrderedTaxi);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonConfirmOrder);
            this.Controls.Add(this.buttonSendOrder);
            this.Controls.Add(this.textBoxCalculatePrice);
            this.Controls.Add(this.labelCalculatePrice);
            this.Controls.Add(this.textBoxTravelTime);
            this.Controls.Add(this.labelTravelTime);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.labelListOrder);
            this.Controls.Add(this.labelTaxiCar);
            this.Controls.Add(this.comboBoxCar);
            this.Controls.Add(this.textBoxMinPrice);
            this.Controls.Add(this.labelMinPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelTaxiType);
            this.Controls.Add(this.comboBoxTaxi);
            this.Controls.Add(this.labelClients);
            this.Controls.Add(this.comboBoxClients);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.textBoxChat);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "DispatcherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatcher taxi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DispatcherForm_FormClosing);
            this.Load += new System.EventHandler(this.DispatcherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.Label labelClients;
        private System.Windows.Forms.ComboBox comboBoxTaxi;
        private System.Windows.Forms.Label labelTaxiType;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.Label labelMinPrice;
        private System.Windows.Forms.Label labelListOrder;
        private System.Windows.Forms.Label labelTaxiCar;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.Label labelTravelTime;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.TextBox textBoxTravelTime;
        private System.Windows.Forms.Button buttonConfirmOrder;
        private System.Windows.Forms.Button buttonSendOrder;
        private System.Windows.Forms.TextBox textBoxCalculatePrice;
        private System.Windows.Forms.Label labelCalculatePrice;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.ListBox listBoxOrderedTaxi;
        private System.Windows.Forms.Button buttonSendPrice;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

