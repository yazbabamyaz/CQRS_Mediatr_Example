using CqrsAndMediatr.CQRS.Commands.Request;
using CqrsAndMediatr.CQRS.Commands.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Handlers.CommandHandler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private AppDbContext context;
        public UpdateProductCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateProduct = this.context.Products.FirstOrDefault(p => p.Id == request.Id);
            updateProduct.Price = request.Price;
            updateProduct.Quantity = request.Quantity;
            updateProduct.Name = request.Name;
            await this.context.SaveChangesAsync();

            return new UpdateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = updateProduct.Id
            };
        }
    }
}
