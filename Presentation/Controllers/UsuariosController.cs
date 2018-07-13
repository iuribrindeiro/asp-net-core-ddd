using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entidades;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : BaseApiController
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuariosService usuariosService, IMapper mapper)
        {
            _usuariosService = usuariosService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UsuarioViewModel))]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Post(UsuarioViewModel novoUsuarioViewModel)
        {   
            var usuario = _mapper.Map<UsuarioViewModel, Usuario>(novoUsuarioViewModel);
            await _usuariosService.SalvarAsync(usuario, novoUsuarioViewModel.Password);
            return CreatedAtAction(nameof(GetById), new {id = usuario.Id.ToString()},
                _mapper.Map<Usuario, UsuarioViewModel>(usuario));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(UsuarioViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Put(UsuarioViewModel usuarioViewModel, string id)
        {
            var usuario = _mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            usuario.Id = Guid.Parse(id);
            await _usuariosService.AtualizarAsync(usuario);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(UsuarioViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(string id)
        {
            return new OkObjectResult(
                (_mapper.Map<Usuario, UsuarioViewModel>(await _usuariosService.BuscarAsync(id))));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(404)]
        public IActionResult Get(string search, int size = 10, int page = 1)
            => new OkObjectResult((_mapper.Map<UsuariosPaginadosDTO, UsuariosPaginadosViewModel>(_usuariosService.BuscarUsuarios(search, size, page))));

        [HttpGet("/confirm-email")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ConfirmEmail(string code, string idUsaurio)
        {
            await _usuariosService.ConfirmUserEmailAsync(code, idUsaurio);
            return Ok();
        }
    }
}