using MediatR;

namespace WandioMobilePhones.Core.Abstractions
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
