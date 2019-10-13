using ChurrasTrinca.Business.Models;
using System;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Interfaces
{
    // Os métodos definidos estão na IRepository; A IChurrasRepository só extende, especializando para a classe Churras;
    public interface IChurrasRepository : IRepository<Churras>
    {
        Task<Churras> ObterChurrasParticipantes(Guid id);
    }
}
