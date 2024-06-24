using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommnad<Unit>
    {

    }
    public interface ICommnad<out TResponse> : IRequest<TResponse>
    {

    }
}
