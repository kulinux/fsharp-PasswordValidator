namespace PasswordValidator.Tests;

[TestClass]
public class PasswordValidatorShould
{

    const string VALID_PASSWORD = "123aA_5678";

    [TestMethod]
    public void ValidateWhenValidaPassword()
    {
        Assert.AreEqual(true, PasswordValidator.validate(VALID_PASSWORD));
    }

    [TestMethod]
    public void NotValidateWhenHasMoreThanEightCharacters()
    {
        Assert.AreEqual(false, PasswordValidator.validate(VALID_PASSWORD.Substring(0, 7)));
    }

    [TestMethod]
    public void NotValidateThereAreNoCapitalLetters()
    {
        Assert.AreEqual(false, PasswordValidator.validate(VALID_PASSWORD.ToLower()));
    }

    [TestMethod]
    public void NotValidateThereAreNoLowerLetters()
    {
        Assert.AreEqual(false, PasswordValidator.validate(VALID_PASSWORD.ToUpper()));
    }

    [TestMethod]
    public void NotValidateThereAreNoUnderscore()
    {
        Assert.AreEqual(false, PasswordValidator.validate(VALID_PASSWORD.Replace("_", "a")));
    }



}