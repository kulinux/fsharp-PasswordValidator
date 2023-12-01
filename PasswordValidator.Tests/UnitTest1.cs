using Microsoft.FSharp.Core;

namespace PasswordValidator.Tests;

[TestClass]
public class PasswordValidatorShould
{

    FSharpFunc<string, bool> passwordValidator = PasswordValidator.validation(ValidationType.ValidationOne);

    const string VALID_PASSWORD = "123aA_5678";

    [TestMethod]
    public void ValidateWhenValidaPassword()
    {
        Assert.AreEqual(true, passwordValidator.Invoke(VALID_PASSWORD));
    }

    [TestMethod]
    public void NotValidateWhenHasMoreThanEightCharacters()
    {
        Assert.AreEqual(false, passwordValidator.Invoke(VALID_PASSWORD.Substring(0, 7)));
    }

    [TestMethod]
    public void NotValidateThereAreNoCapitalLetters()
    {
        Assert.AreEqual(false, passwordValidator.Invoke(VALID_PASSWORD.ToLower()));
    }

    [TestMethod]
    public void NotValidateThereAreNoLowerLetters()
    {
        Assert.AreEqual(false, passwordValidator.Invoke(VALID_PASSWORD.ToUpper()));
    }

    [TestMethod]
    public void NotValidateThereAreNoUnderscore()
    {
        Assert.AreEqual(false, passwordValidator.Invoke(VALID_PASSWORD.Replace("_", "a")));
    }



}