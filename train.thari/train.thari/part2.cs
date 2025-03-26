using System;
using System.Collections.Generic;
using System.IO;

namespace Train
{
    // Base class: Part 1
    public class Part2 : part_1

    {
        public void Part2_Main()
        {
            Console.WriteLine("Welcome to the Seat Reservation system!");


            Console.WriteLine($"distance={distance}");

            while (true)
            {
                int classChoice = GetClassChoice();
                if (classChoice == 0)
                {
                    part4 passanger_info = new part4();
                    passanger_info.Part4_Main();
                    break;
                }

                DisplayAvailableSeats(classChoice);

                int seatCount = GetSeatCount();
                if (seatCount == 0)
                {
                    Console.WriteLine("Booking cancelled.");
                    continue;
                }

                List<int> selectedClassSeats = GetClassSeats(classChoice);
                if (selectedClassSeats == null)
                {
                    Console.WriteLine("Unexpected error occurred. Please try again.");
                    continue;
                }

                if (!BookSeats(selectedClassSeats, seatCount))
                {
                    Console.WriteLine("Sorry, not enough seats are available in this class.");
                }

            }
        }

        public static List<int> firstClassSeats = new List<int>();
        public static List<int> secondClassSeats = new List<int>();
        public static List<int> thirdClassSeats = new List<int>();
        private const int TOTAL_SEATS_PER_CLASS = 50;

        private static int GetClassChoice()
        {
            while (true)
            {
                Console.WriteLine("What class do you want to book?");
                Console.WriteLine("\n Enter 1 for First Class \r\n Enter 2 for Second Class \r\n Enter 3 for Third Class \r\n Enter 0 to exit");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= 3)
                {
                    return choice;
                }
                Console.WriteLine("Invalid input. Please enter 0, 1, 2, or 3.");
            }
        }



        private static int GetSeatCount()
        {
            while (true)
            {
                Console.WriteLine("How many seats would you like to book? (Enter 0 to Conform the booking):");
                if (int.TryParse(Console.ReadLine(), out int count) && count >= 0)
                {
                    return count;
                }
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        private static List<int> GetClassSeats(int classChoice) => classChoice switch
        
       {
            1 => firstClassSeats,
            2 => secondClassSeats,
            3 => thirdClassSeats,
            _ => null,
        };

        private static bool BookSeats(List<int> classSeats, int seatCount)
        {
            if (seatCount > (TOTAL_SEATS_PER_CLASS - classSeats.Count))
            {
                return false;
            }

            List<int> seatsToBook = new List<int>();
            for (int i = 1; i <= TOTAL_SEATS_PER_CLASS; i++)
            {
                if (!classSeats.Contains(i))
                {
                    seatsToBook.Add(i);
                    if (seatsToBook.Count == seatCount)
                    {
                        break;
                    }
                }
            }
            classSeats.AddRange(seatsToBook);
            Console.WriteLine("Booking successful! Your booked seat numbers are: " + string.Join(", ", seatsToBook));
            return true;
        }

        private static void DisplayAvailableSeats(int classChoice)
        {
            int availableSeats = 0;
            switch (classChoice)
            {
                case 1:
                    availableSeats = TOTAL_SEATS_PER_CLASS - firstClassSeats.Count;
                    Console.WriteLine("\nAvailable seats in First Class: " + availableSeats);
                    break;
                case 2:
                    availableSeats = TOTAL_SEATS_PER_CLASS - secondClassSeats.Count;
                    Console.WriteLine("\nAvailable seats in Second Class: " + availableSeats);
                    break;
                case 3:
                    availableSeats = TOTAL_SEATS_PER_CLASS - thirdClassSeats.Count;
                    Console.WriteLine("\nAvailable seats in Third Class: " + availableSeats);
                    break;
            }
        }

        /* private static void DisplaySummaryAndExit()
         {
             Console.WriteLine("\nThank you for using the Ticket Booking System. Goodbye!");
             Console.WriteLine("Here is a summary of all booked seats:");
             Console.WriteLine("First Class: " + string.Join(", ", firstClassSeats));
             Console.WriteLine("Second Class: " + string.Join(", ", secondClassSeats));
             Console.WriteLine("Third Class: " + string.Join(", ", thirdClassSeats));
             Environment.Exit(0);
         }
        */

        public void ticketPrice()
        {

            int fisrtclz_price = distance * 5;
            int secondclz_price = distance * 4;
            int thirdclz_price = distance * 2;

            totalfisrtclz_price = fisrtclz_price * firstClassSeats.Count;
            totalsecondclz_price = secondclz_price * secondClassSeats.Count;
            totalthirdclz_price = thirdclz_price * thirdClassSeats.Count;

            totalticketprice = totalthirdclz_price + totalsecondclz_price + totalfisrtclz_price;
            Console.WriteLine($"{totalticketprice}");
        }

        public int totalfisrtclz_price;
        public int totalsecondclz_price;
        public int totalthirdclz_price;
        public int totalticketprice;





    }



}

