using System;

class Program
{
    static void Main(string[] args)
    {
        // Test constructor 1: 1/1
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());    // Output: 1/1
        Console.WriteLine(f1.GetDecimalValue());      // Output: 1

        // Test constructor 2: 4/1
        Fraction f2 = new Fraction(4);
        Console.WriteLine(f2.GetFractionString());    // Output: 4/1
        Console.WriteLine(f2.GetDecimalValue());      // Output: 4

        // Test constructor 3: 4/5
        Fraction f3 = new Fraction(4, 5);
        Console.WriteLine(f3.GetFractionString());    
        Console.WriteLine(f3.GetDecimalValue());      

        // Test another fraction: 1/3
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());    
        Console.WriteLine(f4.GetDecimalValue());      

        // Setters and Getters
        f4.SetNumerator(2);
        f4.SetDenominator(5);
        Console.WriteLine(f4.GetFractionString());    
        Console.WriteLine(f4.GetDecimalValue());      
    }
}