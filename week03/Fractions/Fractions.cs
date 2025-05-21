using System;

public class Fraction
{   //private fields(Encapsulated data)
    private int _numerator;
    private int _denominator;

    //Constructor 1: Default to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor 2: Pass numerator only(e.g., 4)
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    // Constructor 3: Pass both numerator and denominator(e.g., 4/5)
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    // Getters and Seetters
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int value)
    {
        _numerator = value;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int value)
    {
        _denominator = value;
    }

    // Returns the string representation like "4/5"
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Returns the decimal value like 0.8
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
