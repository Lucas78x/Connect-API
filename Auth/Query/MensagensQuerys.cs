namespace Connect.Auth.Query
{
    using global::Connect.Auth.DTO;
    using MediatR;
    using System;
    using System.Collections.Generic;

    namespace Connect.Auth.Queries
    {
        public class ObterMensagemPorIdQuery :IRequest<MensagemDTO>
        {
            public Guid MensagemId { get; set; }

            public ObterMensagemPorIdQuery(Guid mensagemId)
            {
                MensagemId = mensagemId;
            }
        }

        public class ObterMensagensPorRemetenteQuery : IRequest<List<MensagemDTO>>
        {
            public Guid RemetenteId { get; set; }

            public ObterMensagensPorRemetenteQuery(Guid remetenteId)
            {
                RemetenteId = remetenteId;
            }
        }

        public class ObterMensagensPorDestinatarioQuery : IRequest<List<MensagemDTO>>
        {
            public Guid DestinatarioId { get; set; }

            public ObterMensagensPorDestinatarioQuery(Guid destinatarioId)
            {
                DestinatarioId = destinatarioId;
            }
        }

        public class ObterMensagensNaoLidasPorDestinatarioQuery : IRequest<List<MensagemDTO>>
        {
            public Guid DestinatarioId { get; set; }

            public ObterMensagensNaoLidasPorDestinatarioQuery(Guid destinatarioId)
            {
                DestinatarioId = destinatarioId;
            }
        }

        public class ObterTodasMensagensQuery :IRequest<List<MensagemDTO>>
        {

        }
    }

}
