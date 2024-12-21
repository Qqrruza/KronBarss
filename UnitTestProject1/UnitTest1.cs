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
            
            _mainForm = new MainForm(1, 1);  
        } 

        [TestMethod]
        public void TestSetUserNameLabel_ShouldSetCorrectName_ForCoach()
        {
            int userId = 1; 
            int roleId = 1; 
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
            
            int userId = 1; 

           
            int teamId = _mainForm.GetTeamIdForCoach(userId);

            Assert.AreNotEqual(-1, teamId); 
        }

        [TestMethod]
        public void TestGetTeamIdForCoach_ShouldReturnMinusOne_ForNonExistentCoach()
        {
           
            int userId = 999; 

            int teamId = _mainForm.GetTeamIdForCoach(userId);

            Assert.AreEqual(-1, teamId); 
        }

        [TestMethod]
        public void TestFilterData_ShouldFilterByColumn()
        {
            string columnName = "Команда";
            string filterValue = "Кронверксие Барсы";

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
            string query = "SELECT Player_ID, Surname, Firstname FROM Players";

            _mainForm.LoadData(query);

            Assert.IsTrue(_mainForm.dataGridView1.Rows.Count > 0); 
        }


        [TestMethod]
        public void TestAddButtonVisibility_ShouldBeVisibleForCoach_AndHiddenForPlayer()
        {
            var coachForm = new MainForm(1, 1); 
            var playerForm = new MainForm(2, 2); 

            
            coachForm.SetUserNamelabel(); 
            playerForm.SetUserNamelabel(); 


            bool isAddButtonVisibleForCoach = coachForm.AddBtn.Visible;
            bool isAddButtonVisibleForPlayer = playerForm.AddBtn.Visible;


            Assert.IsTrue(isAddButtonVisibleForCoach, "Кнопка добавления должна быть видна для тренера.");
            Assert.IsFalse(isAddButtonVisibleForPlayer, "Кнопка добавления должна быть скрыта для игрока.");
        }



    }
}
