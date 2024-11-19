namespace Connect.Auth.Queries
{
    using MediatR;
    using Connect.Auth.Models;
    using System;
    using System.Collections.Generic;

    public class ObterRelatoBugQuery : IRequest<List<RelatoBugModel>>
    {
       
        public ObterRelatoBugQuery()
        {

        }
    }
}
