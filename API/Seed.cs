using API.Data;
using API.Models;

namespace API
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;
        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedApplicationDbContext()
        {
            if (!_context.Products.Any())
            {
                var products = new List<Product>()
                {
                   new Product()
                    {
                        ProductName = "Tomato",
                        ProductDescription = "Fresh, home-grown tomatoes."
                    },
                    new Product()
                    {
                        ProductName = "Onion",
                        ProductDescription = "Pungent and flavorful onions."
                    },
                    new Product()
                    {
                        ProductName = "Carrot",
                        ProductDescription = "Sweet and crunchy carrots."
                    },
                    new Product()
                    {
                        ProductName = "Potato",
                        ProductDescription = "Versatile and starchy potatoes."
                    },
                    new Product()
                    {
                        ProductName = "Cucumber",
                        ProductDescription = "Cool and refreshing cucumbers."
                    },
                    new Product()
                    {
                        ProductName = "Strawberry",
                        ProductDescription = "Juicy and sweet strawberries."
                    },
                    new Product()
                    {
                        ProductName = "Basil",
                        ProductDescription = "Aromatic basil leaves."
                    },
                    new Product()
                    {
                        ProductName = "Zucchini",
                        ProductDescription = "Versatile and fresh zucchinis."
                    },
                    new Product()
                    {
                        ProductName = "Sqash",
                        ProductDescription = "Nutritious and delicious squash."
                    },
                    new Product()
                    {
                        ProductName = "Red Apple",
                        ProductDescription = "Crisp and sweet apples."
                    },
                    new Product()
                    {
                        ProductName = "Green Apple",
                        ProductDescription = "Crisp and tart apples."
                    },
                    new Product()
                    {
                        ProductName = "Orange",
                        ProductDescription = "Juicy and sweet oranges."
                    },
                    new Product()
                    {
                        ProductName = "Blueberry",
                        ProductDescription = "Sweet and tangy blueberries from the forest."
                    },
                    new Product()
                    {
                        ProductName = "Raspberry",
                        ProductDescription = "Juicy and tart raspberries."
                    },
                    new Product()
                    {
                        ProductName = "Blackberry",
                        ProductDescription = "Sweet and juicy wild blackberries."
                    },
                    new Product()
                    {
                        ProductName = "Chantarell",
                        ProductDescription = "Delicious and meaty chanterelle mushrooms from the forest."
                    },
                    new Product()
                    {
                        ProductName = "Porcini (Karl Johan)",
                        ProductDescription = "Nutty and flavorful porcini mushrooms."
                    },
                    new Product()
                    {
                        ProductName = "Deer Meet",
                        ProductDescription = "Lean and tender deer meat."
                    },
                    new Product()
                    {
                        ProductName = "Moose Meet",
                        ProductDescription = "Lean and tender moose meat."
                    },
                    new Product()
                    {
                        ProductName = "Wild boar Meet",
                        ProductDescription = "Lean and tender wild boar meat."
                    }                  
                };
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }
    }
}