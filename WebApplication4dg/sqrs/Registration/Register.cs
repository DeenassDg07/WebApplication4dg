using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication4dg.DB;

namespace WebApplication4dg.sqrs.Registration
{
    public class Register : AdditionInfoUser, IRequest<Unit>
    {
        public RegisterDTO User { get; set; }

        public class RegisterHandler(MagazinEptContext db) : IRequestHandler<Register, Unit>
        {
            public async Task<Unit> HandleAsync(Register request, CancellationToken ct = default)
            {
                if (await db.Users.AnyAsync(u => u.Id == request.User.Id))
                    throw new Exception();

                db.Users.Add((User)request.User);
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
