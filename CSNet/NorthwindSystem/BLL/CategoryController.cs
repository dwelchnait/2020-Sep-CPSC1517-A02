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
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Category> Category_ListAll()
        {
            using (var context = new NorthwindSystemContext())
            {
                //this extension method will allow you to retrieve
                //  all the records of your DbSet<T>
                return context.Categories.ToList();
            }
        }
    }
}
