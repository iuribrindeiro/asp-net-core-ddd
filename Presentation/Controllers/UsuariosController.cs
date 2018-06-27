using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Exceptions.Usuario;
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
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
                await _usuariosService.SalvarAsync(usuario, usuarioViewModel.Password);
                return CreatedAtAction(nameof(Get), new { id = usuario.Id.ToString() });
            }
            catch (DadosInvalidosUsuarioException ex)
            {
                var erros = new Dictionary<string, string[]>(); 
                ex.Errors.ToList().ForEach(e =>
                {
                    if (erros.Keys.Contains(e.Campo))
                        erros[e.Campo].ToList().Add(e.Mensagem);
                    else
                        erros[e.Campo] = new[] {e.Mensagem};
                });
                return new UnprocessableEntityObjectResult(erros);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UsuarioViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return new OkObjectResult((_mapper.Map<Usuario, UsuarioViewModel>(await _usuariosService.BuscarAsync(id))));
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound();
            }
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new OkObjectResult((await _usuariosService.BuscarAsync("lol")));
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound();
            }
        }
    }
}