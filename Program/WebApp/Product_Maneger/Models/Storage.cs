namespace Product_Maneger.Models
{
    public class Storage : BaseModel
    {
        public virtual List<Product> Products { get; set; }
        //public int Count { get { return Products.Count; } }
    }
}
