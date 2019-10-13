using ChurrasTrinca.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Interfaces
{
    public interface IParticipanteRepository : IRepository<Participante>
    {
        Task<IEnumerable<Participante>> ObterParticipantePorChurras(Guid ChurrasId);
        Task<IEnumerable<Participante>> ObterParticipanteChurras();
        Task<Participante> ObterParticipanteChurras(Guid id);
    }
}
