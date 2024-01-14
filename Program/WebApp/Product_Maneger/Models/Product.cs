using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Maneger.Models
{
    [Table("Product")]
    public class Product : BaseModel
    {
        [Column("Price")]
        public int Price { get; set; }
        //[Column("CategoryId")]
        //public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        //public virtual List<Storage> Storages { get; set; }
        public override string ToString()
        {
            //return $"Id;{Id}, Name:{Name}, Description:{Description}, Price:{Price}, CategoryId:[{Category.ToString()}]";
            return $"Id;{Id}, Name:{Name}, Description:{Description}, Price:{Price}, CategoryId:{CategoryId}";
        }
    }
}
