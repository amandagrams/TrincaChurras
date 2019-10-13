using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChurrasTrinca.API.ViewModels;
using ChurrasTrinca.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChurrasTrinca.Business.Interfaces;
using ChurrasTrinca.API.Extensions;
using ChurrasTrinca.API.Controllers;

namespace ChurrasTrinca.API.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/churras")]
    public class ChurrasController : MainController
    {
        private readonly IChurrasRepository _ChurrasRepository;
        private readonly IChurrasService _ChurrasService;
        private readonly IMapper _mapper;

        public ChurrasController(IChurrasRepository ChurrasRepository, 
                                      IMapper mapper, 
                                      IChurrasService ChurrasService,
                                      IUser user,
                                      INotificador notificador) : base(notificador, user)
        {
            _ChurrasRepository = ChurrasRepository;
            _mapper = mapper;
            _ChurrasService = ChurrasService;            
        }

        [HttpGet]
        public async Task<IEnumerable<ChurrasViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ChurrasViewModel>>(await _ChurrasRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ChurrasViewModel>> ObterPorId(Guid id)
        {
            var Churras = await ObterChurrasParticipantes(id);

            if (Churras == null) return NotFound();

            return Churras;
        }

        [ClaimsAuthorize("Churras","Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ChurrasViewModel>> Adicionar(ChurrasViewModel ChurrasViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ChurrasService.Adicionar(_mapper.Map<Churras>(ChurrasViewModel));

            return CustomResponse(ChurrasViewModel);
        }

        [ClaimsAuthorize("Churras", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ChurrasViewModel>> Atualizar(Guid id, ChurrasViewModel ChurrasViewModel)
        {
            if (id != ChurrasViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(ChurrasViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ChurrasService.Atualizar(_mapper.Map<Churras>(ChurrasViewModel));

            return CustomResponse(ChurrasViewModel);
        }

        [ClaimsAuthorize("Churras", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ChurrasViewModel>> Excluir(Guid id)
        {
            var Churras = await ObterPorId(id);
            if (Churras == null) return NotFound();
            
            await _ChurrasService.Remover(id);

            return CustomResponse(Churras);
        }

        private async Task<ChurrasViewModel> ObterChurrasParticipantes(Guid id)
        {
            return _mapper.Map<ChurrasViewModel>(await _ChurrasRepository.ObterChurrasParticipantes(id));
        }       
    }
}