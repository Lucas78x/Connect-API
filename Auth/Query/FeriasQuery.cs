namespace Connect.Auth.Query
{
    using global::Connect.Auth.DTO;
    using global::Connect.Auth.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;

    namespace Connect.Auth.Queries
    {
        public class ObterFeriasQuery : IRequest<List<FeriasModel>>
        {

            public ObterFeriasQuery()
            {

            }
        }
    }
}
