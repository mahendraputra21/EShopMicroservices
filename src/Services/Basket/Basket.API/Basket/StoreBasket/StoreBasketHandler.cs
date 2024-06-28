namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StroreBasketResult>;

public record StroreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

internal class StoreBasketCommnadHandler
    : ICommandHandler<StoreBasketCommand, StroreBasketResult>
{
    public async Task<StroreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;

        //Todo: store basket in database (use Marten upsert - if exists = update, if not isert new record
        //Todo: update cache

        return new StroreBasketResult("swn");
    }
}
