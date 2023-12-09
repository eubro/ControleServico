using ControleServicoAPI.Models;
using ControleServicoAPI.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleServicoAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CadServicoController : Controller
    {
        private readonly IControleServico _controleServico;

        public CadServicoController(IControleServico controleServico)
        {
            _controleServico = controleServico;
        }

        [HttpGet]
        public async Task<ActionResult<List<CadServico>>> GetAllServicos()
        {
            return await _controleServico.GetAllServicos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CadServico>>> GetSingleServico( int id)
        {
            var result = await _controleServico.GetSingleServico(id);
            if (result == null)
                return NotFound("Serviço não encontrado");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<CadServico>>> AddServico(CadServico servico)
        {
            var result = await _controleServico.AddServico(servico);
            return Ok(result);  

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<CadServico>>> UpdateHero(int id, CadServico request)
        {
            var result = await _controleServico.UpdateServico(id, request);
            if (result is null)
                return NotFound("Serviço não encontrado.");

           

            return Ok(result);
        }

        [HttpPut("marcarComoConcluido/{id}")]
        public async Task<IActionResult> MarcarComoConcluido(int id)
        {
            var servico = await _controleServico.GetSingleServico(id);
            if (servico == null)
                return NotFound("Serviço não encontrado");

            servico.Concluido = true;

            await _controleServico.UpdateServico(id, servico);

            return NoContent();
        }

        [HttpGet("concluido")]
        public async Task<ActionResult<List<CadServico>>> GetServicosConcluidos ()
        {
            return await _controleServico.GetServicosConcluidos();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CadServico>>> DeleteHero(int id)
        {
            var result = await _controleServico.DeleteServico(id);
            if (result is null)
                return NotFound("Serviço não encontrado");

            return Ok(result);
        }


    }
}
