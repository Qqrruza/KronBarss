using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KronBars
{
    public partial class MainForm : Form
    {
        private int _userRole;
        private int _userId;
        private string _connectionString = "Data Source=LAPTOP-MNFH39V4\\SQLEXPRESS;Initial Catalog=KronBars;Integrated Security=True";
        public string _query;

        public MainForm(int userId, int roleID)
        {
            InitializeComponent();
            _userRole = roleID;
            _userId = userId;
            SetUserNamelabel();
            SetChooseTableBox(roleID);
        }

        public void SetUserNamelabel()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = string.Empty;

                    if (_userRole == 1) // Тренер
                    {
                        query = "SELECT CONCAT(Surname, ' ', Firstname, ' ', Lastname) AS FullName FROM Coaches WHERE User_ID = @UserId";
                    }
                    else if (_userRole == 2) // Игрок
                    {
                        query = "SELECT CONCAT(Surname, ' ', Firstname) AS FullName FROM Players WHERE User_ID = @UserId";
                        AddBtn.Visible = false; // Скрываем кнопку добавления для игроков
                    }
                    else if (_userRole == 3) // Администратор
                    {
                        ProfileBtn.Visible = false;
                        UserName.Text = "Администратор";
                        return;
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", _userId);
                            object fullName = command.ExecuteScalar();

                            if (fullName != null)
                            {
                                UserName.Text = fullName.ToString();
                            }
                            else
                            {
                                UserName.Text = "Пользователь не найден";
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении имени пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetUserNamelabel();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            
            foreach (Form form in Application.OpenForms)
            {
                if (form is Profile)
                {
                    form.BringToFront(); 
                    return;
                }
            }

            Profile profileForm = new Profile(_userId, _userRole);
            profileForm.Show();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 registrationForm = new Form1();
            registrationForm.Show();
        }

        public void SetChooseTableBox(int userRole)
        {
            string[] items;

            switch (userRole)
            {
                case 1: // Тренер
                    items = new string[] { "Расписание", "Мои игроки", "Статистика игроков" };
                    break;

                case 2: // Игрок
                    items = new string[] { "Расписание", "Команда", "Мои результаты" };
                    break;

                case 3: // Администратор
                    items = new string[] { "Тренеры", "Типы мероприятий", "Расписание", "Игроки", "Результаты игроков", "Роли", "Команды", "Пользователи" };
                    break;

                default:
                    items = new string[] { };
                    break;
            }

            ChooseTableBox.Items.Clear();  // Очищаем ComboBox перед добавлением новых элементов
            ChooseTableBox.Items.AddRange(items);
        }

        // Обработчик изменения выбора в ComboBox
        private void ChooseTableBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ChooseTableBox.SelectedItem == null)
                return;

            string selectedTable = ChooseTableBox.SelectedItem.ToString();
            string query = string.Empty;

            switch (selectedTable)
            {
                case "Тренеры":
                    query = "SELECT Coach_ID AS [ID Тренера], CONCAT(Surname, ' ', Firstname, ' ', Lastname) AS [ФИО], Date_of_birth AS [Дата рождения], Team_Name AS [Команда], User_ID AS [ID пользователя]  FROM Coaches JOIN Teams ON Coaches.Team_ID = Teams.Team_ID";
                   break;

                case "Типы мероприятий":
                    query = "SELECT Event_type_ID AS [ID Типа мероприятия], Event_type AS [Тип мероприятия] FROM Event_types";
                    break;

                case "Расписание":
                    query = "SELECT Event_ID AS [ID Мероприятия], Event_type AS [Тип мероприятия], Team_Name AS [Команда], Dates AS [Дата], Times AS [Время], Location AS [Локация] FROM Eventss JOIN Event_types ON Eventss.Event_type_ID = Event_types.Event_type_ID JOIN Teams ON Eventss.Team_ID = Teams.Team_ID";
                    break;

                case "Игроки":
                    
                        query = "SELECT Player_ID AS [ID Игрока], Surname AS [Фамилия], Firstname AS [Имя], Date_of_birth AS [Дата рождения], Position AS [Позиция], Team_Name AS [Команда], User_ID AS [ID пользователя] FROM Players JOIN Teams ON Players.Team_ID = Teams.Team_ID";
                   
                    break;

                case "Результаты игроков":
                    if (_userRole == 3)
                    {
                        query = "SELECT Result_Players.Result_ID AS [ID Результата], Event_types.Event_type AS [Название мероприятия], CONCAT(Players.Surname, ' ', Players.Firstname) AS [Игрок], Teams.Team_Name AS [Команда], Result_Players.Played_Time AS [Время на поле], Result_Players.Points AS [Очки], Result_Players.Throws_2Point AS [2-очковые броски], Result_Players.Throws_3Point AS [3-очковые броски], Result_Players.Throws_Free AS [Штрафные броски], Result_Players.Rebounds AS [Подборы], Result_Players.Assists AS [Передачи], Result_Players.Steals AS [Перехваты] FROM Result_Players JOIN Eventss ON Result_Players.Event_ID = Eventss.Event_ID JOIN Players ON Result_Players.Player_ID = Players.Player_ID JOIN Teams ON Result_Players.Team_ID = Teams.Team_ID JOIN Event_Types ON Eventss.Event_Type_ID = Event_Types.Event_Type_ID";
                    }
                    else if (_userRole == 2)
                    {
                        query = "SELECT Result_ID AS [ID Результата], Event_Type AS [Название мероприятия], CONCAT(Players.Surname, ' ', Players.Firstname) AS [Игрок], Teams.Team_Name AS [Команда], Played_Time AS [Время на поле], Points AS [Очки], Throws_2Point AS [2-очковые броски], Throws_3Point AS [3-очковые броски], Throws_Free AS [Штрафные броски], Rebounds AS [Подборы], Assists AS [Передачи], Steals AS [Перехваты] FROM Result_Players JOIN Eventss ON Result_Players.Event_ID = Eventss.Event_ID JOIN Players ON Result_Players.Player_ID = Players.Player_ID JOIN Teams ON Result_Players.Team_ID = Teams.Team_ID JOIN Event_Types ON Eventss.Event_Type_ID = Event_Types.Event_Type_ID WHERE Players.Player_ID = (SELECT Player_ID FROM Players WHERE User_ID = @UserId)";
                    }
                    else if (_userRole == 1)
                    {
                        query = "SELECT Result_ID AS [ID Результата], Event_types.Event_type AS [Название мероприятия], CONCAT(Players.Surname, ' ', Players.Firstname) AS [Игрок], Teams.Team_Name AS [Команда], Played_Time AS [Время на поле], Points AS [Очки], Throws_2Point AS [2-очковые броски], Throws_3Point AS [3-очковые броски], Throws_Free AS [Штрафные броски], Rebounds AS [Подборы], Assists AS [Передачи], Steals AS [Перехваты] FROM Result_Players JOIN Eventss ON Result_Players.Event_ID = Eventss.Event_ID JOIN Players ON Result_Players.Player_ID = Players.Player_ID JOIN Teams ON Result_Players.Team_ID = Teams.Team_ID JOIN Event_types ON Eventss.Event_Type_ID = Event_types.Event_Type_ID WHERE Players.Team_ID = (SELECT Team_ID FROM Coaches WHERE User_ID = @UserId)";
                    }
                    break;

                case "Роли":
                    query = "SELECT Role_ID AS [ID Роли], Role_Type AS [Тип Роли] FROM Roles";
                    break;

                case "Команды":
                    query = "SELECT Team_ID AS [ID Команды], Team_Name AS [Название команды], Division AS [Дивизион] FROM Teams";
                    break;

                case "Пользователи":                            
                    query = "SELECT User_ID AS [ID Пользователя], User_Name AS [Имя пользователя], Login AS [Логин], Password AS [Пароль], Role_ID AS [ID Роли] FROM Users";
                break;

                case "Мои игроки":
                    query = "SELECT Player_ID AS [ID Игрока], Surname AS [Фамилия], Firstname AS [Имя], Date_of_birth AS [Дата рождения], Position AS [Позиция], Team_Name AS [Команда] FROM Players JOIN Teams ON Players.Team_ID = Teams.Team_ID WHERE Players.Team_ID = (SELECT Team_ID FROM Coaches WHERE User_ID = @UserId)";
                    break;

                case "Статистика игроков":
                    query = "SELECT Result_Players.Result_ID AS [ID Результата], Event_types.Event_type AS [Название мероприятия], CONCAT(Players.Surname, ' ', Players.Firstname) AS [Игрок], Teams.Team_Name AS [Команда], Result_Players.Played_Time AS [Время на поле], Result_Players.Points AS [Очки], Result_Players.Throws_2Point AS [2-очковые броски], Result_Players.Throws_3Point AS [3-очковые броски], Result_Players.Throws_Free AS [Штрафные броски], Result_Players.Rebounds AS [Подборы], Result_Players.Assists AS [Передачи], Result_Players.Steals AS [Перехваты] FROM Result_Players JOIN Eventss ON Result_Players.Event_ID = Eventss.Event_ID JOIN Players ON Result_Players.Player_ID = Players.Player_ID JOIN Teams ON Result_Players.Team_ID = Teams.Team_ID JOIN Event_types ON Eventss.Event_Type_ID = Event_types.Event_Type_ID WHERE Players.Team_ID = (SELECT Team_ID FROM Coaches WHERE User_ID = @UserId)";
                    break;

                case "Команда":
                    query = "SELECT Player_ID AS [ID Игрока], Surname AS [Фамилия], Firstname AS [Имя], Date_of_birth AS [Дата рождения], Position AS [Позиция], Team_Name AS [Команда] FROM Players JOIN Teams ON Players.Team_ID = Teams.Team_ID WHERE Players.Team_ID = (SELECT Team_ID FROM Players WHERE User_ID = @UserId)";
                    break;

                case "Мои результаты":
                    query = "SELECT Result_ID AS [ID Результата], Event_Type AS [Название мероприятия], CONCAT(Players.Surname, ' ', Players.Firstname) AS [Игрок], Teams.Team_Name AS [Команда], Played_Time AS [Время на поле], Points AS [Очки], Throws_2Point AS [2-очковые броски], Throws_3Point AS [3-очковые броски], Throws_Free AS [Штрафные броски], Rebounds AS [Подборы], Assists AS [Передачи], Steals AS [Перехваты] FROM Result_Players JOIN Eventss ON Result_Players.Event_ID = Eventss.Event_ID JOIN Players ON Result_Players.Player_ID = Players.Player_ID JOIN Teams ON Result_Players.Team_ID = Teams.Team_ID JOIN Event_Types ON Eventss.Event_Type_ID = Event_Types.Event_Type_ID WHERE Players.Player_ID = (SELECT Player_ID FROM Players WHERE User_ID = @UserId)";
                    break;
                default:
                    MessageBox.Show("Неизвестная таблица.");
                    return;
            }

            if (string.IsNullOrEmpty(query))
                return;




            _query = query;
            LoadData(query);
            ChooseColumnBox.Text = "";
            ValueBox.Text = "";


        }

        public void LoadData(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        if (query.Contains("@UserId"))
                        {
                            command.Parameters.AddWithValue("@UserId", _userId);
                        }

                        
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            ChooseColumnBox.Items.Clear();
            ValueBox.Items.Clear();

            if (dataGridView1.DataSource is DataTable dataTable)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    ChooseColumnBox.Items.Add(column.ColumnName);
                }
            }
        }

        private void ChooseColumnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumnName = ChooseColumnBox.SelectedItem?.ToString();
            ValueBox.Items.Clear();

            // Проверяем, что DataGridView имеет строки и колонка выбрана
            if (dataGridView1 != null && !string.IsNullOrEmpty(selectedColumnName) && dataGridView1.Columns.Contains(selectedColumnName))
            {
                // Проходим по строкам в DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Проверяем, что значение для выбранной колонки не пустое
                    if (row.Cells[selectedColumnName].Value != null && !ValueBox.Items.Contains(row.Cells[selectedColumnName].Value))
                    {
                        // Добавляем значение в список
                        ValueBox.Items.Add(row.Cells[selectedColumnName].Value);
                    }
                }
            }
            ValueBox.Text = "";
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            string selectedColumnName = ChooseColumnBox.SelectedItem?.ToString();
            string filterValue = ValueBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedColumnName) && !string.IsNullOrEmpty(filterValue))
            {
                FilterData(selectedColumnName, filterValue);
            }
        }

        public void FilterData(string columnName, string filterValue)
        {
            try
            {
                if (dataGridView1.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", columnName, filterValue);
                    dataGridView1.DataSource = dt.DefaultView.ToTable();
                }
                else
                {
                    MessageBox.Show("DataSource не является DataTable.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData(_query);
            ChooseColumnBox.Text = "";
            ValueBox.Text = "";
        }

        private void AddOrChangeBtn_Click(object sender, EventArgs e)
        {
            string choose = ChooseTableBox.SelectedItem.ToString();

            
            if (_userRole == 1) 
            {
                
                int teamId = GetTeamIdForCoach(_userId);

                
                if (teamId != -1)
                {
                    switch (choose)
                    {
                        case "Мои игроки":
                            
                            AddEditPlayers addEditPlayers = new AddEditPlayers(_connectionString, teamId);

                           
                            foreach (Form form in Application.OpenForms)
                            {
                                if (form is AddEditPlayers)
                                {
                                    form.BringToFront();
                                    return;
                                }
                            }

                            addEditPlayers.Show();
                            break;

                        case "Статистика игроков":
                            
                            AddEditResults addEditResults = new AddEditResults(_connectionString, teamId);

                           
                            foreach (Form form in Application.OpenForms)
                            {
                                if (form is AddEditResults)
                                {
                                    form.BringToFront();
                                    return;
                                }
                            }

                            addEditResults.Show();
                            break;

                        case "Расписание":
                            
                            AddEditSchedule addEditSchedule = new AddEditSchedule(_connectionString, teamId);

                            
                            foreach (Form form in Application.OpenForms)
                            {
                                if (form is AddEditSchedule)
                                {
                                    form.BringToFront();
                                    return;
                                }
                            }

                            addEditSchedule.Show();
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: тренер не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: у вас нет прав для выполнения этой операции. Только для тренеров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public int GetTeamIdForCoach(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Team_ID FROM Coaches WHERE User_ID = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении команды тренера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public string GetUserNameText()
        {
            return UserName.Text;
        }
    }
}

