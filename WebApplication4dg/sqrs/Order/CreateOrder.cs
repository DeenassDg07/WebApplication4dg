using MyMediator.Interfaces;

namespace WebApplication4dg.sqrs.Order
{
    public class CreateOrder : IRequest<IEnumerable<OrderDTO>>
    {
        public OrderDTO Order { get; set; }
        public class ListStudentByGroupIndexCommandHandler :
            IRequestHandler<CreateOrder, IEnumerable<OrderDTO>>
        {

            private readonly MagazinEptContext db;
            public ListStudentByGroupIndexCommandHandler(MagazinEptContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<OrderDTO>> HandleAsync(CreateOrder request,
                CancellationToken ct = default)
            {


                return await db.Orders.GroupJoin(db.Users,
                    g => g.Id,
                    s => s.Id, (g, student) => new { Order = g, Users = student })
                    .Where(x => !x.Users.Any())
                    .Select(x => new OrderDTO
                    {
                        Id = x.Order.Id,
                        UserId = x.Order.UserId,
                        ItemsId = x.Order.ItemsId,
                        House = x.Order.House,
                        City = x.Order.City,
                        Street = x.Order.Street,
                        PostalCode = x.Order.PostalCode,
                        PaymentMethod = x.Order.PaymentMethod,

                    }).ToListAsync();
            }

        }
    }
}