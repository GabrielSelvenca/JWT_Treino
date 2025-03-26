using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public DateTime? HoraLogin { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}
