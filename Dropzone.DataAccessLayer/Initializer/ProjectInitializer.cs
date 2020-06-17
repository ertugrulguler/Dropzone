using Dropzene.Model.Models;
using Dropzone.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropzone.DataAccessLayer.Initializer
{
    public class ProjectInitializer : CreateDatabaseIfNotExists<ProjectContext>
    {

        protected override void Seed(ProjectContext context)
        {
            Product product = new Product()
            {
                ProductName = "İphone 7 Plus",
                Price = 8500,
                Stock = 200,
                ImagePath = @"‪C:\Users\ertglr\Desktop\iphone 7plus.jpg"
            };

            context.Products.Add(product);
            context.SaveChanges();
            base.Seed(context);
        }

    }
}
