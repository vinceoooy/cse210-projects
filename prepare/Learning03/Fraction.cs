using System;
using System.Diagnostics;
using System.Xml.XPath;

public class Fraction{
    private int _numerator;
    private int _denominator;

    public Fraction(){
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int top){
        _numerator = top;
        _denominator = 1;
    }

    public Fraction(int top, int bottom){
        _numerator = top;
        _denominator = bottom;
    }

     public string GetFractionString()
    {
        string text = $"{_numerator}/{_denominator}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / (double) _denominator;
    }
}       