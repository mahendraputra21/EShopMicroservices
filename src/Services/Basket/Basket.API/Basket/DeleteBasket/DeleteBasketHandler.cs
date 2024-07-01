
namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

internal class DeleteBasketCommandHandler (IBasketRepository basketRepository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache
        await basketRepository.DeleteBasket(command.UserName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}
