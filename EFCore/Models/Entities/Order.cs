namespace EFCore.Models.Entities
{
    public class Order:BaseEntity
    {
        public string ShippeAddress { get; set; }
        public  int? AppUserID { get; set; }
        //relational properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails{ get; set; }

    }
}
