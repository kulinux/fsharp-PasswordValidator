using Microsoft.FSharp.Core;

namespace PasswordValidator.Tests;

[TestClass]
public class PasswordValidatorOneShould
{
    const string VALID_PASSWORD = "123aA_5678";

    private static Func<string, bool> validate = PasswordValidator.validation(ValidationType.ValidationOne).Invoke;

    [TestMethod]
    public void ValidateWhenValidPassword()
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
        Assert.AreEqual(false, validate(VALID_PASSWORD.ToLower()));
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


[TestClass]
public class PasswordValidatorTwoShould
{
    const string VALID_PASSWORD = "123aA_5";

    private static Func<string, bool> validate = PasswordValidator.validation(ValidationType.ValidationTwo).Invoke;

    [TestMethod]
    public void ValidateWhenValidPassword()
    {
        Assert.AreEqual(true, validate(VALID_PASSWORD));
    }

    [TestMethod]
    public void NotValidateWhenHasMoreThanSixCharacters()
    {
        Assert.AreEqual(false, validate(VALID_PASSWORD.Substring(0, 5)));
    }

    [TestMethod]
    public void NotValidateThereAreNoCapitalLetters()
    {
        Assert.AreEqual(false, validate(VALID_PASSWORD.ToLower()));
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

[TestClass]
public class PasswordValidatorWithReason
{
    const string VALID_PASSWORD = "123aA5678";

    //private static Func<string, string> reason = PasswordValidator.reason(ValidationType.ValidationOne);

    private static List<string> reason(string password)
    {
        return PasswordValidator.reason(ValidationType.ValidationOne).Invoke(password).ToList<string>();
    }


    [TestMethod]
    public void WhenNoUnderscoreGiveTheReasonToFail()
    {
        Assert.AreEqual("Underscore", reason(VALID_PASSWORD.Replace("_", "a"))[0]);
    }

    [TestMethod]
    public void WhenNotValidateThereAreNoCapitalLettersGiveTheReasonToFail()
    {
        Assert.AreEqual("Capital Letter", reason(VALID_PASSWORD.ToLower())[0]);
    }


    [TestMethod]
    public void WhenSeveralReason()
    {
        CollectionAssert.AreEquivalent(new List<string>(new string[] { "Underscore", "Capital Letter" }), reason(VALID_PASSWORD.ToLower()));
    }

}