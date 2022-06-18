using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class AppUserProfile 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AppUserId { get; set; }
        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
