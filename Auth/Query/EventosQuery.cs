namespace Connect.Auth.Query
{
    using global::Connect.Auth.DTO;
    using global::Connect.Auth.Enums;
    using MediatR;
    using System;
    using System.Collections.Generic;

    namespace Connect.Auth.Queries
    {
        public class ObterEventoPorSetorQuery : IRequest<List<EventoDTO>>
        {
            public TipoPermissaoEnum Setor { get; set; }

            public ObterEventoPorSetorQuery(int setor)
            {
               Setor = (TipoPermissaoEnum)setor;
            }
        }

     
    }

}
