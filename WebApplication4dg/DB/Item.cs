namespace WebApplication4dg.DB
{
    public class Item
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? Count { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual Product? Product { get; set; }
    }
}
