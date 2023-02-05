
using MongoDB.Driver;
using Shopping.Api.Models;

namespace Shopping.Api.Data
{
    public  class ProductContext
    {

        public readonly IMongoCollection<Product> Products;
        
        //public static readonly List<Product> Products = new()
        //{
        //        new Product()
        //        {
        //            Name = "IPhone X",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-1.png",
        //            Price = 950.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "Samsung 10",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-2.png",
        //            Price = 840.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "Huawei Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-3.png",
        //            Price = 650.00M,
        //            Category = "White Appliances"
        //        },
        //        new Product()
        //        {
        //            Name = "Xiaomi Mi 9",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-4.png",
        //            Price = 470.00M,
        //            Category = "White Appliances"
        //        },
        //        new Product()
        //        {
        //            Name = "HTC U11+ Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-5.png",
        //            Price = 380.00M,
        //            Category = "Smart Phone"
        //        },
        //        new Product()
        //        {
        //            Name = "LG G7 ThinQ EndofCourse",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-6.png",
        //            Price = 240.00M,
        //            Category = "Home Kitchen"
        //        }
        //    };

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatbaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatbaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatbaseSettings:CollectionName"]);
            SeedData(Products);

        }

        private void SeedData(IMongoCollection<Product> productsCollection)
        {
            bool isProductExists = productsCollection.Find(c => true).Any();
            if (!isProductExists)
            {
                productsCollection.InsertManyAsync(GetPreConfiguredProducts());
            }

        }

        private IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>() {
                new Product()
                {
                Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
                };
        }
    }
}

