using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Models.Products
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category BaseCategory { get; set; }
        public List<Category> SubCategories { get; set; }

        /*
         "products": [
        {
            "id": 12,
            "creationDate": "2021-01-01T00:00:00.000+00:00",
            "name": "Gaucho",
            "description": "Ye8leb el jou3",
            "price": 0.1,
            "picture": "",
            "taxes": [],
            "discount": null,
            "category": null,
            "advertisementProduct": []
        }
    ],
    "category": null,
    "subCategories": null*/
    }
}
