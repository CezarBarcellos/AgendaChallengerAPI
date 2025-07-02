using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class UpdateCompromissoHandler : IRequestHandler<UpdateCompromissoRequest, UpdateCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public UpdateCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public Task<UpdateCompromissoResponse> Handle(UpdateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCompromissoResponse();            
            var compromisso = _compromissoRepository.Get(request.Id, cancellationToken).Result;

            if (compromisso != null)
            {
                var obj = _compromissoRepository.Update(compromisso);

                result.Id = obj.Result.Id;
                result.Titulo = obj.Result.Titulo;
                result.Descricao = obj.Result.Descricao;
                result.DataInicio = obj.Result.DataInicio;
                result.DataFim = obj.Result.DataFim;
                result.Localizacao = obj.Result.Localizacao;
                result.Status = obj.Result.Status;
                result.DataCriacao = obj.Result.DataCriacao;
            }

            return Task.FromResult(result);
        }
    }
}
