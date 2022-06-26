using Project.Core.Enums;

namespace Project.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DataStatus Status { get; set; }


    }
}
