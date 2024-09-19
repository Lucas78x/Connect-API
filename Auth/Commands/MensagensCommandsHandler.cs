using Connect.Auth.Context;
using Connect.Auth.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Commands
{

    public class CriarMensagemCommandHandler : IRequestHandler<CriarMensagemCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CriarMensagemCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CriarMensagemCommand request, CancellationToken cancellationToken)
        {
            var mensagem = new MensagemDTO(request.RemetenteId, request.DestinatarioId, request.Conteudo);
            await _context.Mensagens.AddAsync(mensagem);
            await _context.SaveChangesAsync();
            return mensagem.Id;
        }
    }

    public class AtualizarMensagemCommandHandler : IRequestHandler<AtualizarMensagemCommand>
    {
        private readonly DatabaseContext _context;


        public AtualizarMensagemCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AtualizarMensagemCommand request, CancellationToken cancellationToken)
        {
            var mensagem = await _context.Mensagens
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == request.MensagemId);

            if (mensagem == null)
            {
                throw new Exception("Mensagem não encontrada");
            }
            mensagem.AtualizarConteudo(request.NovoConteudo);
            _context.Mensagens.Update(mensagem);
            _context.SaveChanges();
            return Unit.Value;
        }
    }

    public class MarcarMensagemComoLidaCommandHandler : IRequestHandler<MarcarMensagemComoLidaCommand>
    {
        private readonly DatabaseContext _context;

        public MarcarMensagemComoLidaCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(MarcarMensagemComoLidaCommand request, CancellationToken cancellationToken)
        {
            var mensagem = await _context.Mensagens
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.MensagemId);

            if (mensagem == null)
            {
                throw new Exception("Mensagem não encontrada");
            }

            if (!mensagem.Lida)
            {
                mensagem.MarcarComoLida();
                _context.Mensagens.Update(mensagem);
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }

    public class DeletarMensagemCommandHandler : IRequestHandler<DeletarMensagemCommand>
    {
        private readonly DatabaseContext _context;

        public DeletarMensagemCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarMensagemCommand request, CancellationToken cancellationToken)
        {
            var mensagem = await _context.Mensagens
                .FirstOrDefaultAsync(x => x.Id == request.MensagemId, cancellationToken);

            if (mensagem == null)
            {
                throw new Exception("Mensagem não encontrada");
            }

            _context.Mensagens.Remove(mensagem);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


