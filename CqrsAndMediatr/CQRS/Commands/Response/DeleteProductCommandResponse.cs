﻿namespace CqrsAndMediatr.CQRS.Commands.Response
{
    public class DeleteProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
    }
}
