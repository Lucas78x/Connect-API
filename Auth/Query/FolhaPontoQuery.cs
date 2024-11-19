namespace Connect.Auth.Queries
{
    using MediatR;
    using Connect.Auth.Models;
    using System;
    using System.Collections.Generic;

    public class ObterFolhaPontoQuery : IRequest<List<FolhaPontoModel>>
    {
        public Guid? OwnerId { get; set; }

        public ObterFolhaPontoQuery(Guid? ownerId = null)
        {
            OwnerId = ownerId;
        }
    }
}
