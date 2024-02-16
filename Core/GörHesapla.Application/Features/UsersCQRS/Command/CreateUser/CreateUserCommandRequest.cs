﻿using MediatR;

namespace GörHesapla.Application.Features.UsersCQRS.Command.CreateUser
{
    public class CreateUserCommandRequest : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int CompanyId { get; set; }
    }
}
