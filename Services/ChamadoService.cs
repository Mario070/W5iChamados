using Microsoft.EntityFrameworkCore;
using W5iChamados.Data;
using W5iChamados.Models;

namespace W5iChamados.Services;

public class ChamadoService
{
    private readonly AppDbContext _context;

    public ChamadoService(AppDbContext context)
    {
        _context = context;
    }

    private Chamado ObterCompleto(int id)
{
    return _context.Chamados
        .Include(c => c.Setor)
        .Include(c => c.Prioridade)
        .First(c => c.Id == id);
}

    public Chamado Criar(Chamado chamado)
{
    chamado.Status = StatusChamado.Aberto;
    chamado.DataAbertura = DateTime.Now;

    _context.Chamados.Add(chamado);
    _context.SaveChanges();

    return ObterCompleto(chamado.Id);
}

    public Chamado Iniciar(int id)
{
    var chamado = _context.Chamados.Find(id);

    if (chamado == null)
        throw new Exception("Chamado não encontrado.");

    if (chamado.Status == StatusChamado.Finalizado || chamado.Status == StatusChamado.Cancelado)
        throw new Exception("Chamado não pode ser iniciado.");

    chamado.Status = StatusChamado.EmAtendimento;
    chamado.DataInicio = DateTime.Now;

    _context.SaveChanges();

    return ObterCompleto(id);
}

   public Chamado Finalizar(int id, string solucao)
{
    var chamado = _context.Chamados.Find(id);

    if (chamado == null)
        throw new Exception("Chamado não encontrado.");

    if (chamado.DataInicio == null)
        throw new Exception("Chamado ainda não foi iniciado.");

    chamado.Status = StatusChamado.Finalizado;
    chamado.DataFim = DateTime.Now;
    chamado.Solucao = solucao;

    _context.SaveChanges();

    return ObterCompleto(id);
}

    public List<object> Listar()
    {
        var chamados = _context.Chamados
            .Include(c => c.Setor)
            .Include(c => c.Prioridade)
            .ToList()
            .Select(c =>
            {
                double? tempoHoras = null;
                bool atrasado = false;

                if (c.DataInicio != null && c.DataFim != null)
                {
                    tempoHoras = (c.DataFim.Value - c.DataInicio.Value).TotalHours;

                    if (tempoHoras > c.Prioridade.TempoEstimadoHoras)
                        atrasado = true;
                }

                return new
                {
                    c.Id,
                    c.Titulo,
                    Setor = c.Setor.Nome,
                    Prioridade = c.Prioridade.Nome,
                    Status = c.Status.ToString(),
                    TempoHoras = tempoHoras,
                    Atrasado = atrasado
                };
            }).ToList<object>();

        return chamados;
    }
}