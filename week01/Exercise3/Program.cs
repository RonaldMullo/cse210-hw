using System;

class GuessMyNumber
{
    static void Main()
    {
        Random random = new Random();
        bool playAgain = true;
        
        Console.WriteLine("Welcome to the Guess My Number game!");
        
        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess;
            
            Console.WriteLine("\nI've chosen a number between 1 and 100. Can you guess it?");
            
            do
            {
                Console.Write("What is your guess? ");
                while (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 100)
                {
                    Console.Write("Please enter a valid number between 1 and 100: ");
                }
                
                guessCount++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
                
            } while (guess != magicNumber);
            
            Console.Write("\nWould you like to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes" || response == "y");
        }
        
        Console.WriteLine("\nThanks for playing! Goodbye.");
    }
}
