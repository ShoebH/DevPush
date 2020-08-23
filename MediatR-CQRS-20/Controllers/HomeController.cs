using Management;
using Management.Models;
using Management.Uses.Commands;
using Management.Uses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_CQRS_20.Controllers
{
    [ApiController]
    [Route("users")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator) // MediatRr
        {
            this.mediator = mediator;
        }
        //public Task <IEnumerable<User>>Index([FromBody]GetAllUsersQuery query)

        [HttpGet]
         public Task <IEnumerable<User>>Index()
        
        {
            return mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        public Task<Response<User>> Index([FromBody] CreateUserCommand command)

        {
            return mediator.Send(command);
        }


    }
}
