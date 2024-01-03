using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//static:<- It means Main Method can be called without an object.
//public:<- It is access modifiers which means the compiler can execute this from anywhere.
//void:  <- The void method doesn’t return anything..
//Main():<- It is the configured name of the Main method.
//String <- [] args: For accepting the zero-indexed command line arguments. args is the user-defined name.

namespace Ticket_Office_Assignment
{
    class TicketOffice//class
    {

        public static decimal TaxCalculator(int price)// metod // nyckel-ord
        {

            decimal tax = (decimal)((1 - 1 / 1.06) * price);
            return tax;

        }

        public static int PriceSetter(int age, enum place)// metod // nyckel-ord

        {

            int price = 0;
            if (age <= 11)
            {
                price = (place=="Standing")? 26 : 51;//osäker
            }
            else if (age >= 12 && age <= 64)
            {
                price = (place== "Standing") ? 110 : 170;
            }
            else if (age>=65)
            {
                price = 60;
            
            return price;

        }
        public static int TicketNumberGenerator()// metod // nyckel-ord
        {
            int x = new Random().Next(1, 8001);
            return x;
        }

        public static void Main(string[]args)//main sista nyckel + värden och cw/consol+ parameter värden 
        {
            Console.Write("Enter your age: ");

            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter 'Standing' or 'Seated' for your ticket type: ");

            string? place = Console.ReadLine();

            int price = PriceSetter(age, place);
            Console.WriteLine($"Total Price: {price} sek");

            decimal tax = TaxCalculator(price);
            Console.WriteLine($"Tax: {tax:F2} sek");
            int ticketNumber = TicketNumberGenerator();

            Console.WriteLine($"Ticket Number please!: {ticketNumber}");

        }
      public class enum{
            Seated,Standing
        }
    }
}


