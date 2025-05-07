using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Models;

namespace Controllers
{
    class ProductController
    {
        
        public ProductController()
        {
        }

        public Product LoadProduct()
        {
            Console.WriteLine("_-_-_-_-LOADING PRODUCT-_-_-_-_");
            return ProductView.LoadProduct();
        }

        public List<Product> LoadProductList()
        {
            return ProductView.LoadProductList();
        }
        
        public void ShowProductList(List<Product> productList)
        {
            ProductView.ShowProductList(productList);
        }


    }
}
