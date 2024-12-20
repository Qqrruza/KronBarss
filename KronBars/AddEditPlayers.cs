using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KronBars
{
    public partial class AddEditPlayers : Form
    {
        private string _connectionString;
        private int _teamId;

        public AddEditPlayers(string connectionString, int teamId)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _teamId = teamId;
        }

        private void AddEditPlayers_Load(object sender, EventArgs e)
        {
            LoadTeams();
            LoadPositions();
            LoadPlayers();
        }

        private void LoadTeams()
        {
            // Загрузка команды в ComboBox
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Team_ID, Team_Name FROM Teams WHERE Team_ID = @TeamId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeamId", _teamId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBoxTeams.Items.Add(new KeyValuePair<int, string>((int)reader["Team_ID"], reader["Team_Name"].ToString()));
                    comboBoxTeams.SelectedIndex = 0; // Установить первый элемент
                }
                conn.Close();
            }
        }

        private void LoadPositions()
        {
            // Добавляем позиции в ComboBox
            comboBoxPosition.Items.AddRange(new string[]
            {
                "Центровой", "Разыгрывающий", "Лёгкий форвард", "Тяжелый форвард", "Атакующий защитник"
            });
        }

        private void LoadPlayers()
        {
            listBoxPlayers.Items.Clear();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Player_ID, Firstname + ' ' + Surname AS FullName FROM Players WHERE Team_ID = @TeamId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeamId", _teamId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBoxPlayers.Items.Add(new KeyValuePair<int, string>((int)reader["Player_ID"], reader["FullName"].ToString()));
                }
                conn.Close();
            }
        }

        private void listBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedItem == null) return;

            // Загружаем данные об игроке для редактирования
            var selectedPlayer = (KeyValuePair<int, string>)listBoxPlayers.SelectedItem;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Firstname, Surname, Date_of_birth, Position FROM Players WHERE Player_ID = @PlayerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PlayerId", selectedPlayer.Key);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxFirstName.Text = reader["Firstname"].ToString();
                    textBoxLastName.Text = reader["Surname"].ToString();
                    dateTimePickerBirth.Value = (DateTime)reader["Date_of_birth"];
                    comboBoxPosition.SelectedItem = reader["Position"].ToString();
                }
                conn.Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли все поля
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                comboBoxPosition.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля перед сохранением.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                if (listBoxPlayers.SelectedItem == null)
                {
                    // Добавление нового игрока
                    string query = @"
                        INSERT INTO Players (Firstname, Surname, Date_of_birth, Position, Team_ID) 
                        VALUES (@Firstname, @Surname, @DateOfBirth, @Position, @TeamId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Firstname", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@Surname", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePickerBirth.Value);
                    cmd.Parameters.AddWithValue("@Position", comboBoxPosition.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TeamId", _teamId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Игрок добавлен.");
                }
                else
                {
                    // Редактирование существующего игрока
                    var selectedPlayer = (KeyValuePair<int, string>)listBoxPlayers.SelectedItem;
                    string query = @"
                        UPDATE Players 
                        SET Firstname = @Firstname, Surname = @Surname, Date_of_birth = @DateOfBirth, Position = @Position 
                        WHERE Player_ID = @PlayerId AND Team_ID = @TeamId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Firstname", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@Surname", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePickerBirth.Value);
                    cmd.Parameters.AddWithValue("@Position", comboBoxPosition.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PlayerId", selectedPlayer.Key);
                    cmd.Parameters.AddWithValue("@TeamId", _teamId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные игрока обновлены.");
                }

                conn.Close();
            }

            LoadPlayers();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            comboBoxPosition.Text = "";
            comboBoxTeams.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedItem == null)
            {
                MessageBox.Show("Выберите игрока для удаления.");
                return;
            }

            var selectedPlayer = (KeyValuePair<int, string>)listBoxPlayers.SelectedItem;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Players WHERE Player_ID = @PlayerId AND Team_ID = @TeamId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PlayerId", selectedPlayer.Key);
                cmd.Parameters.AddWithValue("@TeamId", _teamId);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Игрок удалён.");
            LoadPlayers();
        }

        private void AddEditPlayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainForm)
                {
                    form.BringToFront();
                    return;
                }
            }
        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }
    }
}
