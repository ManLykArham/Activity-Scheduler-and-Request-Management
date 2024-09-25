using System;
using System.Collections.Generic;

namespace Task_C
{
    internal class Program
    {
        // Declares a list to store Request objects
        static List<Request> requests = new List<Request>();

        // Converts the list to an array
        static Request[] request;

        static void Main(string[] args)
        {
            bool finished = false; // Initializes a flag to control the loop
            do
            {
                Console.WriteLine("Press ENTER");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. Display Requests");
                Console.WriteLine("3. Display the largest possible set of requests");
                Console.WriteLine("4. Exit");
                Console.WriteLine("\n Choose a function");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddRequest(); // Calls the method to add a request
                        break;
                    case "2":
                        Console.WriteLine("\nID | Start Time | Finish Time\n");
                        DisplayAct(); // Calls the method to display requests
                        Console.WriteLine("\n");
                        break;
                    case "3":
                        activitySelection(); // Calls the method to find the largest set of requests
                        Console.WriteLine("\n");
                        break;
                    case "4":
                        finished = true; // Ends the loop
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            } while (!finished);
        }

        // Method to add a request
        static void AddRequest()
        {
            Console.WriteLine("Please insert request ID:");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("ID cannot be empty!");
                return;
            }

            Console.WriteLine("Please insert request Start Time: (HH:mm)");
            string start = Console.ReadLine();
            if (!ValidateTimeFormat(start))
            {
                Console.WriteLine("Invalid start time format! Please use HH:mm (e.g., 09:00).");
                return;
            }

            Console.WriteLine("Please insert request Finish Time: (HH:mm)");
            string finish = Console.ReadLine();
            if (!ValidateTimeFormat(finish))
            {
                Console.WriteLine("Invalid finish time format! Please use HH:mm (e.g., 17:30).");
                return;
            }

            // Validates if the start time is before the finish time
            DateTime startTime = DateTime.Parse(start);
            DateTime finishTime = DateTime.Parse(finish);

            if (startTime >= finishTime)
            {
                Console.WriteLine("Start time must be before the finish time!");
                return;
            }

            requests.Add(new Request(id, start, finish)); // Adds the new request
            request = requests.ToArray(); // Converts the list to an array
            Console.WriteLine("Request added successfully!\n");
        }

        // Validates time format (HH:mm)
        static bool ValidateTimeFormat(string time)
        {
            return DateTime.TryParseExact(time, "HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }

        // Method to display all requests, sorted by ID numerically
        static void DisplayAct()
        {
            if (request.Length == 0)
            {
                Console.WriteLine("No requests to display.");
                return;
            }

            // Sort the requests by ID numerically
            Array.Sort(request, (r1, r2) => int.Parse(r1.ID).CompareTo(int.Parse(r2.ID)));

            // Display the sorted requests
            for (int i = 0; i < request.Length; i++)
            {
                Console.WriteLine($"{request[i].ID}, {request[i].STime}, {request[i].FTime}");
            }
        }

        // Method to select the largest possible set of requests that don't overlap
        static void activitySelection()
        {
            InsertionSort(); // Sorts the requests by finish time
            int k = 0;
            List<Request> selectedRequests = new List<Request>();
            selectedRequests.Add(request[k]); // Adds the first request

            for (int i = 1; i < request.Length; i++)
            {
                if (DateTime.Parse(request[i].STime).CompareTo(DateTime.Parse(request[k].FTime)) > 0)
                {
                    selectedRequests.Add(request[i]); // Adds the request to the selected list
                    k = i; // Updates the last added request index
                }
            }

            if (selectedRequests.Count == 0)
            {
                Console.WriteLine("No non-overlapping requests found.");
            }
            else
            {
                Console.WriteLine("Selected non-overlapping requests:");
                for (int i = 0; i < selectedRequests.Count; i++)
                {
                    Console.WriteLine($"{selectedRequests[i].ID}, {selectedRequests[i].STime}, {selectedRequests[i].FTime}");
                }
                Console.WriteLine($"\nTotal non-overlapping requests: {selectedRequests.Count}");
            }
        }

        // Method to sort the requests by finish time using insertion sort
        static void InsertionSort()
        {
            for (int i = 1; i < request.Length; i++)
            {
                Request value = request[i];
                int j = i;
                while (j > 0 && DateTime.Parse(value.FTime).CompareTo(DateTime.Parse(request[j - 1].FTime)) < 0)
                {
                    request[j] = request[j - 1];
                    j--;
                }
                request[j] = value;
            }
        }
    }
}
