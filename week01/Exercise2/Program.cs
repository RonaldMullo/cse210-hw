using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the percentage of your grade: ");
        double percentage = Convert.ToDouble(Console.ReadLine());

        string letter = "";
        string sign = "";

       
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (percentage >= 70)
        {
            Console.WriteLine("Excellent! You passed.");
        }
        else
        {
            Console.WriteLine("I'm sorry, you failed.");
        }

        Console.WriteLine($"Your grade is: {letter}");

        
        if (letter != "F") 
        {
            int lastDigit = (int)(percentage % 10);

            if (letter == "A")
            {
                if (lastDigit < 3 && percentage < 100)
                {
                    sign = "-";
                }
            }
         
            else
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
        }

        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}
