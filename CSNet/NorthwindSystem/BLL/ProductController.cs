using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;
using System.ComponentModel; //required for ODS exposure
#endregion

namespace NorthwindSystem.BLL
{
    //expose this class to the ObjectDataSource wizard
    //this will allow for EASY selection of values for
    //    the wizard, and the wizard will generate my code
    [DataObject]
    public class ProductController
    {
        //expose the methods you wish the wizard to known about
        [DataObjectMethod(DataObjectMethodType.Select,false)]
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

        public int Product_Add(Product item)
        {
            using(var context = new NorthwindSystemContext())
            {
                //staging
                //place your entity instance into your DbSet for processing
                //   by EntityFramework
                //This data is in memory NOT yet on your sql database
                //This means that the primary key has NOT YET been created
                //The primary key is created WHEN the data is sent to the database
                context.Products.Add(item);

                //commit your transaction to the database
                //if the following command aborts, then your data record is NOT
                //    on the database, the transaction is AUTOMATICALLY Rolledback
                //After the success of the following command the instance will be
                //  loaded with your new primary key identity value
                //IF you have entity VALIDATION ANNOTATION then when the following
                //   command is executed, the entity validation annotation will be 
                //   EXECUTED
                context.SaveChanges();

                return item.ProductID;
            }
        }

        public int Product_Update(Product item)
        {
            using(var context = new NorthwindSystemContext())
            {
                //stage of update
                //the entire entity on the database will be updated, all fields
                //      except the primary key
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                //commit of update
                //changes the database
                //the return value from an update commit is the rowsaffected
                int rowsaffected = context.SaveChanges();

                //return the rowsaffected
                return rowsaffected;
            }
        }

        public int Product_Discontinue(int productid)
        {
            using (var context = new NorthwindSystemContext())
            {
                //logic to discontinue the produce
                int rowsaffected = 0;
                //find the current record by primary key
                var exists = context.Products.Find(productid);

                //verify that you actually have an instance (object)
                //   of the Product entitiy
                if (exists == null)
                {
                    throw new Exception("Product no longer on file. Refresh your search.");
                }
                else
                {
                    //scenario LOGICAL DELETE

                    //DO NOT rely on the user to actually set the attribute
                    //    indicating "deletion" for you
                    //INSTEAD do it by the program
                    exists.Discontinued = true;

                    //stage of update
                    //a specific field on an instance can be updated WITHOUT needing
                    //    to update the entire entity
                    context.Entry(exists).Property("Discontinued").IsModified = true;


                    //SCENARIO PHYSICAL DELETE

                    //stage of delete
                    //the record is physically removed from the database
                    //context.Products.Remove(exists);

                    //commit of update
                    //changes the database
                    //the return value from an update commit is the rowsaffected
                    rowsaffected = context.SaveChanges();

                    //return the rowsaffected
                    return rowsaffected;
                }
            }
        }
    }
}
