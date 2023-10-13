using CqrsAndMediatr.CQRS.Commands.Request;
using CqrsAndMediatr.CQRS.Commands.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Handlers.CommandHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private AppDbContext context;
        public DeleteProductCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == request.Id);
            this.context.Products.Remove(product);
            await context.SaveChangesAsync();

            return new DeleteProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
