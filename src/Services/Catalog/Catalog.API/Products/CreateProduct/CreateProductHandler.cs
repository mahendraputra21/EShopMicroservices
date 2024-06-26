using FluentValidation;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image File is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is required");
    }
}

internal class CreateProductCommandHandler
    (IDocumentSession session, IValidator<CreateProductCommand> validator)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // validate the request first by validator
        var result = await validator.ValidateAsync(command, cancellationToken);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        if (errors.Any()) 
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        // create Product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Todo : save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        // return CreateProductResult result
        return new CreateProductResult(product.Id);
    }
}
