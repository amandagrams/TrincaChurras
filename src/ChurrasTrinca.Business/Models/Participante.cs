using System;

namespace ChurrasTrinca.Business.Models
{
    public class Participante : Entity
    {
        public Guid ChurrasId { get; set; }

        public string Nome { get; set; }
        public double ValorPago { get; set; }
        public bool Pago { get; set; }
        public bool ComBebida { get; set; }
        public DateTime DataCadastro { get; set; }

        /* EF Relations */
        public Churras Churras { get; set; }
    }
}