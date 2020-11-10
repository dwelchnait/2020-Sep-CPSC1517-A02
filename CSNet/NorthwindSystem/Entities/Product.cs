﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Entities
{
    //anontations are use to assist EntityFramework in the mapping
    //   of your class to the sql table

    //anontations for properties are place BEFORE the property!!!!

    [Table("Products")]
    public class Product
    {
        //private data member
        private string _QuantityPerUnit;

        //if you use the same name as the sql attribute
        //      for your property name, order of properties
        //      does not matter
        //if your names are different then order is required

        //[Key] single attribute primary, identity key
        //[Key, Column(Order=n)] compound pkey, required in front
        //      of each property, n represents the physical
        //      order as found on the sql table
        //[Key, DatabaseGenerated(DatabaseGenerateOption.xxxx)]
        //  .xxx -> Identity: pkey on sql is an Identity key (default)
        //          None: pkey is NOT identity, user entered

        //[DatabaseGenerated(DatabaseGenerateOption.Compute)] 
        //          Compute: the attribute is a sql computed attribute
        //                     which means that NO actual data is stored
        //                      in the sql table, it is generated by the
        //                      expression in the sql table
        // Example: sql table has an attribute called Total which is
        //              calculated by two other attributes on the table
        //              call Quantity and Price
        //[DatabaseGenerated(DatabaseGenerateOption.Compute)] 
        //public decimal Total {get;set}

        //[Key, DatabaseGenerated(DatabaseGenerateOption.Identity)]
        [Key]
        public int ProductID { get; set; }

        //validation annotations

        [Required(ErrorMessage ="Product name is required")]
        [StringLength(40, ErrorMessage ="Product name is limited to 40 characters")]
        public string ProductName { get; set; }

        //this foreign key is nullable on the sql table (don't for the ?)
        //you may be tempted to use the [ForeignKey] annotation
        //      BUT DON'T
        //the [ForeignKey] annotation is ONLY required if the
        //  sql table does not use the same name for it's
        //  foreign key as it's parent primary key
        //OR
        //if yor property name does not match the sql attribute name
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        //nullable string
        //you can still fully implement a nullable string property

        [StringLength(20, ErrorMessage = "Quantity per unit is limited to 20 characters")]
        public string QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set { _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value; }
        }

        //money requires the use of decimal, if it complains use double
        //UnitPrice is nullable
        //nullable numerics DO NOT need to be fully implemented
        [Range(0.00,double.MaxValue,ErrorMessage ="Unit price is 0.00 or more.")]
        public decimal? UnitPrice { get; set; }

        [Range(0, 32767, ErrorMessage = "Units in stock is 0 or more.")]
        public Int16? UnitsInStock { get; set; }

        [Range(0, 32767, ErrorMessage = "Units on order is 0 or more.")]
        public Int16? UnitsOnOrder { get; set; }

        [Range(0, 32767, ErrorMessage = "Reorder level is 0 or more.")]
        public Int16? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        //Read-only property that are setup in your class to make
        //      programming easier
        //example : an Address
        //FullAddress = Street + " " + City + " " Province + " " + PostalCode;
        //this types of properties do not contain data for the sql table
        //a NotMapped property in your entity class is a property that has NO
        //  coresponding sql table attribute

        [NotMapped]
        public string NameAndID
        {
            get { return ProductName + " (" + ProductID + ")"; }
        }
    }
}