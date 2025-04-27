using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Models;
using Views;

namespace Controllers
{
    class OrderController
    {
        private ClientController cController;
        private ProductController pController;
        Order temp = new Order();

        public OrderController()
        {
            this.cController = new ClientController();
            this.pController = new ProductController();
        }

        public void CreateOrder()
        {
            temp.client = cController.LoadClient();
            temp.setProductList(pController.LoadProductList());
        }

        public void ShowOrder()
        {
            if(temp is null)
            {
                OrderView.showMsg("No hay ordenes cargadas.");
            }
            else
            {
                cController.ShowClient(temp.client);
                pController.ShowProductList(temp.getProductList());
            }
            
        }
    }
}
