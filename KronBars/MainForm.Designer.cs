namespace KronBars
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная компонента.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка ресурсов, используемых компонентами.
        /// </summary>
        /// <param name="disposing">Если значение параметра равно true, удаляются все выделенные ресурсы.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически сгенерированный конструктором формы

        /// <summary>
        /// Необходимо для поддержки конструктора.
        /// Не изменяйте этот код вручную.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseTableBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.Label();
            this.ChooseColumnBox = new System.Windows.Forms.ComboBox();
            this.ValueBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.Refreshbtn = new System.Windows.Forms.Button();
            this.ProfileBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FindBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseTableBox
            // 
            this.ChooseTableBox.BackColor = System.Drawing.Color.SkyBlue;
            this.ChooseTableBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseTableBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseTableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseTableBox.FormattingEnabled = true;
            this.ChooseTableBox.Location = new System.Drawing.Point(165, 89);
            this.ChooseTableBox.Name = "ChooseTableBox";
            this.ChooseTableBox.Size = new System.Drawing.Size(218, 28);
            this.ChooseTableBox.TabIndex = 0;
            this.ChooseTableBox.SelectedIndexChanged += new System.EventHandler(this.ChooseTableBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(815, 362);
            this.dataGridView1.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(562, 25);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(34, 13);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "ФИО";
            // 
            // ChooseColumnBox
            // 
            this.ChooseColumnBox.BackColor = System.Drawing.Color.SkyBlue;
            this.ChooseColumnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseColumnBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseColumnBox.FormattingEnabled = true;
            this.ChooseColumnBox.Location = new System.Drawing.Point(118, 131);
            this.ChooseColumnBox.Name = "ChooseColumnBox";
            this.ChooseColumnBox.Size = new System.Drawing.Size(121, 21);
            this.ChooseColumnBox.TabIndex = 4;
            this.ChooseColumnBox.SelectedIndexChanged += new System.EventHandler(this.ChooseColumnBox_SelectedIndexChanged);
            // 
            // ValueBox
            // 
            this.ValueBox.BackColor = System.Drawing.Color.SkyBlue;
            this.ValueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValueBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ValueBox.FormattingEnabled = true;
            this.ValueBox.Location = new System.Drawing.Point(389, 131);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(121, 21);
            this.ValueBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите таблицу";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Поиск по полю";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(245, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "выберите значение";
            // 
            // AddBtn
            // 
            this.AddBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AddBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.AddBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(370, 542);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(140, 35);
            this.AddBtn.TabIndex = 13;
            this.AddBtn.Text = "Добавить запись";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddOrChangeBtn_Click);
            // 
            // Refreshbtn
            // 
            this.Refreshbtn.BackColor = System.Drawing.Color.Transparent;
            this.Refreshbtn.BackgroundImage = global::KronBars.Properties.Resources.refresh;
            this.Refreshbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Refreshbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refreshbtn.ForeColor = System.Drawing.Color.Transparent;
            this.Refreshbtn.Location = new System.Drawing.Point(579, 118);
            this.Refreshbtn.Name = "Refreshbtn";
            this.Refreshbtn.Size = new System.Drawing.Size(40, 40);
            this.Refreshbtn.TabIndex = 14;
            this.Refreshbtn.UseVisualStyleBackColor = false;
            this.Refreshbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProfileBtn.BackgroundImage = global::KronBars.Properties.Resources.user;
            this.ProfileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileBtn.ForeColor = System.Drawing.Color.Transparent;
            this.ProfileBtn.Location = new System.Drawing.Point(723, 9);
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(44, 44);
            this.ProfileBtn.TabIndex = 12;
            this.ProfileBtn.UseVisualStyleBackColor = false;
            this.ProfileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.BackColor = System.Drawing.Color.Transparent;
            this.LogOutBtn.BackgroundImage = global::KronBars.Properties.Resources.logout;
            this.LogOutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutBtn.ForeColor = System.Drawing.Color.Transparent;
            this.LogOutBtn.Location = new System.Drawing.Point(783, 9);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(44, 44);
            this.LogOutBtn.TabIndex = 11;
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KronBars.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FindBtn
            // 
            this.FindBtn.BackColor = System.Drawing.Color.Transparent;
            this.FindBtn.BackgroundImage = global::KronBars.Properties.Resources.find;
            this.FindBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FindBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindBtn.ForeColor = System.Drawing.Color.Transparent;
            this.FindBtn.Location = new System.Drawing.Point(518, 117);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(40, 40);
            this.FindBtn.TabIndex = 6;
            this.FindBtn.UseVisualStyleBackColor = false;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 589);
            this.Controls.Add(this.Refreshbtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ProfileBtn);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FindBtn);
            this.Controls.Add(this.ValueBox);
            this.Controls.Add(this.ChooseColumnBox);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ChooseTableBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Кронверкские Барсы";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox ChooseTableBox;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.ComboBox ChooseColumnBox;
        private System.Windows.Forms.ComboBox ValueBox;
        private System.Windows.Forms.Button FindBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button ProfileBtn;
        public System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button Refreshbtn;
    }
}
