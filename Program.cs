using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************");
            Console.WriteLine("Welcome to my Library");
            Console.WriteLine("***************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Issue Book");
            Console.WriteLine("3. Deposit Book");
            Console.WriteLine("4. Print All issued Books");

            var choice = Console.ReadLine();
            switch (choice)
            {
            case "0":
                    return;

            case "1":
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    var account = Library.CreateAccount(emailAddress);
                    
                    break;

            case "2":
                    break;

            case "3":
                    break;

            case "4":
                    break;

            }
        }

    }
}
