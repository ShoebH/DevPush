using Management.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Uses.Queries
{
    public class GetAllUsersQuery :BaseRequest,IRequest<IEnumerable<User>> { }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        public GetAllUsersQueryHandler()
        {
            // if we need to inject data base or something
        }
        public  async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            //return new[]{
            //    new User {Id = 1234, FirstName= "Sheob", LastName="Aadrit",Address="Borås"},
                
            //};

            return new[]{

                new User {

            Id = $"Id {request.UserId}",
            FirstName = $"Shoeb {request.UserId}", 
            LastName = $"Aadir {request.UserId}",
            Address = $"Borås {request.UserId}",
                        },
                

            };

            //throw new NotImplementedException();
        }
    }
}
