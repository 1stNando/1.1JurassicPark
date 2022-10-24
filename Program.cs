using System;
using System.Linq;
using System.Collections.Generic;
namespace _1._1JurassicPark
{
    class Program
    {

        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to the Dinosaur Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }///////////////////////////////////////////////////////////////////////////////////
        class Dinosaur
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public string DietType { get; set; }
            public int EnclosureNumber { get; set; }
            public string WhenAcquired { get; set; }
        }



        // static void Description()
        // {
        //     foreach (Dinosaur in Dinosaurs)
        //     {
        //         Console.WriteLine($"{Name} + {Weight} + {DietType} + {EnclosureNumber} + {WhenAcquired} ");
        //     }
        // }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            DisplayGreeting();

            var Dinosaurs = new List<Dinosaur>();









        }
    }
}
