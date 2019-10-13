using System;
using System.Threading.Tasks;
using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.Business.Models;
using ChurrasTrinca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChurrasTrinca.Data.Repository
{
    public class ChurrasRepository : Repository<Churras>, IChurrasRepository
    {
        public ChurrasRepository(MeuDbContext context) : base(context) { }

        public async Task<Churras> ObterChurrasParticipantes(Guid id)
        {
            // retorna um Churras com os Participante dele;
            return await Db.Churras.AsNoTracking()
                .Include(c => c.Participantes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}