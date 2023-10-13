﻿using CqrsAndMediatr.CQRS.Commands.Response;
using MediatR;

namespace CqrsAndMediatr.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
