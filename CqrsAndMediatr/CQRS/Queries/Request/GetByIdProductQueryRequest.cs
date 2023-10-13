using CqrsAndMediatr.CQRS.Queries.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Queries.Request
{
    //Requestler ise IRequest interface'ini implement etmeliler
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
