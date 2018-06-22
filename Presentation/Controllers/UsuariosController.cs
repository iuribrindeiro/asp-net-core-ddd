using System;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService) => _usuariosService = usuariosService;

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuariosService.SalvarAsync(usuario);
            
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
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