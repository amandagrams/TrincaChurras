using AutoMapper;
using ChurrasTrinca.API.ViewModels;
using ChurrasTrinca.Business.Models;

namespace ChurrasTrinca.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Churras, ChurrasViewModel>().ReverseMap();
            CreateMap<ParticipanteViewModel, Participante>();
            CreateMap<Participante, ParticipanteViewModel>()
                .ForMember(dest => dest.DescricaoChurras, opt => opt.MapFrom(src => src.Churras.Descricao));
        }
    }
}