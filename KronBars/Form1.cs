using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KronBars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*'; // Установка символа скрытия пароля
            loginTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 255;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Строка подключения к базе данных
            string connectionString = "Data Source=LAPTOP-MNFH39V4\\SQLEXPRESS;Initial Catalog=KronBars;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Запрос на проверку пользователя (получаем хеш пароля и соль)
                    string query = "SELECT User_ID, Role_ID, Password, Salt FROM Users WHERE Login = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0); // User_ID
                            int roleId = reader.GetInt32(1); // Role_ID
                            string storedHash = reader.GetString(2); // Хеш пароля из базы данных
                            string storedSalt = reader.GetString(3); // Соль из базы данных

                            // Проверяем пароль с использованием хеша и соли
                            if (PasswordHasher.VerifyPassword(password, storedHash, storedSalt))
                            {
                                MessageBox.Show($"Успешный вход! Ваша роль: {GetRoleName(roleId)}", "Добро пожаловать!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Открытие главной формы с передачей User_ID и Role_ID
                                MainForm mainForm = new MainForm(userId, roleId);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Тренер";
                case 2: return "Игрок";
                case 3: return "Администратор";
                default: return "Неизвестная роль";
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }
    }

    public class PasswordHasher
    {

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            // Хешируем введенный пароль с использованием сохраненной соли
            string hashedEnteredPassword = HashPassword(enteredPassword, storedSalt);

            // Сравниваем хеши
            return hashedEnteredPassword == storedHash;
        }
        // Метод для генерации соли
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // Генерация 16 байтов случайной соли
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes); // Заполнение массива солью
            }
            return Convert.ToBase64String(saltBytes); // Возвращаем соль как строку
        }

        // Метод для хеширования пароля с солью
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create()) // Используем SHA256 для хеширования
            {
                var saltedPassword = password + salt; // Добавляем соль к паролю
                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes); // Хешируем
                return Convert.ToBase64String(hashBytes); // Возвращаем хеш как строку
            }
        }

        // Обновление паролей в базе данных
        public static void UpdatePasswordsInDatabase()
        {
            string connectionString = "Data Source=LAPTOP-MNFH39V4\\SQLEXPRESS;Initial Catalog=KronBars;Integrated Security=True"; // Строка подключения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Подключение к базе данных успешно установлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Запрос для выборки пользователей
                    string selectQuery = "SELECT User_ID, Login FROM Users WHERE Password IS NULL"; // Извлекаем пользователей, у которых ещё нет пароля
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                    // Открываем SqlDataReader с использованием using
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        bool isUpdated = false; // Флаг успешного обновления

                        // После того как все записи прочитаны, выполняем обновление
                        List<int> userIds = new List<int>(); // Список для User_ID, для последующего обновления
                        List<string> logins = new List<string>(); // Список для Login, для хеширования
                        List<string> salts = new List<string>(); // Список для соли
                        List<string> hashedPasswords = new List<string>(); // Список для хешированных паролей

                        // Собираем данные пользователей
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string login = reader.GetString(1);

                            // Генерируем соль для каждого пользователя
                            string salt = GenerateSalt();

                            // Хешируем пароль (в этом примере мы просто хешируем сам логин для примера)
                            string hashedPassword = HashPassword(login, salt);

                            // Сохраняем данные для дальнейшего обновления
                            userIds.Add(userId);
                            logins.Add(login);
                            salts.Add(salt);
                            hashedPasswords.Add(hashedPassword);
                        }

                        // Закрываем reader, так как далее нужно использовать ExecuteNonQuery
                        reader.Close();

                        // Обновляем записи для каждого пользователя
                        for (int i = 0; i < userIds.Count; i++)
                        {
                            string updateQuery = "UPDATE Users SET Password = @Password, Salt = @Salt WHERE User_ID = @User_ID";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                            updateCommand.Parameters.AddWithValue("@Password", hashedPasswords[i]);
                            updateCommand.Parameters.AddWithValue("@Salt", salts[i]);
                            updateCommand.Parameters.AddWithValue("@User_ID", userIds[i]);

                            updateCommand.ExecuteNonQuery();
                            isUpdated = true; // Устанавливаем флаг успешного обновления
                        }

                        if (isUpdated)
                        {
                            MessageBox.Show("Пароли успешно обновлены с солью и хешированием.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Нет пользователей с пустыми паролями для обновления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения или обновления данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
