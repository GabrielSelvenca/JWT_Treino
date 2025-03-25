using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Participante
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? UsuarioId { get; set; }

    public int? ModalidadeId { get; set; }

    public bool? Presente { get; set; }

    public virtual Modalidade? Modalidade { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
