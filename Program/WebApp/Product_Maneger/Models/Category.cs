using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Maneger.Models
{
    [Table("Category")]
    public class Category : BaseModel
    {
        //[ForeignKey("UserId")]
        public virtual ICollection<Product> Products { get; set; }
        public override string ToString()
        {
            return $"Id;{Id}, Name:{Name}, Description:{Description}";
        }
    }
}
