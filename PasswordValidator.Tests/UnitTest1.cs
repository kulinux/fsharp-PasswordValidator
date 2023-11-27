namespace PasswordValidator.Tests;

[TestClass]
public class PasswordValidatorShould
{
    [TestMethod]
    public void ValidateWhenValidaPassword()
    {
        Assert.AreEqual(true, PasswordValidator.validate("123456789"));
    }

    [TestMethod]
    public void NotValidateWhenHasMoreThanEightCharacters()
    {
        Assert.AreEqual(false, PasswordValidator.validate("1234567"));
    }

   
}