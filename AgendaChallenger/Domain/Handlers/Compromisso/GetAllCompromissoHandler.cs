using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class GetAllCompromissoHandler : IRequestHandler<GetAllCompromissoRequest, GetAllCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public GetAllCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public Task<GetAllCompromissoResponse> Handle(GetAllCompromissoRequest request, CancellationToken cancellationToken)
        {
            GetAllCompromissoResponse result = new GetAllCompromissoResponse();
            var lstCompromisso = _compromissoRepository.GetAll(cancellationToken).Result;

            if (lstCompromisso != null && lstCompromisso.Count > 0)
            {
                result = new GetAllCompromissoResponse
                {
                    lstCompromissos = lstCompromisso
                };
            }

            return Task.FromResult(result);
        }
    }
}
