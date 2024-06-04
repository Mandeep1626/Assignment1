using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignmenyt_1

    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the Virtual Pet Simulator!");
                Console.WriteLine("Choose your pet type (cat, dog, rabbit): ");
                string petType = Console.ReadLine();
                Console.WriteLine("Give your pet a name: ");
                string petName = Console.ReadLine();

                Pet pet = new Pet(petType, petName);

                Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("1. Feed the pet");
                    Console.WriteLine("2. Play with the pet");
                    Console.WriteLine("3. Let the pet rest");
                    Console.WriteLine("4. Check pet status");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an action: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            pet.Feed();
                            break;
                        case "2":
                            pet.Play();
                            break;
                        case "3":
                            pet.Rest();
                            break;
                        case "4":
                            pet.Status();
                            break;
                        case "5":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }

                    // Simulate the passage of time
                    pet.TimePasses();

                    // Display warning if any stat is critically low or high
                    pet.CheckCriticalStatus();

                    Thread.Sleep(2000); // Pause for a moment before clearing the screen
                }
            }
        }

        class Pet
        {
            public string Type { get; private set; }
            public string Name { get; private set; }
            private int Hunger { get; set; }
            private int Happiness { get; set; }
            private int Health { get; set; }

            public Pet(string type, string name)
            {
                Type = type;
                Name = name;
                Hunger = 5;
                Happiness = 5;
                Health = 5;
            }

            public void Feed()
            {
                if (Hunger > 0)
                {
                    Hunger -= 2;
                    Health += 1;
                    Console.WriteLine($"{Name} has been fed. Hunger decreases, health increases.");
                }
                else
                {
                    Console.WriteLine($"{Name} is not hungry.");
                }
                DisplayStats();
            }

            public void Play()
            {
                if (Hunger < 9)
                {
                    Happiness += 2;
                    Hunger += 1;
                    Console.WriteLine($"{Name} played. Happiness increases, hunger increases.");
                }
                else
                {
                    Console.WriteLine($"{Name} is too hungry to play.");
                }
                DisplayStats();
            }

            public void Rest()
            {
                Health += 2;
                Happiness -= 1;
                Console.WriteLine($"{Name} is resting. Health increases, happiness decreases slightly.");
                DisplayStats();
            }

            public void Status()
            {
                DisplayStats();
            }

            private void DisplayStats()
            {
                Console.WriteLine($"Pet Status - Name: {Name}, Type: {Type}, Hunger: {Hunger}, Happiness: {Happiness}, Health: {Health}");
            }

            public void TimePasses()
            {
                Hunger += 1;
                Happiness -= 1;
                Console.WriteLine("Time passes...");
                DisplayStats();
            }

            public void CheckCriticalStatus()
            {
                if (Hunger >= 10)
                {
                    Health -= 2;
                    Console.WriteLine($"{Name} is starving! Health decreases.");
                }
                if (Happiness <= 0)
                {
                    Health -= 2;
                    Console.WriteLine($"{Name} is very unhappy! Health decreases.");
                }
                if (Health <= 0)
                {
                    Console.WriteLine($"{Name} is in critical condition!");
                }
            }
        }
    }
