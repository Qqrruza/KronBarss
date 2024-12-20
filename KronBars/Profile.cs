using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KronBars
{
    public partial class Profile : Form
    {
        private int userId;
        private int userRole; // Изменено на int
        private string connectionString = "Data Source=LAPTOP-MNFH39V4\\SQLEXPRESS;Initial Catalog=KronBars;Integrated Security=True";

        public Profile(int userId, int userRole) // Принимаем int userRole
        {
            InitializeComponent();
            this.userId = userId;
            this.userRole = userRole;
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (userRole == 1) // Тренер
                    {
                        query = "SELECT Surname, Firstname, Lastname, Date_of_birth, Teams.Team_Name " +
                                "FROM Coaches INNER JOIN Teams ON Coaches.Team_ID = Teams.Team_ID " +
                                "WHERE Coaches.User_ID = @UserID";
                    }
                    else if (userRole == 2) // Игрок
                    {
                        query = "SELECT Surname, Firstname, Date_of_birth, Position, Teams.Team_Name " +
                                "FROM Players INNER JOIN Teams ON Players.Team_ID = Teams.Team_ID " +
                                "WHERE Players.User_ID = @UserID";
                    }
                    else
                    {
                        MessageBox.Show("У вас нет личного кабинета.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SurnameBox.Text = reader["Surname"].ToString();
                                NameBox.Text = reader["Firstname"].ToString();

                                if (userRole == 1) // Тренер
                                {
                                    LastnameOrBirthdayBox.Text = reader["Lastname"].ToString();
                                    BirthdayOrPositionBox.Text = Convert.ToDateTime(reader["Date_of_birth"]).ToString("dd.MM.yyyy");
                                }
                                else if (userRole == 2) // Игрок
                                {
                                    LastnameOrBirthdayBox.Text = Convert.ToDateTime(reader["Date_of_birth"]).ToString("dd.MM.yyyy");
                                    BirthdayOrPositionBox.Text = reader["Position"].ToString();
                                }

                                TeamBox.Text = reader["Team_Name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Данные не найдены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            
            if (userRole == 1) // Тренер
            {
                LastnameOrBirthdaylabel.Text = "отчество:";
                BirthdayOrPositionlabel.Text = "дата рождения:";
            }
            else if (userRole == 2) // Игрок
            {
                LastnameOrBirthdaylabel.Text = "дата рождения:";
                BirthdayOrPositionlabel.Text = "позиция:";
            }
        }
    }
}
