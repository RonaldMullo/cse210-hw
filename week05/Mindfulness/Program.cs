using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base class
    public abstract class Activity
    {
        protected string _name;
        protected string _desc;
        protected int _dur;

        // Starting message
        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity");
            Console.WriteLine();
            Console.WriteLine(_desc);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _dur = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            Spinner(3);
        }

        // Ending message
        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("Good job!");
            Spinner(2);
            Console.WriteLine($"You have completed the {_name} Activity for {_dur} seconds.");
            Spinner(3);
        }

        // Spinner animation
        protected void Spinner(int sec)
        {
            for (int i = 0; i < sec * 2; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("o");
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        // Countdown timer
        protected void Countdown(int sec)
        {
            for (int i = sec; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Abstract method to be implemented by derived classes
        public abstract void Run();
    }

    // Breathing 
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _name = "Breathing";
            _desc = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            Start();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_dur);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                Countdown(4);
                Console.WriteLine();
                Console.Write("Breathe out... ");
                Countdown(6);
            }

            End();
        }
    }

    // Reflection 
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            _name = "Reflection";
            _desc = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public override void Run()
        {
            Start();

            // Show random prompt
            Random rnd = new Random();
            Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            Countdown(5);
            Console.WriteLine();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_dur);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write(_questions[rnd.Next(_questions.Count)] + " ");
                Spinner(5);
            }

            End();
        }
    }

    // Listing Activity
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private int _count;

        public ListingActivity()
        {
            _name = "Listing";
            _desc = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void Run()
        {
            Start();

            // Show random prompt
            Random rnd = new Random();
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.Write("You may begin in: ");
            Countdown(5);
            Console.WriteLine();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_dur);
            _count = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                _count++;
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {_count} items!");

            End();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Activities Menu");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choose an activity: ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1000);
                        continue;
                }

                activity.Run();
            }
        }
    }
}
