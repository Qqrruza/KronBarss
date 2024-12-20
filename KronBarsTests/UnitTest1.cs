using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using KronBars;

namespace KronBarsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetUserNamelabel_CorrectUserRole_ShouldSetUserName()
        {
            // Arrange
            var userId = 1;
            var roleId = 1; // Тренер
            var mainForm = new MainForm(userId, roleId);

            // Мокаем ответ от базы данных
            var mockConnection = new Mock<SqlConnection>();
            var mockCommand = new Mock<SqlCommand>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteScalar()).Returns("Иванов Иван Иванович");

            // Act
            mainForm.SetUserNamelabel();

            // Assert
            Assert.AreEqual("Иванов Иван Иванович", mainForm.GetUserNameText());
        }

        [TestMethod]
        public void MainForm_FormClosing_ShouldExitApplication()
        {
            // Arrange
            var userId = 1;
            var roleId = 2; // Игрок
            var mainForm = new MainForm(userId, roleId);

            // Act
            mainForm.MainForm_FormClosing(null, null);

            // Assert
            Assert.AreEqual(0, Application.OpenForms.Count);
        }
    }
}
