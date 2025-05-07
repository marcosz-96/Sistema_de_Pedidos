using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public Client client { get; set; }
        private List<Product> productList = new List<Product>();

        public Order()
        {

        }

        // Calcula el precio total más IVA
        public double CalculateTotalIVA()
        {
            double finalTotal = 0;
            foreach(Product item in productList)
            {
                finalTotal += item.FinalPrice();
            }

            return finalTotal;
        }

        // Calcula el precio total 
        public double CalculateTotal()
        {
            double finalTotal = 0;
            foreach (Product item in productList)
            {
                finalTotal += item.Price;
            }

            return finalTotal;
        }

        // Muestra la lista de productos
        public List<Product> getProductList()
        {
            return this.productList;
        }

        // Modifica la lista de productos
        public void setProductList(List<Product> list)
        {
            this.productList = list;
        }
    }
}
