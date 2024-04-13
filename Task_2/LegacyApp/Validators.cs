using System;

namespace LegacyApp;

public static class Validator
{
    public static bool IsNameValid(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false
        }

        return true
    }

    public static bool IsEmailValid(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true
    }

    public static bool IsDateValid(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;

        if (age < 21)
        {
            return false;
        }

        return true
    }
}