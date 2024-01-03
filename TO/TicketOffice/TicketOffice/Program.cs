using System;

namespace Ticket_Office_Assignment
{
    class TicketOffice_Assignment
    {
        

        public static int TicketNumberGenerator()
        {
            int x = new Random().Next(1, 8001);
            return x;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Enter 'Standing' or 'Seated' for your ticket type: ");
            string? place = Console.ReadLine();
            Ticket ticket;
            Enum.TryParse(place, out ticket);

            Tickets userTicket = new Tickets(age, ticket);

            int price = userTicket.Price();//ändrad
            Console.WriteLine($"Total Price: {price} sek");

            decimal Tax = userTicket .Tax();
            Console.WriteLine($"Tax: {Tax:F2} sek");

            int ticketNumber = TicketNumberGenerator();
            Console.WriteLine($"Ticket Number please!: {ticketNumber}");

            Tickets ticketOb = new Tickets(24, Ticket.Standing);//nytt obj ticketOb
            
            var tax = ticketOb.Tax();
            ticketOb.Place = Ticket.Seated;
            int priceVal = ticketOb.Price();//.price i slutet
            TicketSalesManager ticketSalesManager = new TicketSalesManager();//parantes sista
            ticketSalesManager.Addticket(ticketOb);
            var x= ticketSalesManager.AmountOfTickets();
            Console.WriteLine($"totala antalet biljetter är{x}");
            var z = ticketSalesManager.SalesTotal();
            Console.WriteLine($"totala beloppet är{z}");

            ticketSalesManager.RemoveTicket(ticketOb);//ticketOb

            
        }
    }
    public enum Ticket
    {
        Seated, Standing
    }

    public class Tickets
    {
        public decimal Tax()
        {
            int price = Price();
            decimal tax = (decimal)((1 - 1 / 1.06) * price);
            return tax;
        }
        public int Age { get; set; }
        public Ticket Place { get; set; }
        public int Number { get; set; }

        public Tickets(int age, Ticket place)
        {
            this.Age = age;
            this.Place = place;
            this. Number = TicketOffice_Assignment.TicketNumberGenerator();
        }
        public int Price()
        {
            int price = 0;
            if (Age <= 11)//föregående age till Age
            {
                price = Place == Ticket.Standing ? 26 : 51;// ändrar place till Place.
            }
            else if (Age >= 12 && Age <= 64)// Lika dant ifrån age till Age
            {
                price = Place == Ticket.Standing ? 110 : 170;
            }
            else if (Age >= 65)
            {
                price = 60;
            }
            return price;
        }       
    }
        public class TicketSalesManager
    {
        private List<Tickets> ticketList = new List<Tickets>();
        public Tickets Addticket(Tickets ToAdd ) //skjuter in i listan(Tikets)
        { //ToAdd (namn)
            ticketList.Add(ToAdd);//toAdd
            return ToAdd;
        }
        public bool RemoveTicket(Tickets ticket)//return bool ist för void
        {
            try
            {
                ticketList.RemoveAll(v => v.Number == ticket.Number);//copy pasta i trycatch 
                return true;//throw new exceptions ();
            }
            catch { return false; }
        }
        public decimal SalesTotal()
        {
            int totalPrice = 0;
            
            foreach (Tickets ticket in ticketList)
            {
               totalPrice += ticket.Price();//+=       
            }
            return (decimal) totalPrice; //decimal ()
        }
        public int AmountOfTickets()
        {
            return ticketList.Count;
        }
    }
}
