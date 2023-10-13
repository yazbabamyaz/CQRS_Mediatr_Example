using CqrsAndMediatr.CQRS.Commands.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
