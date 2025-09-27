using Application.Features.CQRS.Commands.UserRegister;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.UserRegister
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _movieContext;
        private readonly UserManager<AppUser> _userManager;
        public CreateUserRegisterCommandHandler(MovieContext movieContext, UserManager<AppUser> userManager)
        {
            _movieContext = movieContext;
            _userManager = userManager;
        }

        public async Task Handle(CreateUserRegisterCommand command)
        {
            var user = new AppUser()
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                UserName = command.Username
            };
            await _userManager.CreateAsync(user, command.Password);
        }
    }
}
