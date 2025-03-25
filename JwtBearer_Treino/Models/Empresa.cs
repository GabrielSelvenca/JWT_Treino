using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Cnpj { get; set; }

    public string? Endereco { get; set; }

    public string? Responsavel { get; set; }

    public virtual ICollection<Modalidade> Modalidades { get; set; } = new List<Modalidade>();
}
