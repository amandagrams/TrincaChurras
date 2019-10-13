using ChurrasTrinca.Business.Models;
using System;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Interfaces
{
    public interface IParticipanteService : IDisposable
    {
        Task Adicionar(Participante Participante);
        Task Atualizar(Participante Participante);
        Task Remover(Guid id);
    }
}
