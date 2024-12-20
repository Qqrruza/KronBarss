using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KronBars
{
    public partial class AddEditSchedule : Form
    {
        private string _connectionString;
        private int _teamId;
        private int? _eventIdToEdit;

        // Конструктор
        public AddEditSchedule(string connectionString, int teamId, int? eventIdToEdit = null)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _teamId = teamId;
            _eventIdToEdit = eventIdToEdit;

            LoadEventTypes();
            LoadTeam();
            if (_eventIdToEdit.HasValue)
            {
                LoadEventData(_eventIdToEdit.Value);
            }
        }

        // Загрузка типов мероприятий
        private void LoadEventTypes()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Event_Type_ID, Event_Type FROM Event_Types";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    eventTypeComboBox.Items.Add(new { Text = reader.GetString(1), Value = reader.GetInt32(0) });
                }

                reader.Close();
            }
        }

        // Загрузка информации о команде
        private void LoadTeam()
        {
            teamComboBox.Items.Add(new { Text = "Ваша команда", Value = _teamId });
            teamComboBox.SelectedIndex = 0;
        }

        // Загрузка данных для редактирования
        private void LoadEventData(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Event_Type_ID, Dates, Times, Location FROM Events WHERE Event_ID = @Event_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Event_ID", eventId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    eventTypeComboBox.SelectedItem = new { Text = reader.GetString(1), Value = reader.GetInt32(0) };
                    dateDateTimePicker.Value = reader.GetDateTime(1);
                    timeMaskedTextBox.Text = reader.GetTimeSpan(2).ToString(@"hh\:mm");
                    locationTextBox.Text = reader.GetString(3);
                }

                reader.Close();
            }
        }

        // Добавление записи
        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                int eventTypeId = ((dynamic)eventTypeComboBox.SelectedItem).Value;
                int teamId = _teamId;
                DateTime eventDate = dateDateTimePicker.Value;
                string eventTime = timeMaskedTextBox.Text;
                string location = locationTextBox.Text;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Events (Event_Type_ID, Team_ID, Dates, Times, Location) " +
                                   "VALUES (@Event_Type_ID, @Team_ID, @Dates, @Times, @Location)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Event_Type_ID", eventTypeId);
                    command.Parameters.AddWithValue("@Team_ID", teamId);
                    command.Parameters.AddWithValue("@Dates", eventDate);
                    command.Parameters.AddWithValue("@Times", eventTime);
                    command.Parameters.AddWithValue("@Location", location);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Запись добавлена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        // Редактирование записи
        private void editButton_Click(object sender, EventArgs e)
        {
            if (_eventIdToEdit.HasValue && IsValidInput())
            {
                int eventTypeId = ((dynamic)eventTypeComboBox.SelectedItem).Value;
                int teamId = _teamId;
                DateTime eventDate = dateDateTimePicker.Value;
                string eventTime = timeMaskedTextBox.Text;
                string location = locationTextBox.Text;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Events SET Event_Type_ID = @Event_Type_ID, Team_ID = @Team_ID, Dates = @Dates, Times = @Times, Location = @Location " +
                                   "WHERE Event_ID = @Event_ID";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Event_Type_ID", eventTypeId);
                    command.Parameters.AddWithValue("@Team_ID", teamId);
                    command.Parameters.AddWithValue("@Dates", eventDate);
                    command.Parameters.AddWithValue("@Times", eventTime);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Event_ID", _eventIdToEdit.Value);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Запись обновлена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        // Удаление записи
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_eventIdToEdit.HasValue)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Events WHERE Event_ID = @Event_ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Event_ID", _eventIdToEdit.Value);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Запись удалена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        // Проверка валидности ввода
        private bool IsValidInput()
        {
            if (eventTypeComboBox.SelectedItem == null || teamComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип мероприятия и команду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка времени
            if (!TimeSpan.TryParse(timeMaskedTextBox.Text, out TimeSpan time))
            {
                MessageBox.Show("Время должно быть в формате HH:mm.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
