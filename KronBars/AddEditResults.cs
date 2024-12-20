using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KronBars
{
    public partial class AddEditResults : Form
    {
        private string _connectionString;
        private int _teamId;
        private int? _resultId; // Для редактирования: результат ID может быть null

        // Конструктор
        public AddEditResults(string connectionString, int teamId, int? resultId = null)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _teamId = teamId;
            _resultId = resultId;

            LoadEventTypes();
            LoadPlayers();

            if (_resultId.HasValue)
            {
                LoadResultData(_resultId.Value);  // Загружаем данные для редактирования
            }
        }

        // Загрузка типов событий в комбобокс
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
                    eventComboBox.Items.Add(new { Text = reader.GetString(1), Value = reader.GetInt32(0) });
                }

                reader.Close();
            }
        }

        // Загрузка игроков тренера в комбобокс
        private void LoadPlayers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Player_ID, Firstname + ' ' + Surname FROM Players WHERE Team_ID = @Team_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Team_ID", _teamId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    playerComboBox.Items.Add(new { Text = reader.GetString(1), Value = reader.GetInt32(0) });
                }

                reader.Close();
            }
        }

        // Загрузка данных для редактирования
        private void LoadResultData(int resultId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT rp.Event_ID, rp.Player_ID, rp.Played_Time, rp.Points, rp.Throws_2Point, rp.Throws_3Point, rp.Throws_Free, rp.Rebounds, rp.Assists, rp.Steals " +
                               "FROM Result_Players rp WHERE rp.Result_ID = @Result_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Result_ID", resultId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    eventComboBox.SelectedItem = new { Text = reader.GetString(0), Value = reader.GetInt32(1) };  // Выбор события
                    playerComboBox.SelectedItem = new { Text = reader.GetString(1), Value = reader.GetInt32(2) };  // Выбор игрока
                    maskedTextBox1.Text = reader.GetString(2); // Время на поле
                    pointsTextBox.Text = reader.GetInt32(3).ToString();
                    twoPointShotsTextBox.Text = reader.GetInt32(4).ToString();
                    threePointShotsTextBox.Text = reader.GetInt32(5).ToString();
                    freeThrowsTextBox.Text = reader.GetInt32(6).ToString();
                    reboundsTextBox.Text = reader.GetInt32(7).ToString();
                    assistsTextBox.Text = reader.GetInt32(8).ToString();
                    stealsTextBox.Text = reader.GetInt32(9).ToString();
                }

                reader.Close();
            }
        }

        // Добавление или редактирование результата
        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                int eventTypeId = ((dynamic)eventComboBox.SelectedItem).Value;
                int playerId = ((dynamic)playerComboBox.SelectedItem).Value;
                int teamId = _teamId;
                string timeOnField = maskedTextBox1.Text;
                int points = int.Parse(pointsTextBox.Text);
                int twoPointShots = int.Parse(twoPointShotsTextBox.Text);
                int threePointShots = int.Parse(threePointShotsTextBox.Text);
                int freeThrows = int.Parse(freeThrowsTextBox.Text);
                int rebounds = int.Parse(reboundsTextBox.Text);
                int assists = int.Parse(assistsTextBox.Text);
                int steals = int.Parse(stealsTextBox.Text);

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command;

                    if (_resultId.HasValue) // Если есть ID результата, выполняем обновление
                    {
                        string query = "UPDATE Result_Players SET Event_ID = @Event_ID, Player_ID = @Player_ID, Team_ID = @Team_ID, Played_Time = @Played_Time, " +
                                       "Points = @Points, Throws_2Point = @Throws_2Point, Throws_3Point = @Throws_3Point, Throws_Free = @Throws_Free, " +
                                       "Rebounds = @Rebounds, Assists = @Assists, Steals = @Steals WHERE Result_ID = @Result_ID";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Result_ID", _resultId.Value);  // Используем Result_ID для обновления
                    }
                    else // Если ID нет, это добавление
                    {
                        string query = "INSERT INTO Result_Players (Event_ID, Player_ID, Team_ID, Played_Time, Points, Throws_2Point, Throws_3Point, Throws_Free, Rebounds, Assists, Steals) " +
                                       "VALUES (@Event_ID, @Player_ID, @Team_ID, @Played_Time, @Points, @Throws_2Point, @Throws_3Point, @Throws_Free, @Rebounds, @Assists, @Steals)";
                        command = new SqlCommand(query, connection);
                    }

                    // Добавление параметров для запроса
                    command.Parameters.AddWithValue("@Event_ID", eventTypeId);
                    command.Parameters.AddWithValue("@Player_ID", playerId);
                    command.Parameters.AddWithValue("@Team_ID", teamId);
                    command.Parameters.AddWithValue("@Played_Time", timeOnField);
                    command.Parameters.AddWithValue("@Points", points);
                    command.Parameters.AddWithValue("@Throws_2Point", twoPointShots);
                    command.Parameters.AddWithValue("@Throws_3Point", threePointShots);
                    command.Parameters.AddWithValue("@Throws_Free", freeThrows);
                    command.Parameters.AddWithValue("@Rebounds", rebounds);
                    command.Parameters.AddWithValue("@Assists", assists);
                    command.Parameters.AddWithValue("@Steals", steals);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Результат успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        // Проверка валидности ввода
        private bool IsValidInput()
        {
            if (eventComboBox.SelectedItem == null || playerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие и игрока.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка на корректность времени на поле (формат MM:SS)
            if (!TimeSpan.TryParse(maskedTextBox1.Text, out TimeSpan time) || time.TotalMinutes > 40)
            {
                MessageBox.Show("Время на поле должно быть в формате MM:SS и не более 40 минут.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка на числа
            if (!IsNumeric(pointsTextBox.Text) || !IsNumeric(twoPointShotsTextBox.Text) ||
                !IsNumeric(threePointShotsTextBox.Text) || !IsNumeric(freeThrowsTextBox.Text) ||
                !IsNumeric(reboundsTextBox.Text) || !IsNumeric(assistsTextBox.Text) || !IsNumeric(stealsTextBox.Text))
            {
                MessageBox.Show("Все статистические поля должны содержать только цифры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Проверка, что строка состоит только из цифр
        private bool IsNumeric(string str)
        {
            return int.TryParse(str, out _);
        }

        // Удаление результата
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_resultId.HasValue)
            {
                var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить этот результат?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Result_Players WHERE Result_ID = @Result_ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Result_ID", _resultId.Value);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Результат удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Не выбрана запись для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
