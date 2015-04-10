namespace Common.Contracts
{
    using System;

    public interface IRandomDataGenerator
    {
        DateTime GeneraDateTime();

        bool GetChance(int percent);

        double GetDouble();

        int GetInt(int min, int max);

        string GetString(int min, int max);

        string GetString(int min, int max, string charsToUse);

        string GetStringExact(int length, string charsToUse);

        string GetStringExact(int length);

        string GetUrlSafeString(int min, int max);
    }
}