namespace KronBars
{
    partial class AddEditResults
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.ComboBox playerComboBox;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.TextBox twoPointShotsTextBox;
        private System.Windows.Forms.TextBox threePointShotsTextBox;
        private System.Windows.Forms.TextBox freeThrowsTextBox;
        private System.Windows.Forms.TextBox reboundsTextBox;
        private System.Windows.Forms.TextBox assistsTextBox;
        private System.Windows.Forms.TextBox stealsTextBox;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;  // MaskedTextBox для времени
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

        // Очищаем ресурсы компонента
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.playerComboBox = new System.Windows.Forms.ComboBox();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.twoPointShotsTextBox = new System.Windows.Forms.TextBox();
            this.threePointShotsTextBox = new System.Windows.Forms.TextBox();
            this.freeThrowsTextBox = new System.Windows.Forms.TextBox();
            this.reboundsTextBox = new System.Windows.Forms.TextBox();
            this.assistsTextBox = new System.Windows.Forms.TextBox();
            this.stealsTextBox = new System.Windows.Forms.TextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventComboBox
            // 
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(210, 33);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(201, 28);
            this.eventComboBox.TabIndex = 0;
            // 
            // playerComboBox
            // 
            this.playerComboBox.FormattingEnabled = true;
            this.playerComboBox.Location = new System.Drawing.Point(210, 73);
            this.playerComboBox.Name = "playerComboBox";
            this.playerComboBox.Size = new System.Drawing.Size(201, 28);
            this.playerComboBox.TabIndex = 1;
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.Location = new System.Drawing.Point(210, 113);
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.Size = new System.Drawing.Size(201, 26);
            this.pointsTextBox.TabIndex = 2;
            // 
            // twoPointShotsTextBox
            // 
            this.twoPointShotsTextBox.Location = new System.Drawing.Point(210, 153);
            this.twoPointShotsTextBox.Name = "twoPointShotsTextBox";
            this.twoPointShotsTextBox.Size = new System.Drawing.Size(201, 26);
            this.twoPointShotsTextBox.TabIndex = 3;
            // 
            // threePointShotsTextBox
            // 
            this.threePointShotsTextBox.Location = new System.Drawing.Point(210, 193);
            this.threePointShotsTextBox.Name = "threePointShotsTextBox";
            this.threePointShotsTextBox.Size = new System.Drawing.Size(201, 26);
            this.threePointShotsTextBox.TabIndex = 4;
            // 
            // freeThrowsTextBox
            // 
            this.freeThrowsTextBox.Location = new System.Drawing.Point(210, 233);
            this.freeThrowsTextBox.Name = "freeThrowsTextBox";
            this.freeThrowsTextBox.Size = new System.Drawing.Size(201, 26);
            this.freeThrowsTextBox.TabIndex = 5;
            // 
            // reboundsTextBox
            // 
            this.reboundsTextBox.Location = new System.Drawing.Point(210, 273);
            this.reboundsTextBox.Name = "reboundsTextBox";
            this.reboundsTextBox.Size = new System.Drawing.Size(201, 26);
            this.reboundsTextBox.TabIndex = 6;
            // 
            // assistsTextBox
            // 
            this.assistsTextBox.Location = new System.Drawing.Point(210, 313);
            this.assistsTextBox.Name = "assistsTextBox";
            this.assistsTextBox.Size = new System.Drawing.Size(201, 26);
            this.assistsTextBox.TabIndex = 7;
            // 
            // stealsTextBox
            // 
            this.stealsTextBox.Location = new System.Drawing.Point(210, 353);
            this.stealsTextBox.Name = "stealsTextBox";
            this.stealsTextBox.Size = new System.Drawing.Size(201, 26);
            this.stealsTextBox.TabIndex = 8;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(210, 393);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(201, 26);
            this.maskedTextBox1.TabIndex = 9;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(30, 430);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(120, 430);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(210, 430);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Тип мероприятия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Игрок:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Очки:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "2-очковые броски:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "3-очковые броски:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Штрафные броски:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Подборы:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Передачи:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Перехваты:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Время на поле (мм:сс):";
            // 
            // AddEditResults
            // 
            this.ClientSize = new System.Drawing.Size(451, 466);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.stealsTextBox);
            this.Controls.Add(this.assistsTextBox);
            this.Controls.Add(this.reboundsTextBox);
            this.Controls.Add(this.freeThrowsTextBox);
            this.Controls.Add(this.threePointShotsTextBox);
            this.Controls.Add(this.twoPointShotsTextBox);
            this.Controls.Add(this.pointsTextBox);
            this.Controls.Add(this.playerComboBox);
            this.Controls.Add(this.eventComboBox);
            this.Name = "AddEditResults";
            this.Text = "Добавить/Редактировать результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
