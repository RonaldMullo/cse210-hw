using System;

class Program
{
    static void DisWel() 
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string ProNam() 
    {
        Console.Write("Please enter your name: ");
        string nam = Console.ReadLine();
        return nam;
    }

    static int ProNum() 
    {
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    static int SquNum(int num) 
    {
        int sqr = num * num;
        return sqr;
    }

    static void DisRes(string nam, int sqr) 
    {
        Console.WriteLine($"{nam}, the square of your number is {sqr}");
    }

    static void Main(string[] args)
    {
        DisWel();
        string nam = ProNam();
        int num = ProNum();
        int sqr = SquNum(num);
        DisRes(nam, sqr);
    }
}
