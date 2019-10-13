using ChurrasTrinca.Business.Models;
using System;
using System.Threading.Tasks;

namespace ChurrasTrinca.Business.Interfaces
{
    public interface IChurrasService : IDisposable
    {
        Task<bool> Adicionar(Churras Churras);
        Task<bool> Atualizar(Churras Churras);
        Task<bool> Remover(Guid id);

    }
}
