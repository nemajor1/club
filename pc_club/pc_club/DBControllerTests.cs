using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class DBControllerTests
{
    private DBController dbController;

    [SetUp]
    public void Setup()
    {
        dbController = new DBController(); // Создаем экземпляр класса DBController для каждого теста
    }

    [Test]
    public void UserRegistration_ValidInput_ReturnsTrue()
    {
        // Arrange
        string firstName = "Иван";
        string lastName = "Иванов";
        string username = "ivanov";
        string password = "password12563";

        // Act
        bool result = dbController.UserRegistration(firstName, lastName, username, password);

        // Assert
        ClassicAssert.IsTrue(result, "Ожидалось успешное выполнение регистрации с правильными данными.");
    }

    [Test]
    public void UserRegistration_MissingFields_ReturnsFalse()
    {
        // Arrange
        string firstName = "";
        string lastName = "Иванов";
        string username = "ivanov";
        string password = "";

        // Act
        bool result = dbController.UserRegistration(firstName, lastName, username, password);

        // Assert
        ClassicAssert.IsFalse(result, "Ожидалось, что регистрация с пустыми данными вернёт false.");
    }

    [Test]
    public void UserRegistration_NullParameters_ReturnsFalse()
    {
        // Act
        bool result = dbController.UserRegistration(null, null, null, null);

        // Assert
        ClassicAssert.IsFalse(result, "Ожидалось, что регистрация с null параметрами вернёт false.");
    }
}