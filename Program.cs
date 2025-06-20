// See https://aka.ms/new-console-template for more information
run();

void run()
{
    while (true)
    {

        Console.WriteLine("Select option");
        Console.WriteLine("1. List users");
        Console.WriteLine("2. Create user");
        Console.WriteLine("3. Exit");

        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Listing users...");
        }
        else if (choice == "2")
        {
            Console.WriteLine("Creating new user...");
            CreateUser();
        }
        else if (choice == "3")
        {
            Console.WriteLine("Session ended.");
            return;
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}

void CreateUser()
{
    Console.Write("Name: ");
    string? name = Console.ReadLine();
    Console.Write("Password: ");
    string? password = Console.ReadLine();
    Console.Write("Created {0}, {1}", name, password);
}