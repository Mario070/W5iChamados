using Microsoft.AspNetCore.Mvc;
using W5iChamados.Data;
using W5iChamados.Models;

namespace W5iChamados.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SetoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public SetoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var setores = _context.Setores.ToList();
        return Ok(setores);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Setor setor)
    {
        _context.Setores.Add(setor);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = setor.Id }, setor);
    }
}