// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using var db = new UserContext();

while (true)
{

    Console.WriteLine("Select option");
    Console.WriteLine("1. List all users");
    Console.WriteLine("2. Create user");
    Console.WriteLine("3. Delete user");
    Console.WriteLine("4. Find user by ID");
    Console.WriteLine("5. Exit");

    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            PrintUsers();
            break;
        case "2":
            CreateUser();
            break;
        case "3":
            DeleteUser();
            break;
        case "4":
            FindUserById();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

void PrintUsers()
{
    var users = db.Users.ToList();
    foreach (User user in users)
    {
        Console.WriteLine("{0}  {1}", user.Id, user.Name);
    }

}

void CreateUser()
{
    Console.Write("Name: ");
    string? name = Console.ReadLine();
    Console.Write("Password: ");
    string? password = Console.ReadLine();
    var user = new User { Name = name, Password = password };
    var valResults = new List<ValidationResult>();

    bool isValid = Validator.TryValidateObject(
        user, new ValidationContext(user),
        valResults,
        validateAllProperties: true
    );

    if (!isValid)
    {
        Console.WriteLine("Invalid Record");
        return;
    }

    db.Add(user);
    db.SaveChangesAsync();
    Console.WriteLine("Created user {0}", name);
}

void DeleteUser()
{
    Console.Write("ID to delete: ");
    int id = int.Parse(Console.ReadLine());
    User userToDelete = db.Users.Find(id);
    Console.WriteLine("Deleting {0}, {1}. Enter to proceed", userToDelete.Id, userToDelete.Name);
    Console.ReadLine();
    db.Remove(userToDelete);
    db.SaveChangesAsync();

}

void FindUserById()
{
    Console.Write("ID to find: ");
    int id = int.Parse(Console.ReadLine());
    User user = db.Users.Find(id);
    Console.WriteLine("{0}, {1}, {2}", user.Id, user.Name, user.Password);

}