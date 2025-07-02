using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class DeleteCompromissoHandler : IRequestHandler<DeleteCompromissoRequest, DeleteCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public DeleteCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public Task<DeleteCompromissoResponse> Handle(DeleteCompromissoRequest request, CancellationToken cancellationToken)
        {
            DeleteCompromissoResponse result = new DeleteCompromissoResponse();
            var compromisso = _compromissoRepository.Get(request.Id, cancellationToken).Result;

            if (compromisso != null)
            {
                if (_compromissoRepository.Delete(compromisso).Result > 0)
                {
                    result.mensagem = "Removido com sucesso.";
                }
                else
                {
                    result.mensagem = "Falha ao remover Usuário.";
                }
            }
            else
            {
                result.mensagem = "Usuário inexistente.";
            }

            return Task.FromResult(result);
        }
    }
}
