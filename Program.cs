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
        }///////////////////////////////////////////////////////////////////////////////////WRAP format from sdg above.
        class Dinosaur
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public string DietType { get; set; }
            public int EnclosureNumber { get; set; }
            public string WhenAcquired { get; set; }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            var rightNow = DateTime.Now;
            Console.WriteLine($"This is your current date and time: " + rightNow);
            DisplayGreeting();

            //Adding a List to store our dinosaur.
            var dinosaurs = new List<Dinosaur>();


            //////////////////////////Start of our interactive menu/////////////////////////
            //Should we keep showing the menu?
            var keepGoing = true;
            //While user has not QUIT yet
            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What would you like to do?\n(V)iew all the dinosaurs on the list\n(A)dd a dinosaur\n(D)elete a dinosaur\n(T)ransfer\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {   //User choses to quit, so set keepGoing to false
                    keepGoing = false;
                }

                else if (choice == "V")
                {

                    Console.WriteLine("Would you like to see the dinosaur list by (A)ll facts, or sorted by (N)ame, and (E)nclosureNumber? ");
                    var choice2 = Console.ReadLine().ToUpper();
                    if (choice2 == "N")
                    {
                        //We now create a NEW variable to contain dinosaurs ordered by name.KEY POINT to make is 
                        //that we also NEED to use the foreach loop to implement the sortedList we created. We must iterate through 
                        //this is how we are able to sort the list of dinosaurs by Name.
                        var sortedList = dinosaurs.OrderBy(x => x.Name).ToList();
                        foreach (var dinosaur in sortedList)
                        {
                            Console.WriteLine(dinosaur.Name);
                        }
                    }
                    else if (choice2 == "A")
                    {
                        foreach (var dinosaur in dinosaurs)
                        {
                            Console.WriteLine($"Name: {dinosaur.Name}, Enclosure #: {dinosaur.EnclosureNumber}, Diet type: {dinosaur.DietType}, Weight: {dinosaur.Weight}, When Acquired: {dinosaur.WhenAcquired}.");
                        }
                    }
                    else if (choice2 == "E")
                    {
                        var sortedList = dinosaurs.OrderBy(x => x.EnclosureNumber).ToList();
                        foreach (var dinosaur in sortedList)
                        {
                            Console.WriteLine($"Number: {dinosaur.EnclosureNumber} contains {dinosaur.Name}");
                        }

                    }

                    if (choice == "T")
                    {
                        var nameToSearchFor = PromptForString("What name are you trying to transfer? ");
                        Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearchFor);

                        if (foundDinosaur == null)
                        {
                            Console.WriteLine("No such dinosaur!");
                        }
                        else
                        {
                            //If dinosaur was found, ask user what enclosure number they would like to transfer the current to?
                        }
                    }

                    else if (choice == "A")
                    {   //CREATE  
                        //Make a new dinosaur object
                        var dinosaur = new Dinosaur();
                        //Prompt for values and save them in the dinosaur's properties
                        dinosaur.Name = PromptForString("What is the name? ");
                        dinosaur.Weight = PromptForInteger("How much is the weight (in pounds)? ");
                        dinosaur.DietType = PromptForString("What type of diet? ");
                        dinosaur.EnclosureNumber = PromptForInteger("What is the enclosure number? ");
                        dinosaur.WhenAcquired = rightNow.ToString();
                        //Add new dinosaur object to the list
                        dinosaurs.Add(dinosaur);


                    }

                    else if (choice == "D")
                    {
                        //get employee name
                        var nameToSearchFor = PromptForString("What name are you looking to delete? ");

                        //Search database to see if they exist!
                        Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearchFor);
                        //If we did not find an employee
                        if (foundDinosaur == null)
                        {
                            //Show that the person doesn't exist
                            Console.WriteLine("No such dinosaur found! ");
                        }
                        //if dinosaur is found
                        else
                        {
                            Console.WriteLine($"{foundDinosaur.Name} was found they can be found in enclosure #{foundDinosaur.EnclosureNumber}.");
                            //ask to confirm deletion
                            var confirm = PromptForString("Are you sure you want to delete this one? [Y/N] ").ToUpper();
                            if (confirm == "Y")
                            {
                                //delete them!
                                dinosaurs.Remove(foundDinosaur);
                            }
                        }

                    }

                    else if (choice == "F")
                    {
                        // Prompt for the name
                        var nameToSearchFor = PromptForString("What name are you looking for? ");
                        //Show the use of LINQ method shortcut style to search for something.!SUPERPOWER.!!!!!!
                        Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearchFor);

                        //After the loop, 'foundEmployee' is either 'null' (not found) or refers to the matching item
                        if (foundDinosaur == null)
                        {
                            Console.WriteLine("No such dinosaur!");
                        }
                        else
                        {
                            //Show a message if 'null', 
                            //otherwise show the details.
                            Console.WriteLine($"{foundDinosaur.Name} is in enclosure #{foundDinosaur.EnclosureNumber} and weights {foundDinosaur.Weight}. ");
                        }
                    }



                }//end of while loop


            }
        }
    }

