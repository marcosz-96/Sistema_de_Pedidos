using System;
using Controllers;

namespace SistemaDePedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            OrderController oController = new OrderController();
            bool salida = false;
            do
            {
                int input = 0;
                Console.WriteLine("Ingrese una opcion");
                Console.WriteLine("Opcion 1: Cargar pedido");
                Console.WriteLine("Opcion 2: Mostrar pedido");
                Console.WriteLine("Opcion 3: Salir...");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        oController.CreateOrder();
                        break;
                    case 2:
                        oController.ShowOrder();
                        break;
                    case 3:
                        Console.WriteLine("Ha Salido del programa.");
                        salida = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Ingrese una opción del menú.");
                        break;
                }
            } while (!salida);
        }
    }
}
