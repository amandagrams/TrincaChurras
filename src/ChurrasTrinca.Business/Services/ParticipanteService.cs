using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.Business.Models;
using ChurrasTrinca.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Services
{
    public class ParticipanteService : BaseService, IParticipanteService
    {
        private readonly IParticipanteRepository _ParticipanteRepository;
       

        public ParticipanteService(IParticipanteRepository ParticipanteRepository,
                              INotificador notificador) : base(notificador)
        {
            _ParticipanteRepository = ParticipanteRepository;
            
        }

        public async Task Adicionar(Participante Participante)
        {
            if (!ExecutarValidacao(new ParticipanteValidation(), Participante)) return;

            

            await _ParticipanteRepository.Adicionar(Participante);
        }

        public async Task Atualizar(Participante Participante)
        {
            if (!ExecutarValidacao(new ParticipanteValidation(), Participante)) return;

            await _ParticipanteRepository.Atualizar(Participante);
        }

        public async Task Remover(Guid id)
        {
            await _ParticipanteRepository.Remover(id);
        }

        public void Dispose()
        {
            _ParticipanteRepository?.Dispose();
        }
    }
}
