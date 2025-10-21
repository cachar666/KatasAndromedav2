namespace LeapYears.Test;

public class CalculadoraBisiestos
{
    public bool IsLeapYear(int year)
    {
        if (EsDivisible(year, 400))
            return true;

        if (EsDivisible(year, 100))
            return false;

        return (EsDivisible(year, 4));
    }

    private static bool EsDivisible(int year, int divisor)
    {
        return year % divisor == 0;
    }
}