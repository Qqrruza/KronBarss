using KronBars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace KronBars.Tests
{
    [TestClass]
    public class TestMainForm
    {
        private MainForm _mainForm;

        [TestInitialize]
        public void Setup()
        {
            // Инициализация MainForm с тестовыми данными
            _mainForm = new MainForm(1, 1);  // Пример с тренером (userId = 1, roleID = 1)
        } 

        [TestMethod]
        public void TestSetUserNameLabel_ShouldSetCorrectName_ForCoach()
        {
            int userId = 1; // Замените на правильный ID пользователя
            int roleId = 1; // Роль тренера
            _mainForm.SetUserNamelabel();
            Assert.AreEqual(1, 1);
            Assert.AreEqual("Воронов Олег Александрович", _mainForm.GetUserNameText());
        }

        [TestMethod]
        public void TestSetChooseTableBox_ShouldPopulateCorrectItems_ForCoach()
        {
            var expectedItems = new string[] { "Расписание", "Мои игроки", "Статистика игроков" };

            _mainForm.SetChooseTableBox(1); // Роль тренера

            CollectionAssert.AreEqual(expectedItems, _mainForm.ChooseTableBox.Items);
        }

        [TestMethod]
        public void TestSetChooseTableBox_ShouldPopulateCorrectItems_ForPlayer()
        {
            
            var expectedItems = new string[] { "Расписание", "Команда", "Мои результаты" };

            _mainForm.SetChooseTableBox(2); 

            CollectionAssert.AreEqual(expectedItems, _mainForm.ChooseTableBox.Items);
        }

        [TestMethod]
        public void TestSetChooseTableBox_ShouldPopulateCorrectItems_ForAdmin()
        {
           
            var expectedItems = new string[] { "Тренеры", "Типы мероприятий", "Расписание", "Игроки", "Результаты игроков", "Роли", "Команды", "Пользователи" };

            
            _mainForm.SetChooseTableBox(3); // Роль администратора

            
            CollectionAssert.AreEqual(expectedItems, _mainForm.ChooseTableBox.Items);
        }

        [TestMethod]
        public void TestGetTeamIdForCoach_ShouldReturnTeamId_ForExistingCoach()
        {
            // Arrange
            int userId = 1; // Пример существующего тренера

            // Act
            int teamId = _mainForm.GetTeamIdForCoach(userId);

            // Assert
            Assert.AreNotEqual(-1, teamId); // Проверяем, что команда найдена
        }

        [TestMethod]
        public void TestGetTeamIdForCoach_ShouldReturnMinusOne_ForNonExistentCoach()
        {
            // Arrange
            int userId = 999; // Пример несуществующего тренера

            // Act
            int teamId = _mainForm.GetTeamIdForCoach(userId);

            // Assert
            Assert.AreEqual(-1, teamId); // Проверяем, что возвращен -1
        }

        [TestMethod]
        public void TestFilterData_ShouldFilterByColumn()
        {
            // Arrange
            string columnName = "Команда";
            string filterValue = "Кронверксие Барсы";

            // Создаем DataTable с тестовыми данными
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Команда");
            dataTable.Rows.Add("Кронверксие Барсы");
            dataTable.Rows.Add("Другие команды");

            // Устанавливаем DataTable как источник данных для DataGridView
            _mainForm.dataGridView1.DataSource = dataTable;

            // Act
            _mainForm.FilterData(columnName, filterValue); // Вызываем метод фильтрации

            // Assert
            // Проверяем, что таблица отфильтрована, и осталась хотя бы одна строка с нужным значением
            int expectedRowCount = dataTable.Select($"Команда LIKE '{filterValue}'").Length;
            Assert.AreEqual(expectedRowCount, _mainForm.dataGridView1.Rows.Count);
        }


        [TestMethod]
        public void TestFilterData_ShouldNotFilterIfNoMatch()
        {
            string columnName = "Команда";
            string filterValue = "Несуществующая команда";

           
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Команда");
            dataTable.Rows.Add("Кронверксие Барсы");
            dataTable.Rows.Add("Другие команды");

            _mainForm.dataGridView1.DataSource = dataTable;

            _mainForm.FilterData(columnName, filterValue); 

            int expectedRowCount = dataTable.Select($"Команда LIKE '{filterValue}'").Length;

            Assert.AreEqual(expectedRowCount, _mainForm.dataGridView1.Rows.Count); 
        }

        [TestMethod]
        public void TestLoadData_ShouldLoadCorrectData_ForPlayers()
        {
            // Arrange
            string query = "SELECT Player_ID, Surname, Firstname FROM Players";

            // Act
            _mainForm.LoadData(query);

            // Assert
            Assert.IsTrue(_mainForm.dataGridView1.Rows.Count > 0); 
        }


        [TestMethod]
        public void TestAddButtonVisibility_ShouldBeVisibleForCoach_AndHiddenForPlayer()
        {
            // Arrange
            var coachForm = new MainForm(1, 1); // Тренер (userId = 1, roleId = 1)
            var playerForm = new MainForm(2, 2); // Игрок (userId = 2, roleId = 2)

            // Act
            // Обновляем видимость кнопки для тренера и игрока
            coachForm.SetUserNamelabel(); // Принудительно вызываем установку имени (может быть связана с обновлением UI)
            playerForm.SetUserNamelabel(); // Для игрока также вызываем это для корректной инициализации

            // Проверяем видимость кнопки
            bool isAddButtonVisibleForCoach = coachForm.AddBtn.Visible;
            bool isAddButtonVisibleForPlayer = playerForm.AddBtn.Visible;

            // Assert
            Assert.IsTrue(isAddButtonVisibleForCoach, "Кнопка добавления должна быть видна для тренера.");
            Assert.IsFalse(isAddButtonVisibleForPlayer, "Кнопка добавления должна быть скрыта для игрока.");
        }



    }
}
