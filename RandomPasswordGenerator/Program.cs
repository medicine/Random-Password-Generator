using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Random Password Generator\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("How many digits? : ");
        string input = Console.ReadLine();
        int passwordLength;

        // Validate user input
        while (!int.TryParse(input, out passwordLength) || passwordLength <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.Write("How many digits? : ");
            input = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Include special characters? [1] Yes  [2] No : ");
        string specialCharInput = Console.ReadLine();
        bool includeSpecialChars;

        // Validate user input for special characters
        while (!int.TryParse(specialCharInput, out int specialCharChoice) || (specialCharChoice != 1 && specialCharChoice != 2))
        {
            Console.WriteLine("Invalid input. Please enter 1 for Yes or 2 for No.");
            Console.WriteLine("Do you want to include special characters? [1] Yes  [2] No");
            specialCharInput = Console.ReadLine();
        }

        includeSpecialChars = specialCharInput == "1";

        // Generate a random password
        string password = GenerateRandomPassword(passwordLength, includeSpecialChars);

        // Output the password
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Generated Random Password : " + password);
    }

    static string GenerateRandomPassword(int length, bool includeSpecialChars)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string specialChars = "!@#$%^&*_+=-;?";
        StringBuilder sb = new StringBuilder();

        Random random = new Random();

        // Select the character set based on user choice
        string selectedChars = includeSpecialChars ? chars + specialChars : chars;

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(selectedChars.Length);
            sb.Append(selectedChars[index]);
        }

        return sb.ToString();
    }
}