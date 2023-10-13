using CqrsAndMediatr.CQRS.Queries.Request;
using CqrsAndMediatr.CQRS.Queries.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Handlers.QueryHandler
{
    //Handler classları,Mediatr kütüphanesinden gelen IRequestHandler interface’ini implemente etmeli.
    //parametre olarak request model ve dönüş tipi vermeliyiz.
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private AppDbContext context;
        public GetAllProductQueryHandler(AppDbContext context)
        {
            this.context = context;
        }
        //Handle metodu içinde database işlemlerini gerçekleştirelim.
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return this.context.Products.Select(product => new GetAllProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }
    }
}
