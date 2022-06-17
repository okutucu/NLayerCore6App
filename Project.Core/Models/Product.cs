using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal  Price { get; set; }


        public int? CategoryId { get; set; }



        //Relational Property
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }


    }
}
