using System;

class Program
{
    static void Main()
    {
        string name = "";
        int age = 0;
        int ticketType = 0;
        double ticketPrice = 0;
        double finalPrice = 0;
        string discountCode = "";
        const string validCode = "SALE20";

        // --- Step 1: Ask for name ---
        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
                break;
            else
                Console.WriteLine("Name cannot be empty. Please try again.");
        }

        // --- Step 2: Ask for age ---
        while (true)
        {
            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();

            if (int.TryParse(ageInput, out age) && age > 0)
                break;
            else
                Console.WriteLine("Please enter a valid positive number for age.");
        }

        // --- Step 3: Select Ticket Type ---
        while (true)
        {
            Console.WriteLine("\nSelect Ticket Type:");
            Console.WriteLine("1: Child Ticket (€5) - Under 12 years");
            Console.WriteLine("2: Adult Ticket (€10) - 12 to 64 years");
            Console.WriteLine("3: Senior Ticket (€7) - 65+ years");
            Console.Write("Enter your choice (1-3): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out ticketType) && ticketType >= 1 && ticketType <= 3)
            {
                // Match age and ticket type
                if (ticketType == 1 && age < 12)
                {
                    ticketPrice = 5;
                    break;
                }
                else if (ticketType == 2 && age >= 12 && age <= 64)
                {
                    ticketPrice = 10;
                    break;
                }
                else if (ticketType == 3 && age >= 65)
                {
                    ticketPrice = 7;
                    break;
                }
                else
                {
                    Console.WriteLine("Selected ticket type does not match your age. Try again.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please choose 1, 2, or 3.\n");
            }
        }

        // --- Step 4: Discount code ---
        Console.Write("\nDo you have a discount code? (yes/no): ");
        string hasCode = Console.ReadLine().ToLower();

        if (hasCode == "yes")
        {
            while (true)
            {
                Console.Write("Enter discount code: ");
                discountCode = Console.ReadLine();

                if (discountCode.Equals(validCode, StringComparison.OrdinalIgnoreCase))
                {
                    finalPrice = ticketPrice * 0.8;
                    Console.WriteLine("Discount applied (20% off)!");
                    break;
                }
                else
                {
                    Console.Write("Invalid code. Try again? (yes/no): ");
                    string tryAgain = Console.ReadLine().ToLower();
                    if (tryAgain != "yes")
                    {
                        finalPrice = ticketPrice;
                        break;
                    }
                }
            }
        }
        else
        {
            finalPrice = ticketPrice;
        }

        // --- Step 5: Summary ---
        Console.WriteLine("\n===== PURCHASE SUMMARY =====");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");

        string ticketLabel = ticketType == 1 ? "Child Ticket" :
                             ticketType == 2 ? "Adult Ticket" : "Senior Ticket";

        Console.WriteLine($"Ticket Type: {ticketLabel}");
        Console.WriteLine($"Original Price: €{ticketPrice}");
        Console.WriteLine($"Final Price: €{finalPrice}");
        Console.WriteLine("=============================");
    }
}