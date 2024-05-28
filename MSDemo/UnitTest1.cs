using Microsoft.VisualStudio.TestTools.UnitTesting;
using test;
using System.Data.SqlClient;
namespace MSDemo
{
    //public static string ConnectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;";
    [TestClass]
    public class UserValidationTests
    {
        [TestMethod]
        public void TestValidUser()
        {
            // Arrange
            string validLogin = "Elizor@gmai,com";
            string validPassword = "yntiRS";

            // Act
            bool result = �����������.IsUserValid(validLogin, validPassword);

            // Assert
            Assert.IsTrue(result, "���������, ��� ������������ ����� ��������������.");
        }

        [TestMethod]
        public void TestInvalidUser()
        {
            // Arrange
            string invalidLogin = "Elizor@gmai,com";
            string invalidPassword = "07i7Lb";

            // Act
            bool result = �����������.IsUserValid(invalidLogin, invalidPassword);

            // Assert
            Assert.IsFalse(result, "���������, ��� ������������ ����� ����������������.");
        }
    }
    
    
}