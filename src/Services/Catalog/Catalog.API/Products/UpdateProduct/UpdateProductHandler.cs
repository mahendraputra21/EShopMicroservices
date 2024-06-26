
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

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
                throw new ProductNotFoundException();
            }

            product = command.Adapt<Product>();
            
            session.Update(product);
            
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
