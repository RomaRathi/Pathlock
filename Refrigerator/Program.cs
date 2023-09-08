using PAthlock;


class Program
{
    static void Main()
    {
        var refrigerator = new Refrigerator();

        while (true)
        {
            Console.WriteLine("Refrigerator App");
            Console.WriteLine("1. Insert Product");
            Console.WriteLine("2. Consume Product");
            Console.WriteLine("3. Current Status");
            Console.WriteLine("4. Check Expiry");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        InsertProduct(refrigerator);
                        break;
                    case 2:
                        ConsumeProduct(refrigerator);
                        break;
                    case 3:
                        DisplayCurrentStatus(refrigerator);
                        break;
                    case 4:
                        CheckExpiry(refrigerator);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void InsertProduct(Refrigerator refrigerator)
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.Write("Enter expiration date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime expiryDate))
            {
                refrigerator.InsertProduct(productName, quantity, expiryDate);
                Console.WriteLine("Product inserted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please enter a number.");
        }
    }

    static void ConsumeProduct(Refrigerator refrigerator)
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter quantity consumed: ");
        if (int.TryParse(Console.ReadLine(), out int quantity))
        {
            refrigerator.ConsumeProduct(productName, quantity);
            Console.WriteLine("Product consumed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please enter a number.");
        }
    }

    static void DisplayCurrentStatus(Refrigerator refrigerator)
    {
        var currentStatus = refrigerator.GetCurrentStatus();
        Console.WriteLine("Current Status:");
        foreach (var item in currentStatus)
        {
            Console.WriteLine($"{item.Key}: {item.Value} (Expires on: {item.Key.ExpiryDate:yyyy-MM-dd})");
        }
    }

    static void CheckExpiry(Refrigerator refrigerator)
    {
        var expiredProducts = refrigerator.CheckExpiry();
        foreach (var product in expiredProducts)
        {
            Console.WriteLine($"Remove {product.Name} from the refrigerator. It has expired.");
        }
    }
}
