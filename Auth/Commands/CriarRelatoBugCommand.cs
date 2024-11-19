using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Commands
{
    public class CriarRelatoBugCommand : IRequest<RelatoBugModel>
    {
        public RelatoBugModel Bug { get; set; }

        public CriarRelatoBugCommand(RelatoBugModel bug)
        {
            Bug = bug;
        }
    }
}
