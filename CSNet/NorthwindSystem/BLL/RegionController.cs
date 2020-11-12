using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    //classes in the BLL need to be public IF they are
    //   to be accessed by an outside user (webapp project)
    public class RegionController
    {
        //the interface is a set of methods that can be
        //   called by an outside user
        //these methods must be public
        public Region Region_FindByID(int regionid)
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
                return context.Regions.Find(regionid);
            }
        }

        public List<Region> Region_ListAll()
        {
            using (var context = new NorthwindSystemContext())
            {
                //this extension method will allow you to retrieve
                //  all the records of your DbSet<T>
                return context.Regions.ToList();
            }
        }
    }
}
