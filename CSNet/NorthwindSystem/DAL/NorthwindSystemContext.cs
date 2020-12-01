using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using NorthwindSystem.Entities;
#endregion

namespace NorthwindSystem.DAL
{
    //retrict acces to this class so ONLY other classes
    //      within this library has access priviledge
    //security measure

    //connect this class to EntityFramework by inheriting DbContext
    internal class NorthwindSystemContext:DbContext
    {
        //you will need a constructor that passes the connection
        //      string name to EntityFramework via the inherited
        //      class DbContext
        //base refers to :DbContext
        public NorthwindSystemContext() : base("NWDB")
        {
            
        }

        //properties to interact with EntityFramework
        //these properties represent the whole table and all data
        //      of the sql database
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
