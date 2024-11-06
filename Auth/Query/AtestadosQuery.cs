namespace Connect.Auth.Query
{
    using global::Connect.Auth.DTO;
    using global::Connect.Auth.Enums;
    using MediatR;
    using System;
    using System.Collections.Generic;

    namespace Connect.Auth.Queries
    {
        public class ObterAtestadosQuery : IRequest<List<AtestadoDTO>>
        {

            public Guid OwnerId { get; set; }

            public ObterAtestadosQuery(Guid ownerId)
            {
                OwnerId = ownerId;
            }
        }
    }
}
