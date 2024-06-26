
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommnadValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommnadValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            
        }
    }

    internal class UpdateProductCommnadHandler
        (IDocumentSession session, ILogger<UpdateProductCommnadHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommnadHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if(product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }

            product = command.Adapt<Product>();
            
            session.Update(product);
            
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
