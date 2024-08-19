using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task_C
{
    internal class Program
    {
        // Declares a list to store Request objects
        static List<Request> requests = new List<Request>();

        // Converts the list to an array
        static Request[] request = requests.ToArray();

        static void Main(string[] args)
        {
            bool finished = false; // Initializes a flag to control the loop
            do
            {
                Console.WriteLine("Press ENTER"); // Prompts the user to press ENTER
                Console.ReadKey(); // Waits for user input
                Console.Clear(); // Clears the console
                Console.WriteLine("1. Add Request"); // Displays menu option to add a request
                Console.WriteLine("2. Display Requests"); // Displays menu option to show requests
                Console.WriteLine("3. Display the largest possible set of requests"); // Displays menu option to find the largest set of requests
                Console.WriteLine("4. Exit"); // Displays menu option to exit
                Console.WriteLine("\n Choose a function"); // Prompts the user to choose a function

                string option = Console.ReadLine(); // Reads user input

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Please insert request ID:"); // Asks for request ID
                        string id = Console.ReadLine(); // Stores user input as ID
                        Console.WriteLine("Please insert request Start Time: (23:59)"); // Asks for start time
                        string start = Console.ReadLine(); // Stores user input as start time
                        Console.WriteLine("Please insert request Finish Time: (23:59)"); // Asks for finish time
                        string finish = Console.ReadLine(); // Stores user input as finish time
                        requests.Add(new Request(id, start, finish)); // Adds a new request to the list
                        request = requests.ToArray(); // Converts the list to an array
                        break;
                    case "2":
                        DisplayAct(); // Calls the method to display requests
                        break;
                    case "3":
                        activitySelection(); // Calls the method to find the largest set of requests
                        break;
                    case "4":
                        finished = true; // Sets flag to true to end loop
                        Console.WriteLine("Give me First Class :)"); // Displays a message before exiting
                        break;
                }
            } while (!finished); // Continues loop until the user chooses to exit

            // Method to display all requests
            void DisplayAct()
            {
                for (int i = 0; i < request.Length; i++) // Iterates through the array
                {
                    Console.WriteLine(request[i].ID + ", " + request[i].STime + ", " + request[i].FTime); // Displays request details
                }
            }

            // Method to select the largest possible set of requests that don't overlap
            void activitySelection()
            {
                InsertionSort(); // Sorts the requests by finish time
                int k = 0;
                List<Request> ActivitySelection = new List<Request>();
                ActivitySelection.Add(request[k]); // Adds the first request to the selected list

                for (int i = 1; i < request.Length; i++)
                {
                    if (request[i].STime.CompareTo(request[k].FTime) > 0) // Checks if the next request does not overlap with the last added request
                    {
                        ActivitySelection.Add(request[i]); // Adds the request to the selected list
                        k = i; // Updates the index of the last added request
                    }
                }

                for (int i = 0; i < ActivitySelection.Count; i++) // Iterates through the selected list
                {
                    Console.WriteLine(ActivitySelection[i].ID + ", " + ActivitySelection[i].STime + ", " + ActivitySelection[i].FTime); // Displays the selected requests
                }
            }

            // Method to sort the requests by finish time using insertion sort
            void InsertionSort()
            {
                for (int i = 1; i < request.Length; i++) // Iterates through the array
                {
                    Request value = request[i]; // Stores the current request for comparison
                    int j = i;
                    for (; j > 0 && value.FTime.CompareTo(request[j - 1].FTime) < 0; j--) // Compares current request with previous ones
                    {
                        request[j] = request[j - 1]; // Shifts requests to the right if they have a later finish time
                    }
                    request[j] = value; // Inserts the current request in the correct position
                }
            }

            Console.ReadKey(); // Waits for user input before closing the console
        }
    }
}
