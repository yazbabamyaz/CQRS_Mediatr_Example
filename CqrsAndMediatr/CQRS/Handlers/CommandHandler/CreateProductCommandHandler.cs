using CqrsAndMediatr.CQRS.Commands.Request;
using CqrsAndMediatr.CQRS.Commands.Response;
using CqrsAndMediatr.Models;
using MediatR;

namespace CqrsAndMediatr.CQRS.Handlers.CommandHandler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private AppDbContext context;
        public CreateProductCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            };
            context.Products.Add(product);

            await this.context.SaveChangesAsync();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
