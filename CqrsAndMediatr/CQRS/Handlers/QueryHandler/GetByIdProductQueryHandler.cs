using CqrsAndMediatr.CQRS.Queries.Request;
using CqrsAndMediatr.CQRS.Queries.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Handlers.QueryHandler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly AppDbContext context;
        public GetByIdProductQueryHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == request.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
