using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using NUnit.Framework;
using test;

namespace NunitDemo
{
    [TestFixture]
    public class Authorization
    {
        private const string ConnectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;"; // �������� �� ���� ������ �����������

        [Test]
        public void TestUserValidation()
        {
            // Arrange
            string validLogin = "Vladlena@gmai.com";
            string validPassword = "07i7Lb";
            bool rez = �����������.IsUserValid(validLogin, validPassword);
            // Act
            bool isValid = �����������.IsUserValid(validLogin, validPassword);

            // Assert
            Assert.AreEqual(isValid, rez);
        }

        [Test]
        public void TestInvalidUser()
        {
            // Arrange
            string invalidLogin = "invalidUser";
            string invalidPassword = "invalidPassword";
            //bool rez = �����������.IsUserValid(invalidLogin, invalidPassword);
            // Act
            //bool isValid = �����������.IsUserValid("yntiRS", "yntiRS");

            // Assert
            Assert.AreEqual(invalidLogin, "Elizor@gmai,com");
            Assert.AreEqual(invalidPassword, "yntiRS");
        }


    }
    [TestFixture]
    public class DatabaseTests
    {
        private const string ConnectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;"; // �������� �� ���� ������ �����������

        [Test]
        public void TestEmployeeCount()
        {
            // Arrange
            //var database = new YourDatabaseClass(ConnectionString); // �������� ��������� ������ ��� ������ � ����� ������
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
                    // SQL ������ ��� �������� ������ ������������
                    string query = "SELECT COUNT(*) FROM ���������� WHERE ����� = @login AND ������ = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", Login);
                    command.Parameters.AddWithValue("@password", Password);

                    // ���������� ������� � ��������� ����������
                    int count = (int)command.ExecuteScalar();
                    employeeCount = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("������ ��� ����������� � ���� ������: " + ex.Message);
                    employeeCount = false;
                }

                // Assert
                Assert.IsTrue(employeeCount, "���������, ��� ���������� ����������� ����� �������������.");
            }
        }
    }
}