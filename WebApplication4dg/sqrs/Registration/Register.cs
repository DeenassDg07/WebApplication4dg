using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication4dg.DB;

namespace WebApplication4dg.sqrs.Registration
{
    public class Register(RegisterDTO user) : AdditionInfoUser, IRequest
    {
        public readonly RegisterDTO user = user;

        public class RegisterHandler(MagazinEptContext db) : IRequestHandler<Register, Unit>
        {
            public async Task<Unit> HandleAsync(Register request, CancellationToken ct = default)
            {
                if (await db.Users.AnyAsync(u => u.Id == request.user.Id))
                    throw new Exception();

                db.Users.Add((User)request.user);
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
