using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.Business.Models;
using ChurrasTrinca.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Services
{
    public class ChurrasService : BaseService, IChurrasService
    {
        private readonly IChurrasRepository _ChurrasRepository;

        public ChurrasService(IChurrasRepository ChurrasRepository,
                               INotificador notificador) : base(notificador)
        {
            _ChurrasRepository = ChurrasRepository;
        }

        public async Task<bool> Adicionar(Churras Churras)
        {
            if (!ExecutarValidacao(new ChurrasValidation(), Churras)) return false;


            // O Buscar é um método assíncrono; para pegar o result tem que esperar ele finalizar;
            if (_ChurrasRepository.Buscar(f => f.Data == Churras.Data).Result.Any())
            {
                Notificar("Já existe um Churras na data informada.");
                return false;
            }

            await _ChurrasRepository.Adicionar(Churras);
            return true;
        }

        public async Task<bool> Atualizar(Churras Churras)
        {
            if (!ExecutarValidacao(new ChurrasValidation(), Churras)) return false;

            if (_ChurrasRepository.Buscar(f => f.Data == Churras.Data && f.Id != Churras.Id).Result.Any())
            {
                Notificar("Já existe um Churras na data informada.");
                return false;
            }

            await _ChurrasRepository.Atualizar(Churras);
            return true;
        }


        public async Task<bool> Remover(Guid id)
        {
            if (_ChurrasRepository.ObterChurrasParticipantes(id).Result.Participantes.Any())
            {
                Notificar("O Churras possui Participantes cadastrados!");
                return false;
            }

            await _ChurrasRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _ChurrasRepository?.Dispose();

        }
    }
}
