using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? SenhaHash { get; set; }

    public byte[]? FotoPerfil { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}
