using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL.Entities;

namespace TestWeb.DAL.Entities
{
    public class Product : IEntity
    {     

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Id
        {
            get; set;
        }
    }
} 