using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;
#endregion

namespace NorthwindSystem.BLL
{
    public class ProductController
    {
        public List<Product> Product_GetByPartialProductName(string productname)
        {
            using(var context = new NorthwindSystemContext())
            {
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByPartialProductName @PartialName",
                    new SqlParameter("PartialName", productname));
                return results.ToList();
            }
        }
        public Product Product_FindByID(int productid)
        {
            //create a using area that will ensure the sql
            //    connection will be closed when the
            //    query to sql is complete
            using (var context = new NorthwindSystemContext())
            {
                //there are extension methods within Entityframe
                //  that allow you to do some very common queries
                //this extension method will allow you to search
                //  your DbSet<T> by primary key value
                return context.Products.Find(productid);
            }
        }
    }
}
