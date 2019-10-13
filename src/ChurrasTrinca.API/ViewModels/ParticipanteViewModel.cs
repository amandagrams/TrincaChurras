using System;
using System.ComponentModel.DataAnnotations;

namespace ChurrasTrinca.API.ViewModels
{
    public class ParticipanteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid ChurrasId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ValorPago { get; set; }

        public bool Pago { get; set; }

        public bool ComBebida { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public string DescricaoChurras { get; set; }
    }
}
