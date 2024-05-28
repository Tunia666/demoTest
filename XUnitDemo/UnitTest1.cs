using test;
namespace XUnitDemo
{
    public class UnitTest1
    {
        [Fact]
        public void TestUserValidation_ValidUser()
        {
            // Arrange
            string validLogin = "validUser";
            string validPassword = "validPassword";

            // Act
            bool isValid = �����������.IsUserValid(validLogin, validPassword);

            // Assert
            Assert.True(isValid, "���������, ��� ������������ ����� ��������������.");
        }

        [Fact]
        public void TestUserValidation_InvalidUser()
        {
            // Arrange
            string invalidLogin = "invalidUser";
            string invalidPassword = "invalidPassword";

            // Act
            //bool isValid = �����������.IsUserValid(invalidLogin, invalidPassword);

            // Assert
            Assert.Equal(invalidLogin, "test");
            Assert.Equal(invalidPassword, "test");
        }
    }
}