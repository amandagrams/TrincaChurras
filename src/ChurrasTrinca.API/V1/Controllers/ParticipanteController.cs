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
    [Route("API/v{version:APIVersion}/Participantes")]
    public class ParticipanteController : MainController
    {
        private readonly IParticipanteRepository _ParticipanteRepository;
        private readonly IParticipanteService _Participanteservice;
        private readonly IMapper _mapper;

        public ParticipanteController(INotificador notificador, 
                                      IParticipanteRepository ParticipanteRepository,
                                      IParticipanteService Participanteservice,
                                      IUser user,
                                      IMapper mapper
                                      ) : base(notificador, user)
        {
            _ParticipanteRepository = ParticipanteRepository;
            _Participanteservice = Participanteservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ParticipanteViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ParticipanteViewModel>>(await _ParticipanteRepository.ObterParticipanteChurras());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ParticipanteViewModel>> ObterPorId(Guid id)
        {
            var ParticipanteViewModel = await ObterParticipante(id);

            if (ParticipanteViewModel == null) return NotFound();

            return ParticipanteViewModel;
        }

        [ClaimsAuthorize("Participante", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ParticipanteViewModel>> Adicionar(ParticipanteViewModel ParticipanteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _Participanteservice.Adicionar(_mapper.Map<Participante>(ParticipanteViewModel));

            return CustomResponse(ParticipanteViewModel);
        }

        [ClaimsAuthorize("Participante", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ParticipanteViewModel ParticipanteViewModel)
        {
            if (id != ParticipanteViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var ParticipanteAtualizacao = await ObterParticipante(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            ParticipanteAtualizacao.Nome = ParticipanteViewModel.Nome;
            ParticipanteAtualizacao.ValorPago = ParticipanteViewModel.ValorPago;
            ParticipanteAtualizacao.Pago = ParticipanteViewModel.Pago;
            ParticipanteAtualizacao.ComBebida = ParticipanteViewModel.ComBebida;
            ParticipanteAtualizacao.DataCadastro = DateTime.UtcNow;

            await _Participanteservice.Atualizar(_mapper.Map<Participante>(ParticipanteAtualizacao));

            return CustomResponse(ParticipanteViewModel);
        }


        [ClaimsAuthorize("Participante", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ParticipanteViewModel>> Excluir(Guid id)
        {
            var Participante = await ObterParticipante(id);

            if (Participante == null) return NotFound();

            await _Participanteservice.Remover(id);

            return CustomResponse(Participante);
        }
        private async Task<ParticipanteViewModel> ObterParticipante(Guid id)
        {
            return _mapper.Map<ParticipanteViewModel>(await _ParticipanteRepository.ObterParticipanteChurras(id));
        }
    }
}