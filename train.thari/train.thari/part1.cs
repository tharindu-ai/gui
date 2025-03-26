using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Train
{
    public class part_1
    {
        public int start_number;
        public int end_number;
        public int date;
        public int month;
        private int selectedDate;
        private int Mainchoice;
        protected int distance; // Changed to protected for inheritance










        public void Main_menu()
        {
            Console.WriteLine("_____Hello welcome to SLRD_____");
            Console.WriteLine();
            Console.WriteLine("1.Train shedule");
            Console.WriteLine("2.Ticket Reservation");
            Console.WriteLine("3.Seat Booking");
            Console.WriteLine("4.Check the special train availability");
            Console.WriteLine("5.Exit");
            Console.WriteLine();

            Console.WriteLine(" Enter your choice: ");

            Mainchoice = Convert.ToInt32(Console.ReadLine());

            switch (Mainchoice)
            {
                case 1:
                    show_shedule();

                    break;

                case 2:
                    {
                        Console.WriteLine("____Ticket Reservation____");
                        get_journey();
                    }

                    break;

                case 3:
                    {
                        Console.WriteLine("____Seat booking____");
                        get_journey();
                    }
                    break;

                case 4:
                    special_tarin();
                    break;

                case 5:
                    ;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        Main_menu();
                    }

                    break;



            }
        }

        public void show_shedule()
        {
            Console.WriteLine("_____Weekly Train schedule_____");

            //normal time schedule (weekly)

            Console.WriteLine();
            Console.WriteLine("1.Ticket Reservation");
            Console.WriteLine("2.Seat Booking");
            Console.WriteLine("3.Check the special train availability");
            Console.WriteLine("4.Back to Main menu");
            Console.WriteLine("5.Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());

            switch (choice1)
            {
                case 1:
                    get_journey();
                    break;

                case 2:
                    get_journey();
                    break;

                case 3:
                    special_tarin();
                    break;
                case 4:
                    Main_menu();
                    break;
                case 5:
                    ;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        show_shedule();
                    }

                    break;


            }


        }
        public void special_tarin()
        {
            Console.WriteLine("No special trains in this week!");

            Console.WriteLine();
            Console.WriteLine("1.Back to Main menu");
            Console.WriteLine("2.Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());

            switch (choice2)
            {
                case 1:
                    Main_menu();
                    break;
                case 2:
                    ;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        special_tarin();
                    }

                    break;


            }

        }



        public void get_journey()
        {

            Console.WriteLine();
            Console.WriteLine("Chooes your journey");
            Console.WriteLine();

            Console.WriteLine("1.Banbaranda\r\n2.Beliatta\r\n3.Kekanadura\r\n4.Matara\r\n5.Nakulugamuwa\r\n6.Piladuwa\r" +
                "\n7.Wawrukannala\r\n8.Weherahena");

            Console.WriteLine();
            Console.WriteLine("Enter the number starting station:");
            start_number = Convert.ToInt32(Console.ReadLine());//get the starting station of the journey 

            Console.WriteLine();
            Console.WriteLine("Enter the number Ending station:");
            end_number = Convert.ToInt32(Console.ReadLine());//get the endinging station of the journey



            if (start_number == end_number)
            {
                Console.WriteLine("Invalid destination..! Please re-enter your stations");
                get_journey();
            }
            check_correction();
 
        }



        public void check_correction()
        {

            int[] train_1 = { 1, 2, 3, 4, 7, 8 };//train_1 express train 
            int[] train_2 = { 1, 2, 3, 4, 5, 6, 7, 8 };//train_2 slow train


            bool istrain1Available = train_1.Contains(start_number) && train_1.Contains(end_number);
            bool istrain2Available = train_2.Contains(start_number) && train_2.Contains(end_number);
            if (istrain1Available || istrain2Available)
            {
                get_date();
            }

            else
            {
                Console.WriteLine("Invalid station...! Try again....");
                get_journey();

            }

        }

        // get the date
        public void get_date()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("__ Select Your Journey Date __");
            Console.WriteLine();

            // Display today and the next 3 days
            for (int i = 0; i < 3; i++)
            {
                DateTime nextDay = today.AddDays(i);
                string dayOfWeek = nextDay.DayOfWeek.ToString();
                Console.WriteLine($"Day {i + 1}: {nextDay.ToShortDateString()} ({dayOfWeek})");
            }

            Console.WriteLine();
            Console.WriteLine("Select a date (1 for today, 2 or 3):");

            bool isValid = int.TryParse(Console.ReadLine(), out selectedDate);  // Use global `selectedDate`

            if (isValid && (selectedDate >= 1 && selectedDate <= 3))
            {
                Console.WriteLine($"You selected Day {selectedDate}.");
                check_availbleTrain();  // Ensure this executes
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");
                get_date();  // Retry on invalid input
            }
        }



        public void check_availbleTrain()
        {
            DateTime today = DateTime.Now;
            DateTime selectedDay = today.AddDays(selectedDate - 1);  // Use class-level `selectedDate`
            string dayName = selectedDay.DayOfWeek.ToString();

            Console.WriteLine($"Day {selectedDate}: {selectedDay.ToShortDateString()} ({dayName})");

            // Check if it's a weekend
            bool isWeekend = (selectedDay.DayOfWeek == DayOfWeek.Saturday || selectedDay.DayOfWeek == DayOfWeek.Sunday);

            // Available train lists
            int[] train_1 = { 1, 2, 3, 4, 7, 8 };  // Express train
            int[] train_2 = { 1, 2, 3, 4, 5, 6, 7, 8 };  // Slow train

            if (isWeekend)
            {
                Console.WriteLine("No trains available on weekends!");
                Environment.Exit(0);

            }
            else
            {

                if (start_number == 0 || end_number == 0)
                {
                    Console.WriteLine("Error: Start or End station not selected!");
                    return;
                }

                // Check train availability
                bool isTrain1Available = train_1.Contains(start_number) && train_1.Contains(end_number);
                bool isTrain2Available = train_2.Contains(start_number) && train_2.Contains(end_number);

                if (isTrain1Available || isTrain2Available)
                {
                    Console.WriteLine("\nAvailable Trains:");
                    if (isTrain1Available)
                    {
                        Console.WriteLine("- 1. Train 1 (Express: Beliatta to Maradana)");
                    }
                    if (isTrain2Available)
                    {
                        Console.WriteLine("- 2. Train 2 (Slow: Beliatta to Matara)");
                    }
                    select_train();
                }
                else
                {
                    Console.WriteLine("No available trains for the selected route.");
                }
            }

        }




        // select the train
        public void select_train()
        {

            Console.WriteLine();
            Console.WriteLine("Choose your train number:");
            int train_number = Convert.ToInt32(Console.ReadLine());


            switch (train_number)
            {
                case 1:
                    {
                        Console.WriteLine();
                        Console.WriteLine("___1. Train 1 (Express-Beliatta to Maradana)___");
                        Console.WriteLine();
                        Console.WriteLine("starting at Beliatta: 4.15 am-----arrivale to Maradana: 8.30 am");
                        Console.WriteLine("Delay time:0 ");
                        Console.WriteLine();



                    }
                    break;

                case 2:
                    {
                        Console.WriteLine();
                        Console.WriteLine("___2. Train 2 (Slow-Beliatta to Matara)___");
                        Console.WriteLine();
                        Console.WriteLine("starting at Beliatta: 7.20 am-----arrivale to Matara: 8.00 am ");
                        Console.WriteLine("Delay time:10min");
                        Console.WriteLine();


                    }
                    break;


            }
            get_distance();

        }

        //get  distance between the stations
        public void get_distance()
        {

            int[] Ds = new int[8];
            int[] De = new int[8];



            Ds = [8, 0, 10, 16, 3, 14, 5, 12];// Distance to all stations at reference to Beliatta
            De = [8, 0, 10, 16, 3, 14, 5, 12];// Distance to all stations at reference to Beliatta


            if (start_number == 2 && end_number != 2)
            {
                distance = Ds[start_number - 1] + Ds[end_number - 1];
                Console.WriteLine("Your travel distance : " + distance + "km.");
            }
            else if (start_number != 2 && end_number != start_number)
            {
                distance = Ds[end_number - 1] - Ds[start_number - 1];
                if (distance > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your travel distance : " + distance + "km.");
                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Your travel distance : " + distance * (-1) + "km.");
                }

            }
            arrival_time();
        }



        //get the arrival time to choosen stations
        public void arrival_time()
        {


            string[] A1_time = new string[9];
            string[] S1_time = new string[9];
            A1_time = ["0.0", "7.45", "7.20", "7.55", "8.10", "7.30", "8.05", "7.35", "8.00"];
            S1_time = ["0.0", "7.45", "7.20", "7.55", "8.10", "7.30", "8.05", "7.35", "8.00"];

            string s1 = S1_time[start_number];
            string a1 = A1_time[end_number];
            string[] station_name = new string[9];
            station_name = ["0", "Banbaranda", "Beliatta", "Kekanadura", "Matara", "Nakulugamuwa", "Piladuwa", "Wawrukannala", "Weherahena"];

            Console.WriteLine($"starting at {station_name[start_number]}: {s1} am-----arrivale to {station_name[end_number]}: {a1}am ");

            // Move to Part2_Main() after arrival time

            switch (Mainchoice)
            {
                case 3:
                    {
                        Part2 seatReservation = new Part2();
                        seatReservation.Part2_Main();
                    }
                    break;

                case 2:
                    {
                        part3 ticketReservation = new part3();
                        ticketReservation.Part3_Main();
                    }
                    break;
                default:
                    Console.WriteLine("No further action defined for this option.");
                    break;
            }


        }



    }


}