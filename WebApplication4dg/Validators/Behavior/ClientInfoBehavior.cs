
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication4dg.DB;

namespace WebApplication4dg.Validators.Behavior
{
    public class ClientInfoBehavior<TRequest, TResponse>(IHttpContextAccessor httpContextAccessor) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string ipAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "";
            string userAgent = httpContextAccessor.HttpContext?.Request.Headers.UserAgent.ToString() ?? "";
            UserAdditionalInfo info = new(ipAddress, userAgent);

            var prop = typeof(TRequest).GetProperty("UserAdditionalInfo"); //TRequest параметр
            if (prop != null)
            {
                prop.SetValue(request, info);
            }
            return await next();
        }
    }
}
