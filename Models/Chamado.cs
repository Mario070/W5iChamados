namespace W5iChamados.Models;

public class Chamado
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public int SetorId { get; set; }

    public Setor Setor { get; set; }

    public int PrioridadeId { get; set; }

    public Prioridade Prioridade { get; set; }

    public StatusChamado Status { get; set; }

    public DateTime DataAbertura { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public string Solucao { get; set; }
}