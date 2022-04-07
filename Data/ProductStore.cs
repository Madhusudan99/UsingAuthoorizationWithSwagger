using UsingAuthoorizationWithSwagger.Models;




namespace UsingAuthoorizationWithSwagger.Data
{
    public class ProductStore
    {

        private static Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Rubber"},
            new Product { Id = 2, Name = "Pencil"},
            new Product { Id = 3, Name = "Sharpner"},
            new Product { Id = 4, Name = "Pen"},
        };

        public static IEnumerable<Product>  GetProduct()
        {
            return products;
        }

        public  static Product GetProductById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
