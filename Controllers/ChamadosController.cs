using Microsoft.AspNetCore.Mvc;
using W5iChamados.Models;
using W5iChamados.Services;
using W5iChamados.DTOs;

namespace W5iChamados.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    private readonly ChamadoService _service;

    public ChamadosController(ChamadoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarChamadoDto dto)
    {
        try
        {
            var chamado = new Chamado
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                SetorId = dto.SetorId,
                PrioridadeId = dto.PrioridadeId
            };

            var resultado = _service.Criar(chamado);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/iniciar")]
    public IActionResult Iniciar(int id)
    {
        try
        {
            var resultado = _service.Iniciar(id);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/finalizar")]
    public IActionResult Finalizar(int id, [FromBody] FinalizarChamadoDto dto)
    {
        try
        {
            var resultado = _service.Finalizar(id, dto.Solucao);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/cancelar")]
    public IActionResult Cancelar(int id)
    {
        try
        {
            var resultado = _service.Cancelar(id);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var lista = _service.Listar();
        return Ok(lista);
    }
}