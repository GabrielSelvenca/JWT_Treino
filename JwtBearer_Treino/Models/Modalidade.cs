using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Modalidade
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Local { get; set; }

    public DateTime? DataCompeticao { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}
