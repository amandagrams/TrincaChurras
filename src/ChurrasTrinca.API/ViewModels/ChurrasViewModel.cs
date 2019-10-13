using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurrasTrinca.API.ViewModels
{
    public class ChurrasViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ValorComBebida { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ValorSemBebida { get; set; }        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double ValorArrecadado { get; set; }

        public IEnumerable<ParticipanteViewModel> Participantes { get; set; }
    }
}
