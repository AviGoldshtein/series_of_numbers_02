using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace series_of_numbers_02
{
    internal class Program
    {
        // print a list in an interactive vewu
        static void printList(List<int> list)
        {
            Console.Write("===  ");
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("  ===");
        }

        // insert args when the program is initiolized
        static bool insertArgs(string[] args, List<int> numbers)
        {
            foreach(string arg in args)
            {
                if (int.TryParse(arg, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers.Count >= 3;
        }

        // set new valews for the list
        static void askForArgs(List<int> numbers)
        {
            numbers.Clear();
            Console.WriteLine("Enter at least 3 positive numbers one after another (or type 'exit' to finish):");
            string numStr;
            string messege;
            while (true)
            {
                if (numbers.Count > 0)
                {
                    messege = numbers.Count >= 3 ? "enter another number or exit to finish" : "enter another number";
                    Console.WriteLine(messege + "\n");
                }
                numStr = Console.ReadLine();
                if (int.TryParse(numStr, out int number))
                {
                    if (number > 0)
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive number.");
                    }
                }
                else
                {
                    if (numStr == "exit")
                    {
                        if (numbers.Count < 3)
                        {
                            Console.WriteLine("You must enter at least 3 numbers.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input: {numStr} is not a number.");
                    }
                }
            }
            Console.WriteLine("you have set the list succesffuly");
        }

        // returen the list in revese order
        static List<int> showSeriesInReverse(List<int> numbers)
        {
            List<int> reversedSeries = new List<int>();
            int len = numbers.Count;
            for (int i = len - 1; i >= 0; i--)
            {
                reversedSeries.Add(numbers[i]);
            }
            return reversedSeries;
        }

        // returen the list in sorted order
        static List<int> showSeriesSorted(List<int> numbers)
        {
            List<int> copyList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                copyList.Add(numbers[i]);
            }

            List<int> sortedList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int min = copyList[0];
                for (int j = 0; j < copyList.Count; j++)
                {
                    if (copyList[j] < min)
                    {
                        min = copyList[j];
                    }
                }
                sortedList.Add(min);
                copyList.Remove(min);
            }
            return sortedList;
        }

        // returen the nax valew
        static int getMax(List<int> numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        // returen the min valew
        static int getMin(List<int> numbers)
        {
            int min = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }

        // returen the average of list
        static double getAverage(List<int> numbers)
        {
            //double sum = 0;
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    sum += numbers[i];
            //}
            //double average = sum / numbers.Count;
            double average = getSum(numbers) / numbers.Count;
            return average;
        }

        // returen the length of list
        static int getLen(List<int> numbers)
        {
            return numbers.Count;
        }

        // returen the sum of list
        static double getSum(List<int> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        // display the menu
        static string menu()
        {
            Console.WriteLine("\n\na. input a new series (replace the prives)\n" +
                "b. Display the series in the order it was entered.\n" +
                "c. Display the series in the reversed order it was entered.\n" +
                "d. Display the series in sorted order (from low to high).\n" +
                "e. Display the Max value of the series.\n" +
                "f. Display the Min value of the series.\n" +
                "g. Display the Average of the series.\n" +
                "h. Display the Number of elements in the series.\n" +
                "i. Display the Sum of the series.\n" +
                "j. Exit.");
            return Console.ReadLine().ToLower();
        }





        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isOk = insertArgs(args, numbers);
            if (!isOk)
            {
                askForArgs(numbers);
            }

            string choice;
            bool running = true;
            while (running)
            {
                choice = menu();
                switch (choice)
                {
                    case "a":
                        askForArgs(numbers);
                        break;
                    case "b":
                        printList(numbers);
                        break;
                    case "c":
                        printList(showSeriesInReverse(numbers));
                        break;
                    case "d":
                        printList(showSeriesSorted(numbers));
                        break;
                    case "e":
                        Console.WriteLine($"max: {getMax(numbers)}");
                        break;
                    case "f":
                        Console.WriteLine($"min: {getMin(numbers)}");
                        break;
                    case "g":
                        Console.WriteLine($"average: {getAverage(numbers)}");
                        break;
                    case "h":
                        Console.WriteLine($"the number of eivarim: {getLen(numbers)}");
                        break;
                    case "i":
                        Console.WriteLine($"sum: {getSum(numbers)}");
                        break;
                    case "j":
                        Console.WriteLine("have a good day");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("invalid input\n");
                        break;
                }
            }
        }
    }
}
