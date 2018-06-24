using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
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

        public UsuariosController(IUsuariosService usuariosService) => _usuariosService = usuariosService;

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody]UsuarioViewModel usuario)
        {   
            await _usuariosService.SalvarAsync(new Usuario(), "lol");
            
            return CreatedAtAction(nameof(Get), new { id = 1 }, usuario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return new OkObjectResult((await _usuariosService.BuscarAsync(id)));
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