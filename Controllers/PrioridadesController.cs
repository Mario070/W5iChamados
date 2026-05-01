using Microsoft.AspNetCore.Mvc;
using W5iChamados.Data;
using W5iChamados.Models;

namespace W5iChamados.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrioridadesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrioridadesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var prioridades = _context.Prioridades.ToList();
        return Ok(prioridades);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Prioridade prioridade)
    {
        if (string.IsNullOrEmpty(prioridade.Nome))
            return BadRequest("Nome é obrigatório");

        if (prioridade.TempoEstimadoHoras <= 0)
            return BadRequest("Tempo estimado deve ser maior que zero");

        _context.Prioridades.Add(prioridade);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = prioridade.Id }, prioridade);
    }
}