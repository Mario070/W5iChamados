namespace W5iChamados.DTOs;

public class ChamadoResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public string Setor { get; set; }
    public string Prioridade { get; set; }

    public string Status { get; set; }

    public DateTime DataAbertura { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public string Solucao { get; set; }
}