using CqrsAndMediatr.CQRS.Queries.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
