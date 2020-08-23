using Management.Models;
using Management.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Uses.Commands
{
    public class CreateUserCommand : IRequestWrapper<User> { }

    //public class CreateUserCommand : IRequest<Response<User>> { }

    //public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<User>>

    //public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>

    public class CreateUserCommandHandler : IHandlerWrapper<CreateUserCommand, User>

    {


        //public Task<Response<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)

        public Task<Response<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (false)
            {
                return Task.FromResult(Response.Fail<User>("already exists"));

            }
            return Task.FromResult(Response.Ok(new User { Id="",FirstName = "Mila", LastName = "vala", Address="MJ" }, "User Created"));
            //return Task.FromResult(Response.Ok(new User { LastName = "vala" }, "User Created"));


            //throw new NotImplementedException();
        }
    }


}

