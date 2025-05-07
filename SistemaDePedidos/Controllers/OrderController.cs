using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Models;
using SistemaDePedidos.Repository;
using Views;

namespace Controllers
{
    class OrderController
    {
        private ClientController cController;
        private ProductController pController;
        private List<Order> orderList = new List<Order>();

        public OrderController()
        {
            this.cController = new ClientController();
            this.pController = new ProductController();
            this.orderList = Repository<Order>.ObtenerTodos(Path.Combine("Repository", "Data", "ordenes"));
        }

        public void CreateOrder()
        {
            var temp = new Order
            {
                client = cController.LoadClient()
            };
            temp.setProductList(pController.LoadProductList());
            // GUARDA LA LISTA EN MEMORIA
            this.orderList.Add(temp);
            // PARA QUE EL ELEMENTO PERSISTA, LO GUARDA EN EL REPOSITORIO
            Repository<Order>.Agregar(Path.Combine("Repository", "Data", "ordenes"),temp);
            // MUESTRA UN MENSAJE DE GUARDADO
            OrderView.showMsg("Orden creada y guardada.");
        }

        // Método que muestra las órdenes persistidas (guardadas en memoria)
        public void ShowOrder()
        {
            // VERIFICA SI HAY ÓRDENES CARGADAS
            if (orderList == null || orderList.Count == 0)
            {
                OrderView.showMsg("No hay órdenes cargadas");
                return;
            }
            // SI LAS HAY
            OrderView.showMsg("===LAS ÓRDENES SON===");
            foreach (Order o in orderList)
            {
                cController.ShowClient(o.client);
                pController.ShowProductList(o.getProductList());
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                Console.WriteLine($"Total sin IVA: ${o.CalculateTotal()}");
                Console.WriteLine($"Total con IVA: ${o.CalculateTotalIVA()}");
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            }
        }
    }
}
