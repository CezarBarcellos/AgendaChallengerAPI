using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Abstractions;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class GetCompromissoHandler : IRequestHandler<GetCompromissoRequest, GetCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public GetCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public Task<GetCompromissoResponse> Handle(GetCompromissoRequest request, CancellationToken cancellationToken)
        {
            GetCompromissoResponse result = new GetCompromissoResponse();
            var compromisso = _compromissoRepository.Get(request.Id, cancellationToken).Result;

            if (compromisso != null)
            {
                result = new GetCompromissoResponse
                {
                    Titulo = compromisso.Titulo,
                    Descricao = compromisso.Descricao,
                    Localizacao = compromisso.Localizacao,
                    DataInicio = compromisso.DataInicio,
                    DataFim = compromisso.DataFim,
                    Status = compromisso.Status,
                    DataCriacao = compromisso.DataCriacao,
                    DataAlteracao = compromisso.DataAlteracao
                };
            }

            return Task.FromResult(result);
        }
    }
}
