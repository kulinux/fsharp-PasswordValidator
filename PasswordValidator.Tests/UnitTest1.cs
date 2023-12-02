using Microsoft.FSharp.Core;

namespace PasswordValidator.Tests;

[TestClass]
public class PasswordValidatorOneShould
{
    const string VALID_PASSWORD = "123aA_5678";

    private static Func<string, bool> validate = PasswordValidator.validation(ValidationType.ValidationOne).Invoke;

    [TestMethod]
    public void ValidateWhenValidaPassword()
    {
        Assert.AreEqual(true, validate(VALID_PASSWORD));
    }

    [TestMethod]
    public void NotValidateWhenHasMoreThanEightCharacters()
    {
        Assert.AreEqual(false, validate(VALID_PASSWORD.Substring(0, 7)));
    }

    [TestMethod]
    public void NotValidateThereAreNoCapitalLetters()
    {
        Assert.AreEqual(false, validate.Invoke(VALID_PASSWORD.ToLower()));
    }

    [TestMethod]
    public void NotValidateThereAreNoLowerLetters()
    {
        Assert.AreEqual(false, validate(VALID_PASSWORD.ToUpper()));
    }

    [TestMethod]
    public void NotValidateThereAreNoUnderscore()
    {
        Assert.AreEqual(false, validate(VALID_PASSWORD.Replace("_", "a")));
    }



}