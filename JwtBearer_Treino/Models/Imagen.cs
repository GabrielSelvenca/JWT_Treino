using System;
using System.Collections.Generic;

namespace JwtBearer_Treino.Models;

public partial class Imagen
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Tipo { get; set; }

    public byte[]? Dados { get; set; }
}
