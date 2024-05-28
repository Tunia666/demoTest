using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using NUnit.Framework;
using test;

namespace NunitDemo
{
    [TestFixture]
    public class Authorization
    {
        private const string ConnectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;"; // Замените на вашу строку подключения

        [Test]
        public void TestUserValidation()
        {
            // Arrange
            string validLogin = "Vladlena@gmai.com";
            string validPassword = "07i7Lb";
            bool rez = Авторизация.IsUserValid(validLogin, validPassword);
            // Act
            bool isValid = Авторизация.IsUserValid(validLogin, validPassword);

            // Assert
            Assert.AreEqual(isValid, rez);
        }

        [Test]
        public void TestInvalidUser()
        {
            // Arrange
            string invalidLogin = "invalidUser";
            string invalidPassword = "invalidPassword";
            //bool rez = Авторизация.IsUserValid(invalidLogin, invalidPassword);
            // Act
            //bool isValid = Авторизация.IsUserValid("yntiRS", "yntiRS");

            // Assert
            Assert.AreEqual(invalidLogin, "Elizor@gmai,com");
            Assert.AreEqual(invalidPassword, "yntiRS");
        }


    }
    [TestFixture]
    public class DatabaseTests
    {
        private const string ConnectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;"; // Замените на вашу строку подключения

        [Test]
        public void TestEmployeeCount()
        {
            // Arrange
            //var database = new YourDatabaseClass(ConnectionString); // Создайте экземпляр класса для работы с базой данных
            SqlConnection database = new SqlConnection(ConnectionString);
            // Act
            string Login = "Vladlena@gmai.com";
            string Password = "07i7Lb";
            bool employeeCount;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // SQL запрос для проверки данных пользователя
                    string query = "SELECT COUNT(*) FROM Сотрудники WHERE Логин = @login AND Пароль = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", Login);
                    command.Parameters.AddWithValue("@password", Password);

                    // Выполнение запроса и получение результата
                    int count = (int)command.ExecuteScalar();
                    employeeCount = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                    employeeCount = false;
                }

                // Assert
                Assert.IsTrue(employeeCount, "Ожидалось, что количество сотрудников будет положительным.");
            }
        }
    }
}