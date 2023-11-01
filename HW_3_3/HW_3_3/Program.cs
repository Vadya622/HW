using System;

// Класс 1
public class Class1
{
    public delegate void ShowDelegate(bool value);
    public delegate int MultiplyDelegate(int a, int b);

    public void Show(bool value)
    {
        Console.WriteLine($"The value is: {value}");
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}

// Класс 2
public class Class2
{
    public Class1.ShowDelegate Calc(Class1.MultiplyDelegate del, int a, int b)
    {
        int result = del(a, b);
        return ShowResult;
    }

    public void ShowResult(bool result)
    {
        Console.WriteLine($"The result is: {result}");
    }
}

// Класс Program
class Program
{
    static void Main(string[] args)
    {
        Class1 class1 = new Class1();
        Class2 class2 = new Class2();

        Class1.ShowDelegate showDelegate = new Class1.ShowDelegate(class1.Show);

        int a = 5;
        int b = 3;

        Class1.MultiplyDelegate multiplyDelegate = new Class1.MultiplyDelegate(class1.Multiply);
        var calcDelegate = class2.Calc(multiplyDelegate, a, b);

        calcDelegate(true);
    }
}
