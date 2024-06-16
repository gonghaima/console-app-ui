using System.Text;
using SimpleHashing.Net;

namespace ui;

class Program
{
    static void Main(string[] args)
    {
        // Example stored password hashes for the provided users
        var users = new[]
        {
            new { LoginID = "12345678", Name = "Matthew Bolger", PasswordHash = "Rfc2898DeriveBytes$50000$MrW2CQoJvjPMlynGLkGFrg==$x8iV0TiDbEXndl0Fg8V3Rw91j5f5nztWK1zu7eQa0EE=" },
            new { LoginID = "38074569", Name = "Rodney Cocker", PasswordHash = "Rfc2898DeriveBytes$50000$ABCDEF==$/ZlZGYg==" }, // replace with actual hash
            new { LoginID = "17963428", Name = "Shekhar Kalra", PasswordHash = "Rfc2898DeriveBytes$50000$123456==$/ZlZGYg==" } // replace with actual hash
        };

        Console.Write("Enter Login ID: ");
        string loginID = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = ReadPassword();

        // login process ...
        // Find the user by LoginID
        var user = Array.Find(users, u => u.LoginID == loginID);
        if (user == null)
        {
            Console.WriteLine("Invalid LoginID.");
            return;
        }
        // Verify the entered password
        bool loginSucceeded = new SimpleHash().Verify(password, user.PasswordHash);    
        
        if (loginSucceeded) {
            Console.WriteLine("\n\nlogin successful!");
            Console.WriteLine("Login ID entered: " + loginID);
            Console.WriteLine("Password entered: " + password);
            DisplayMenu("--- Mtthew Bolger ---");
        } else {
            Console.WriteLine("\n\nlogin failed!");
        }
    }

    static string ReadPassword()
    {
        StringBuilder password = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        while (true)
        {
            keyInfo = Console.ReadKey(true);

            // Check if Enter key is pressed
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            // Check if Backspace key is pressed
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password.Length--;
                    Console.Write("\b \b"); // Erase the last * character
                }
            }
            else
            {
                password.Append(keyInfo.KeyChar);
                Console.Write("*");
            }
        }

        return password.ToString();
    }

    static void DisplayMenu(String userFullName)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"--- {userFullName} ---");
            Console.WriteLine("[1] Deposit");
            Console.WriteLine("[2] Withdraw");
            Console.WriteLine("[3] Transfer");
            Console.WriteLine("[4] My Statement");
            Console.WriteLine("[5] Logout");
            Console.WriteLine("[6] Exit");
            Console.Write("\n\nEnter an option: ");

            string input = Console.ReadLine();
            int choice;
            bool isValidChoice = int.TryParse(input, out choice);

            if (isValidChoice)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You chose to Deposit.");
                        // Add deposit logic here
                        break;
                    case 2:
                        Console.WriteLine("You chose to Withdraw.");
                        // Add withdraw logic here
                        break;
                    case 3:
                        Console.WriteLine("You chose to Transfer.");
                        // Add transfer logic here
                        break;
                    case 4:
                        Console.WriteLine("You choose to My Statement.");
                        // Add My Statement logic here
                        break;
                    case 5:
                        Console.WriteLine("You choose to Logout.");
                        // Add My Logout logic here
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, 5 or 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine(); // Add an empty line for better readability
        }
    }
}

