using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public static class ClientView
    {
        public static void ShowClient(Client client)
        {
            Console.WriteLine("#############################");
            Console.WriteLine($"Name: {client.Name}");
            Console.WriteLine($"LastName: {client.LastName}");
            Console.WriteLine($"ID: {client.ID}");
            Console.WriteLine($"Adress: {client.Adress}");
            Console.WriteLine($"Email: {client.Email}");
            Console.WriteLine("#############################");
        }

        public static Client LoadClient()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Client name?");
            string name = Console.ReadLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Client last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Client ID?");
            string id = Console.ReadLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Client adress?");
            string adress = Console.ReadLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Client email?");
            string email = Console.ReadLine();
            Console.WriteLine("-----------------------");

            Client temp = new Client(name, lastName, id, adress, email);

            return temp;
        }
    }
}
