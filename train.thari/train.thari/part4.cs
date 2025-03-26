using System;

namespace Train
{
    public class part4 : Part2
    {

        public void Part4_Main()
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to the Passenger Information System ===\n");

            Console.Write("Please select your status (Local [L] or Foreign [F]): ");
            string choice = Console.ReadLine().Trim().ToUpper();


            if (choice == "L")
            {
                Console.WriteLine("\nYou selected Local Passenger.");
                Console.Write("Enter your ID Number: ");
                string? idNumber = Console.ReadLine();

                Console.Write("Enter your full name: ");
                string? name = Console.ReadLine();
                ticketPrice(); // call ticketprice to calculate ticket prices
                Console.WriteLine("\n=== Passenger Information ===");
                Console.WriteLine($"ID Number      : {idNumber}");
                Console.WriteLine($"Name           : {name}");
                Console.WriteLine("Passenger Type : Local");
                Console.WriteLine("\nHere is a summary of all booked seats:");
                Console.WriteLine("\nFirst Class: " + string.Join(", ", firstClassSeats));
                Console.WriteLine("Second Class: " + string.Join(", ", secondClassSeats));
                Console.WriteLine("Third Class: " + string.Join(", ", thirdClassSeats));
                Console.WriteLine($"\nYour first clz tickets price Rs.{totalfisrtclz_price}");
                Console.WriteLine($"Your second clz tickets price Rs.{totalsecondclz_price}");
                Console.WriteLine($"Your third clz tickets price Rs.{totalthirdclz_price}");
                Console.WriteLine($"Your Total tickets price Rs.{totalticketprice}");
                Console.WriteLine("\nThank you for choosing Sri Lanka Railway.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "F")
            {
                Console.WriteLine("\nYou selected Foreign Passenger.");
                Console.Write("Enter your Passport Number: ");
                string? passportNumber = Console.ReadLine();

                Console.Write("Enter your full name: ");
                string? name = Console.ReadLine();
                ticketPrice(); // call ticketprice to calculate ticket prices
                Console.WriteLine("\n=== Passenger Information ===");
                Console.WriteLine($"Passport Number : {passportNumber}");
                Console.WriteLine($"Name            : {name}");
                Console.WriteLine("Passenger Type  : Foreign");
                Console.WriteLine("\nHere is a summary of all booked seats:");
                Console.WriteLine("\nFirst Class: " + string.Join(", ", firstClassSeats));
                Console.WriteLine("Second Class: " + string.Join(", ", secondClassSeats));
                Console.WriteLine("Third Class: " + string.Join(", ", thirdClassSeats));
                Console.WriteLine($"\nYour first clz tickets price Rs.{totalfisrtclz_price}");
                Console.WriteLine($"Your second clz tickets price Rs.{totalsecondclz_price}");
                Console.WriteLine($"Your third clz tickets price Rs.{totalthirdclz_price}");
                Console.WriteLine($"Your Total tickets price Rs.{totalticketprice}");
                Console.WriteLine("\nThank you for choosing Sri Lanka Railway.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'L' for Local or 'F' for Foreign.");
                Part4_Main(); // Retry on invalid input.
            }
        }
    }
}
