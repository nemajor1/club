using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class DBControllerTests
{
    private DBController dbController = new DBController();

    [Test]
    public void UserRegistration_ValidInput_ReturnsTrue(string[] data)
    {
        bool result = dbController.UserRegistration(data[0], data[1], data[2], data[3]);

        ClassicAssert.IsTrue(result, "Ожидалось успешное выполнение регистрации с правильными данными.");
    }
}