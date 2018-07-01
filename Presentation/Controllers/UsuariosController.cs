using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entidades;
using Domain.Exceptions.Usuario;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Presentation.Attributes.ModelAttributes;
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
        [ProducesResponseType(201, Type = typeof(EditUsuarioViewModel))]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Post(NovoUsuarioViewModel novoUsuarioViewModel)
        {
            var usuario = _mapper.Map<NovoUsuarioViewModel, Usuario>(novoUsuarioViewModel);
            await _usuariosService.SalvarAsync(usuario, novoUsuarioViewModel.Password);
            return CreatedAtAction(nameof(GetById), new {id = usuario.Id.ToString()}, _mapper.Map<Usuario, EditUsuarioViewModel>(usuario));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(EditUsuarioViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Put(EditUsuarioViewModel editUsuarioViewModel, string id)
        {
            var usuario = _mapper.Map<EditUsuarioViewModel, Usuario>(editUsuarioViewModel);
            usuario.Id = Guid.Parse(id);
            await _usuariosService.AtualizarAsync(usuario);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(EditUsuarioViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(string id)
        {
            return new OkObjectResult((_mapper.Map<Usuario, EditUsuarioViewModel>(await _usuariosService.BuscarAsync(id))));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult((await _usuariosService.BuscarAsync("lol")));
        }
    }
}