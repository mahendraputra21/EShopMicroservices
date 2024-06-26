﻿
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommnadHandler
    (IDocumentSession session, ILogger<DeleteProductCommnadHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommnadHandler.Handle called with {@Command}", command);

        session.Delete<Product>(command.Id);
        
        await session.SaveChangesAsync(cancellationToken);
        
        return new DeleteProductResult(true);
    }
}
