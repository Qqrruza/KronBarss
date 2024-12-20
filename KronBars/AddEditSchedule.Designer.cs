namespace KronBars
{
    partial class AddEditSchedule
    {
        private System.ComponentModel.IContainer components = null;

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
            this.eventTypeComboBox = new System.Windows.Forms.ComboBox();
            this.teamComboBox = new System.Windows.Forms.ComboBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.timeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // eventTypeComboBox
            this.eventTypeComboBox.FormattingEnabled = true;
            this.eventTypeComboBox.Location = new System.Drawing.Point(120, 30);
            this.eventTypeComboBox.Name = "eventTypeComboBox";
            this.eventTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.eventTypeComboBox.TabIndex = 0;

            // teamComboBox
            this.teamComboBox.FormattingEnabled = true;
            this.teamComboBox.Location = new System.Drawing.Point(120, 70);
            this.teamComboBox.Name = "teamComboBox";
            this.teamComboBox.Size = new System.Drawing.Size(200, 21);
            this.teamComboBox.TabIndex = 1;

            // dateDateTimePicker
            this.dateDateTimePicker.Location = new System.Drawing.Point(120, 110);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDateTimePicker.TabIndex = 2;

            // timeMaskedTextBox
            this.timeMaskedTextBox.Location = new System.Drawing.Point(120, 150);
            this.timeMaskedTextBox.Mask = "00:00";
            this.timeMaskedTextBox.Name = "timeMaskedTextBox";
            this.timeMaskedTextBox.Size = new System.Drawing.Size(50, 20);
            this.timeMaskedTextBox.TabIndex = 3;

            // locationTextBox
            this.locationTextBox.Location = new System.Drawing.Point(120, 190);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(200, 20);
            this.locationTextBox.TabIndex = 4;

            // addButton
            this.addButton.Location = new System.Drawing.Point(20, 230);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // editButton
            this.editButton.Location = new System.Drawing.Point(110, 230);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);

            // deleteButton
            this.deleteButton.Location = new System.Drawing.Point(200, 230);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // AddEditSchedule
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.timeMaskedTextBox);
            this.Controls.Add(this.dateDateTimePicker);
            this.Controls.Add(this.teamComboBox);
            this.Controls.Add(this.eventTypeComboBox);
            this.Name = "AddEditSchedule";
            this.Text = "Добавить/Редактировать Расписание";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox eventTypeComboBox;
        private System.Windows.Forms.ComboBox teamComboBox;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.MaskedTextBox timeMaskedTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
