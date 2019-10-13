using System;
using System.Collections.Generic;

namespace ChurrasTrinca.Business.Models
{
    public class Churras : Entity
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public double ValorComBebida { get; set; }
        public double ValorSemBebida { get; set; }
        public double ValorArrecadado { get; set; }

        /* EF Relations */
        public IEnumerable<Participante> Participantes { get; set; }
    }
}