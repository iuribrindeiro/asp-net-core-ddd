using Domain.Entidades;
using MediatR;

namespace Bus.Events
{
    public class UserCreatedEvent : IRequest
    {
        public Usuario Usuario { get; set; }
        public string EmailConfirmationToken { get; set; }
    }
}