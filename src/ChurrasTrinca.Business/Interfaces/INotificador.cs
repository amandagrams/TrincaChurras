using ChurrasTrinca.Business.Notificacoes;
using System.Collections.Generic;

namespace ChurrasTrinca.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
