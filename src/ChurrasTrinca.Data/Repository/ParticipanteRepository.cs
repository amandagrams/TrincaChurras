using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.Business.Models;
using ChurrasTrinca.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChurrasTrinca.Data.Repository
{
    public class ParticipanteRepository : Repository<Participante>, IParticipanteRepository
    {
        // O Repository é uma classe abstrata, então não pode pode criar uma instancia dela, então se ele recebe alguma coisa no construtor,
        // alguém vai ter que passar pra ela; Então aqui, através do construtor desta classe, está recebendo o MeuDbContext e passar para a classe base esse contexto;
        public ParticipanteRepository(MeuDbContext context) : base(context) { }

        public async Task<Participante> ObterParticipanteChurras(Guid id)
        {
            // "Traga dados de Participante, faça um inner join com Churras, onde o Participante tiver esse id informado";
            return await Db.Participante.AsNoTracking().Include(f => f.Churras)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Participante>> ObterParticipanteChurras()
        {
            return await Db.Participante.AsNoTracking().Include(f => f.Churras)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Participante>> ObterParticipantePorChurras(Guid ChurrasId)
        {
            return await Buscar(p => p.ChurrasId == ChurrasId);
        }
    }
}