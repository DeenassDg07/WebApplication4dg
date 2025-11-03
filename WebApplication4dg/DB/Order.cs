namespace WebApplication4dg.DB
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ItemsId { get; set; }

        public int? House { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public int? PostalCode { get; set; }

        public string? PaymentMethod { get; set; }

        public virtual Item? Items { get; set; }

        public virtual User? User { get; set; }
    }
}
