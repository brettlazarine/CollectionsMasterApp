using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50 - DONE
            var number = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50 - DONE
            Populater(number);

            //TODO: Print the first number of the array - DONE
            Console.WriteLine($"First: {number[0]}");

            //TODO: Print the last number of the array - DONE    
            Console.WriteLine($"Last: {number[number.Length - 1]}");

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists - DONE
            NumberPrinter(number);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); - DONE
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇) - DONE
            */

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(number.Reverse());

            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(number);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers - DONE
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(number);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now - DONE
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(number);
            NumberPrinter(number);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List - DONE
            var lst = new List<int>();

            //TODO: Print the capacity of the list to the console - DONE
            Console.WriteLine($"List capacity: {lst.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this - DONE            
            Populater(lst);

            //TODO: Print the new capacity - DONE
            Console.WriteLine($"New list capacity: {lst.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list - DONE
            //Remember: What if the user types "abc" accident your app should handle that! - DONE
            Console.WriteLine("What number will you search for in the number list?");
            int search;
            var searchQuestion = Console.ReadLine();
            var isNumber = int.TryParse(searchQuestion, out search);
            while (!isNumber)
            {
                Console.Write("Please input a valid integer: ");
                searchQuestion = Console.ReadLine();
                isNumber = int.TryParse(searchQuestion, out search);
            }
            NumberChecker(lst, search);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists - DONE
            NumberPrinter(lst);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results - DONE
            Console.WriteLine("Evens Only!!");
            OddKiller(lst);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results - DONE
            Console.WriteLine("Sorted Evens!!");
            lst.Sort();
            NumberPrinter(lst);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable - DONE
            Console.WriteLine("List to Array!!");
            var lstToArr = lst.ToArray();
            NumberPrinter(lstToArr);

            //TODO: Clear the list - DONE
            lst.Clear();
            Console.WriteLine($"List contents after clearing:");
            NumberPrinter(lst);

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
           for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            numberList.RemoveAll(num=> num % 2 != 0);
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            Console.WriteLine((numberList.Contains(searchNumber)) ? $"{searchNumber} is in the list." : $"{searchNumber} is NOT in the list.");
        }

        private static void Populater(List<int> numberList)
        {
            while (numberList.Count < 50)
            {
                Random rng = new Random();
                int number = rng.Next(0, 50);
                numberList.Add(number);
            }
            

        }

        private static void Populater(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Random rng = new Random();
                numbers[i] = rng.Next(0, 50);
            }         
        }        

        private static void ReverseArray(int[] array)
        {
            var reversed = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversed[i] = array[array.Length - 1 - i];
            }
            foreach (int num in reversed)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
