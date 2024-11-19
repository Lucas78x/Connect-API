using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Commands
{
    public class CriarFolhaPontoCommand : IRequest<long?>
    {
        public FolhaPontoModel Folha { get; set; }

        public CriarFolhaPontoCommand(FolhaPontoModel folha)
        {
            Folha = folha;
        }
    }
}
